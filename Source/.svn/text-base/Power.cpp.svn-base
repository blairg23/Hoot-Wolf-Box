#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <sstream> //need stringstream
#include <string>

#include "power.h"
#include "logger.h"

using namespace std;

Power::Power()
{

}

Power::~Power()
{

}

bool Power::scheduleReboot(long int time)
{
	Logger log;
	
    
	cout << "--Event::scheduleReboot("<< time <<")--" << endl;
	string temp = "./Scripts/SetWakeAlarm.sh ";
	
	stringstream convertInt;
	convertInt << time;
	temp += convertInt.str();
	
	log.write_log(LOG_INFO, "Scheduling a reboot using command '"+temp+"' ...");

	cout << "--Event::scheduleReboot():: system call string = '"<< temp <<"'" << endl;

	cout << temp << endl;

	system(temp.c_str());
	return true;
}
bool Power::shutdown()
{
	Logger log;
	
	log.write_log(LOG_WARNING, "System shutting down...");
    
	system("shutdown -h now");
	cout << "::::: Computer Will Now Shutdown :::::" << endl;
	return true;
}
