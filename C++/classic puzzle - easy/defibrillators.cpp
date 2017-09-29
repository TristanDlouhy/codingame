#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <limits>
#include <regex>
#include <cmath>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
std::vector<std::string> Split(std::string strSep, std::string str);
double CalculateDistance(double userLON, double userLAT, double stationLON, double stationLAT);

int main()
{
	// closest defibrillator station
	string closestStation;
	double closestDistance = std::numeric_limits<double>::max();

	// read longitude location
	string LON;
	cin >> LON; cin.ignore();
	std::replace(LON.begin(), LON.end(), ',', '.');
	double Longitude = std::stod(LON);

	// read latitude location
	string LAT;
	cin >> LAT; cin.ignore();
	std::replace(LAT.begin(), LAT.end(), ',', '.');
	double Latitude = std::stod(LAT);

	// read stations
	int N;
	cin >> N; cin.ignore();

	for (int i = 0; i < N; i++)
	{
		string DEFIB = "";
		getline(cin, DEFIB);

		std::vector<std::string> substring = Split("[;]+", DEFIB);
		string stationName = substring[1];

		std::replace(substring[substring.size() - 2].begin(), substring[substring.size() - 2].end(), ',', '.');
		double stationLON = std::stod(substring[substring.size() - 2]);

		std::replace(substring[substring.size() - 1].begin(), substring[substring.size() - 1].end(), ',', '.');
		double stationLAT = std::stod(substring[substring.size() - 1]);

		double distance = CalculateDistance(Longitude, Latitude, stationLON, stationLAT);

		if (closestStation.empty())
		{
			closestStation = stationName;
			closestDistance = distance;
		}
		else if (closestDistance > distance)
		{
			closestStation = stationName;
			closestDistance = distance;
		}
	}

	cout << closestStation << endl;
}

std::vector<std::string> Split(std::string strSep, std::string str)
{
	std::vector<std::string> vecElements;

	std::regex sep(strSep);
	std::sregex_token_iterator elements(str.cbegin(), str.cend(), sep, -1);
	std::sregex_token_iterator end;

	for (; elements != end; ++elements) {
		cerr << *elements << endl;
		vecElements.push_back(*elements);
	}

	return vecElements;
}

double CalculateDistance(double userLON, double userLAT, double stationLON, double stationLAT)
{
	double x = (stationLON - userLON) * cos((userLAT + stationLAT) / 2);
	double y = (stationLAT - userLAT);

	return sqrt(pow(x, 2) + pow(y, 2)) * 6371;
}
