using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace listOfBooks
{
 
    class Library
    {

        public int Count;
        public const int size = 10;
        public Library() { _books = new string[size]; Count = 0; }

       
        private string[] _books;
        public string this[int index]
        {
            get
            {
                if (index >= 0 & index < size)
                    return _books[index];
                else
                {
                    Console.WriteLine("Error!");
                    return null;
                }
            }
            set
            {
                if (index >= 0 & index < size)
                    _books[index] = value;
                else Console.WriteLine("Error!!!");
            }
        }
    }
    internal class Program
    {
      
        static Library Add(Library lib)
        {
            Console.Write("Введите название книги - ");

            string str = Console.ReadLine();
            for (int i = 0; i < Library.size; i++)
            {
                if (lib[i] == null)
                {
                    lib[i] = str;
                    break;
                }
            }
            if (lib.Count + 1 < Library.size) lib.Count++;
            else Console.WriteLine("Выход за предел массива!");
            return lib;
        }
      
        static Library Del(Library lib)
        {
            View(lib);
            Console.Write("Введите номер удаляемой книги - ");

            int str = Convert.ToInt32(Console.ReadLine());
            lib[str - 1] = null;
            return lib;
        }
        
        static void View(Library lib)
        {
            Console.WriteLine();
            for (int i = 0; i < lib.Count; i++)
            {
                if (lib[i] != null)
                    Console.WriteLine($"Книга {i + 1} - {lib[i]}");
            }
            Console.WriteLine();
        }
      
        static void Search(Library lib)
        {
            Console.Write("Введите название книги, которую необходимо найти - ");
            string str = Console.ReadLine();
            for (int i = 0; i < Library.size; i++)
            {
                if (lib[i] == str)
                {
                    Console.WriteLine("Даная книга находится в базе под индексом - " + (i + 1));
                    break;
                }
                else if (i == 9) Console.WriteLine($"Книги под названием <<{str}>> в базе нет!\n");
            }
            if (lib.Count + 1 < Library.size) lib.Count++;
            else Console.WriteLine("Выход за предел массива!");
        }
        static void Main(string[] args)
        {
            Library lib = new Library();
            string ask;
            while (true)
            {
                Console.WriteLine("Выберите действие: \n1 - добавить книгу" +
                " \n2 - удалить книгу \n3 - проверка на наличие книги \n4 - распечатать весь список книг" +
                "\n0 - выход");
                ask = Console.ReadLine();
                switch (ask)
                {
                    case "1": Add(lib); break;
                    case "2": Del(lib); break;
                    case "3": Search(lib); break;
                    case "4": View(lib); break;
                    case "0": break;
                    default:
                        Console.WriteLine("Что-то не то выбрал..."); Console.ReadKey();
                        break;
                }
                if (ask == "0") { Console.WriteLine("До свидания!!!"); break; }
            }
            Console.WriteLine();
        }
    }
}