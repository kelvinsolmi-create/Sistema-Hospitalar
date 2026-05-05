using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthSys
{
    public partial class Menu : Form
    {
        Cadastrar cad;
        Consultar cons;
        Atualizar atu;
        Excluir exc;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cad = new Cadastrar();
            cad.ShowDialog();
        }//botão cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            cons = new Consultar();
            cons.ShowDialog();
        }//botão consultar

        private void button3_Click(object sender, EventArgs e)
        {
            atu = new Atualizar();
            atu.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exc = new Excluir();
            exc.ShowDialog();
        }
    }//fim da classe
}//fim do projeto de sistema hospitalar
