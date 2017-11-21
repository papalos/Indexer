using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class NaturalNum
    {
        /* Реализовать класс «натуральное число» с полями «основание» и «степень» */        
        private int _power;

        /* Для свойства поля «основание» создать автоматически реализуемое свойство */
        public int basis {get; set;}

        /* Для свойства поля «степень» аксессор set задает степень, 
         * а get-возвращает значение основания в указанной степени. */
        public int power
        {
            set{ _power = value;}
            get { return (int)Math.Pow(basis, _power); }
        }
    }
}
