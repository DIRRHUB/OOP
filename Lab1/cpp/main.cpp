#include "TMixFraction.h"

using namespace std;

int main (){
    TFraction t1,t2;
    TMixFraction tm1, tm2;
    bool isEnabled = true;
    bool isMixEnabled = false;
    while(isEnabled){
        int input;
        cin>>input;
        switch (input){
            case 0:
                isMixEnabled = !isMixEnabled;
                break;
            case 1:
                if(isMixEnabled){
                    tm1 = TMixFraction();
                    tm1.inputFraction();
                } else {
                    t1 = TFraction();
                    t1.inputFraction();
                }
                break;
            case 2:
                if(isMixEnabled){
                    tm2 = TMixFraction();
                    tm2.inputFraction();
                } else {
                    t2 = TFraction();
                    t2.inputFraction();
                }
                break;
            case 3:
                if(isMixEnabled){
                   TMixFraction tm3;
                   tm3 = tm1 + tm2;
                   tm3.printFraction();
                   tm3 = tm1 - tm2;
                   tm3.printFraction();
                   tm3 = tm1 * tm2;
                   tm3.printFraction();
                   tm3 = tm1 / tm2;
                    tm3.printFraction();
                } else {
                    TFraction t3;
                    t3 = t1 + t2;
                    t3.printFraction();
                    t3 = t1 - t2;
                    t3.printFraction();
                    t3 = t1 * t2;
                    t3.printFraction();
                    t3 = t1 / t2;
                    t3.printFraction();
                }
                break;
            case 4:
                if(isMixEnabled){
                    tm1.printFraction();
                    tm2.printFraction();
                } else {
                    t1.printFraction();
                    t2.printFraction();
                }
                break;
            case 5:
               if (isMixEnabled) {
                   tm1.simplifyFraction();
                   tm2.simplifyFraction();
               } else {
                   t1.simplifyFraction();
                   t2.simplifyFraction();
               }
                break;
            case 9:
                return 0;
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