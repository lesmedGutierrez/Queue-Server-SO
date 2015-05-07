/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaclient;


import logic.MyMQ;

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
        
        rp.setPropertie("host", "172.24.28.147");
        rp.setPropertie("port", "13000");
        
        
        
        String host = rp.getPropertie("host");
        int port = Integer.parseInt(rp.getPropertie("port"));
        
        MyMQ mymq = new MyMQ(host, port);
        int ciclos =12;
        
        mymq.Producir(ciclos);
        
        
    }
    
}
