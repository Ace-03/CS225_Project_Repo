#include <iostream>
#include <time.h>
#include <vector>
#include "AlchemyQuiz.h"

using namespace std;

template <class T>
void InputProcessor(T& userInput, string message)
{
    bool invalidResponse;
    do
    {
        invalidResponse = false;
        cout<<message;
        cin>>userInput;

        if (!cin)
        {
            cout<<"Invalid Response" << endl;
            cin.clear();
            cin.ignore(10000,'\n');
            invalidResponse = true;
        }
    } while (invalidResponse);
    cin.clear();
    cin.ignore(10000,'\n');
}

Room::Room()
{
    InputProcessor(name, "What is this room Called: ");
    InputProcessor(size, "How large is the room (square feet): ");
    cout << endl;
}

Room::Room(int s, string n): size(s), name(n) {}

ostream& operator<<(ostream& out, const Room& r)
{
    out << "Room Name: " << r.name << endl;
    out << "size: " << r.size << " square feet" << endl;
    out << endl;

    return out;
}

House::House()
{
    InputProcessor(owner, "Who owns this house: ");
    InputProcessor(location, "Where is the house located: ");
    InputProcessor(numberOfRooms, "How many rooms are there in the house: ");
    cout << endl;
    
    for (int i = 0; i < numberOfRooms; i++)
    {
        cout << "Time for room " << i+1 << endl;
        roomsInHouse.push_back(Room());
    }
}

House::House(string o, string l, int n): owner(o), location(l), numberOfRooms(n) {}

House::~House() { cout<<"The house was destroyed in an accident!"<<endl; }

ostream& operator<<(ostream& out, const House& h)
{
    out << "Home Owner: " << h.owner << endl;
    out << "Location: " << h.location << endl;
    out << "Number of Rooms:" << h.numberOfRooms << endl;

    for (int i = 0; i < h.numberOfRooms; i++)
    {
        cout << endl << "Room " << i+1 << endl;
        out << h.roomsInHouse[i];
    }

    out << endl;

    return out;
}
