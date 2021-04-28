using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperacionesBasicas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            number1.Clear();
            number2.Clear();
            txtresult.Clear();
        }

        private void txtCalcular_Click(object sender, EventArgs e)
        {
            string op = cboOperacion.Text;
            double n1 = double.Parse(number1.Text);
            double n2 = double.Parse(number2.Text);
            double result = 0;

            switch (op) {
                case "Suma":
                    result = n1 + n2;
                    break;
                case "Resta":
                    result = n1 - n2;
                    break;
                case "Multiplicacion":
                    result = n1 * n2;
                    break;
                case "Division":
                    result = n1 / n2;
                    break;

            }
        }
    }
}
