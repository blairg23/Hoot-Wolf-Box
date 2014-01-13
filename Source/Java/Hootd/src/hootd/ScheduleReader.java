/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package hootd;

import java.io.*;
import java.util.*;
import java.text.SimpleDateFormat;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;
import org.w3c.dom.*;

/**
 *
 * @author jesse
 */
public class ScheduleReader {

    private static String DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private static String SCHEDULE_XML_FILE = "schedule.xml";

    //Load events from the specified file
    public static ArrayList loadEvents(String filename) {
        SCHEDULE_XML_FILE = filename;
        return loadEvents();
    }

    //Read in XML list of events to Event object. Store in ArrayList
    public static ArrayList loadEvents() {
        ArrayList events = new ArrayList();

        File importedFile = new File(SCHEDULE_XML_FILE);

        try {
            //open the XML file and parse it
            DocumentBuilderFactory docBuilderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder docBuilder = docBuilderFactory.newDocumentBuilder();
            Document doc = docBuilder.parse(importedFile);
            // normalize text representation
            doc.getDocumentElement().normalize();
            // grab a list of all ScheduledEvent tags from the XML doc
            NodeList nodeList = doc.getElementsByTagName("ScheduledEvent");

            // loop through all ScheduledEvent tags
            for (int s = 0; s < nodeList.getLength(); s++) {

                //Create derived Event types.
                Event playEvent = new PlayEvent();
                Event recordEvent = new RecordEvent();
                //Get the items from this ScheduledEvent to convert to values below
                Node fstNode = nodeList.item(s);

                //Setup a Play event
                //Try to parse each field to a valid value. Set the value in the event
                //If any field fails to parse, ignore it and move on.
                try {
                    String startPlay = getXMLElement("StartPlay", fstNode);
                    String playDuration = getXMLElement("PlayDuration", fstNode);
                    String audioFile = getXMLElement("AudioFile", fstNode);
                    playEvent.setStartDateTime(parseTimestamp(startPlay, DATE_FORMAT));
                    playEvent.setAudioFile(audioFile);
                    playEvent.setDuration(Integer.parseInt(playDuration));

                } catch (Exception e) {
                    Logger.debug("Error parsing play event values: " + e.getMessage());
                }
                //Setup a Record event
                //Try to parse each field to a valid value. Set the value in the event
                //If any field fails to parse, ignore it and move on.
                try {
                    String startRecord = getXMLElement("StartRecord", fstNode);
                    String recordDuration = getXMLElement("RecordDuration", fstNode);
                    recordEvent.setDuration(Integer.parseInt(recordDuration));
                    recordEvent.setStartDateTime(parseTimestamp(startRecord, DATE_FORMAT));
                } catch (Exception e) {
                    Logger.debug("Error parsing record event values: " + e.getMessage());
                }

                //if the Play event has a start date/time
                if (playEvent.startDateTime != null) {
                    //and the event is not expired
                    if (!playEvent.isExpired()) {
                        Logger.log("Play event added to schedule:\n" + playEvent.printEvent());
                        //add the event
                        events.add(playEvent);
                    } else {
                        Logger.log("Expired play event not added to schedule:\n" + playEvent.printEvent());
                    }
                }

                //if the Record event has a start date/time
                if (recordEvent.startDateTime != null) {
                    if (!recordEvent.isExpired()) {
                        Logger.log("Record event added to schedule:\n" + recordEvent.printEvent());
                        events.add(recordEvent);
                    } else {
                        Logger.log("Expired record event not added to schedule:\n" + recordEvent.printEvent());
                    }
                }
            }
        } catch (Exception e) {
            Logger.log(e.getMessage());
        }
        return events;
    }

    /* Parses a string representation of a Calendar date
     * @params timestamp the string representation of a date
     * @params format the string representation of the date format
     */
    private static Calendar parseTimestamp(String timestamp, String format) throws Exception {
        /*
         ** we specify Locale.US since months are in english
         */
        SimpleDateFormat sdf = new SimpleDateFormat(format, Locale.US);
        Date d = sdf.parse(timestamp);
        Calendar cal = Calendar.getInstance();
        cal.setTime(d);
        return cal;
    }

    /* Gets an XML element from a Node
     * @params elementToSearchFor is the XML element you want to find
     * @params fstNode
     */
    private static String getXMLElement(String elementToSearchFor, Node node) {
        String returnValue = "";
        try {
            if (node.getNodeType() == Node.ELEMENT_NODE) {
                Element firstElement = (Element) node;
                NodeList elementList = firstElement.getElementsByTagName(elementToSearchFor);
                Element element = (Element) elementList.item(0);
                NodeList nodeList = element.getChildNodes();
                try {
                    returnValue = ((Node) nodeList.item(0)).getNodeValue();
                } catch (Exception exception) {
                    Logger.debug("Conversion failed for XML element [" + elementToSearchFor + "] value = " + exception.getMessage());
                }
            }
        } catch (Exception exception) {
            Logger.log(exception.getMessage());
        }
        return returnValue;
    }
}
