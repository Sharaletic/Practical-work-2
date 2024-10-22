using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Models;

namespace Logic
{
    public class Factory
    {
        public static string[] getLines(string text)
        {
            return text.Trim().Split('\n');
        }

        public static string[] readFile()
        {
            return File.ReadAllText("text.txt").Trim().Split('\n');
        }

        public static List<string> splitLine(string line)
        {
            if (!cheeckLine(line))
                throw new Exception("Неверный формат строки");
            List<string> lineList = new List<string>();
            string[] part1 = line.Trim().Split('"');
            lineList.AddRange(part1.Take(part1.Length - 1).Where(x => !string.IsNullOrWhiteSpace(x)));
            string[] part2 = part1[part1.Length - 1].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            lineList.AddRange(part2);
            return lineList;
        }

        public static bool cheeckLine(string line)
        {
            int count = line.Count(x => x == '"');
            if (count == 6 && line != string.Empty)
                return true;
            return false;
        } 

        public static Tasks createTask(List<string> lineList)
        {
            if (lineList.Count != 4)
                throw new Exception("Неверное количество полей");
            return new Tasks(lineList[1], lineList[2], parseDate(lineList[3]));
        }

        public static Tasks createMathematicsTask(List<string> lineList)
        {
            if (lineList.Count != 5)
                throw new Exception("Неверное количество полей");
            return new MathematicsTask(lineList[1], lineList[2], parseDate(lineList[3]), parseMark(lineList[4]));
        }

        public static Tasks createPhysicsTask(List<string> lineList)
        {
            if (lineList.Count != 6)
                throw new Exception("Неверное количество полей");
            return new PhysicsTask(lineList[1], lineList[2], parseDate(lineList[3]), parseInt(lineList[4]), parseDate(lineList[5]));
        }

        public static bool checkType(string type)
        {
            if (type == "Задача" || type == "Задача по математике" || type == "Задача по физике")
                return true;
            return false;
        }

        public static DateTime parseDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dt))
                throw new Exception("Дата имеет неверный формат");
            return DateTime.Parse(date);
        }

        public static int parseInt(string number)
        {
            if (!int.TryParse(number, out int nb))
                throw new Exception("Число имеет неверный формат");
            return Convert.ToInt16(number);
        }

        public static double parseMark(string mark)
        {
            if (double.TryParse(mark, out double d) && (d >= 0 && d <= 10))
                return Double.Parse(mark);
            throw new Exception("Оценка имеет неверный формат");
        }

        public static Tasks createObjects(List<string> lineList)
        {
            if (!checkType(lineList[0]))
                throw new Exception("Неверный тип объекта");
            string type = lineList[0];
            if (type == "Задача")
                return createTask(lineList);
            if (type == "Задача по математике")
                return createMathematicsTask(lineList);
            if (type == "Задача по физике")
                return createPhysicsTask(lineList);
            else
                throw new Exception("Не удалось создать объект");
        }
    }
}
