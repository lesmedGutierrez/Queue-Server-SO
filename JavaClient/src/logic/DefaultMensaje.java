/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logic;

import java.time.Instant;
import java.util.Date;

/**
 *
 * @author Lesmed®
 */
 public class DefaultMensaje{
        public String Servidor ;
        public String Fecha ;
        public String Cedula ;
        public String Nombre;

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public DefaultMensaje(String Servidor, String Cedula, String Nombre)
        {
            this.Servidor = Servidor;
            this.Fecha = Date.from(Instant.now()).toString();//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.Cedula = Cedula;
            this.Nombre = Nombre;
        }
        
    /**
     *
     * @return
     */
    public String ToString()
        {
            return "Servidor: " + Servidor + " Fecha: " + Fecha + " Cedula: " + Cedula + " Nombre: " + Nombre;
        }
 }