using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CadastroDoacoes
{
    public partial class FrmConsulta : Form
    {
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public static string cod = "";
        public static NpgsqlCommand cmd1;
        public FrmConsulta()
        {
            InitializeComponent();
            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";

        }
        

        private void FrmConsulta_Load(object sender, EventArgs e)
        {


            carregagrid();
            string comandoSQL;
            comandoSQL = ("select nome,sexo,tipo,login from usuario where login=@login;");

            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = FrmLogin.login;
            NpgsqlDataReader dr = null;



            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                String tipo = dr["tipo"].ToString();
                
                
                cn.Close();
                if (tipo == "Visitante")
                {
                    button1.Enabled = false;

                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            FrmCadastraDoacao abrir = new FrmCadastraDoacao();
            abrir.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cod == "")
            {
                MessageBox.Show("Selecione uma doação a ser alterada", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                FrmAlterar abrir = new FrmAlterar();
                abrir.Show();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }
        public void carregagrid()
        {
            string comandoSQL = ("select * from itens");




            //cria a conexão com o banco de dados

            //cria o objeto command para executar a instruçao sql
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);

            //abre a conexao
            cn.Open();

            //define o tipo do comando 
            cmd.CommandType = CommandType.Text;
            //cria um dataadapter
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dataGridView1.DataSource = clientes;

            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string comandoSQL = ("select * from itens");
           int aux=0;
           if (check_data.Checked == true)
            {
                comandoSQL = comandoSQL + "WHERE data_add >= " + maskedTextBox1.Text + " AND data_add <= " + mtxt_data.Text;
                aux++;
            }

           if (check_ano.Checked == true)
            {
                if (aux > 0)
                    comandoSQL = comandoSQL + " AND ";
                else
                    comandoSQL = comandoSQL + " WHERE ";
                aux++;

                comandoSQL = comandoSQL + " ano = " + numericUpDown1.Text;
            }

            if (check_tipo.Checked == true)
            {
                if (aux > 0)
                    comandoSQL = comandoSQL + " AND ";
                else
                    comandoSQL = comandoSQL + " WHERE ";

                if (radio_alimento.Checked == true)
                    comandoSQL = comandoSQL + " tipo_item = '" + radio_alimento.Text + "'";
                else if (radio_dinheiro.Checked == true)
                    comandoSQL = comandoSQL + " tipo_item = '" + radio_dinheiro.Text + "'";
                else
                    comandoSQL = comandoSQL + " tipo_item like '%%'";
            }

            cmd1 = new NpgsqlCommand(comandoSQL, cn);



            //cria a conexão com o banco de dados

            //cria o objeto command para executar a instruçao sql


            //abre a conexao
            cn.Open();

                //define o tipo do comando 
                cmd1.CommandType = CommandType.Text;
                //cria um dataadapter
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);

                //cria um objeto datatable
                DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(clientes);

                //atribui o datatable ao datagridview para exibir o resultado
                dataGridView1.DataSource = clientes;

                cn.Close();
            }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string vArq = "Consulta";

            FolderBrowserDialog vSalvar = new FolderBrowserDialog();

            if (vSalvar.ShowDialog() == DialogResult.Cancel)
                return;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 50;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                //cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        pdfTable.AddCell("");
                    }
                    else
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }

            //Exporting to PDF
            using (FileStream stream = new FileStream(vSalvar.SelectedPath + "\\" + vArq + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                //criando uma string vazia
                string dados = "";

                //criando a variavel para paragrafo
                Paragraph paragrafo = new Paragraph(dados, FontFactory.GetFont("Segoe UI", 40.0f, BaseColor.BLACK));
                //etipulando o alinhamneto
                paragrafo.Alignment = Element.ALIGN_CENTER;
                //Alinhamento Justificado
                //adicioando texto
                paragrafo.Add("Consulta: \n\n");
                pdfDoc.Add(paragrafo);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Arquivo Gerado com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }

