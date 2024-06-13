namespace forMod;

public class Nord_west
{
    private List<List<int?>> matrix { get; set; }
    private int countResult {get; set;}
    private string _fileIn { get; set; }
    private string _fileOut { get; set; }

    public Nord_west(string fileIn, string fileOut){
        _fileIn = fileIn;
        _fileOut = fileOut;
        GetData();
    }

    void GetData(){
        if (!File.Exists(_fileIn)){
            throw new FileNotFoundException($"File to \"{_fileIn}\" not found");
        }

        countResult = 0;
        using StreamReader sr = new StreamReader(_fileIn);
        string line;
        List <int?> temp = new List<int?>();
        matrix = new List<List<int?>>();
        while((line = sr.ReadLine())!= null)
        {
            foreach(string s in line.Split())
                temp.Add(int.Parse(s));
            
            matrix.Add(new List<int?>(temp));
        }
    }
}
