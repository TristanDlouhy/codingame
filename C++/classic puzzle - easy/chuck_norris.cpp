#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <bitset>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    string MESSAGE;
    getline(cin, MESSAGE);
    
    string bit = "";
    string out = "";
    string tmp = "";
    int curBit = -1;
    
    /* *************************************
     * ********** CONVERT STRING TO BIT
     * *************************************/
    for (int i = 0; i < MESSAGE.length(); i++)
    {
        char c = MESSAGE[i];
        bitset<7> bs(c);
        bit += bs.to_string();
    }
    
    /* *************************************
     * ********** GENERATE CHUCK NORRIS CODE
     * *************************************/
    for (string::iterator it = bit.begin(); it != bit.end(); ++it) 
    {
        
        if (*it != curBit)
        {
            if (curBit != -1)
                out += " ";
                
            curBit = *it;
            
            if (*it == '0')
                out += "00 ";
            else
                out += "0 ";
        }
        
        out += "0";
    }
    
    cout << out << endl;
}