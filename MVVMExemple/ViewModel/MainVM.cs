using System.ComponentModel;
using MVVMExemple.Model;

namespace MVVMExemple.ViewModel
{
    public class MainVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                NewMethod();
            }
        }

        private void NewMethod()
        {
            OnPropertyChanged(nameof(Sum)); OnPropertyChanged(nameof(Sub));
            OnPropertyChanged(nameof(Mull)); OnPropertyChanged(nameof(Dev));
        }

        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                NewMethod();
            }
        }
        
        public int Sum => MathFuncs.GetSumOf(Number1, Number2);

        public int Sub => MathFuncs.GetSubOf(Number1, Number2);

        public int Mull => MathFuncs.GetMullOf(Number1, Number2);

        public double Dev => MathFuncs.GetDevOf(Number1, Number2);
        
    }
}