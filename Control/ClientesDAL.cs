using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using static System.Windows.Forms.AxHost;

namespace Control
{
    internal class ClientesDAL
    {
        
        
        public static int Agregar(Cliente pCliente)
        {
            MySqlConnection conexion = new MySqlConnection("" +
            "server=localhost; user id=root; password=;" +
            "database= dbsalon; sslMode=none");
            MySqlCommand cmd = new MySqlCommand();

            conexion.Open();
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into  registros(nombre, servicio, precio, porcentaje, medio, ganancia) values ('{0}','{1}','{2}','{3}','{4}','{5}')", pCliente.nombre, pCliente.servicio, pCliente.precio, pCliente.porcentage, pCliente.medio, pCliente.ganancia), cmd.Connection= conexion);

            retorno = comando.ExecuteNonQuery();

            return retorno;

        }

        public static List<Cliente> Buscar(string dato, string fecha1, string fecha2)
        {
            List<Cliente> _lista = new List<Cliente>();
            MySqlConnection conexion = new MySqlConnection("" +
            "server=localhost; user id=root; password=;" +
            "database= dbsalon; sslMode=none");
            MySqlCommand cmd = new MySqlCommand();
       
            conexion.Open();
            MySqlCommand _comando = new MySqlCommand("SELECT nombre, servicio, precio, porcentaje, medio, ganancia FROM registros WHERE registro BETWEEN "+fecha1+" AND "+fecha2+" AND nombre='"+dato+"'", cmd.Connection = conexion);
           
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                
                Cliente pCliente = new Cliente();
                pCliente.nombre = _reader.GetString(0);
                pCliente.servicio = _reader.GetString(1);
                pCliente.precio = _reader.GetString(2);
                pCliente.porcentage = _reader.GetString(3);
                pCliente.medio = _reader.GetString(4);
                pCliente.ganancia = _reader.GetString(5);
                _lista.Add(pCliente);
            }
            conexion.Close();

            return _lista;
        }

        public static Cliente ObtenerCliente(int pId)
        {
            Cliente pCliente = new Cliente();
            MySqlConnection conexion = new MySqlConnection("" +
            "server=localhost; user id=root; password=;" +
            "database= dbsalon; sslMode=none");
            MySqlCommand cmd = new MySqlCommand();
            conexion.Open();
            

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT personaid, nombre, servicio, precio, porcentaje, medio, ganancia FROM registros where personaid ={0}", pId), cmd.Connection = conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pCliente.personaid = _reader.GetInt32(0);
                pCliente.nombre = _reader.GetString(1);
                pCliente.servicio = _reader.GetString(2);
                pCliente.precio = _reader.GetString(3);
                pCliente.porcentage = _reader.GetString(4);
                pCliente.medio = _reader.GetString(5);
                pCliente.ganancia = _reader.GetString(6);
                pCliente.registro = _reader.GetString(7);

            
            }
            conexion.Close();
            return pCliente;
        }

        public static int Totales (double total, double ganancia)
        {
            MySqlConnection conexion = new MySqlConnection("" +
           "server=localhost; user id=root; password=;" +
           "database= dbsalon; sslMode=none");
            MySqlCommand cmd = new MySqlCommand();

            conexion.Open();
            string consutaAgregar = string.Format("Insert into contabilidad(produccion, ganancia) values ({0},{1})",total, ganancia);
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(consutaAgregar, cmd.Connection = conexion);

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }


    }
}
