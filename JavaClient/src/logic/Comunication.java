/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logic;
    import java.io.*;
    import java.net.*;
    import com.google.gson.Gson;
/**
 *
 * @author Lesmed®
 */
public class Comunication {
    
    

    public void send(String host, int port, String msg) throws Exception
    {
        String sentence = msg;
        //BufferedReader inFromUser = new BufferedReader( new InputStreamReader(System.in));
        Socket clientSocket = new Socket(host, port);
        DataOutputStream outToServer = new DataOutputStream(clientSocket.getOutputStream());
        //BufferedReader inFromServer = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
        //sentence = inFromUser.readLine();
        
        
        byte[] data = sentence.getBytes("UTF-8");
        
        outToServer.write(data,0,data.length);
        //sentence = inFromServer.readLine();
        //System.out.println("FROM SERVER: " + modifiedSentence);
        
        
        outToServer.close();
        clientSocket.close();
    }
    public String recieve(String host, int port, String msg) throws IOException
    {
        String modifiedSentence;
        String sentence = msg;
        byte[] sb = {24,20,19};
        
        
        
        byte[] byt = msg.getBytes("UTF-8"); //Convert a Java String to an ASCII byte array

        //BufferedReader inFromUser = new BufferedReader( new InputStreamReader(System.in));
        Socket clientSocket = new Socket(host, port);
        
        DataOutputStream outToServer = new DataOutputStream(clientSocket.getOutputStream());
        //sentence = inFromUser.readLine();
        outToServer.write(byt,0,byt.length);
        
        byt = new byte[2048];
        
        
        DataInputStream dataIN = new DataInputStream(clientSocket.getInputStream());
        int bytes = dataIN.read(byt, 0, byt.length);
        
        modifiedSentence = new String(byt, "UTF-8");
//        InputStream clso= clientSocket.getInputStream();
//        InputStreamReader input = new InputStreamReader(clientSocket.getInputStream());
        
        //BufferedReader inFromServer = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
        
        //modifiedSentence = inFromServer.readLine();
        //System.out.println("FROM SERVER: " + modifiedSentence);
        dataIN.close();
        clientSocket.close();
        
        return modifiedSentence;     
        
        
        
    }
    

}
    

