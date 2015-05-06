/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaclient;

import java.util.logging.Level;
import java.util.logging.Logger;
import logic.Comunication;

/**
 *
 * @author Lesmed®
 */
public class JavaClient {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        
        
        System.out.println("Hola me estoy ejecutando");
        
        readProperties rp = new readProperties();
        rp.setPropertie("host", "127.0.0.1");
        rp.setPropertie("port", "13000");
        
        
        
        String host = rp.getPropertie("host");
        int port = Integer.parseInt(rp.getPropertie("port"));
        
        Comunication comunication = new Comunication();
        try {
            comunication.producir(host, port);
        } catch (Exception ex) {
            Logger.getLogger(JavaClient.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        
    }
    
}
