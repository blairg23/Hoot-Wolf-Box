// writing on a text file

//FROM http://www.cplusplus.com/doc/tutorial/files/
#include <iostream>
#include <fstream>
#include <time.h>

#include "logger.h"

using namespace std;

Logger::Logger()
{
	logFile.open("../var/logs/hoot.log", ios::app);
}

Logger::~Logger()
{
	logFile.close();
}

/**
* @param string Level of Log entry. This can be LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR
* @param string Message to write to the log.
*/

bool Logger::write_log(string level, string message)
{
    time_t rawtime;
    struct tm* timeinfo;
    if (logFile.is_open())
    {
	    time( &rawtime );
	    timeinfo = localtime(&rawtime);

	    logFile << level << ": " << asctime(timeinfo)  << " - " << message << "\n";
    }
    else
    {
	cout << "WARNING! LOG FILE COULD NOT BE OPENED FOR WRITING!" << endl;
	return false;
    }
    return true;
}

/*
int main()
{
	Logger fr;

	fr.write_log("TEST", "123");
	fr.write_log("TEST2", "BLAM");
	return 0;
} */
