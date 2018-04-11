using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NewsModel;

namespace NewsDataAccess
{
    public class SeccionRepository
    {
        static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";

        public static IEnumerable<Seccion> GetSecciones()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from Seccion";
            SqlDataReader reader = command.ExecuteReader();
            List<Seccion> secciones = new List<Seccion>();
            while (reader.Read())
            {
                Seccion seccion = new Seccion();
                seccion.seccionID = (int)reader["seccionID"];
                seccion.nombreSeccion = reader["nombreSeccion"] as string;
                secciones.Add(seccion);
            }
            return secciones;
        }

        public static Seccion GetSeccion(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * from Seccion where seccionID = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Seccion seccion = new Seccion();
            while (reader.Read())
            {
                seccion.seccionID = (int)reader["seccionID"];
                seccion.nombreSeccion = reader["nombreSeccion"] as string;
            }
            return seccion;
        }

        public static bool InsertSeccion(Seccion seccion)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Seccion(nombreSeccion)
                                    values(@nombreSeccion)";
            command.Parameters.AddWithValue("@nombreSeccion", seccion.nombreSeccion);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
