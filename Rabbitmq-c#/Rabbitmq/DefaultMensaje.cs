using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Rabbitmq
{
    public class DefaultMensaje
    {
        public String Servidor { get; set; }
        public String Fecha { get; set; }
        public String Cedula { get; set; }
        public String Nombre { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public DefaultMensaje(String Servidor, String Cedula, String Nombre)
        {
            this.Servidor = Servidor;
            this.Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.Cedula = Cedula;
            this.Nombre = Nombre;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void insertarMsj()
        {
            SqlConnection conexion;
            SqlCommand comando;
            string consulta;
            try
            {
                String DBString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                conexion = new SqlConnection(DBString);
                conexion.Open();
                consulta = string.Format("insertarMsj  '{0}','{1}','{2}','{3}'", Servidor, Fecha, Cedula, Nombre);
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return "Servidor: " + Servidor + " Fecha: " + Fecha + " Cedula: " + Cedula + " Nombre: " + Nombre;
        }
    }
}
