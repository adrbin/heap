// Kopiec max
// Wejście: lista liczb oddzielonych przecinkami w jednej linii, znak nowej linii (klawisz Enter)
// kończy wczytywanie, np. 5,32,45,12,1,31,12


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopiec
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            Test2();
            //Read();
            Console.ReadLine();
        }

        static void Read()
        {
            Console.WriteLine("Podaj liczby oddzielone przecinkami, aby utworzyc kopiec");
            var input = Console.ReadLine();
            var splitted = input.Split(',');
            var lista = new List<int>();
            try
            {
                foreach (var element in splitted)
                {
                    if (element != null && element.Trim() != "")
                    {
                        lista.Add(Int32.Parse(element.Trim()));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Zły format danych wejsciowych");
            }
            var kopiec = new Heap<int>(lista);
            kopiec.Print();
        }

        static void Test2()
        {
            Console.WriteLine("Tworze liste");
            var lista = new List<int>() { 5, 10, 4, 2, 15, 35, 30, 9, 3, 8 };
            foreach (var element in lista)
            {
                Console.Write(element + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("Tworze kopiec");
            var kopiec = new Heap<int>(lista);
            Console.WriteLine(kopiec);
            kopiec.Print();
            var kopiec2 = new Heap<int>();
            kopiec2.CreateHeap(lista);
            Console.WriteLine(kopiec2);
            kopiec2.Print();
            Console.WriteLine("Pobieram maksymalny element: " + kopiec.DeleteMax() + "\n");
            Console.WriteLine(kopiec);
            kopiec.Print();
            Console.WriteLine("Wstawiam 20");
            kopiec.Insert(20);
            Console.WriteLine(kopiec);
            kopiec.Print();
        }

        static void Test()
        {
            Console.WriteLine("Tworze liste");
            var lista = new List<int>() { 5, 10, 4, 2, 15, 35, 30, 9, 3, 8 };
            foreach (var element in lista)
            {
                Console.Write(element + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("Tworze kopiec");
            var kopiec = new Heap<int>(lista);
            Console.WriteLine(kopiec);
            kopiec.Print();
            Console.WriteLine("Wstawiam 20");
            kopiec.Insert(20);
            Console.WriteLine("Wstawiam 11");
            kopiec.Insert(11);
            kopiec.Print();
            try
            {
                while (true)
                {
                    Console.WriteLine("Pobieram maksymalny element: " + kopiec.DeleteMax() + "\n");
                    kopiec.Print();

                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
