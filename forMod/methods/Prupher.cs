using System.Text;
using System.Text.RegularExpressions;

namespace forMod;

public class Prupher
{
    private string _fileIn { get; set; }
    private string _fileOut { get; set; }
    private List<int> listEdges {get; set;}
    private List<int> code {get; set;}
    public Prupher(string fileIn, string fileOut)
    {
        _fileIn = fileIn;
        _fileOut = fileOut;
        GetData();
        Method();
        PostData();
    }
    void GetData()
    {
        listEdges = new List<int>();
        code = new List<int>();
        using StreamReader sr = new StreamReader(_fileIn);
        string line;
        Regex simbol = new Regex(@"\d");
        while ((line = sr.ReadLine()) != null)
        {
            foreach (var item in line.Split(' '))
            {
                if (!simbol.IsMatch(item))
                    throw new Exception($"Data no correct = {item}");
                
                listEdges.Add(int.Parse(item));
            }
        }
    }
    void PostData()
    {
        using StreamWriter sw = new StreamWriter(_fileOut, false, Encoding.UTF8);
        sw.Write("код Прюфера: ");
        foreach (var item in code)
        {
            sw.Write(item + " ");
        }
    }
    void Method()
    {
        int exp = 0;
        int indexExp = 0;
        int indexNei = 0;
        while (listEdges.Count > 2)
        {
            //минимальное значенеи, которое только одно в списке рёбер
            List<int> temp = new List<int>(listEdges);
            exp = temp.Where(x => temp.Where(y => y == x).Count() == 1).ToList().Min();
            //получаем индекс элемента
            indexExp =listEdges.IndexOf(exp);
            //определяем соседа
            if (indexExp%2 == 0)
                indexNei = indexExp + 1;
            else
                indexNei = indexExp - 1;
            //записываем код
            code.Add(listEdges[indexNei]);
            //удаляем
            if (indexExp%2 == 0)
            {
                listEdges.RemoveAt(indexNei);
                listEdges.RemoveAt(indexExp);
            }
            else
            {
                listEdges.RemoveAt(indexExp);
                listEdges.RemoveAt(indexNei);
            }
        }
    }
}
