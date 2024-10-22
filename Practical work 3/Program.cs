using System;
using Logic;

namespace Practical_work_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = "\"Задача\" \"Алексей Иванов    \"Контрольная работа\"     16.09.2024\n" +
            "\"Задача\" \"Алексей Иванов\"    \"Контрольная работа\"     16.09.2024\n" +
            "\"Задача по математике\"    \"Александр Борисов\"       \"Практическая работа\"     10.15.2024     4,7\n" +
            "\"Задача по математике\" \"Ирина Николаевна\"     \"Лабораторная работа\"    07.09.2024        5,5\n" +
            "\"Задача по физике\" \"Дмитрий Иванов\"       \"Курсовая работа\"   04.09.2024    5       25.09.2024\n" +
            "\"Задача по физике\" \"Петр Петров\"    \"Итоговая работа\"    14.09.2024     5     25.09.2024";
            while (true)
            {
                Console.WriteLine("Нужно ли считать с текстового файла\n1 - да\n2 - нет");
                int.TryParse(Console.ReadLine(), out int selectedNumber);
                if (selectedNumber == 1)
                {
                    createObjectForTextFromFile();
                }
                if (selectedNumber == 2)
                {
                    cresteObjectForTextFromString(text);
                }
                Console.WriteLine();
            }
        }

        private static void cresteObjectForTextFromString(string text)
        {
            foreach (var item in Factory.getLines(text))
            {
                try
                {
                    Factory.createObjects(Factory.splitLine(item)).print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void createObjectForTextFromFile()
        {
            foreach (var item in Factory.readFile())
            {
                try
                {
                    Factory.createObjects(Factory.splitLine(item)).print();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
