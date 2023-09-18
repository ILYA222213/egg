using System;
using System.Threading;

public class ChickenAndEgg
{
    static bool chickenLast = false; // переменная для отслеживания, сказал ли последнее слово поток "Курица"
    static bool eggLast = false; // переменная для отслеживания, сказал ли последнее слово поток "Яйцо"

    static void Main(string[] args)
    {
        Thread chickenThread = new Thread(Chicken); // создание потока "Курица"
        Thread eggThread = new Thread(Egg); // создание потока "Яйцо"

        chickenThread.Start(); // запуск потока "Курица"
        eggThread.Start(); // запуск потока "Яйцо"

        chickenThread.Join(); // ожидание завершения работы потока "Курица"
        eggThread.Join(); // ожидание завершения работы потока "Яйцо"

        if (chickenLast)
        {
            Console.WriteLine("Результат спора: Курица появилась сначала!");
        }
        else if (eggLast)
        {
            Console.WriteLine("Результат спора: Яйцо появилось сначала!");
        }
        else
        {
            Console.WriteLine("Результат спора: Ничья!");
        }

        Console.ReadLine();
    }

    static void Chicken()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Курица");
            chickenLast = true; // устанавливаем флаг, что последнее слово сказал поток "Курица"
            eggLast = false; // сбрасываем флаг, что последнее слово сказал поток "Яйцо"
            Thread.Sleep(1000);
        }
    }

    static void Egg()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Яйцо");
            chickenLast = false; // сбрасываем флаг, что последнее слово сказал поток "Курица"
            eggLast = true; // устанавливаем флаг, что последнее слово сказал поток "Яйцо"
            Thread.Sleep(1000);
        }
    }
}