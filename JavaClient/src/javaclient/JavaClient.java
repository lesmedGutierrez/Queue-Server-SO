/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaclient;


import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import logic.MyMQ;

/**
 *
 * @author Lesmed®
 */
public class JavaClient {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        
        while (true){
            System.out.println("Producir: P / Recibir: R");
            String opcion;
            BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));
	    opcion = bufferRead.readLine();
 
            if (opcion.equalsIgnoreCase("s")){
                return;
            }
            System.out.println("Cantidad de ciclos: ");
            int ciclos;
            ciclos = Integer.parseInt(bufferRead.readLine());
            //scanIn.close();

            //System.out.println("Hola me estoy ejecutando");
            readProperties rp = new readProperties();

//                    rp.setPropertie("host", "127.0.0.1");
//                    rp.setPropertie("port", "13000");
//                    rp.setPropertie("ciclos", "12");
//                    rp.setPropertie("DB_Server", "127.0.0.1");
            String DB_server = rp.getPropertie("DB_Server");

            String host = rp.getPropertie("host");
            int port = Integer.parseInt(rp.getPropertie("port"));
            //ciclos = Integer.parseInt(rp.getPropertie("ciclos"));


            System.out.println("port {0}" + port);
            System.out.println("host" + host);

            MyMQ mymq = new MyMQ(host, port);
            opcion = opcion.toLowerCase();
            if (opcion.equals("p")){
                mymq.Producir(ciclos);
            }        
            else if (opcion.equals("r")){
                mymq.recibir(ciclos, DB_server);
            }
        }
    }
    
    
    public void readProp(){
        
    }
    
    
}
