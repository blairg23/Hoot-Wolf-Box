/* 
 * File:   aplay.h
 * Author: jesse
 *
 * Created on February 22, 2010, 1:24 AM
 */

#ifndef _APLAY_H
#define	_APLAY_H

#ifdef	__cplusplus
extern "C" {
#endif

int playAudio(char* filename, int duration);
int recordAudio(char* filename, int duration);


#ifdef	__cplusplus
}
#endif

#endif	/* _APLAY_H */

