#include <iostream>
#include <time.h>
#include <vector>
#include "AlchemyQuiz.h"

using namespace std;

int main()
{
    cout << "It's time to build a house." << endl;
    string input;

    try 
    {
        cout << "First of all do you have the credentials (y/n): ";
        cin >> input;
        if (input != "y")
            throw("not good");
    }
    catch(...)
    {
        cout << "I knew you were a fraud. You're Fired!" << endl;
        return 0;
    }
    cout << "Alright then lets get to work." << endl;
    House h;

    cout << "Looks Like the house has been built. Lets take a look at it" << endl;
    cout << h;

    return 0;
}