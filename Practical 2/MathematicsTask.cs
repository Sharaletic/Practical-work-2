using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    public class MathematicsTask : Task
    {
        public double Mark { get; set; }

        public MathematicsTask(string nameStudent, string nameTopic, DateTime dateGet, double mark)
            : base(nameStudent, nameTopic, dateGet)
        {
            Mark = mark;
        }

        public static Task createMathematicsTask(List<string> lineList)
        {
            return new MathematicsTask(lineList[1], lineList[2], DateTime.ParseExact(lineList[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), Double.Parse(lineList[4]));
        }

        public override void print()
        {
            Console.WriteLine($"Задача по математике: {NameStudent}, {NameTopic}, {DateGet:dd.MM.yyy}, {Mark}");
        }
    }
}
