//$g++ main.cpp - compile
//$./a.out - run
#include <iostream>
#include <string>
#include <cctype>
#include <cmath>
#include <stdio.h>
#include <string.h>
#include <iostream>
#include <regex>
#include <list>
using namespace std;

int main(){
    int n = 0;
    double sd, avg;
    list<double> lst;
    while(cin >> n){
        if(n == 0) break;
        sd = 0;
        avg = 0;
        double *s = new double[n];
        for(int i = 0; i < n; i++){
            cin >> s[i];
            avg += s[i];
        }
        avg /= n;
        for(int i = 0; i < n; i++){
            sd += pow(s[i] - avg, 2);
        }
        sd = sqrt(sd / n);
        lst.push_back(sd);
    }
    list<double>::iterator itr = lst.begin();
    while(itr != lst.end()){
        printf("%.8f\n", *itr);
        itr++;
    }
}