#include "stdafx.h"
/*
#include <iostream>
#include <math.h>
#include <algorithm>
#include <string>
//#include <cctype>
#include <stdio.h>
#include <string.h>
#include <iostream>
#include <regex>
#include <climits>
*/
#include <stdio.h>
#include <iostream>
using namespace std;

int main()
{
	const int numOfAlp = 26;
	char ch;
	int *cnt = new int[numOfAlp];
	for (int i = 0; i < numOfAlp; i++) cnt[i] = 0;
	while (scanf_s("%c", &ch) != EOF) {
		if (isupper(ch)) ch = tolower(ch);
		if (islower(ch)) cnt[ch - 'a']++;
	}
	for (int i = 0; i < numOfAlp; i++) {
		printf("%c : %d\n", 'a' + i, cnt[i]);
	}
}

