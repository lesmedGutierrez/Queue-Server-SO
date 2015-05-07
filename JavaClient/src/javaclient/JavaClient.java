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
        System.out.println("Hola me estoy ejecutando");
        
        readProperties rp = new readProperties();
        
//        rp.setPropertie("host", "172.24.28.147");
//        rp.setPropertie("port", "13000");
//        rp.setPropertie("ciclos", "12");
        
        
        String host = rp.getPropertie("host");
        int port = Integer.parseInt(rp.getPropertie("port"));
        int ciclos = Integer.parseInt(rp.getPropertie("ciclos"));
        
        MyMQ mymq = new MyMQ(host, port);
        
        mymq.Producir(ciclos);
        
        
    }
    
}
