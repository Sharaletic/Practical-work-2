using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "\"Алексей Иванов\"    \"Дифференциальные уравнения\"     16.09.2024\n" +
            "\"Задача по математике\"    \"Александр Борисов\"       \"Линейные уравнения\"     10.09.2024     4,7\n" +
            "\"Задача по математике\" \"Ирина Николаевна\"     \"Тригонометрия\"    07.09.2024        5\n" +
            "\"Задача по физике\" \"Дмитрий Иванов\"       \"Дисперсия света\"   04.09.2024    5       25.09.2024\n" +
            "\"Задача по физике\" \"Петр Петров\"    \"Дисперсия света\"    14.09.2024     5     25.09.2024";
            while (true)
            {
                Console.WriteLine("Нужно ли считать с текстового файла\n1 - да\n2 - нет");
                int.TryParse(Console.ReadLine(), out int selectedNumber);
                if (selectedNumber == 1)
                {
                    foreach (var item in Factory.readFile())
                    {
                        try
                        {
                            Factory.createObject(item).print();
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось создать объект");
                        }
                    }
                }
                if (selectedNumber == 2)
                {
                    foreach (var item in Factory.getLines(text))
                    {
                        try
                        {
                            Factory.createObject(item).print();
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось создать объект");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
