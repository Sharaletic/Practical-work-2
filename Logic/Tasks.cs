﻿using System;

namespace Logic
{
    public class Tasks
    {
        public string NameStudent { get; set; }
        public string TypeOfTopic { get; set; }
        public DateTime DateGet { get; set; }

        public Tasks(string nameStudent, string typeOfTopic, DateTime dateGet)
        {
            NameStudent = nameStudent;
            TypeOfTopic = typeOfTopic;
            DateGet = dateGet;
        }

        public virtual void print()
        {
            Console.WriteLine($"Задача: {NameStudent}, {TypeOfTopic}, {DateGet:dd.MM.yyy}");
        }
    }
}
