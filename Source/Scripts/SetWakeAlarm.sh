#! /bin/bash

###########################################################################
#
#  This script sets the next wake alarm time for the system.
#
##########################################################################

LOG_FILE="/var/rascal/hoot.log"

# $1 is the Unix time passed in as a string

echo 0 > /sys/class/rtc/rtc0/wakealarm  #clears current wake settings
echo $1 > /sys/class/rtc/rtc0/wakealarm #enters the new wake time

echo "#######################################################################" >> $LOG_FILE
echo " " >> $LOG_FILE
echo "SetWakeAlarm.sh was accessed at: " >> $LOG_FILE
date >> $LOG_FILE
echo "Next wake time is: " >> $LOG_FILE
date -d @"$1" >> $LOG_FILE
echo "Current rtc settings: " >> $LOG_FILE
cat /proc/driver/rtc >> $LOG_FILE

echo "System shutting down" >> $LOG_FILE
echo " " >> $LOG_FILE
shutdown -h now
