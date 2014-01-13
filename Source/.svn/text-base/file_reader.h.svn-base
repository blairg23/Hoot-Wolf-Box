#ifndef FILE_READER_H
#define FILE_READER_H

#include <libxml++-2.6/libxml++/libxml++.h> //apt-get install libxml++2.6-dev
#include <iostream>
#include <stdio.h>
#include <string>
#include <list>

#include "event.h"



using namespace std;

//----------------------------------------------------------------
//Parses the schedule xml file and stores the Events in a list.
//----------------------------------------------------------------
class File_Reader
{
  private: 
	list<Event> _list;
	string _filePath;

  public: 
	File_Reader(string filePath);
  	~File_Reader();
	list<Event> getEventList();

  private: 
	void parseXml(string file);
  	string getNodeText(xmlpp::Node * node);
};

//Compare two events.
//Returns true if first event start time < second event start time, else returns false
struct CompareEvents
{
  bool operator()(Event event1, Event event2)
  {
    //string x = event1.getDateTimeStart();
    if(event1.getDateTimeStart() < event2.getDateTimeStart())
    {
      return true;
    }
    return false;
  }
};

#endif
