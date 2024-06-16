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
        PostData();
    }

    void GetData()
    {
        listEdges = new List<int>();
        using StreamReader sr = new StreamReader(_fileIn);
        string line;
        Regex simbol = new Regex(@"\d");
        while ((line = sr.ReadLine()) != null)
        {
            foreach (var item in line.Split(' '))
            {
                if (simbol.IsMatch(item))
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
}
