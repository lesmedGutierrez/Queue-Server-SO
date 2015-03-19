package IronMQ;


import io.iron.ironmq.Client;
import io.iron.ironmq.Cloud;
import io.iron.ironmq.Message;
import io.iron.ironmq.Queue;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Lesmed
 */
public class IronMQConn {
    
  
    
    
    //public void main(String[] args){
    public void producir(int ciclos){
        String project = "5505e6df2d0412000600001c";
        String token = "D4YXJjgT6sldvBcpOcCuybmuY";
        
        Client client = new Client(project, token, Cloud.ironAWSUSEast);
        Queue queue = client.queue("test-queue-lesmed");

        try {
            for (int i = 0; i < ciclos; i++) {
                // Put a message on the queue
                queue.push("Hello, world!"); // Get a message
                Message msg = queue.get();

                // Delete the message
                queue.deleteMessage(msg);
                
            }
            
        } catch (IOException ex) {
            Logger.getLogger(IronMQConn.class.getName()).log(Level.SEVERE, null, ex);
            System.out.println("Hubo error 1");
        }
        //sqlserver.conectar();

       

        
        
        
    }
    
}

