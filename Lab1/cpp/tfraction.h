#include <iostream>
using namespace std;

 class TFraction {
 protected:
    int upNumber;
    int downNumber;
    virtual int findGCD(int n1, int n2);
 public:
    TFraction();
    TFraction(int up, int down);
    TFraction(const TFraction& copy);
    int getUpNumber() const;
    int getDownNumber() const;
    virtual void inputFraction();
    virtual void printFraction();
     virtual void simplifyFraction();
    TFraction operator + (TFraction const &obj);
    TFraction operator - (TFraction const &obj);
    TFraction operator * (TFraction const &obj) const;
    TFraction operator / (TFraction const &obj) const;
};