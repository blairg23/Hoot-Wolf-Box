/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package hootd;

import java.util.*;
import de.schlichtherle.io.File;

/**
 *
 * @author jesse
 */
public class Hootd {

    /**	Flag for debugging messages.
     *	If true, some messages are dumped to the console
     *	during operation.
     */
    private static Timer eventsTimer;
    private static ArrayList events;
    private static Integer sleepWindowInMinutes = 10;
    public static String ZIP_FILE;

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        try {
            ZIP_FILE = args[1];
        } catch (Exception e) {
            ZIP_FILE = "schedule.zip";
            Logger.log("No schedule file name specified. Using " + ZIP_FILE);
        }

        Logger.log("Hootd starting up");

        //Uncompress files to current directory
        Logger.log("Unzipping files...");
        ZipTools.unzipFile(ZIP_FILE, ".");
        Logger.log("Unzip complete");

        // Create a new Timer to hold scheduled events
        eventsTimer = new Timer();

        // You can call loadEvents() and scheduleEvents() anytime you want to 
        // update the schedule

        // Load events from the XML file.
        events = ScheduleReader.loadEvents();
        // Add an ArrayList of Events to the current Timer.
        scheduleEvents(eventsTimer, events);

        // Decide if the system should sleep depending on the next upcoming event's start time
        sleepIfNeeded();

    }

    /*
     * @param timer The Timer object to spool events into
     * @param events The ArrayList of events to schedule into the timer
     */
    private static void scheduleEvents(Timer timer, ArrayList events) {
        //Loop through all events in the list
        for (int i = 0; i < events.size(); i++) {
            //Grab an event
            final Event eventToSchedule = (Event) events.get(i);
            //If the event is not expired
            if (!eventToSchedule.isExpired()) {
                //Create a TimerTask to process the event
                Logger.log("Event[" + i + "] scheduled for " + eventToSchedule.getStartDateTime().getTime());
                TimerTask event = new TimerTask() {

                    public void run() {
                        eventToSchedule.process();
                        removeEvent(eventToSchedule);
                        sleepIfNeeded();
                    }
                };
                //schedule the event
                timer.schedule(event, eventToSchedule.getStartDateTime().getTime());
            }
        }
    }

    /*
     * @param event An event to remove from the list
     */
    public static void removeEvent(Event event) {
        events.remove(event);
    }

    /*
     * Finds and returns the next earliest event in the list
     */
    public static Event nextEarliestEvent() {
        // If there are events in the list
        if (events.size() > 0) {
            // Grab the first event we find
            Event nextEarliestEvent = (Event) events.get(0);
            // look through all the other events
            for (int i = 1; i < events.size(); i++) {
                Event event = (Event) events.get(i);
                // if this event occurs before the earliest event we found, hang on to it
                if (event.occursBefore(nextEarliestEvent)) {
                    nextEarliestEvent = event;
                }
            }
            Logger.log("Next earliest event:\n" + nextEarliestEvent.printEvent());
            return nextEarliestEvent;
        } else {
            return null;
        }
    }

    /*
     * Method to decide when to sleep the machine
     */
    public static void sleepIfNeeded() {
        //Find the next upcoming event
        Event nextEvent = nextEarliestEvent();
        //If no upcoming events, let Sleeper sleep the machine
        if (nextEvent == null) {
            Logger.log("No upcoming events scheduled. Deep sleep (hibernation) recommended");
            //Fully hibernate the box
            Sleeper.deepSleep();
            return;
        }
        //Grab the current time by getting a new Calendar object
        Calendar sleepDelay = Calendar.getInstance();
        //Pad the calendar object out the specified number of minutes @param sleepWindowInMinutes
        sleepDelay.add(Calendar.MINUTE, sleepWindowInMinutes);
        //if the next event isn't scheduled for more than 10 minutes, sleep.
        if (!nextEvent.occursBefore(sleepDelay)) {
            Logger.log("Next event occurs greater than " + sleepWindowInMinutes + " minutes. Sleep recommended");
            //Sleep until the specified time
            Sleeper.sleepUntil(nextEvent.startDateTime);
        } else {
            Logger.log("Next event occurs within " + sleepWindowInMinutes + " minutes. Sleep not recommended");
        }
    }
}
