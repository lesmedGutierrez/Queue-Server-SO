/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logic;

import com.google.gson.Gson;
import com.google.gson.stream.JsonReader;
import java.io.IOException;
import java.io.StringReader;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Lesmed®
 */
public class MyMQ {
    
    public String host;
    public int port;
    public Comunication communication = new Comunication();

    public MyMQ(String host, int port) {
        this.host = host;
        this.port = port;
    }
    public void Producir(int ciclos )
    {
        for (int i = 0; i < ciclos; i++)
        {
             try
            {
                DefaultMensaje msg = new DefaultMensaje("MyMQ_JavaProducer", "Persona " + i, "ID" + i);
                Gson gson = new Gson();

                String jsonified = gson.toJson(msg);                  

                communication.send(host, port, jsonified);
                //var data = Encoding.UTF8.GetBytes(jsonified);

                //Console.WriteLine("Sent: {0} ,{1}", jsonified ,i);

            } catch (Exception ex) {
                Logger.getLogger(MyMQ.class.getName()).log(Level.SEVERE, null, ex);
            }

        }
    }
    
    public void recibir(int ciclos, String DB_server){
        
        String recieve;
        
        long currentTimeMillis = System.currentTimeMillis();
        
        
        for (int i = 0; i < ciclos; i++) {
            try {
                recieve = communication.recieve(host, port, "1");
                
                
                Gson gson = new Gson();
                DefaultMensaje def_msg;
                String ced="";
                
                //recieve = recieve.replace('\0','0');
                System.out.println(" string recibido :" + recieve);
                JsonReader reader = new JsonReader(new StringReader(recieve));
                reader.setLenient(true);
                    def_msg = gson.fromJson(reader, DefaultMensaje.class);
                    ced = def_msg.Cedula;
                insert(def_msg,DB_server);
                               
                                
            } catch (IOException ex) {
                Logger.getLogger(MyMQ.class.getName()).log(Level.SEVERE, null, ex);
            }
            
        }
        long currentTimeMillisFin = System.currentTimeMillis();
        
        
        System.out.println(" Tiempo Final: "   + (currentTimeMillisFin  - currentTimeMillis) + " milisegundos");
        
       
    }
    public void insert(DefaultMensaje def_msj, String DB_Server)
    {
        
        
        def_msj.insertMensaje(DB_Server);
            
    } 
        
        
        
        
    
    
    
    
    
    
}
