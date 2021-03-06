﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorDeTexto
{

    public partial class Form1 : Form
    {
        StringReader leitura = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void tsb_Novo_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem Certeza??", "Criar novo texto?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Novo();
            }
            else if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem Certeza??", "Criar novo texto?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Novo();
            }
            else if (DialogResult == DialogResult.No)
            {
                Close();
            }
        }
        private void Salvar()
        {
              try
              {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream Arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter Natali_StreamWriter = new StreamWriter(Arquivo);
                    Natali_StreamWriter.Flush();
                    Natali_StreamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    Natali_StreamWriter.Write(richTextBox1.Text);
                    Natali_StreamWriter.Flush();
                    Natali_StreamWriter.Close();
                }
              } catch(Exception rx)
            {
                MessageBox.Show("Erro no salvamento" + rx.Message,"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsb_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Abrir Arquivo";

            openFileDialog1.InitialDirectory = @"Área de Trabalho";
            openFileDialog1.Filter = "(*.GT)|*.GT";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader Natali_StreamReader = new StreamReader(arquivo);
                    Natali_StreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = Natali_StreamReader.ReadLine();
                    while (linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = Natali_StreamReader.ReadLine();

                    }
                    Natali_StreamReader.Close();

                }
                catch(Exception rx)
                {
                    MessageBox.Show("Erro no salvamento" + rx.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tsb_Abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void tsb_Copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void tsb_Colar_Click(object sender, EventArgs e)
        {
            Colar();
        }
        private void Negrito()
        {
            string nome_da_fonte = null;
            float tamanho_Fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_Fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Regular);
            if (n == false)
            {
                if (i == true& s== true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold| FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true)
                    {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (i == true& s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Italic);

                }
                else if (i == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold);

                }
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold);
            }
            else 
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte,FontStyle.Underline);

                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte,FontStyle.Italic);

                }
               
            }
        }
        private void Italico()
        {
            string nome_da_fonte = null;
            float tamanho_Fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_Fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Regular);
            if (i == false)
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Italic);

                }
                else if (n == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Italic);

                }
                
            }
            else
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold);

                }

            }
        }
        private void Sublinhado()
        {
            string nome_da_fonte = null;
            float tamanho_Fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_Fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Regular);
            if (s == false)
            {
                if (n == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (n == false & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Underline);

                }
               
            }
            else
            {
                if (n == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Italic);

                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_Fonte, FontStyle.Bold);

                }

            } 
        }
        private void Imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }
        private void alinharEsquerda()
            {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void tsb_Negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void tsb_Italico_Click(object sender, EventArgs e)
        {
            Italico();

        }

        private void tsb_Sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void tsb_Centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void tsb_Esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void esquerdaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void tsb_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void direitaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float PosY = 0;
            int cont = 0;
            float MargemEsquerda = e.MarginBounds.Left - 50;
            float MargemSuperior = e.MarginBounds.Top - 50;

            if(MargemEsquerda < 5)
            {
                MargemEsquerda = 20;
            }
            if (MargemSuperior < 5)
            {
                MargemSuperior = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while(cont < linhasPagina)
            {
                PosY = MargemSuperior + (cont * fonte.GetHeight(e.Graphics));
                e.Graphics.DrawString(linha, fonte, pincel, MargemEsquerda, PosY, new StringFormat());
                cont += 1;
                linha = leitura.ReadLine();
            }
            if(linha != null)
            {
                e.HasMorePages = true;
            }
            pincel.Dispose();
        }

        private void tsb_imprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja Salvar o texto?", "Salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Salvar();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
                
            }
        }

        private void cONFIDENCIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eu te amo Tati, Deus abençoe por estar comigo! <3");
        }

        private void desfazerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
