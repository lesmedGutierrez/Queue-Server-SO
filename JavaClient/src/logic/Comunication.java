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
        BufferedReader inFromServer = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
        //sentence = inFromUser.readLine();
        outToServer.writeBytes(sentence + '\n');
        //modifiedSentence = inFromServer.readLine();
        //System.out.println("FROM SERVER: " + modifiedSentence);
        clientSocket.close();
    }
    
    public String convertTOJson(){
        
        
        
        
        return "";
    }
}
    

