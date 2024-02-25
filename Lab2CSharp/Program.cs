using System;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Пiдрахунок суми елементiв, кратних 9 (одновимiрний масив)");
            Console.WriteLine("2. Знаходження номеру першого максимального елемента (одновимiрний масив)");
            Console.WriteLine("3. Помiняти стовпцi мiсцями за певним правилом (двовимiрний масив)");
            Console.WriteLine("4. Знаходження номеру першого вiд'ємного елемента у кожному рядку (двовимiрний масив)");
            Console.WriteLine("0. Вийти з програми");
            Console.Write("Оберiть завдання: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 0:
                    Console.WriteLine("Програма завершена.");
                    break;
                default:
                    Console.WriteLine("Неправильний вибiр. Спробуйте ще раз.");
                    break;
            }

        } while (choice != 0);
    }

    static void Task1()
    {
        Console.Write("Введiть розмiрнiсть масиву: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(100); // Генеруємо випадкове число в дiапазонi вiд 0 до 99
            Console.WriteLine($"Елемент {i + 1}: {array[i]}");
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (array[i] % 9 == 0)
                sum += array[i];
        }

        Console.WriteLine($"Сума елементiв, кратних 9: {sum}");
    }

    static void Task2()
    {
        Console.Write("Введiть розмiрнiсть масиву: ");
        int n = int.Parse(Console.ReadLine());
        double[] array = new double[n];

        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            array[i] = Math.Round(random.NextDouble() * 100, 1); // Генеруємо випадкове дiйсне число з однiєю цифрою пiсля коми в дiапазонi вiд 0 до 99
            Console.WriteLine($"Елемент {i + 1}: {array[i]}");
        }

        double max = array[0];
        int maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }

        Console.WriteLine($"Номер першого максимального елемента: {maxIndex + 1}");
    }

    static void Task3()
    {
        Console.Write("Введiть розмiрнiсть масиву (n): ");
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];

        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = random.Next(100); // Генеруємо випадкове число в дiапазонi вiд 0 до 99
                Console.WriteLine($"Елемент [{i},{j}]: {array[i, j]}");
            }
        }

        if (n % 2 == 0)
        {
            for (int i = 0; i < n; i += 2)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = array[i, j];
                    array[i, j] = array[i + 1, j];
                    array[i + 1, j] = temp;
                }
            }
            Console.WriteLine("Масив зi змiненими стовпцями:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Кiлькiсть стовпцiв у масивi непарна, тому масив залишається без змiн.");
        }
    }

    static void Task4()
    {
        Console.Write("Введiть кiлькiсть рядкiв (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введiть кiлькiсть елементiв у кожному рядку (m): ");
        int m = int.Parse(Console.ReadLine());

        int[,] array = new int[n, m];

        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = random.Next(-100, 101); // Генеруємо випадкове число в дiапазонi вiд -100 до 100
                Console.WriteLine($"Елемент [{i},{j}]: {array[i, j]}");
            }
        }

        int[] resultArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            resultArray[i] = -1; // Якщо не знайдено вiд'ємних елементiв у рядку, результат буде -1
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < 0)
                {
                    resultArray[i] = j;
                    break;
                }
            }
        }

        Console.WriteLine("Номери перших вiд'ємних елементiв у кожному рядку:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Рядок {i + 1}: {(resultArray[i] == -1 ? "Немає вiд'ємних елементiв" : (resultArray[i] + 1).ToString())}");
        }
    }
}
