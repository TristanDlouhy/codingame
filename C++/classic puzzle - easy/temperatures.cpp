#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <sstream> 

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    int n; // the number of temperatures to analyse
    cin >> n; cin.ignore();
    string temps; // the n temperatures expressed as integers ranging from -273 to 5526
    getline(cin, temps);
    
    stringstream ss;
    string sNumber;
    int result;
    
    // push string in stream
    ss << temps;
    
    while (getline(ss, sNumber, ' ')) 
    {
        int tmpNumber = stoi(sNumber);
        
        // if result null set result with first value
        if (result == NULL)
            result = tmpNumber;
        
        // if result not null
        if (result != tmpNumber)
        {
            // check result and tmpNumber equals
            if (abs(result) == abs(tmpNumber) && tmpNumber > 0)
                result = tmpNumber;
            // check number is negative
            else if (tmpNumber < 0)
                result = result < tmpNumber ? tmpNumber : result;
            // check number is positive
            else if (tmpNumber > 0)
                result = result > tmpNumber ? tmpNumber : result;
        }
    }
    
    cout << result << endl;
}