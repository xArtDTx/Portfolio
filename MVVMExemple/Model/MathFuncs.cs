using System.Net.Mime;
using MVVMExemple.ViewModel;

namespace MVVMExemple.Model
{
    public static class MathFuncs
    {
        
        public static int GetSumOf(int a, int b) => a + b;
        public static int GetSubOf(int a, int b) => a - b;
        public static int GetMullOf(int a, int b) => a * b;
        public static double GetDevOf(double a, double b)
        {
            if (b != 0)
            {
                return a / b;

            }
            else
            {
                return 0;
            }
        }
    }
}