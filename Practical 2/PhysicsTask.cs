using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    public class PhysicsTask : Task
    {
        public int Mark { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public PhysicsTask(string nameStudent, string nameTopic, DateTime dateGet, int mark, DateTime dateOfCompletion)
            : base(nameStudent, nameTopic, dateGet)
        {
            Mark = mark;
            DateOfCompletion = dateOfCompletion;
        }

        public static Task createPhysicsTask(List<string> lineList)
        {
            return new PhysicsTask(lineList[1], lineList[2], DateTime.ParseExact(lineList[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), Int16.Parse(lineList[4]), DateTime.ParseExact(lineList[5], "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }

        public override void print()
        {
            Console.WriteLine($"Задача по физике: {NameStudent}, {NameTopic}, {DateGet:dd.MM.yyy}, {Mark}, {DateOfCompletion:dd.MM.yyy}");
        }
    }
}
