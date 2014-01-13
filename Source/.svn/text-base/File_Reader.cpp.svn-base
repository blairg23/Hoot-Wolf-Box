#ifdef HAVE_CONFIG_H
#include <config.h>
#endif

#include <libxml++-2.6/libxml++/libxml++.h> //apt-get install libxml++2.6-dev

#include <iostream>
#include <string>
#include <stdlib.h> 
#include <list>
#include <time.h>

#include "file_reader.h"
#include "event.h"

using namespace std;

//----------------------------------------------------------------
//Parses the schedule xml file and stores the Events in a list.
//----------------------------------------------------------------

  //Constructor
  //Parameters: String path to xml file.
  File_Reader::File_Reader(string filePath)
  {
    _filePath = filePath;
    parseXml(_filePath);
  }

  //Deconstructor
  File_Reader::~File_Reader(){}

  //Get event list
  list<Event> File_Reader::getEventList(){return _list;}

  //Parses the schedule file.
  //Parameters: String path to xml file.
  //Returns: List of Event objects.
  void File_Reader::parseXml(string file)
  {
	cout << "File_Reader::parseXml(file='"<< file <<"')" << endl;
    try
    {
      xmlpp::DomParser parser;
      parser.parse_file(file);  //Parse file.
      if(parser)
      {
	//Get system time
	time_t rawtime;
	struct tm * timeinfo;
	char buffer [50];
	time ( &rawtime );
	timeinfo = localtime ( &rawtime );
	strftime (buffer,50,"%Y-%m-%d %X",timeinfo);
	string currentDateTime = buffer;

	const xmlpp::Node* xml = parser.get_document()->get_root_node();
	xmlpp::NodeSet eventList = xml->find("/EventsList/ScheduledEvent");  //Get all Scheduled Events.

	for(xmlpp::NodeSet::iterator i = eventList.begin(); i != eventList.end(); ++i)
	{
	  //Get children for Scheduled Events.
	  xmlpp::Node::NodeList event = dynamic_cast<const xmlpp::Node*>(*i)->get_children();

	  //Initialize event variables
	  string startPlay;
	  string audioFile;
	  int playDuration;
	  string startRecord;
	  int recordDuration;
	
	  for(xmlpp::Node::NodeList::iterator j = event.begin(); j != event.end(); ++j)
	  {
	    xmlpp::Node* item = *j;
	    
	    //Set event variables
	    if(item->get_name()=="StartPlay")
	    {
	      startPlay = getNodeText(item);
	    }
	    else if(item->get_name()=="AudioFile")
	    {
	      audioFile = getNodeText(item);
	    }
	    else if(item->get_name()=="PlayDuration")
	    {
	      string temp = getNodeText(item);
	      playDuration = atoi(temp.c_str());//Convert string to int
	    }
	    else if(item->get_name()=="StartRecord")
	    {
	      startRecord = getNodeText(item);
	    }
	    else if(item->get_name()=="RecordDuration")
	    {
	      string temp = getNodeText(item);
	      recordDuration = atoi(temp.c_str());//Convert string to int
	    }
	  }
	  cout << "startPlay: "<< startPlay << endl;
	  cout << "startRecord: "<< startRecord << endl;
	  cout << "currentDateTime: "<< currentDateTime << endl;
	  //Create event and add to event list.
	  if(startPlay != "" && startPlay > currentDateTime)
	  {
	    Event playEvent;
	    playEvent.setEvent("play", startPlay, playDuration, audioFile);
	    _list.push_front(playEvent);
	  }
	  if(startRecord != "" && startRecord > currentDateTime)
	  {
	    Event recordEvent;
	    recordEvent.setEvent("record", startRecord, recordDuration, "");
	    _list.push_front(recordEvent);
	  }
	}
	//Sort event list
	_list.sort(CompareEvents());
      }	
    }
    catch(const exception& e)
    {
      cout << "Exception caught: " << e.what() << endl;
    }
  }

  //Get the content from a NodeText object.
  //Parameter: Node that contains content in its child Nodes.
  //Returns: String of NodeText.
  string File_Reader::getNodeText(xmlpp::Node* node)
  {
    xmlpp::Node::NodeList child = dynamic_cast<const xmlpp::Node*>(node)->get_children();

    //Check to see if Node has children.
    if(child.size() > 0)
    {
      //Get children
      for(xmlpp::Node::NodeList::iterator i = child.begin(); i != child.end(); ++i)
      {
        const xmlpp::TextNode* nodeText = dynamic_cast<const xmlpp::TextNode*>(*i);
	    
        string content = "";

	//Set content
        if(nodeText)
        {
	  content = nodeText->get_content();
        }
        return content;
      }
    }

    return "";
  }



/*
int main()
{
  FileReader read("test.xml");
  list<Event> eventList = read.getEventList();

  for(list<Event>::iterator i = eventList.begin(); i != eventList.end(); ++i)
  {
    string startTime = (*i).getDateTimeStart();
    cout<<startTime<<endl;
  }

  return 0;
}*/
