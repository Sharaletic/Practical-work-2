using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MathematicsTask : Tasks
    {
        public double Mark { get; set; }

        public MathematicsTask(string nameStudent, string typeOfTopic, DateTime dateGet, double mark)
            : base(nameStudent, typeOfTopic, dateGet)
        {
            Mark = mark;
        }

        public override void print()
        {
            Console.WriteLine($"Задача по математике: {NameStudent}, {TypeOfTopic}, {DateGet:dd.MM.yyy}, {Mark}");
        }
    }
}
