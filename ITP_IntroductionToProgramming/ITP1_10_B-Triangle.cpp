//Visual Studio
#include "stdafx.h"
//C++11
#include <regex>
//C, C++
#define _USE_MATH_DEFINES
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
#include <cmath>
#include <climits>
#include <list>
#include <stdio.h>
#include <string.h>
#include <math.h>

using namespace std;

int main()
{
	double a, b, c, C, S, L, h;
	cin >> a >> b >> C;
	C = C * M_PI / 180;
	h = b * sin(C);
	S = a * h / 2;
	c = sqrt(pow(a, 2) + pow(b, 2) - 2 * a*b*cos(C));
	L = a + b + c;
	printf("%.8f %.8f %.8f\n", S, L, h);
	return 0;
}
