namespace forMod;

class Program
{
    static void Main()
    {
        Console.WriteLine("Данная программа работает с методами математического моделирования");
        Console.WriteLine("Выьерите метод по индексу:");
        Console.WriteLine("1. Северо-западный");
        Console.WriteLine("2. Минимальной стоимости");
        Console.WriteLine("3. Создание кода Прюфера");
        Console.WriteLine("4. Дейкстра");
        Console.WriteLine("Другой символ. Выход");
        Console.Write("Ваш выбор:\t");
        int userChoise = 0;
        try
        {
            userChoise = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Данного функционала программа не предусматривает!");
            Console.WriteLine("До свидания!");
        }
        if (userChoise < 1 && userChoise > 4)
        {
            Console.WriteLine("Данного функционала программа не предусматривает!");
            Console.WriteLine("До свидания!");
            return;
        }
        Console.WriteLine("Укажите путь к файлу с исходными данными и путь куда хотите получить файл с результатом");
        Console.Write("Путь к исходным данным:\t");
        string fileIn = Console.ReadLine();
        Console.Write("Путь для файла вывода:\t");
        string fileOut = Console.ReadLine();
        switch (userChoise)
        {
            case 1:
                Console.WriteLine("Вы выбрали метод \"Северо-западный\"");
                Nord_west nord = new Nord_west(fileIn, fileOut);
                break;
            case 2:
                Console.WriteLine("Вы выбрали метод \"Минимальной стоимости\"");
                Min_element me = new Min_element(fileIn, fileOut);
                break;
            case 3:
                Console.WriteLine("Вы выбрали метод \"Создание кода Прюфера\"");
                Prupher pr = new Prupher(fileIn, fileOut);
                break;
            case 4:
                Console.WriteLine("Вы выбрали метод \"Дейкстра\"");

                break;
            default:
                Console.WriteLine("Данного функционала программа не предусматривает!");
                Console.WriteLine("До свидания!");
                return;
        }
        Console.WriteLine("До свидания!");
    }
}
