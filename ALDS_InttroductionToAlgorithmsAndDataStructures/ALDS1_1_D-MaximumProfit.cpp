// AOJPlusPlus.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

//#include "stdafx.h"
#include <iostream>
#include <math.h>
#include <algorithm>
#include <iostream>
#include <string>
#include <cctype>
#include <stdio.h>
#include <string.h>
#include <iostream>
#include <regex>
#include <climits>
using namespace std;

int main()
{
	int n, minv = INT_MAX, maxd = INT_MIN, dis = 0;
	cin >> n;
	int *r = new int[n];
	for (int i = 0; i < n; i++) {
		cin >> r[i];
		if (i == 0) minv = r[i];
		else {
			maxd = max(maxd, r[i] - minv);
			minv = min(minv, r[i]);
		}
	}
	cout << maxd << endl;
    return 0;
}

