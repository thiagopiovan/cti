using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CadastroDoacoes
{
   
    public partial class FrmCadastraDoacao : Form
    {
      
        public static NpgsqlConnection cn = new NpgsqlConnection();

        public FrmCadastraDoacao()
        {
            InitializeComponent();

           
            
            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
            txt_alimento.Clear();
            txt_valor.Clear();
            mtxt_data.Clear();
            mtxt_data.ResetText();
            qtde.Value = 0;
            cn.Close();
            if (MessageBox.Show("Deseja fechar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();


            }
            else
            {
                
                FrmCadastraDoacao fechar = new FrmCadastraDoacao();
                fechar.Close();
            }

        }

      

     

       

        private void button1_Click(object sender, EventArgs e)
        {
           
           
                if (txt_valor.Text == "" || txt_alimento.Text == "" || qtde.Value == 0)
                {
                    MessageBox.Show("Preencha todos os campos!!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {



                    cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
                    cn.Open();

                    string sql = "INSERT INTO itens (tipo_item,item,valor,data_add,ano,qtde,total) VALUES (@tipo,@item,@valor,@data,@ano,@qtde,(@valor * @qtde));";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    if (radio_alimento.Checked == true)
                    {
                        cmd.Parameters.Add("tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = radio_alimento.Text;
                    }
                    if (radio_dinheiro.Checked == true)
                    {
                        cmd.Parameters.Add("tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = radio_dinheiro.Text;
                    }

                    cmd.Parameters.Add("item", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_alimento.Text;
                    cmd.Parameters.Add("valor", NpgsqlTypes.NpgsqlDbType.Numeric).Value = txt_valor.Text;
                  
                    cmd.Parameters.Add("data", NpgsqlTypes.NpgsqlDbType.Date).Value = mtxt_data.Text;
                    cmd.Parameters.Add("ano", NpgsqlTypes.NpgsqlDbType.Numeric).Value = numericUpDown1.Value;
                    cmd.Parameters.Add("qtde", NpgsqlTypes.NpgsqlDbType.Numeric).Value = qtde.Value;
                   
                    
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Doação cadastrada com sucesso!!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_alimento.Clear();
                    txt_valor.Clear();
                    mtxt_data.Clear();
                    qtde.Value = 0;
                    mtxt_data.ResetText();
                
            }
           
        }

        

        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
                MessageBox.Show("Você não pode usar ponto, use vírgula!!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void radio_alimento_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_alimento.Checked == true)
            {
                txt_alimento.Clear();
                qtde.Value = 0;
                qtde.Enabled = true;
                txt_alimento.Enabled = true;
                txt_valor.Text = "00,00";
                txt_valor.Enabled = false;
            }
        }

        private void radio_dinheiro_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_dinheiro.Checked == true)
            {
                txt_alimento.Text = "Dinheiro";
                txt_alimento.Enabled = false;
                txt_valor.ResetText();
                txt_valor.Enabled = true;
                qtde.Value = 1;
                qtde.Enabled = false;
            }
        }

        
    }
}
