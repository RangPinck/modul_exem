using System.Dynamic;
using System.Text;

namespace forMod;

public class Nord_west
{
    private List<List<int?>> matrix { get; set; }
    private List<List<int?>> matrixResult { get; set; }
    private int countResult { get; set; }
    private string _fileIn { get; set; }
    private string _fileOut { get; set; }

    public Nord_west(string fileIn, string fileOut)
    {
        _fileIn = fileIn;
        _fileOut = fileOut;
        GetData();

        PushData();
    }

    void GetData()
    {
        if (!File.Exists(_fileIn))
        {
            throw new FileNotFoundException($"File to \"{_fileIn}\" not found");
        }

        countResult = 0;
        using StreamReader sr = new StreamReader(_fileIn);
        string line;
        List<int?> temp = new List<int?>();
        matrix = new List<List<int?>>();
        while ((line = sr.ReadLine()) != null)
        {
            foreach (string s in line.Split("\t"))
                try{
                    temp.Add(int.Parse(s));
                }
                catch (System.Exception)
                {
                    temp.Add(null);
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
        for (int i = 0; i < matrix.Count; i++)
        {
            if (i == 0)
            {
                foreach (int? j in matrix[0])
                    sr.Write(j + "\t");

                sr.WriteLine();
            }
            else
            {
                sr.Write(matrix[i][0] + "\t");
                foreach (int? j in matrixResult[i - 1])
                    sr.Write(j + "\t");
                sr.WriteLine();
            }
        }
    }
}
