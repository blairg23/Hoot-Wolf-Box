/* 
 * File:   main.cpp
 * Author: jesse
 *
 * Created on February 22, 2010, 12:37 AM
 */

#include <stdlib.h>
#include "audiolib.h"

/*
 * 
 */
int main(int argc, char** argv) {
    playAudio("15 You Rock My World (Radio Edit).wav", 20);
    recordAudio("test2.wav", 5);
    return (EXIT_SUCCESS);
}

