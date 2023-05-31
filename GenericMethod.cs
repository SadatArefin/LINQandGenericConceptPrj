using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPrj
{
    public class GenericMethod
    {
        public T FirstNumber<T>(T n)
        {
            return n;
        }
        public T SecondNumber<T>(T n)
        {
            return n;
        }
    }
}
