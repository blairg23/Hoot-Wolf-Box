#include <iostream>
#include <stdio.h>
#include <string>
#include <list>

#include "file_reader.h"
#include "event_list.h"
#include "event.h"

using namespace std;


Event_List::Event_List()
{
	
	File_Reader read("../var/schedule.xml");
 	eventList = read.getEventList();
	eventPointer = eventList.begin();

}

//Deconstructor
Event_List::~Event_List(){}

Event * Event_List::getNextEvent() 
{
	cout << "Event_List::getNextEvent() " << endl;

	if(eventList.empty() || eventPointer == eventList.end())
		return NULL;

	Event * e = &(*eventPointer);

	++eventPointer;


	return e;
}

Event * Event_List::getNextEvent(int time) 
{
	cout << "Event_List::getNextEvent(time="<< time <<")" << endl;
	return NULL;
}

bool Event_List::noFutureEvents()
{
	cout << "Event_List::noFutureEvents() " << endl;
	if(eventPointer == eventList.end() || eventList.empty())
		return true;

	return false;
}
