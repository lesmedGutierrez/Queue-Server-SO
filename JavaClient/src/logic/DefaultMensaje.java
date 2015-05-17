/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package logic;

import java.sql.*;
import java.time.Instant;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;


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
     public void insertMensaje() {
        try {
            String url = "jdbc:sqlserver://localhost;databaseName=BSO;user=BSO;password=321";
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

            Connection conn = DriverManager.getConnection(url);
            Statement st = conn.createStatement();
            String sql = "insMensaje ?,?,?,?";
            PreparedStatement preparedStmt = conn.prepareStatement(sql);
            preparedStmt.setString(1, Servidor);
            preparedStmt.setString(2, Fecha);
            preparedStmt.setString(3, Cedula);
            preparedStmt.setString(4, Nombre);
            preparedStmt.execute();
            st.close();
            conn.close();
        } catch (SQLException sqle) {
            System.out.println("Sql exception " + sqle);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(DefaultMensaje.class.getName()).log(Level.SEVERE, null, ex);
        }
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