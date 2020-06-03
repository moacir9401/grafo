using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematicaDiscreta
{
    class Vertice
    {
        private String rotulo;
        private int peso;
        public int nome { get; set; }

        public Vertice()
        {

        }

        public String getRotulo()
        {
            return rotulo;
        }

        public void setRotulo(String rotulo)
        {
            this.rotulo = rotulo;
        }

        public int getPeso()
        {
            return peso;
        }

        public void setPeso(int peso)
        {
            this.peso = peso;
        }
    }

}
