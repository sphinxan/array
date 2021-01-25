using System;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            //creation
            int[] array;
            array = new int[3];
            array[0] = 1; array[1] = 2; array[2] = 3;
            var array2 = new[] { 1, 2, 3 };
            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine(array2[i]);
            foreach (var e in array2)
                Console.WriteLine(e);
            var array3 = new object[] { 1, "2", 3 };
            //Двумерные массивы имеют тип int[,] (double[,], string[,])
            int[,] twoDimensionalArray = new int[2, 3];
            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++) //Длины размерностей через метод GetLength
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                    twoDimensionalArray[i, j] = 10 * i + j;
            //В памяти значения хранятся в следующем порядке: 0,1,2,10,11,12
            Console.WriteLine(twoDimensionalArray.Length); //напечатает 6
            //массив массивов
            int[][] array4;//в массиве массивов все хранимые массивы могут быть разной длины
            array4 = new int[2][];
            array4[0] = new int[3];//проинициализировали нулевой элемент

        }

        //метод поиска минимума в массиве
        static double Min(double[] array)
        {
           var min = double.MaxValue;
           foreach (var item in array)
               if (item < min) min = item;
           return min;
        }

        //метод поиска индекса максимального элемента
        static int MaxIndex(double[] array)
        {
            int max = 0;
            if (array.Length == 0) return -1;
            for (int i = 0; i < array.Length; i++)
            {
                 if (array[i] > array[max]) max = i;
                 else continue;
            }
            return max;
        }

        //метод, который создает массив длинной count элементов, содержащий последовательные четные числа в порядке возрастания
        static int[] GetFirstEvenNumbers(int count)
        {
            int[] array = new int[count];
            int k = 2;
            for (int i = 0; i < count; i++)
            {
                array[i] = k;
                k += 2;
            }
            return array;
        }

        //найти количество вхождений заданного числа в массив чисел
        static int GetElementCount(int[] items, int itemToCount)
        {
            int k = 0;
            foreach (int e in items)
                if (e == itemToCount) k += 1;
            return k;
        }

        //найти в массиве подмассив
        static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }
        static bool ContainsAtIndex(int[] array, int[] subArray, int i)
        {
            for (int k = 0; k < subArray.Length; k++)
                if (array[i + k] != subArray[k]) return false;
            return true;
        }

        //руссификация карт таро
        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }
        public static void Main1()
        {
            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));
        }
        static string GetSuit(Suits suit)
        {
            return new[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
        }

        //метод, проверяющий, что первый элемент переданного массива равен 0
        public static void Main2()
        {
            Console.WriteLine(CheckFirstElement(null));
            Console.WriteLine(CheckFirstElement(new int[0]));
            Console.WriteLine(CheckFirstElement(new[] { 1 }));
            Console.WriteLine(CheckFirstElement(new[] { 0 }));
        }
        static bool CheckFirstElement(int[] array)
        {
            return array != null && array.Length != 0 && array[0] == 0;
        }

        //метод, который принимает массив int[], возводит все его элементы в заданную степень и возвращает массив с результатом, Исходный массив при этом должен остаться неизменным
        public static void Main3()
        {
            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Метод PrintArray уже написан
            PrintArray(GetPoweredArray(arrayToPower, 1));
            //если менять исходный массив, то следующие два теста сработают неверно
            PrintArray(GetPoweredArray(arrayToPower, 2));
            PrintArray(GetPoweredArray(arrayToPower, 3));
            //частные случаи:
            PrintArray(GetPoweredArray(new int[0], 1));
            PrintArray(GetPoweredArray(new[] { 42 }, 0));
        }
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            int[] a = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = arr[i];
                a[i] = (int)Math.Pow(a[i], power);
            }
            return a;
        }
    }
}
