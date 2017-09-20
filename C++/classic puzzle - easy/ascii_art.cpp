#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    int L;
    cin >> L; cin.ignore();
    int H;
    cin >> H; cin.ignore();
    string T;
    getline(cin, T);
    
    string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
    vector<string> vecAbc;
    vector<string> vecOutput(H, "");

    /* *************************************
     * ********** SAVE ASCII SYMBOLS IN VECTOR
     * *************************************/
    for (int i = 0; i < H; i++) 
    {
        string ROW;
        getline(cin, ROW);
        vecAbc.push_back(ROW);
    }
    
    /* *************************************
     * ********** GET WORD AND WRITE ASCII SYMBOLS
     * *************************************/
    for (int i = 0; i < T.length(); i++)
    {
        // get one letter
        char letter = toupper(T[i]);
        
        // check if letter aviable
        if (letter < 'A' || letter > 'Z' )
            letter = '?';
        
        // get index
        int index = abc.find(letter);
        
        // find ascii symbols
        for (int j = 0; j < H; j++)
        {
            vecOutput[j] += vecAbc[j].substr(L * index, L);
        }
    }
    
    /* *************************************
     * ********** OUTPUT
     * *************************************/
    for (int i = 0; i < H; i++)
    {
        cout << vecOutput[i] << endl;
    }
}