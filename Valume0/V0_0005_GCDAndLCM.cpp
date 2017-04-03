#include <iostream>
#include <algorithm>
#define llong long long
llong gcd(llong a, llong b)
{
    llong mod;
    mod = std::max(a, b) % std::min(a, b);
    if(mod == 0) return std::min(a, b);
    else return gcd(std::min(a, b), mod);
}
llong lcm(llong a, llong b, llong gcd)
{
    return (a * b) / gcd;
}
int main()
{
    llong a, b;
    while(std::cin >> a >> b)
    {
        llong g = gcd(a, b);
        std::cout << g << " " << lcm(a, b, g) << std::endl;
    }
}