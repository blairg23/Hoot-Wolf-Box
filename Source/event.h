#ifndef EVENT_H
#define EVENT_H
#include <iostream>
#include <stdio.h>
#include <string>
using namespace std;


class Event
{

	private:
		string _type;
		string _dateTimeStart;
		int _duration;
		string _audioFile;
		string _playFileDir;
		string _recordFileDir;
		string _recordFileType;
		string replace_all(string needle, string replacement,string haystack);

	public:
		Event();
		~Event();
		long int timeUntilProcess();
		long int getStartTime();
		bool process();
		string getType();
		string getDateTimeStart();
		int getDuration();
		string getAudioFile();
		void setEvent(string type, string dateTimeStart, int duration, string audioFile);
};

#endif

