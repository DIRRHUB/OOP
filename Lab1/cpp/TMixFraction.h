#include <iostream>
#include "tfraction.h"

using namespace std;

class TMixFraction : public TFraction {
private:
    int mix;
public:
    TMixFraction();
    TMixFraction(int mix, int up, int down);
    TMixFraction(const TMixFraction& copy);
    int getMixNumber() const;
    void inputFraction () override;
    void printFraction() override;
    void simplifyFraction() override;
    TMixFraction operator + (TMixFraction const &obj);
    TMixFraction operator - (TMixFraction const &obj);
    TMixFraction operator * (TMixFraction const &obj);
    TMixFraction operator / (TMixFraction const &obj);
};
