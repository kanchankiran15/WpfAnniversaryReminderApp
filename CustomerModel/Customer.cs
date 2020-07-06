using System;

namespace CustomerModel
{
    public class Customer
    {
        private string _CustomerName;
        private double _Amount;
        private double _Tax;
        private string _Married;
        public double Tax
        {
            get { return _Tax; }
        }

        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public double Amount { get => _Amount; set => _Amount = value; }
        public string Married { get => _Married; set => _Married = value; }

        public void CalculateTax()
        {
            if (_Amount > 2000)
            {
                _Tax = 20;
            }
            else if (_Amount > 1000)
            {
                _Tax = 10;
            }
            else
            {
                _Tax = 5;
            }
        }

    }
}
