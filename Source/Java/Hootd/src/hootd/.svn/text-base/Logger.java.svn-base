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
public class Logger {

    public static void log(String strMessage) {
        try {
            BufferedWriter writer = new BufferedWriter(new FileWriter("log.txt", true));
            writer.write("\n---" + Calendar.getInstance().getTime() + "---\n" + strMessage + "\n");
            writer.close();
            //Console output during debugging
            System.out.println("\n---" + Calendar.getInstance().getTime() + "---\n" + strMessage);
        } catch (Exception e) {
            System.out.println("--Failed to write message to log--\n"+ e.getMessage() + "\n" + strMessage);
        }
    }

    public static void debug(String strMessage) {
        try {
            BufferedWriter writer = new BufferedWriter(new FileWriter("debug.txt", true));
            writer.write("\n---" + Calendar.getInstance().getTime() + "---\n" + strMessage + "\n");
            writer.close();
        } catch (Exception e) {
            System.out.println("--Failed to write message to log--\n" + e.getMessage() + "\n" + strMessage);
        }
    }
}
