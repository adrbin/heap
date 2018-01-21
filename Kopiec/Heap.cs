// Kopiec max

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopiec
{
    /// <summary>
    /// Struktura danych implementująca kopiec, gdzie największy element jest w korzeniu
    /// </summary>
    /// <typeparam name="T">Typ elementu przechowywanego w kopcu. Musi dać się porównywać,
    /// czyli implementować interfejs IComprable</typeparam>
    class Heap<T> where T: IComparable<T>
    {
        private List<T> _array;

        /// <summary>
        /// Tworzy pusty kopiec
        /// </summary>
        public Heap()
        {
            _array = new List<T>();
        }

        /// <summary>
        /// Tworzy nowy kopiec z podanej listy
        /// </summary>
        /// <param name="array"></param>
        public Heap(List<T> array)
        {
            _array = new List<T>();
			foreach (var element in array)
			{
				Insert(element);
			}
        }

        /// <summary>
        /// Dodaje nowy element do pierwszego wolnego liścia, a następnie zamienia się ze swoim rodzicem,
        /// aby osiągnąć porządek kopcowy
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element)
        {
            if (_array.Contains(element))
            {
                return;
            }
            _array.Add(element);
            int size = _array.Count;
            // zaczynamy indeksowanie od 0
            int index = size - 1;
            int parent_index;
            while (index > 0)
            {
                parent_index = (index + 1)/2 - 1;
                if (_array[index].CompareTo(_array[parent_index]) <= 0)
                {
                    break;
                }
                _array.Swap(index, parent_index);
                index = parent_index;
            }
        }

        /// <summary>
        /// Zwraca największy element, który znajduje się w korzeniu
        /// </summary>
        /// <returns>Największy element w kopcu</returns>
        public T Max()
        {
            if (_array.Count == 0)
            {
                throw new IndexOutOfRangeException("Kopiec jest pusty, nie mozna pobrac z niego zadnego elementu.");
            }
            return _array[0];
        }

        /// <summary>
        /// Tworzy nowy kopiec.
        /// </summary>
        /// <param name="array"></param>
        public void CreateHeap(List<T> array)
        {
            _array = new List<T>(array);
            int size = _array.Count;
            for (int index = size / 2; index >= 0; index--)
            {
                while (true)
                {
                    int child_index1 = (index + 1) * 2 - 1;
                    int child_index2 = child_index1 + 1;
                    if (child_index1 >= size)
                    {
                        break;
                    }
                    int bigger_child_index;
                    if (child_index2 >= size)
                    {
                        bigger_child_index = child_index1;
                    }
                    //else if (_array[child_index1] >= _array[child_index2])
                    else if (_array[child_index1].CompareTo(_array[child_index2]) >= 0)
                    {
                        bigger_child_index = child_index1;
                    }
                    else
                    {
                        bigger_child_index = child_index2;
                    }
                    //if (_array[bigger_child_index] <= _array[index])
                    if (_array[bigger_child_index].CompareTo(_array[index]) <= 0)
                    {
                        break;
                    }
                    _array.Swap(index, bigger_child_index);
                    index = bigger_child_index;

                }
            }
        }

        /// <summary>
        /// Usuwa i zwraca największy element, który znajduje się w korzeniu.
        /// Następnie przenosi ostatni liść do korzenia i zamienia się z większym z synów,
        /// aby utworzyć porządek kopcowy.
        /// W przypadku, gdy kopiec jest pusty, wyrzuca wyjątek.
        /// </summary>
        /// <returns>Największy element w kopcu</returns>
        public T DeleteMax()
        {
            if (_array.Count == 0)
            {
                throw new IndexOutOfRangeException("Kopiec jest pusty, nie mozna pobrac z niego zadnego elementu.");
            }
            T max = _array[0];
            int last_index = _array.Count - 1;
            _array[0] = _array[last_index];
            _array.RemoveAt(last_index);
            int size = _array.Count;
            int index = 0;
			while (true)
            {
				int child_index1 = (index + 1) * 2 - 1;
				int child_index2 = child_index1 + 1;
				if (child_index1 >= size)
				{
					break;
				}
                int bigger_child_index;
                if (child_index2 >= size)
				{
					bigger_child_index = child_index1;
				}
                //else if (_array[child_index1] >= _array[child_index2])
				else if (_array[child_index1].CompareTo(_array[child_index2]) >= 0)
				{
					bigger_child_index = child_index1;
				}
				else
				{
					bigger_child_index = child_index2;
				}
                //if (_array[bigger_child_index] <= _array[index])
                if (_array[bigger_child_index].CompareTo(_array[index]) <= 0)
				{
					break;
				}
				_array.Swap(index, bigger_child_index);
				index = bigger_child_index;
				
            }
            return max;
        }
		
        /// <summary>
        /// Drukuje kopiec w postaci drzewa w konsoli
        /// </summary>
		public void Print()
		{
            int size = _array.Count;
            if (size == 0)
            {
                Console.WriteLine("Kopiec jest pusty");
            }
            Console.WriteLine(new string('-', Console.BufferWidth));
            for(int i = 0; Math.Pow(2, i) <= size; i++)
            {
                int elements_in_row = (int) Math.Pow(2, i);
                int first_index_in_row = elements_in_row - 1;
                int empty = (Console.WindowWidth - elements_in_row * _array[first_index_in_row].ToString().Length)/(elements_in_row + 1);
                string empty_space = new string(' ', empty);
                for (int j = 0; first_index_in_row + j < size && j < elements_in_row; j++)
                {
                    Console.Write(empty_space);
                    Console.Write(_array[first_index_in_row + j].ToString());
                }
                Console.Write("\n\n");
            }
            Console.WriteLine(new string('-', Console.BufferWidth));

		}

        /// <summary>
        /// Zwraca tekst zawierający tablicę z kopcem.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var element in _array)
            {
                sb.Append(element.ToString());
                sb.Append(",");
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
