#include "tfraction.h"

TFraction::TFraction() {
    this->upNumber = 0;
    this->downNumber = 1;
}

TFraction::TFraction(int up, int down) {
    this->upNumber = up;
    this->downNumber = down;
}

TFraction::TFraction(const TFraction &copy) {
    this->upNumber = copy.upNumber;
    this->downNumber = copy.downNumber;
}

int TFraction::getUpNumber() const  {
    return this->upNumber;
}

int TFraction::getDownNumber() const {
    return this->downNumber;
}

void TFraction::inputFraction() {
    try {
        cout<<"Enter numerator: ";
        cin>>this->upNumber;
        cout<<"Enter denominator: ";
        cin>>this->downNumber;
    }
    catch (...)
    {
        cout<<"Wrong format of data: " << "\n";
    }
}

void TFraction::printFraction() {
    cout << "Fraction: " + to_string(upNumber) + "/" + to_string(downNumber) << "\n";
}

TFraction TFraction::operator+(const TFraction &obj) {
    int lcm = (this->downNumber*obj.downNumber)/findGCD(this->downNumber,obj.downNumber);
    int sum=(this->upNumber*lcm/this->downNumber) + (obj.upNumber*lcm/obj.downNumber);
    return { sum, lcm};
}

TFraction TFraction::operator-(const TFraction &obj) {
    int lcm = (this->downNumber*obj.downNumber)/findGCD(this->downNumber,obj.downNumber);
    int sum=(this->upNumber*lcm/this->downNumber) - (obj.upNumber*lcm/obj.downNumber);
    return { sum, lcm};
}

TFraction TFraction::operator*(const TFraction &obj) const {
    return { obj.upNumber * this->upNumber, obj.downNumber*this->downNumber};
}

TFraction TFraction::operator/(const TFraction &obj) const {
    if(obj.downNumber==0){
        cout<<"Can't divide by 0" << "\n";
        return {};
    }
    return { this->upNumber*obj.downNumber, obj.upNumber*this->downNumber};
}

void TFraction::simplifyFraction() {
    int denominator = findGCD(this->upNumber, this->downNumber);
    if(denominator == 0) return;
    this->upNumber /= denominator;
    this->downNumber /= denominator;
}

int TFraction::findGCD(int n1, int n2) {
    int gcd;
    for(int i=1; i <= n1 && i <= n2; i++)
    {
        if(n1%i==0 && n2%i==0)
            gcd = i;
    }
    return gcd;
}
