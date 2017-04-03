//$g++ main.cpp - compile
//$./a.out - run
#include <iostream>
#include <string>
#include <cctype>
#include <stdio.h>
#include <string.h>
using namespace std;

int main(){
    string str;
    getline(cin, str);
    for(int i = 0; i < str.length(); i++){
        if(isupper(str[i])) str[i] = tolower(str[i]);
        else if(islower(str[i])) str[i] = toupper(str[i]);
    }
    cout << str << endl;
}