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
public class IronTest {
    
    
    
    
    public static void main(String[] args){
        String project = "5505e6df2d0412000600001c";
        String token = "D4YXJjgT6sldvBcpOvwcCuybmuY";
        
        Client client = new Client(project, token, Cloud.ironAWSUSEast);
        Queue queue = client.queue("test-queue");

        try {
            for (int i = 0; i < 10; i++) {
                // Put a message on the queue
                queue.push("Hello, world!"); // Get a message
                Message msg = queue.get();

                // Delete the message
                queue.deleteMessage(msg);
                
            }
            
        } catch (IOException ex) {
            Logger.getLogger(IronTest.class.getName()).log(Level.SEVERE, null, ex);
        }

       

        
        
        
    }
    
}

