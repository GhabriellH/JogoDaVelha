using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogoFinal = false;
        string[] texto = new string[9];
        public Form1() 
        { 
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn1 = (Button)sender;
            int buttonIndex = btn1.TabIndex;

            if (btn1.Text == "" && jogoFinal == false)
            {
                if (turno)
                {
                    btn1.Text = "X";
                    texto[buttonIndex] = btn1.Text;
                    rodadas ++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn1.Text = "O";
                    texto[buttonIndex] = btn1.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
            }
        }
        void Checagem(int ChecagemPlayer)
        {
            string _suporte;

            if (ChecagemPlayer == 1)
            {
                _suporte = "X";
            }
            else
            {
                _suporte = "O";
            }

            for (int Horizontal = 0; Horizontal < 8; Horizontal +=3 )
            {
                if (_suporte == texto[Horizontal]) 
                { 
                    if ((texto[Horizontal] == texto[Horizontal + 1]) && texto[Horizontal] == texto[Horizontal + 2])
                    {
                        MessageBox.Show("Jogador 1 venceu!");
                        return;
                    }
                }

            }
        }
        
    }
}
