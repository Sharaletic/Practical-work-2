using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_2
{
    public class Task
    {
        public string NameStudent { get; set; }
        public string NameTopic { get; set; }
        public DateTime DateGet { get; set; }

        public Task(string nameWork, string nameTopic, DateTime dateGet)
        {
            NameStudent = nameWork;
            NameTopic = nameTopic;
            DateGet = dateGet;
        }

        public static Task createTask(List<string> lineList)
        {
            return new Task(lineList[1], lineList[2], DateTime.ParseExact(lineList[3], "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }

        public virtual void print()
        {
            Console.WriteLine($"Задача: {NameStudent}, {NameTopic}, {DateGet:dd.MM.yyy}");
        }
    }
}
