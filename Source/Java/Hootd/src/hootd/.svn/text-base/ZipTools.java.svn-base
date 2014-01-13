/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hootd;

import de.schlichtherle.io.*;



/**
 *
 * @author jesse
 */
public class ZipTools {

    public static void unzipFile(String filename, String pathToUnzipTo) {
        File directory = new File(pathToUnzipTo);
        File zipFile = new File(filename);
        zipFile.archiveCopyAllTo(directory);
    }

}
