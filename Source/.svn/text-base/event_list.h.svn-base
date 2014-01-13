#ifndef EVENT_LIST_H
#define EVENT_LIST_H
#include <iostream>
#include <stdio.h>
#include <string>
#include <list>

using namespace std;

class Event;

class Event_List
{
	private:
		list<Event> eventList;
		list<Event>::iterator eventPointer;

	public:
		Event_List();
		~Event_List();
		Event * getNextEvent();
		Event * getNextEvent(int time);
		bool noFutureEvents();
		//bool process();
};

#endif

