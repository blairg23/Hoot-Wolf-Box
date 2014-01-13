/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package hootd;

import java.io.*;
import javax.sound.sampled.*;

/**
 *
 * @author jesse
 */
public class PlayEvent extends Event {

    private static final int	EXTERNAL_BUFFER_SIZE = 512;

    @Override
    public void process() {
        Logger.log("Playback triggered for " + audioFile.getName());
        playAudio();
        this.isFinished = true;
    }

    private void playAudio() {
        try {
            //Open the audio file
            File inputFile = new File(audioFile.getName());
            //Get an audio input stream from the file
            AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(inputFile);
            //Determine information about the audio format
            AudioFormat audioFormat = audioInputStream.getFormat();
            SourceDataLine line = null;
            DataLine.Info info = new DataLine.Info(SourceDataLine.class, audioFormat);
            line = (SourceDataLine) AudioSystem.getLine(info);
            //Open the line using the known audio format
            line.open(audioFormat);
            line.start();

            int nBytesRead = 0;
            int totalBytesRead = 0;

            float sampleRate = audioFormat.getSampleRate();
            float bitRate = audioFormat.getSampleSizeInBits();
            int audioChannels = audioFormat.getChannels();
            //calculate the number of bytes we should play to play audio for this.duration (seconds)
            float numberOfBytesToPlay = (sampleRate * bitRate * audioChannels * this.duration) / 8;
            //create a byte buffer to hold bytes of audio data as we read them
            byte[] abData = new byte[EXTERNAL_BUFFER_SIZE];
            
            //while we still have bytes to read and we haven't exceeded the maximum play length (numberOfBytesToPlay)
            while (nBytesRead != -1 && totalBytesRead < numberOfBytesToPlay) {
                try {
                    //Read a block of bytes off the input stream
                    nBytesRead = audioInputStream.read(abData, 0, abData.length);
                    totalBytesRead += nBytesRead;
                } catch (IOException e) {
                    e.printStackTrace();
                }
                if (nBytesRead >= 0) {
                    line.write(abData, 0, nBytesRead);
                }
            }
            //line.drain();
            line.close();

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    @Override
    public String printEvent() {
        String returnString = "";
        returnString += ("Start play:" + this.startDateTime.getTime() + "\n");
        returnString += ("File:" + this.audioFile + "\n");
        returnString += ("Play duration:" + this.duration);
        return returnString;
    }
}
