#include <iostream>
#include <stdio.h>
#include <pthread.h> //need sleep()... THE FUNCTION...

#include "event.h"
#include "event_list.h"
#include "power.h"
#include "logger.h"
#include "error_output.h"
using namespace std;

const int STAY_ON = 500;
const bool EXIT_ON_SHUTDOWN = true;

int main()
{
	Event_List eventList;
	Power power;
	Event * e = NULL;
	long int temp_time;
	Logger log;
	log.write_log(LOG_INFO, "Hoot initialized.");
	
	bool continueLooping = true;
	while (continueLooping)
	{
		e = NULL;
		if (eventList.noFutureEvents())
		{
			cout << "main() -- No future events found. Shutting down..." << endl;
			power.shutdown();
			if(EXIT_ON_SHUTDOWN) return 2;
		}
		e = eventList.getNextEvent(); //remember: class pointers use '->' instead of '.' to access functions.

		if(e == NULL)
		{
			cout << "main() -- ERROR! No event was returned." << endl;
			
			outputError("No events found (Event::getNextEvent() returned null), and system did not shut down.");
			
			return -1;
		}
		cout << "main() -- 1111111111111111111111111111111111111" << endl;
		if (e->timeUntilProcess() > STAY_ON)
		{
			cout << "main() -- Time until process ("<< e->timeUntilProcess() <<")is greater than the stay on time. Sleeping..." << endl;

			temp_time = e->getStartTime() - STAY_ON;
			power.scheduleReboot(temp_time);
			if(EXIT_ON_SHUTDOWN) return 1;
		}
		cout << "main() -- LOCKING UNTIL PROCESS..." << endl;
		//continue;
		temp_time = e->timeUntilProcess();
		while (temp_time > 0)
		{
			cout << "main() --  e->timeUntilProcess() = " << temp_time << endl;
			sleep(1); //Sleep for one second
			temp_time = e->timeUntilProcess();
		}
		cout << "main() -- PROCESSING..." << endl;
		e->process();

		
	}
	return 0;
}
