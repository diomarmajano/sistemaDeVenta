using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;

namespace Control
{
    internal class Cliente
    {
        public int personaid { get; set; }
        public string nombre { get; set; }
        public string servicio { get; set; }
        public string precio { get; set; }
        public string porcentage { get; set; }
        public string medio { get; set; }
        public string registro { get; set; }
        public string ganancia { get; set; }
        public Cliente() { }

        public Cliente(int ppersonaid, string registro, string pnombre, string pservicio, string pprecio, string pporcentage, string pmedio, string ganancia)

        {
            this.personaid = ppersonaid;
            this.registro = registro;
            this.nombre = pnombre;
            this.servicio = pservicio;
            this.precio = pprecio;
            this.porcentage = pporcentage;
            this.medio = pmedio;
            this.ganancia = ganancia;
        }
    }
}
