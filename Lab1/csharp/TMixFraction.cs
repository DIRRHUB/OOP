namespace csharp {
    public class TMixFraction : TFraction
    {
        private int _mix;

        public int MixNumber
        {
            get => _mix;
            set => _mix = value;
        }

        public TMixFraction()
        {
            this._mix = 0;
            this._upNumber = 0;
            this._downNumber = 1;
        }

        public TMixFraction(int mix, int up, int down)
        {
            this._mix = mix;
            this._upNumber = up;
            this._downNumber = down;
        }

        public TMixFraction(in TMixFraction copy) : base(copy)
        {
            this._mix = copy._mix;
            this._upNumber = copy._upNumber;
            this._downNumber = copy._downNumber;
        }

        public override void InputFraction()
        {
            try
            {
                Console.Write("Enter mix: ");
                this._mix = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter numerator: ");
                this._upNumber = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter denominator: ");
                this._downNumber = int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                Console.Write("Wrong format of data: ");
                Console.Write("\n");
            }
        }

        public override void PrintFraction()
        {
            Console.Write("Mix: " + Convert.ToString(_mix) + " Fraction: " + Convert.ToString(_upNumber) + "/" +
                Convert.ToString(_downNumber));
            Console.Write("\n");
        }

        public override void SimplifyFraction()
        {
            this._upNumber = (this._mix * this._downNumber) + this._upNumber;
            int denominator = FindGCD(this._upNumber, this._downNumber);
            if (denominator == 0)
            {
                return;
            }

            this._upNumber /= denominator;
            this._downNumber /= denominator;
            int upLeft = this._upNumber % this._downNumber;
            this._mix = (this._upNumber - upLeft) / this._downNumber;
            this._upNumber = upLeft;
        }

        public static TMixFraction operator +(TMixFraction impliedObject, in TMixFraction obj)
        {
            impliedObject._upNumber = (impliedObject._mix * impliedObject._downNumber) + impliedObject._upNumber;
            int objUpNumber = (obj._mix * obj._downNumber) + obj._upNumber;
            int lcm = (impliedObject._downNumber * obj._downNumber) / FindGCD(impliedObject._downNumber, obj._downNumber);
            int sum = (impliedObject._upNumber * lcm / impliedObject._downNumber) + (objUpNumber * lcm / obj._downNumber);
            int sumLeft = sum % lcm;
            int mixNumber = (sum - sumLeft) / lcm;
            return new TMixFraction(mixNumber, sumLeft, lcm);
        }

        public static TMixFraction operator -(TMixFraction impliedObject, in TMixFraction obj)
        {
            impliedObject._upNumber = (impliedObject._mix * impliedObject._downNumber) + impliedObject._upNumber;
            int objUpNumber = (obj._mix * obj._downNumber) + obj._upNumber;
            int lcm = (impliedObject._downNumber * obj._downNumber) / FindGCD(impliedObject._downNumber, obj._downNumber);
            int sum = (impliedObject._upNumber * lcm / impliedObject._downNumber) - (objUpNumber * lcm / obj._downNumber);
            int sumLeft = sum % lcm;
            int mixNumber = (sum - sumLeft) / lcm;
            return new TMixFraction(mixNumber, sumLeft, lcm);
        }

        public static TMixFraction operator *(TMixFraction impliedObject, in TMixFraction obj)
        {
            impliedObject._upNumber = (impliedObject._mix * impliedObject._downNumber) + impliedObject._upNumber;
            int objUpNumber = (obj._mix * obj._downNumber) + obj._upNumber;
            int sum = impliedObject._upNumber * objUpNumber;
            int lcm = impliedObject._downNumber * obj._downNumber;
            int sumLeft = sum % lcm;
            int mixNumber = (sum - sumLeft) / lcm;
            return new TMixFraction(mixNumber, sumLeft, lcm);
        }

        public static TMixFraction operator /(TMixFraction impliedObject, in TMixFraction obj)
        {
            if (obj._downNumber == 0)
            {
                Console.Write("Can't divide by 0 \n");
                return new TMixFraction();
            }

            impliedObject._upNumber = (impliedObject._mix * impliedObject._downNumber) + impliedObject._upNumber;
            int objUpNumber = (obj._mix * obj._downNumber) + obj._upNumber;
            int sum = impliedObject._upNumber * obj._downNumber;
            int lcm = impliedObject._downNumber * objUpNumber;
            int sumLeft = sum % lcm;
            int mixNumber = (sum - sumLeft) / lcm;
            return new TMixFraction(mixNumber, sumLeft, lcm);
        }
    }
}
