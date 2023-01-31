namespace csharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TFraction t1 = new TFraction();
            TFraction t2 = new TFraction();
            TMixFraction tm1= new TMixFraction();
            TMixFraction tm2 = new TMixFraction();
            bool isMixEnabled = false;
            while(true){
                var input = int.Parse(Console.ReadLine() ?? "0");
                switch (input){
                    case 0:
                        isMixEnabled = !isMixEnabled;
                        break;
                    case 1:
                        if(isMixEnabled){
                            tm1 = new TMixFraction();
                            tm1.InputFraction();
                        } else {
                            t1 = new TFraction();
                            t1.InputFraction();
                        }
                        break;
                    case 2:
                        if(isMixEnabled){
                            tm2 = new TMixFraction();
                            tm2.InputFraction();
                        } else {
                            t2 = new TFraction();
                            t2.InputFraction();
                        }
                        break;
                    case 3:
                        if(isMixEnabled){
                            TMixFraction tm3;
                            tm3 = tm1 + tm2;
                            tm3.PrintFraction();
                            tm3 = tm1 - tm2;
                            tm3.PrintFraction();
                            tm3 = tm1 * tm2;
                            tm3.PrintFraction();
                            tm3 = tm1 / tm2;
                            tm3.PrintFraction();
                        } else {
                            TFraction t3;
                            t3 = t1 + t2;
                            t3.PrintFraction();
                            t3 = t1 - t2;
                            t3.PrintFraction();
                            t3 = t1 * t2;
                            t3.PrintFraction();
                            t3 = t1 / t2;
                            t3.PrintFraction();
                        }
                        break;
                    case 4:
                        if(isMixEnabled){
                            tm1.PrintFraction();
                            tm2.PrintFraction();
                        } else {
                            t1.PrintFraction();
                            t2.PrintFraction();
                        }
                        break;
                    case 5:
                        if (isMixEnabled) {
                            tm1.SimplifyFraction();
                            tm2.SimplifyFraction();
                        } else {
                            t1.SimplifyFraction();
                            t2.SimplifyFraction();
                        }
                        break;
                    case 9:
                        return;
                }

            }
        }
    }
}

/**
 * 0 - Перейти в режим TMixFraction / TFraction
 * 1 - Cтворити TFraction / TMixFraction
 * 2 - Cтворити TFraction / TMixFraction
 * 3 - Арефметичні операції
 * 4 - Виведеня даних
 * 5 - Скорочення дробів
 * 9 - Вихід
*/
