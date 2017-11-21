using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    /* Реализовать класс RandomArray, представляющий собой массив натуральных чисел. */
    class RandomArray
    {
        /* Внутренний массив для хранения данных */
        private int[] _arr;

        /* Реализовать в классе свойства, 
         * используемые для хранения длины массива(int) и ошибки последней обработки(bool). 
         * Редактирование поддерживаемого свойством поля запрещено в вызывающем коде.*/
        public int lenght { get { return _arr.Length; } }
        public bool err { get; private set; }

        public RandomArray(int numVal)
        {
            _arr = new int[numVal];
        }

        /* В классе RandomArray есть 2 индексатора, которые контролируют выход индекса за пределы массива, 
         * а также возможность записи в массив только числа являющегося степенью двойки. */
        public int this[int ind]
        {
            get
            {
                if (ind > _arr.Length - 1) { err = true; throw new IndexOutOfRangeException();  }
                err = true;
                return _arr[ind];
            }

            set
            {
                if (ind > _arr.Length - 1) { err = true; throw new IndexOutOfRangeException(); }
                
                if ((value & value - 1) == 0)//является ли призваиваемое число степенью 2
                {
                    _arr[ind] = value;
                    err = false;
                }
                else
                {
                    err = true; throw new Exception("Присваиваемое число не является степенью 2!");
                }
            }
        }

        /* Второй индексатор перегружает первый с возможностью обработки индекса нецелого типа */
        public int this[float ind]
        {
            
            get
            {
                bool check = ((ind / 0.5) - (int)(ind / 0.5))==0;
                if (!check){ err = true; throw new Exception("Индекс массива не кратен 0,5!"); }
                if ((int)(ind / 0.5) > _arr.Length - 1) { err = true; throw new IndexOutOfRangeException(); }
                err = false;
                return _arr[(int)(ind / 0.5)]; }

            set
            {
                bool check = ((ind / 0.5) - (int)(ind / 0.5)) == 0;
                if (!check) { err = true; throw new Exception("Индекс массива не кратен 0,5!"); }
                if ((int)(ind / 0.5) > _arr.Length - 1) { err = true; throw new IndexOutOfRangeException(); }

                if ((value & value - 1) == 0)//является ли призваиваемое число степенью 2
                {
                    _arr[(int)(ind / 0.5)] = value;
                    err = false;
                }
                else
                {
                    err = true; throw new Exception("Присваиваемое число не является степенью 2!");
                }
            }
        }

        /* создать открытый метод AmountOfDegrees, возвращающий отношение: 
         * произведение степеней основания 2 / сумму степеней основания 2. */
         public double AmountOfDegrees()
        {
            double mul=1;
            double sum=0;
            double e;
            foreach (int elem in _arr)
            {
                e = Math.Log(elem, 2);
                mul *= e;
                sum += e;
            }
            return mul / sum;
        }
    }
}
