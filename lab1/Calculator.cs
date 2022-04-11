using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface ICalc
    {
        int BinaryAnd(int x1, int x2);
        int BinaryOr(int x1, int x2);
        int BinaryXor(int x1, int x2);
        int BinaryNot(int x1);
    }
     public class Calculator : ICalc
    {
        public int BinaryAnd(int x1, int x2)
        {
            return x1 & x2;
        }

        public int BinaryNot(int x1)
        {
            return ~x1;
        }

        public int BinaryOr(int x1, int x2)
        {
            return x1 | x2;
        }

        public int BinaryXor(int x1, int x2)
        {
            return x1 ^ x2;
        }
    }
}
