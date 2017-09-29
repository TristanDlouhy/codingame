#include <iostream>
#include <string>
#include <list>
#include <algorithm>

using namespace std;

/**
* Auto-generated code below aims at helping you parse
* the standard input according to the problem statement.
**/
int main()
{
	int N;

	std::list<int> horsesStrength;
	int closestStrength = -1;

	cin >> N; cin.ignore();
	for (int i = 0; i < N; i++) {
		int Pi;
		cin >> Pi; cin.ignore();
		// push horse strength in list
		horsesStrength.push_back(Pi);
	}

	// sort list 
	horsesStrength.sort();
	
	for (std::list<int>::iterator it = horsesStrength.begin(); it != horsesStrength.end(); ++it)
	{
		// check if last element dont compare anymore horse strength
		if (it == std::prev(horsesStrength.end())) break;

		int strength = *next(it) - (*it);

		if (closestStrength == -1 || strength < closestStrength)
			closestStrength = strength;
	}

	// result output
	cout << closestStrength << endl;
}