using System;
using System.Text;
using Xamarin.Forms;

namespace AppCalculadora
{
    public partial class MainPage : ContentPage
    {
        private double numeroUno = 0, numeroDos = 0, resultado = 0;
        private int operador = 4;
        private bool hayPunto = false, esDecimal = false;
        private StringBuilder numeroActual = new StringBuilder("0");

        public MainPage()
        {
            InitializeComponent();
        }

        private void igualar_Valores(string operando, int valor)
        {
            if (resultado != 0 || (!string.IsNullOrEmpty(lblNumero.Text) && !string.IsNullOrEmpty(spnFirst.Text)))
                esDecimal = true;

            numeroUno = double.Parse(numeroActual.ToString());
            spnFirst.Text = numeroUno + " ";
            numeroActual.Clear().Append("0");

            spnSecond.Text = operando;
            operador = valor;
            hayPunto = false;
        }

        private bool esta_Lleno()
        {
            return string.IsNullOrEmpty(spnFirst.Text) && string.IsNullOrEmpty(spnSecond.Text);
        }

        private void ingresarNumero(string numero)
        {
            if (numeroActual.ToString() == "0" && numero != ".")
                numeroActual.Clear().Append(numero);
            else
                numeroActual.Append(numero);

            lblNumero.Text = numeroActual.ToString();
        }

        private void Btn_AC(object sender, EventArgs e)
        {
            numeroUno = 0;
            numeroDos = 0;
            resultado = 0;
            hayPunto = false;

            spnFirst.Text = "";
            spnSecond.Text = "";
            spnThird.Text = "";
            lblNumero.Text = "0";

            numeroActual.Clear().Append("0");
        }

        private void Btn_Sumar(object sender, EventArgs e)
        {
            igualar_Valores("+", 0);
            if (!esta_Lleno())
                spnThird.Text = "";
        }

        private void Btn_C(object sender, EventArgs e)
        {
            if (numeroActual.ToString().EndsWith("."))
            {
                hayPunto = false;
            }
            if (numeroActual.ToString() != "0" && numeroActual.ToString() != "0.")
            {
                if (double.Parse(numeroActual.ToString()) > 10)
                {
                    numeroActual.Remove(numeroActual.Length - 1, 1);
                }
                else
                {
                    numeroActual.Clear().Append("0");
                }
            }
            if (numeroActual.ToString().EndsWith("."))
            {
                numeroActual.Remove(numeroActual.Length - 1, 1);
            }

            lblNumero.Text = numeroActual.ToString();
        }

        private void Btn_Restar(object sender, EventArgs e)
        {
            igualar_Valores("-", 1);
            if (!esta_Lleno())
                spnThird.Text = "";
        }

        private void Btn_Multiplicar(object sender, EventArgs e)
        {
            igualar_Valores("*", 2);
            if (!esta_Lleno())
                spnThird.Text = "";
        }

        private void Btn_Dividir(object sender, EventArgs e)
        {
            igualar_Valores("/", 3);
            if (!esta_Lleno())
                spnThird.Text = "";
        }

        private void Click_Cero(object sender, EventArgs e)
        {
            if (lblNumero.Text != "0")
            {
                ingresarNumero("0");
            }
        }

        private void Click_Uno(object sender, EventArgs e)
        {
            ingresarNumero("1");
        }

        private void Click_Dos(object sender, EventArgs e)
        {
            ingresarNumero("2");
        }

        private void Click_Tres(object sender, EventArgs e)
        {
            ingresarNumero("3");
        }

        private void Click_Cuatro(object sender, EventArgs e)
        {
            ingresarNumero("4");
        }

        private void Click_Cinco(object sender, EventArgs e)
        {
            ingresarNumero("5");
        }

        private void Click_Seis(object sender, EventArgs e)
        {
            ingresarNumero("6");
        }

        private void Click_Siete(object sender, EventArgs e)
        {
            ingresarNumero("7");
        }

        private void Click_Ocho(object sender, EventArgs e)
        {
            ingresarNumero("8");
        }

        private void Click_Nueve(object sender, EventArgs e)
        {
            ingresarNumero("9");
        }



        private void Btn_Igual(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(spnFirst.Text) && !string.IsNullOrEmpty(spnSecond.Text))
            {
                spnThird.Text = " " + numeroActual.ToString();

                numeroDos = double.Parse(numeroActual.ToString());

                if (operador == 0)
                {
                    resultado = numeroUno + numeroDos;
                }
                else if (operador == 1)
                {
                    resultado = numeroUno - numeroDos;
                }
                else if (operador == 2)
                {
                    resultado = numeroUno * numeroDos;
                }
                else if (operador == 3)
                {
                    resultado = numeroUno / numeroDos;
                }

                lblNumero.Text = resultado.ToString();

                numeroUno = 0;
                numeroDos = 0;
                resultado = 0;
                operador = 4;
                esDecimal = false;
                numeroActual.Clear().Append(lblNumero.Text);
            }
        }

        private void Click_Point(object sender, EventArgs e)
        {
            if (!hayPunto)
            {
                ingresarNumero(".");
                hayPunto = true;
            }

            if (operador == 4)
                esDecimal = true;
        }
    }
}
