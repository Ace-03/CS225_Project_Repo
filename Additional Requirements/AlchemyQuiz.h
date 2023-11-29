#ifndef ALCHEMY_QUIZ_H
#define ALCHEMY_QUIZ_H


#include <iostream>
#include <vector>

using namespace std;

template <class T>
void inputProcessor(T, string);

class Room
{
    private:
    int size;
    string name;
    public:
    Room();
    Room(int, string);
    friend ostream& operator<<(ostream&, const Room&);
};

class House
{
    private:
    string owner;
    string location;
    int numberOfRooms;
    vector<Room> roomsInHouse;
    public:
    House();
    House(string, string, int);
    ~House();
    friend ostream& operator<<(ostream&, const House&);
    
};




#endif