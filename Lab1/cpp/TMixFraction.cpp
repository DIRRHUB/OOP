#include "TMixFraction.h"

TMixFraction::TMixFraction() {
    this->mix = 0;
    this->upNumber = 0;
    this->downNumber = 1;
}

TMixFraction::TMixFraction(int mix, int up, int down) {
    this->mix=mix;
    this->upNumber=up;
    this->downNumber=down;
}

TMixFraction::TMixFraction(const TMixFraction &copy)  : TFraction(copy) {
    this->mix=copy.mix;
    this->upNumber=copy.upNumber;
    this->downNumber=copy.downNumber;
}

int TMixFraction::getMixNumber() const {
    return this->mix;
}

void TMixFraction::inputFraction() {
    try {
        cout<<" Enter numerator: ";
        cin >> this->upNumber;
        cout<<"Enter denominator: ";
        cin>> this->downNumber;
    }
    catch (...)
    {
        cout<<"Wrong format of data: ";
    }
}

void TMixFraction::printFraction() {
    cout << "Mix: " + to_string(mix) + " Fraction: " + to_string(upNumber) + "/" + to_string(downNumber);
}

void TMixFraction::simplifyFraction() {
    this->upNumber = (this->mix * this->downNumber) + this->upNumber;
    int denominator = findGCD(this->upNumber, this->downNumber);
    this->upNumber /= denominator;
    this->downNumber /= denominator;
    int upLeft = this->upNumber % this->downNumber;
    this->mix = (this->upNumber - upLeft) / this->downNumber;
    this->upNumber = upLeft;
}

TMixFraction TMixFraction::operator+(const TMixFraction &obj) {
    this->upNumber = (this->mix * this->downNumber) + this->upNumber;
    int objUpNumber = (obj.mix * obj.downNumber) + obj.upNumber;
    int lcm = (this->downNumber*obj.downNumber)/findGCD(this->downNumber,obj.downNumber);
    int sum=(this->upNumber*lcm/this->downNumber) + (objUpNumber*lcm/obj.downNumber);
    int sumLeft = sum % lcm;
    int mixNumber = (sum - sumLeft) / lcm;
    return {mixNumber, sumLeft, lcm};
}

TMixFraction TMixFraction::operator-(const TMixFraction &obj) {
    this->upNumber = (this->mix * this->downNumber) + this->upNumber;
    int objUpNumber = (obj.mix * obj.downNumber) + obj.upNumber;
    int lcm = (this->downNumber*obj.downNumber)/findGCD(this->downNumber,obj.downNumber);
    int sum=(this->upNumber*lcm/this->downNumber) - (objUpNumber*lcm/obj.downNumber);
    int sumLeft = sum % lcm;
    int mixNumber = (sum - sumLeft) / lcm;
    return {mixNumber, sumLeft, lcm};
}

TMixFraction TMixFraction::operator*(const TMixFraction &obj) {
    this->upNumber = (this->mix * this->downNumber) + this->upNumber;
    int objUpNumber = (obj.mix * obj.downNumber) + obj.upNumber;
    int sum = this->upNumber*objUpNumber;
    int lcm = this->downNumber*obj.downNumber;
    int sumLeft = sum%lcm;
    int mixNumber = (sum-sumLeft)/lcm;
    return { mixNumber, sumLeft, lcm};
}

TMixFraction TMixFraction::operator/(const TMixFraction &obj) {
    if(obj.downNumber==0){
        cout<<"Can't divide by 0";
        return {};
    }
    this->upNumber = (this->mix * this->downNumber) + this->upNumber;
    int objUpNumber = (obj.mix * obj.downNumber) + obj.upNumber;
    int sum = this->upNumber*obj.downNumber;
    int lcm = this->downNumber*objUpNumber;
    int sumLeft = sum%lcm;
    int mixNumber = (sum-sumLeft)/lcm;
    return { mixNumber, sumLeft, lcm};
}

