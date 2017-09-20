#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
int main()
{
    int lightX; // the X position of the light of power
    int lightY; // the Y position of the light of power
    int initialTX; // Thor's starting X position
    int initialTY; // Thor's starting Y position
    cin >> lightX >> lightY >> initialTX >> initialTY; cin.ignore();

    int disX = lightX - initialTX;
    int disY = lightY - initialTY;

    // game loop
    while (1) {
        int remainingTurns; // The remaining amount of turns Thor can move. Do not remove this line.
        cin >> remainingTurns; cin.ignore();

        char move[2] = {'\0', '\0'};
        int movePos = 0;

        /* *************************************
         * ********** NORTH AND SOUTH
         * *************************************/
        if (disY != 0)
        {
            move[movePos] = disY > 0 ? 'S' : 'N';
            disY += disY > 0 ? -1 : 1;
            movePos++;
        }
        
        /* *************************************
         * ********** EAST AND WEST
         * *************************************/
        if (disX != 0)
        {
            move[movePos] = disX > 0 ? 'E' : 'W';
            disX += disX > 0 ? -1 : 1;
        }
        
        /* *************************************
         * ********** MOVE ACTION
         * *************************************/
        if (move[1] == '\0')
            cout << move[0] << endl;
        else
            cout << move[0] << move[1] << endl;
    }
}