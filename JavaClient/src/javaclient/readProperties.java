//package com.mkyong.properties;
package javaclient;

import java.io.FileOutputStream;
import java.io.OutputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
 
public class readProperties {
    Properties prop = new Properties();
    
  public void setPropertie(String name,String propertie) {
 
	
	OutputStream output = null;
 
	try {
 
		output = new FileOutputStream("config.properties");
 
		// set the properties value
		prop.setProperty(name, propertie);
		// save properties to project root folder
		prop.store(output, null);
 
	} catch (IOException io) {
		io.printStackTrace();
	} finally {
            if (output != null) {
                try {
                        output.close();
                } catch (IOException e) {
                        e.printStackTrace();
                }
            }
	}
    }
    public String getPropertie(String name){
        
        Properties prop = new Properties();
	InputStream input = null;
        String propertie = null;
 
	try {
 
		input = new FileInputStream("config.properties");
 
		// load a properties file
		prop.load(input);
 
		// get the property value and print it out
		propertie = prop.getProperty(name);
                
 
	} catch (IOException ex) {
		ex.printStackTrace();
	} finally {
		if (input != null) {
			try {
				input.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
                return propertie;   
	} 
            
    }
}