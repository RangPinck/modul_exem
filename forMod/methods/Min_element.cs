using System.Text;

namespace forMod;

public class Min_element
{
    private List<List<int?>> matrix { get; set; }
    private List<List<int?>> matrixResult { get; set; }
    private int? countResult { get; set; }
    private string _fileIn { get; set; }
    private string _fileOut { get; set; }

    public Min_element(string fileIn, string fileOut)
    {
        _fileIn = fileIn;
        _fileOut = fileOut;
        GetData();
        Method();
        PushData();
    }
    void GetData()
    {
        if (!File.Exists(_fileIn))
        {
            throw new FileNotFoundException($"File to \"{_fileIn}\" not found");
        }
        bool checkOfFirstNull = true;
        countResult = 0;
        using StreamReader sr = new StreamReader(_fileIn);
        string line;
        List<int?> temp = new List<int?>();
        matrix = new List<List<int?>>();
        while ((line = sr.ReadLine()) != null)
        {
            foreach (string s in line.Split(' '))
            {
                try
                {
                    temp.Add(int.Parse(s));
                }
                catch (System.Exception)
                {
                    if (checkOfFirstNull)
                    {
                        temp.Add(null);
                        checkOfFirstNull = false;
                    }
                    else
                    {
                        throw new Exception("No correct input data");
                    }
                }
            }
            matrix.Add(new List<int?>(temp));
            temp.Clear();
        }
        matrixResult = new List<List<int?>>();
        for (int i = 1; i < matrix.Count; i++)
        {
            for (int j = 1; j < matrix[0].Count; j++)
            {
                temp.Add(0);
            }
            matrixResult.Add(new List<int?>(temp));
            temp.Clear();
        }
    }

    void PushData()
    {
        using StreamWriter sr = new StreamWriter(_fileOut, false, Encoding.UTF8);
        for (int i = 0; i < matrixResult.Count; i++)
        {
            foreach (int? value in matrixResult[i])
            {
                sr.Write(value + "\t");
            }
            sr.WriteLine();
        }
        sr.WriteLine($"Общая стоимость перевозок = {countResult}");
    }

    void Method()
    {
        int indexRow = 0;
        int indexCol = 0;
        while (checkToEnd())
        {
            GetIndexShipment(ref indexRow, ref indexCol);
            CreateShipment(indexRow, indexCol);
        }
    }

    bool checkToEnd()
    {
        for (int i = 1; i < matrix.Count; i++)
        {
            if (matrix[i][0]> 0) return true;
        }
        for (int i = 1; i < matrix[0].Count; i++)
        {
            if (matrix[0][i]> 0) return true;
        }
        return false;
    }

    void GetIndexShipment(ref int indexRow, ref int indexCol)
    {
        int? temp = int.MaxValue;
        for (int i = 1; i < matrix.Count; i++)
        {
            for (int j = 1; j < matrix[i].Count; j++)
            {
                if (temp > matrix[i][j] && matrix[0][j] > 0 && matrix[i][0] > 0)
                {
                    temp = matrix[i][j];
                    indexCol = j;
                    indexRow = i;
                }
            }
        }
    }

    void CreateShipment(int indexRow, int indexCol)
    {
        if (matrix[indexRow][0] > matrix[0][indexCol])
        {
            matrixResult[indexRow-1][indexCol-1] = matrix[0][indexCol];
            matrix[indexRow][0] -= matrix[0][indexCol];
            matrix[0][indexCol] = 0;
            countResult += matrix[indexRow][indexCol];
            return;
        }
        if (matrix[indexRow][0] < matrix[0][indexCol])
        {
            matrixResult[indexRow-1][indexCol-1] = matrix[indexRow][0];
            matrix[0][indexCol] -= matrix[indexRow][0];
            matrix[indexRow][0] = 0;
            countResult += matrix[indexRow][indexCol];
            return;
        }
        if (matrix[indexRow][0] == matrix[0][indexCol])
        {
            matrixResult[indexRow-1][indexCol-1] = matrix[indexRow][0];
            matrix[indexRow][0] = 0;
            matrix[0][indexCol] = 0;
            countResult += matrix[indexRow][indexCol];
            return;
        }
    }
}
