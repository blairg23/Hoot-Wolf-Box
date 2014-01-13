#include <iostream>
#include <stdio.h>
#include <string>

#include "error_output.h"
#include "logger.h"
#include "AudioLib/audiolib.h"

using namespace std;

/**
* @param string Message to write to log.
* @param string Audio filename, without path, to play to speakers. Can be "". If "", then only the log is written and no file is played.
*/
void outputError(string message, string audioFile)
{
    Logger log;
    
    log.write_log(LOG_ERROR, message);
    
    if(!audioFile.empty() && audioFile != "") playAudio((char *)audioFile.c_str(), 0);
}


void outputError(string message)
{
    outputError(message, "");
}