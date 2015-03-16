/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package rabbitmq;

import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author LAB SIRZEE
 */
public class Mensaje {

    private String Servidor;
    private String Fecha;
    private String Cedula;
    private String Nombre;

    public String getCedula() {
        return Cedula;
    }

    public void setCedula(String cedula) {
        this.Cedula = cedula;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        this.Nombre = nombre;
    }

    public String getServidor() {
        return Servidor;
    }

    public void setServidor(String Servidor) {
        this.Servidor = Servidor;
    }

    public String getFecha() {
        return Fecha;
    }

    public void setFecha(String Fecha) {
        this.Fecha = Fecha;
    }

    public Mensaje(String app, String cedula, String nombre) {
        this.Servidor = app;
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Calendar cal = Calendar.getInstance();
        this.Fecha = dateFormat.format(cal.getTime());
        this.Cedula = cedula;
        this.Nombre = nombre;
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
            Logger.getLogger(Mensaje.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public String toString() {
        return "Servidor: " + Servidor + "Fecha: " + Fecha + "Cedula: " + Cedula + " Nombre: " + Nombre;
    }
}
