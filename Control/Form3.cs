using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }
        
        string usuario;
        string contraseña;
        Form1 formularioPrinccipal = new Form1();
        private void button1_Click(object sender, EventArgs e)
        {
            usuario = "admin";
            contraseña = "admin2022";
            string entradaUsuario = textBox1.Text;
            string entradaContraseña = textBox2.Text;

            if(entradaUsuario == usuario && entradaContraseña == contraseña)
            {
                formularioPrinccipal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o Clave incorrecta");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
          
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
