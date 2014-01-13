/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package hootd;

import java.util.*;
import java.io.*;

/**
 *
 * @author jesse
 */
public abstract class Event {

    Calendar startDateTime;
    int duration;
    File audioFile;
    Boolean isFinished;

    public Boolean isExpired() {
        if (this.occursBefore(Calendar.getInstance())) {
            return true;
        } else {
            return false;
        }

    }

    public Boolean isFinished() {
        return this.isFinished;
    }

    public void process() {
    }

    public Boolean occursBefore(Calendar calendar) {
        if (this.startDateTime.before(calendar)) {
            return true;
        } else {
            return false;
        }
    }

    public Boolean occursBefore(Event event) {
        if (this.startDateTime.before(event.startDateTime)) {
            return true;
        } else {
            return false;
        }
    }

    public Calendar getStartDateTime() {
        return startDateTime;
    }

    public void setStartDateTime(Calendar startPlayDateTime) {
        this.startDateTime = startPlayDateTime;
    }

    public void setDuration(int duration) {
        this.duration = duration;
    }

    public void setAudioFile(String name) {
        this.audioFile = new File(name);
    }

    public String printEvent() {
        String returnString = "Invalid event";
        return returnString;
    }
}
