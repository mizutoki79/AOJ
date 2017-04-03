//Visual Studio
#include "stdafx.h"
//C++11
#include <regex>
//C++
#define _USE_MATH_DEFINES
#include <stdio.h>
#include <string.h>
#include <math.h>
#include <iostream>
#include <string>
#include <cctype>
#include <cmath>
#include <cfloat>
#include <algorithm>
#include <climits>
#include <vector>
#include <list>

using namespace std;

int main()
{
	int n;
	cin >> n;
	double *x = new double[n];
	double *y = new double[n];
	for (int i = 0; i < n; i++) {
		cin >> x[i];
	}
	for (int i = 0; i < n; i++) {
		cin >> y[i];
	}
	for (int i = 0; i < n; i++) {
		x[i] = fabs(x[i] - y[i]);
	}
	for (double p : { 1.0, 2.0, 3.0}) {
		double sum = 0;
		for (int i = 0; i < n; i++) {
			sum += pow(x[i], p);
		}
		printf("%.08f\n", pow(sum, 1 / p));
	}
	double max = 0;
	for (int i = 0; i < n; i++) {
		if (max < x[i]) max = x[i];
	}
	printf("%.08f\n", max);
	return 0;
}
