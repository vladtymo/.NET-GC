using System;
using System.Text;
using static System.Console;
namespace SimpleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            WriteLine("Демонстрация System.GC");
            WriteLine($"Максимальное поколение: { GC.MaxGeneration}");

            GarbageHelper hlp = new GarbageHelper();

            //узнаем поколение, в котором находится объект
            WriteLine($"Поколение объекта:{ GC.GetGeneration(hlp)}");

            // количество занятой памяти
            WriteLine($"Занято памяти(байт):{ GC.GetTotalMemory(false)}");
            hlp.MakeGarbage(); //создаем мусор
            WriteLine($"Занято памяти(байт):{ GC.GetTotalMemory(false)}");

            Console.ReadKey();
            GC.Collect(0); //вызываем явный сбор мусора в поколении 0

            WriteLine($"Занято памяти(байт):{ GC.GetTotalMemory(false)}");
            WriteLine($"Поколение объекта:{ GC.GetGeneration(hlp)}");

            Console.ReadKey();
            GC.Collect(); //вызываем явный сбор мусора во всех поколениях

            WriteLine($"Занято памяти(байт):{ GC.GetTotalMemory(false)}");
            WriteLine($"Поколение объекта:{ GC.GetGeneration(hlp)}");
        }
    }

    //Вспомогательный класс для создания мусора
    class GarbageHelper
    {
        //Метод, создающий мусор
        public void MakeGarbage()
        {
            for (int i = 0; i < 1000; i++)
            {
                Person p = new Person();
            }
        }
        class Person
        {
            string _name;
            decimal _salary;
            byte _age;
        }
    }
}