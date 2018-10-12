using System.Net.Mime;
using MVVMExemple.ViewModel;

namespace MVVMExemple.Model
{
    public static class MathFuncs
    {
        public static string _devEx = "Dividing by zero is impossible. Please enter a different number";        

        public static int GetSumOf(int a, int b) => a + b;
        public static int GetSubOf(int a, int b) => a - b;
        public static int GetMullOf(int a, int b) => a * b;


        public static object GetDevOf(double a, double b, string c)
        {
            if(b == 0)
            {
                return c = _devEx;
            }
            return a / b;
        }
    }
}