#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <time.h>


#include "event.h"
#include "AudioLib/audiolib.h"
#include "logger.h"

using namespace std;

//Constructor
//Parameters: type - Play or record.
//		dateTimeStart - Date and time the event should start.
//		duration - The length of time the event should run.
//		audioFile - The name of the file that should be played.  Null if recording.
Event::Event()
{
	_type = "";
	_dateTimeStart = "";
	_duration = 0;
	_audioFile = "";

	_playFileDir = "../var/";
	_recordFileDir = "../var/recordings/";

	_recordFileType = ".wav";

	string test = "2010-03-18 00:49:22";
	test = replace_all(":", "_", test);
	test = replace_all(" ", "_", test);
}


//Deconstructor
Event::~Event(){}

//Getters
string Event::getType(){return _type;}
string Event::getDateTimeStart(){return _dateTimeStart;}
int Event::getDuration(){return _duration;}
string Event::getAudioFile(){return _audioFile;}

//Setter
void Event::setEvent(string type, string dateTimeStart, int duration, string audioFile)
{
	cout << "Event::setEvent(type='"<< type <<"', dateTimeStart='"<< dateTimeStart <<"', duration="<< duration <<", audioFile='"<< audioFile <<"')" << endl;
	_type = type;
	_dateTimeStart = dateTimeStart;
	_duration = duration;
	_audioFile = audioFile;
}

long int Event::timeUntilProcess()
{
	//cout << "Event::timeUntilProcess()" << endl;

	time_t current_timestamp; //timestamp will hold the timestamp of when the event starts.

	long int dateTimeStart = getStartTime();

	current_timestamp = time(NULL);
	

	cout << "current_timestamp =" << current_timestamp  << endl;
	//cout << "dateTimeStart =" << dateTimeStart  << endl;

//cout << "(dateTimeStart - current_timestamp) =" << (dateTimeStart - current_timestamp)  << endl;

	return (dateTimeStart - current_timestamp);
	//return 0;
}

long int Event::getStartTime()
{
	//cout << "Event::getStartTime()" << endl;

	struct tm temp_time; //strptime requires this type of variable
	time_t timestamp = NULL;
	temp_time.tm_isdst = -1; //this may be VERY PROBLEMATIC in the future.

	string timeFormat = "%Y-%m-%d %H:%M:%S";

	cout << "_dateTimeStart = '" << _dateTimeStart << "'" << endl;
	
	//FORMAT: >2010-02-13 18:52:20
	if(strptime(_dateTimeStart.c_str(), timeFormat.c_str(), &temp_time) == NULL)
          return -1;

	timestamp = mktime(&temp_time);

	  cout << "--Event::getStartTime()-- timestamp = '"<< timestamp <<"'" << endl;
	
	return timestamp;
}
bool Event::process()
{
	cout << "Event::process()"<< endl;
	
	Logger log;
	
	string temp = "";

	if(_type == "play")
	{
		
		temp = _playFileDir + _audioFile;
		
		log.write_log(LOG_INFO, "Processing Play event using file '"+temp+"'");
		
		playAudio((char *)temp.c_str(), _duration);
	}	
	else if(_type == "record")
	{
		//Have to remove all unwanted spaces and colons.
		temp = replace_all(":", "_", _dateTimeStart);
		temp = _recordFileDir + replace_all(" ", "_", temp) + _recordFileType;
		
		log.write_log(LOG_INFO, "Processing Record event using file '"+temp+"'");
		
		cout << "Event::process() -- recording '"<< temp <<"' for "<< _duration <<" seconds"<< endl;

		recordAudio((char *)temp.c_str(), _duration);
	}

	return true;
}

string Event::replace_all(string needle, string replacement,string haystack)
{
    int pos ;
	string returnString = "";
    do
    {
        pos = haystack.find(needle);
        if (pos!=-1)  haystack.replace(pos, needle.length(), replacement);
    }
    while (pos!=-1);
    return haystack;
}

