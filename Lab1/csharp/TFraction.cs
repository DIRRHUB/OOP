namespace csharp {
    public class TFraction {
        protected int _upNumber, _downNumber;

        public int UpNumber
        {
            get => _upNumber;
            set => _upNumber=value;
        }
        public int DownNumber
        {
            get => _downNumber;
            set => _downNumber=value;
        }

        public TFraction()
        {
            _upNumber=0;
            _downNumber=1;
        }

        public TFraction(int upNumber, int downNumber)
        {
            this._upNumber=upNumber;
            this._downNumber=downNumber;
        }

        public TFraction(in TFraction obj)
        {
            _upNumber = obj.UpNumber;
            _downNumber = obj.DownNumber;
        }

        public virtual void InputFraction()
        {
            try
            {
                Console.Write("Enter numerator: ");
                this._upNumber = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter denominator: ");
                this._downNumber = int.Parse(Console.ReadLine() ?? "1");
            }
            catch
            {
                Console.Write("Wrong format of data: \n");
            }
        }

        public virtual void PrintFraction()
        {
            Console.Write("Fraction: " + Convert.ToString(_upNumber) + "/" + Convert.ToString(_downNumber) + "\n");
        }

        public virtual void SimplifyFraction()
        {
            int denominator = FindGCD(this._upNumber, this._downNumber);
            if (denominator == 0)
            {
                return;
            }
            this._upNumber /= denominator;
            this._downNumber /= denominator;
        }

        public static TFraction operator + (TFraction impliedObject, in TFraction obj)
        {
            int lcm = (impliedObject._downNumber * obj._downNumber) / FindGCD(impliedObject._downNumber,obj._downNumber);
            int sum = (impliedObject._upNumber * lcm / impliedObject._downNumber) + (obj._upNumber * lcm / obj._downNumber);
            return new TFraction(sum, lcm);
        }

        public static TFraction operator - (TFraction impliedObject, in TFraction obj)
        {
            int lcm = (impliedObject._downNumber * obj._downNumber) / FindGCD(impliedObject._downNumber,obj._downNumber);
            int sum = (impliedObject._upNumber * lcm / impliedObject._downNumber) - (obj._upNumber * lcm / obj._downNumber);
            return new TFraction(sum, lcm);
        }

        public static TFraction operator * (TFraction impliedObject, in TFraction obj)
        {
            return new TFraction(obj._upNumber * impliedObject._upNumber, obj._downNumber * impliedObject._downNumber);
        }

        public static TFraction operator / (TFraction impliedObject, in TFraction obj)
        {
            if (obj._downNumber == 0)
            {
                Console.Write("Can't divide by 0 \n");
                return new TFraction();
            }
            return new TFraction(impliedObject._upNumber * obj._downNumber, obj._upNumber * impliedObject._downNumber);
        }

        protected static int FindGCD(int n1, int n2)
        {
            int gcd = 1;
            for (int i = 1; i <= n1 && i <= n2; i++)
            {
                if (n1 % i == 0 && n2 % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }
    }
}