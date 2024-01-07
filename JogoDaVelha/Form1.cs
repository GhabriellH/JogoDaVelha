﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        string[] texto = new string[9];

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            foreach (Button item in panel1.Controls)
                item.Text = "";

            rodadas = 0;
            jogoFinal = false;
            texto = new string[9];
            Xplayer = 0;
            Xpontos.Text = Convert.ToString(Xplayer);
            Oplayer = 0;
            Opontos.Text = Convert.ToString(Oplayer);
            empatesPontos = 0;
            Empates.Text = Convert.ToString(empatesPontos);
            MessageBox.Show("Reiniciado com sucesso!");
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            foreach (Button item in panel1.Controls)
                item.Text = "";

            rodadas = 0;
            jogoFinal = false;
            texto = new string[9];
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
                    rodadas++;
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
        void Vencedor(int PlayerQueGanhou)
        {
            jogoFinal = true;
            if (PlayerQueGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou!");
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou!");
                turno = false;
            }
        }
        void Checagem(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }
            }
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }
            }
            if (texto[0] == suporte)
            {

                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }
            }
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                }
            }
            if (rodadas == 9 && jogoFinal == false)
            {
                empatesPontos++;
                Empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Empate!");
                jogoFinal = true;
                return;
            }
        }

    }
}
