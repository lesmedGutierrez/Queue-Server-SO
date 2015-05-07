/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logic;

import com.google.gson.Gson;
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
//                catch (ArgumentNullException e)
//                {
//                    Console.WriteLine("ArgumentNullException: {0}", e);
//                }
//                catch (SocketException e)
//                {
//                    Console.WriteLine("SocketException: {0}", e);
//                }
//
//                Console.WriteLine("\n Press Enter to continue...");
//                Console.Read();

            }
        }
    
    
    
    
    
}
