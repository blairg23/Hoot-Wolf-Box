#ifndef LOGGER_H
#define LOGGER_H

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
using namespace std;

#define LOG_DEBUG "DEBUG"
#define LOG_INFO "INFO"
#define LOG_WARNING "WARNING"
#define LOG_ERROR "ERROR"

class Logger 
{
    private:
	ofstream logFile;

    public:
	Logger();
	~Logger();
	bool write_log(string level, string message);
};

#endif
