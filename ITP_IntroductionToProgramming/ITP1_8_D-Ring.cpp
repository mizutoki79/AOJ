//Visual Studio—p
#include "stdafx.h"
//after C++11
#include <regex>
//C++
#include <stdio.h>
#include <string.h>
#include <math.h>
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
#include <climits>

using namespace std;

int main()
{
	string s, p;
	regex re;
	cin >> s >> p;
	s += s;
	re = p;
	if (regex_search(s, re)) cout << "Yes" << endl;
	else cout << "No" << endl;
}
