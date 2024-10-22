using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace TestLib
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void parseDateTimeData()
        {
            Assert.AreEqual(new DateTime(2024, 12, 12), Factory.parseDate("12.12.2024"));
            Assert.AreEqual(new DateTime(2024, 12, 12), Factory.parseDate("12/12/2024"));
            Assert.AreEqual(new DateTime(2024, 12, 12), Factory.parseDate("12,12,2024"));
            Assert.AreEqual(new DateTime(2024, 12, 12), Factory.parseDate("12 12 2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("12.13.2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("00.00.0000"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("text"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate(""));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("12.12.2024 abc"));
        }

        [TestMethod]
        public void parseIntData()
        {
            Assert.AreEqual(123, Factory.parseInt("123"));
            Assert.AreEqual(-123, Factory.parseInt("-123"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("_"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("12.34"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("text"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt(""));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("123 abc"));
        }

        [TestMethod]
        public void parseMark()
        {
            Assert.AreEqual(4, 5, Factory.parseMark("4,5"));
            Assert.AreEqual(0, Factory.parseMark("0"));
            Assert.AreEqual(10, Factory.parseMark("10"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("-9"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("4.5"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("text"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark(""));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("4,5 abc"));
        }

        [TestMethod]
        public void createTaskObject()
        {
            List<string> list1 = new List<string>() { "Задача", "Иван Иванов", "Самостоятельная работа", "25.12.2024" };
            Tasks task1 = Factory.createObjects(list1);
            Assert.AreEqual("Иван Иванов", task1.NameStudent);
            Assert.AreEqual("Самостоятельная работа", task1.TypeOfTopic);
            Assert.AreEqual(new DateTime(2024, 12, 25), task1.DateGet);

            List<string> list2 = new List<string>() { "Задачи", "Иван Иванов", "Самостоятельная работа", "25.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list2));

            List<string> list3 = new List<string>() { "Иван Иванов", "Самостоятельная работа", "25.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list3));

            List<string> list4 = new List<string>() { "Задача", "Самостоятельная работа", "25.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list4));

            List<string> list5 = new List<string>() { "Задача" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list5));

            List<string> list6 = new List<string>() { "" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list6));
        }

        [TestMethod]
        public void createMathematicsTaskObject()
        {
            List<string> list1 = new List<string>() { "Задача по математике", "Иван Иванов", "Самостоятельная работа", "25.12.2024", "6,7" };
            MathematicsTask task1 = (MathematicsTask)Factory.createObjects(list1);
            Assert.AreEqual("Иван Иванов", task1.NameStudent);
            Assert.AreEqual("Самостоятельная работа", task1.TypeOfTopic);
            Assert.AreEqual(new DateTime(2024, 12, 25), task1.DateGet);
            Assert.AreEqual(6, 7, task1.Mark);

            List<string> list2 = new List<string>() { "Задачи по математике", "Иван Иванов", "Самостоятельная работа", "25.12.2024", "6,7" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list2));

            List<string> list3 = new List<string>() { "Иван Иванов", "Самостоятельная работа", "25.12.2024", "6,7" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list3));

            List<string> list4 = new List<string>() { "Задача по математике", "Самостоятельная работа", "25.12.2024", "6,7" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list4));

            List<string> list5 = new List<string>() { "Задача по математике" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list5));

            List<string> list6 = new List<string>() { "" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list6));
        }

        [TestMethod]
        public void createPhysicsTaskObject()
        {
            List<string> list = new List<string>() { "Задача по физике", "Иван Иванов", "Самостоятельная работа", "25.12.2024", "10", "26.12.2024" };
            PhysicsTask task = (PhysicsTask)Factory.createObjects(list);
            Assert.AreEqual("Иван Иванов", task.NameStudent);
            Assert.AreEqual("Самостоятельная работа", task.TypeOfTopic);
            Assert.AreEqual(new DateTime(2024, 12, 25), task.DateGet);
            Assert.AreEqual(10, task.Quantity);
            Assert.AreEqual(new DateTime(2024, 12, 26), task.DateOfCompletion);

            List<string> list2 = new List<string>() { "Задачи по физике", "Иван Иванов", "Самостоятельная работа", "25.12.2024", "10", "26.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list2));

            List<string> list3 = new List<string>() { "Иван Иванов", "Самостоятельная работа", "25.12.2024", "10", "26.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list3));

            List<string> list4 = new List<string>() { "Задача по физике", "Самостоятельная работа", "25.12.2024", "10", "26.12.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list4));

            List<string> list5 = new List<string>() { "Задача по физике" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list5));

            List<string> list6 = new List<string>() { "" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(list6));
        }

        [TestMethod]
        public void cheeckLine()
        {
            string line1 = "\"Задача\" \"Алексей Иванов\"    \"Контрольная работа\"     16.09.2024";
            Assert.AreEqual(true, Factory.cheeckLine(line1));

            string line2 = "\"Задача\" Алексей Иванов\"    \"Контрольная работа\"     16.09.2024";
            Assert.AreEqual(false, Factory.cheeckLine(line2));

            string line3 = "\"Задача\" Алексей Иванов    Контрольная работа     16.09.2024";
            Assert.AreEqual(false, Factory.cheeckLine(line3));

            string line4 = "Задача Алексей Иванов    Контрольная работа     16.09.2024";
            Assert.AreEqual(false, Factory.cheeckLine(line4));

            string line5 = string.Empty;
            Assert.AreEqual(false, Factory.cheeckLine(line5));
        }
    }
}