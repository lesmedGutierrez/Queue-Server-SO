/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package rabbitmq;

import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.Channel;
import java.io.File;
import com.google.gson.Gson;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author LAB SIRZEE
 */
public class Producer extends Thread{
    private final static String QUEUE_NAME = "RabbitMQ_Java";
    private int num;
    private int id;

    public Producer(int num,int id) {
        this.num = num;
        this.id = id;
    }
    
    public void run(){
        try {
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");
            
            Connection connection = factory.newConnection();
            Channel channel = connection.createChannel();
            
            channel.queueDeclare(QUEUE_NAME, false, false, false, null);
            
            for (int i = 0; i < num; i++)
            {
                Mensaje persona = new Mensaje("RabbitMQ_Java","Persona"+i,"ID"+i);
                Gson gson = new Gson();
                String message = gson.toJson(persona);
                
                channel.basicPublish("", QUEUE_NAME, null, message.getBytes());
                System.out.println(" ["+id+"] Sent '" + message + "'");
            }
            
            channel.close();
            connection.close();
        } catch (IOException ex) {
            Logger.getLogger(Producer.class.getName()).log(Level.SEVERE, null, ex);
        }
    }  
}
