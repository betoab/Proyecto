using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NewsModel;


namespace NewsDataAccess
{
    public class NewsRepository
    {
       static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        public static IEnumerable<Nota> GetNews()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from Nota";
            SqlDataReader reader = command.ExecuteReader();
            List<Nota> notas = new List<Nota>();
            while (reader.Read())
            {
                Nota nota = new Nota();
                nota.Notaid = (int)reader["Notaid"];
                nota.Titulo = reader["Titulo"] as string;
                nota.Reportero = reader["Reportero"] as string;
                nota.Seccion = reader["Seccion"] as string;
                nota.Categoria = reader["Categoria"] as string;
                nota.Fecha = (DateTime)reader["Fecha"];
                nota.Ubicacion = reader["Ubicacion"] as string;
                nota.Relevancia = reader["Relevancia"] as string;
                nota.Espacio = reader["Espacio"] as string;
                nota.Archivo = reader["Archivo"] as string;
                nota.Dimensiones = reader["Dimensiones"] as string;
                nota.Precio = Convert.ToDecimal(reader["Precio"]);
                nota.Privacidad = Convert.ToChar(reader["Privacidad"]);
                nota.DiarioImpreso = reader["DiarioImpreso"] as string;

                notas.Add(nota);
            }
            return notas;
        }

        public static Nota GetNew(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from Nota where Notaid = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Nota nota = new Nota();
            while (reader.Read())
           {               
                nota.Notaid = (int)reader["Notaid"];
                nota.Titulo = reader["Titulo"] as string;
                nota.Reportero = reader["Reportero"] as string;
                nota.Seccion = reader["Seccion"] as string;
                nota.Categoria = reader["Categoria"] as string;
                nota.Fecha = (DateTime)reader["Fecha"];
                nota.Ubicacion = reader["Ubicacion"] as string;
                nota.Relevancia = reader["Relevancia"] as string;
                nota.Espacio = reader["Espacio"] as string;
                nota.Archivo = reader["Archivo"] as string;
                nota.Dimensiones = reader["Dimensiones"] as string;
                nota.Precio = Convert.ToDecimal(reader["Precio"]);
                nota.Privacidad = Convert.ToChar(reader["Privacidad"]);
                nota.DiarioImpreso = reader["DiarioImpreso"] as string;                
            }
            return nota;
        }

        public static bool InsertNota(Nota nota)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();            
            command.CommandText = @"insert into Nota(Titulo,Reportero,Seccion,Categoria,Fecha,Ubicacion,Relevancia,
                                    Espacio,Archivo,Dimensiones,Precio,Privacidad,DiarioImpreso)
                                    values(@titulo,@reportero,@seccion,@categoria,@fecha,@ubicacion,@relevancia,
                                    @espacio,@archivo,@dimensiones,@precio,@privacidad,@diario)";
            command.Parameters.AddWithValue("@titulo", nota.Titulo);
            command.Parameters.AddWithValue("@reportero", nota.Reportero);
            command.Parameters.AddWithValue("@seccion", nota.Seccion);
            command.Parameters.AddWithValue("@categoria", nota.Categoria);
            command.Parameters.AddWithValue("@fecha", nota.Fecha);
            command.Parameters.AddWithValue("@ubicacion", nota.Ubicacion);
            command.Parameters.AddWithValue("@relevancia", nota.Relevancia);
            command.Parameters.AddWithValue("@espacio", nota.Espacio);
            command.Parameters.AddWithValue("@archivo", nota.Archivo);
            command.Parameters.AddWithValue("@dimensiones", nota.Dimensiones);
            command.Parameters.AddWithValue("@precio", nota.Precio);
            command.Parameters.AddWithValue("@privacidad", nota.Privacidad);
            command.Parameters.AddWithValue("@diario", nota.DiarioImpreso);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
       
    }
}
