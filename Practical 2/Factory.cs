using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    public class Factory
    {
        public static string[] getLines(string text)
        {
            return text.Trim().Split('\n');
        }

        public static Task createObject(string line)
        {
            List<string> lineList = new List<string>();
            string[] part1 = line.Trim().Split('"');
            lineList.AddRange(part1.Take(part1.Length - 1).Where(x => !string.IsNullOrWhiteSpace(x)));
            string[] part2 = part1[part1.Length - 1].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            lineList.AddRange(part2);
            string test = lineList[0];
            if (test == "Задача")
                return Task.createTask(lineList);
            if (test == "Задача по математике")
                return MathematicsTask.createMathematicsTask(lineList);
            if (test == "Задача по физике")
                return PhysicsTask.createPhysicsTask(lineList);
            else
                throw new Exception("Не удалось создать объект");
        }

        public static string[] readFile()
        {
            return File.ReadAllText("text.txt").Trim().Split('\n');
        }
    }
}
