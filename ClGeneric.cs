using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPrj
{
    public class ClGeneric<T>
    {
        public T Value { get; }
        public string Name { get; }
        public ClGeneric(T value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
