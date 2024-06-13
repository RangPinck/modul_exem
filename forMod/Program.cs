namespace forMod;

class Program
{
    static void Main()
    {
        Console.WriteLine("Данная программа работает с методами математического моделирования");
        Console.WriteLine("Выьерите метод по индексу:");
        System.Console.WriteLine("1. Северо-западный");
        System.Console.WriteLine("2. Минимальной стоимости");
        System.Console.WriteLine("3. Создание кода Прюфера");
        System.Console.WriteLine("4. Дейкстра");
        System.Console.WriteLine("Другой символ. Выход");
        System.Console.Write("Ваш выбор:\t");
        int userChoise = 0;
        try
        {
            userChoise = int.Parse(Console.ReadLine());
        }
        catch
        {
            System.Console.WriteLine("Данного функционала программа не предусматривает!");
            System.Console.WriteLine("До свидания!");
        }
        Console.Clear();
        switch (userChoise)
        {
            case 1:
                System.Console.WriteLine("Вы выбрали метод \"Северо-западный\"");

                break;
            case 2:
                System.Console.WriteLine("Вы выбрали метод \"Минимальной стоимости\"");

                break;
            case 3:
                System.Console.WriteLine("Вы выбрали метод \"оздание кода Прюфера\"");

                break;
            case 4:
                System.Console.WriteLine("Вы выбрали метод \"Дейкстра\"");

                break;

            default:
                System.Console.WriteLine("Данного функционала программа не предусматривает!");
                System.Console.WriteLine("До свидания!");
                break;
        }

    }
}
