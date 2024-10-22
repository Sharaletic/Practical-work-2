using System;

namespace Logic
{
    public class PhysicsTask : Tasks
    {
        public int Quantity { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public PhysicsTask(string nameStudent, string typeOfTopic, DateTime dateGet, int quantity, DateTime dateOfCompletion)
            : base(nameStudent, typeOfTopic, dateGet)
        {
            Quantity = quantity;
            DateOfCompletion = dateOfCompletion;
        }

        public override void print()
        {
            Console.WriteLine($"Задача по физике: {NameStudent}, {TypeOfTopic}, {DateGet:dd.MM.yyy}, {Quantity}, {DateOfCompletion:dd.MM.yyy}");
        }
    }
}
