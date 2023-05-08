using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Control
{
    public partial class BuscarClientes : Form
    {
        public BuscarClientes()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string theDate3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string theDate4 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            object buscar = comboBox1.SelectedItem;
            object subbuscar = comboBox1.GetItemText(buscar);
            string nombreABuscar = subbuscar.ToString();

            dgvBuscar.DataSource = ClientesDAL.Buscar(nombreABuscar, theDate3, theDate4);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarClientes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string theDate3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string theDate4 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            object buscar = comboBox1.SelectedItem;
            object subbuscar = comboBox1.GetItemText(buscar);
            string nombreABuscar = subbuscar.ToString();

            //SELECT nombre, SUM(precio) as total from registros where nombre ='diomar' and (registro >='12-11-2022' and registro <= '13-12-2022');

            SqlConnection conexion = new SqlConnection("" +
           "server=localhost; user id=root; password=;" +
           "database= dbsalon; sslMode=none");
            conexion.Open();
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(String.Format("select nombre, SUM(ganancia) as aPagar from dbsalon"), conexion);
            datos.Clear();
            adapter.Fill(datos);
            dataGridView1.DataSource = datos;
            conexion.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        DataSet ds;
        DataSet cal;
        string consulta;
        string calcular;
        private void button3_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////
            string theDate3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string theDate4 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            object buscar = comboBox1.SelectedItem;
            object subbuscar = comboBox1.GetItemText(buscar);
            string nombreABuscar = subbuscar.ToString();
            //////////////////////////////////////////////////////////////////
            ///

            MySqlConnection conexion = new MySqlConnection("" +
           "server=localhost; user id=root; password=;" +
           "database= dbsalon; sslMode=none");
            //consulta=string.Format("SELECT nombre, servicio, precio, porcentaje, medio, ganancia FROM registros WHERE registro BETWEEN " + theDate3 + " AND " + theDate4 + " AND nombre='" + nombreABuscar + "'");
            consulta = string.Format("SELECT nombre, servicio, precio, porcentaje, medio, ganancia FROM registros WHERE registro >= '{0}' and  registro <= '{1}' and nombre='{2}'", theDate3, theDate4, nombreABuscar);
            calcular = string.Format("SELECT nombre, SUM(ganancia) as total from registros where nombre= '{0}' and registro >= '{1}' and registro <= '{2}'", nombreABuscar, theDate3, theDate4);
            conexion.Open();
            MySqlCommand comandoM = new MySqlCommand(consulta,conexion);
            MySqlCommand comandoC = new MySqlCommand(calcular, conexion);
            MySqlDataAdapter con = new MySqlDataAdapter(comandoM);
            MySqlDataAdapter ncon = new MySqlDataAdapter(comandoC);
            ds = new DataSet();
            cal = new DataSet();
            con.Fill(ds);
            ncon.Fill(cal);
            dgvBuscar.DataSource = ds.Tables[0];
            dataGridView1.DataSource = cal.Tables[0];
            conexion.Close();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string theDate3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string theDate4 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            MySqlConnection conexion = new MySqlConnection("" +
          "server=localhost; user id=root; password=;" +
          "database= dbsalon; sslMode=none");
            calcular = string.Format("select sum(produccion), SUM(ganancia) from contabilidad where fecha >='{0}' and fecha <='{1}'", theDate3, theDate4);
            conexion.Open();
            MySqlCommand comandoC = new MySqlCommand(calcular, conexion);
            MySqlDataAdapter ncon = new MySqlDataAdapter(comandoC);
            cal = new DataSet();
            ncon.Fill(cal);
            dgvBuscar.DataSource=cal.Tables[0];
            conexion.Close();
        }
    }
}
