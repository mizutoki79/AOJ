//Visual Studio
#include "stdafx.h"
//C++11
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
#include <list>

using namespace std;

int main()
{
	double x1, x2, y1, y2, d;
	cin >> x1 >> y1 >> x2 >> y2;
	d = sqrt(pow(x2 - x1, 2) + pow(y2 - y1, 2));
	printf("%.8f\n", d);
	return 0;
}
