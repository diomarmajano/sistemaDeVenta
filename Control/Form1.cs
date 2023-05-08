using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  
        }

        MySqlConnection conexion = new MySqlConnection("" +
            "server=localhost; user id=root; password=;" +
            "database= dbsalon; sslMode=none");
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        double Styl001 = 0, Styl002 = 0, Styl003 = 0, Styl004 = 0, Styl005 = 0, Styl006 = 0, Nails001 = 0, Nails002 = 0, Nails003 = 0;

        double styl01 = 0, styl02 = 0, styl03 = 0, styl04 = 0, styl05 = 0, styl06 = 0, nails01 = 0, nails02 = 0, nails03 = 0;

        double precio = 0, totalGanancia=0, totalDelDia = 0, efectivo = 0, transferencia = 0, tarjeta = 0, otros = 0;


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text)
                || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Debe llenar Todos los campos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                object estilista = comboBox1.SelectedItem;
                object subestilista = comboBox1.GetItemText(estilista);

                object servicio = comboBox2.SelectedItem;
                object subservicio = comboBox2.GetItemText(servicio);

                object medio = comboBox3.SelectedItem;
                object medioPago = comboBox3.GetItemText(medio);



                //Obtener el precio del servicio
                precio = double.Parse(textBox1.Text);
                int porcentaje = int.Parse(textBox2.Text);

                double aPagar = (precio * porcentaje) / 100;
                String ganancia = aPagar.ToString();
                ListViewItem nombres = new ListViewItem(subestilista.ToString());
                nombres.SubItems.Add(subservicio.ToString());
                nombres.SubItems.Add(textBox1.Text); //precio
                nombres.SubItems.Add(textBox2.Text);
                nombres.SubItems.Add(ganancia); 
                nombres.SubItems.Add(comboBox3.Text.ToString());//Medio de pago
                listView1.Items.Add(nombres);


                if (subestilista.ToString() == "Styl001")
                {
                    styl01+= aPagar;
                    Styl001 += precio;
                    totalDelDia += precio;
                    totalGanancia+=(precio-aPagar);

                }
                else if (subestilista.ToString() == "Styl002")
                {
                    styl02+= aPagar;
                    Styl002+= precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);

                }
                else if (subestilista.ToString() == "Styl003")
                {
                    styl03+= aPagar;
                    Styl003+= precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Styl004")
                {
                    styl04 += aPagar;
                    Styl004 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Styl005")
                {
                    styl05 += aPagar;
                    Styl005 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Styl006")
                {
                    styl06 += aPagar;
                    Styl006 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Nails001")
                {
                    nails01 += aPagar;
                    Nails001 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Nails002")
                {
                    nails02 += aPagar;
                    Nails002 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }
                else if (subestilista.ToString() == "Nails003")
                {
                    nails03 += aPagar;
                    Nails003 += precio;
                    totalDelDia += precio;
                    totalGanancia += (precio - aPagar);
                }

                if (medioPago.ToString() == "Efectivo")
                {

                    efectivo += precio;

                }
                else if (medioPago.ToString() == "Transferencia")
                {

                    transferencia += precio;
                }
                else if (medioPago.ToString() == "Tarjeta")
                {

                    tarjeta += precio;
                }
                else
                {

                    otros += precio;
                }

                Cliente pCliente = new Cliente();
                pCliente.nombre = subestilista.ToString();
                pCliente.servicio = subservicio.ToString();
                pCliente.precio = precio.ToString();
                pCliente.porcentage = porcentaje.ToString();
                pCliente.medio = medioPago.ToString();
                pCliente.ganancia= aPagar.ToString();

                int resultado = ClientesDAL.Agregar(pCliente);

                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                comboBox3.SelectedItem = null;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            linkLabel1.Links.Add(0, 0, "https://api.whatsapp.com/send?phone=56949557081");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {

           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            label6.Text = "Styl001";
            label7.Text = "$" + Styl001.ToString();
            label8.Text = "$" + styl01.ToString();

            label6.Text += "\nStyl002";
            label7.Text += "\n$" + Styl002.ToString();
            label8.Text += "\n$" + styl02.ToString();

            label6.Text += "\nStyl003";
            label7.Text += "\n$" + Styl003.ToString();
            label8.Text += "\n$" + styl03.ToString();

            label6.Text += "\nStyl004";
            label7.Text += "\n$" + Styl004.ToString();
            label8.Text += "\n$" + styl04.ToString();

            label6.Text += "\nStyl005";
            label7.Text += "\n$" + Styl005.ToString();
            label8.Text += "\n$" + styl05.ToString();

            label6.Text += "\nStyl006";
            label7.Text += "\n$" + Styl006.ToString();
            label8.Text += "\n$" + styl06.ToString();

            label6.Text += "\nNails001";
            label7.Text += "\n$" + Nails001.ToString();
            label8.Text += "\n$" + nails01.ToString();

            label6.Text += "\nNails002";
            label7.Text += "\n$" + Nails002.ToString();
            label8.Text += "\n$" + nails02.ToString();

            label6.Text += "\nNails003";
            label7.Text += "\n$" + Nails003.ToString();
            label8.Text += "\n$" + nails03.ToString();

            label12.Text = "Ingresos: $" + totalDelDia;
            label12.Text += "\nGanancias: $" + totalGanancia;
            label15.Text = "Efectivo:  $"+efectivo.ToString();
            label15.Text += "\nTransferencia:  $" + transferencia.ToString();
            label15.Text += "\nTarjeta:  $" + tarjeta.ToString();
            label15.Text += "\nOtros:  $" + otros.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label15.Text= "-----------------";
            label12.Text= "-----------------";
            label6.Text = "-----------------";
            label7.Text = "-----------------";
            label8.Text = "-----------------";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ClientesDAL.Totales(totalDelDia, totalGanancia);
            MessageBox.Show("Cierre de caja\n Total del Dia: " + totalDelDia + "\nGanancia: " + totalGanancia);
            MessageBox.Show("Cierre de caja realizado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //btnMax.Visible = false;
            //btnrestaurar.Visible = true;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            //his.WindowState=FormWindowState.Normal;
            //btnrestaurar.Visible=false;
            //btnMax.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //actualizarDatos();
            //LoadData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuscarClientes busqueda = new BuscarClientes();
            busqueda.Show();
        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToString("hh:mm:ss");
            label17.Text= DateTime.Now.ToLongDateString();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
