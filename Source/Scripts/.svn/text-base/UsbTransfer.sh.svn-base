#! /bin/bash

EXECUTABLE='/usr/bin/totem'
SCHEDULE_FOLDER='./ScheduleFiles'
PLAY_FOLDER='./PlayFiles'
RECORD_FOLDER='./RecordedFiles'
BACKUP_FOLDER='./BackupFiles'
RECORD_FOLDER='./RecordedFiles'
LOG_FILE='/var/hoot/hoot.log'
SIGNAL_SUCCESS='./SystemSounds/success.wav'
SIGNAL_FAIL='./SystemSounds/fail.wav'

usb_folder=`awk '/sdb/ {print $2}' /etc/mtab`

echo "System booted at " $(date) >> $LOG_FILE

if [ -z "$usb_folder" ]; then
    echo "   No USB device detected" >> $LOG_FILE
    echo "   Starting appliaction"  >> $LOG_FILE
    $EXECUTABLE &
    exit 0
	
else
    echo "   USB device found attempting to transfer zip file" >> $LOG_FILE
    mkdir /tmp/rascal
    unzip -d /tmp/rascal $usb_folder/test.zip
    if [ $? == 0 ]; then
	rm -f $SCHEDULE_FOLDER/*.xml
	rm -f $PLAY_FOLDER/*.wav
	chown rascal:rascal /tmp/rascal
	cp /tmp/rascal/*.xml $SCHEDULE_FOLDER
	cp /tmp/rascal/*.wav $PLAY_FOLDER
	echo "      File transfered successfully to computer" >> $LOG_FILE
	find $RECORD_FOLDER/*.wav >> /dev/null

	if [ $? == 0 ]; then
		echo "         Tranfering files" >> $LOG_FILE
		cp $RECORD_FOLDER/*.wav $BACKUP_FOLDER
		mv $RECORD_FOLDER/*.wav $usb_folder
        	echo "         Recordings backed up and transfered successfully" >> $LOG_FILE
	else
		echo "         No files to transfer" >> $LOG_FILE
	fi

	rm -rf /tmp/rascal
	aplay $SIGNAL_SUCCESS
	$EXECUTABLE &
	exit 0
    else
	echo "   Unable to transfer file from USB"  >> $LOG_FILE
	aplay $SIGNAL_FAIL
	exit 1
    fi

fi
