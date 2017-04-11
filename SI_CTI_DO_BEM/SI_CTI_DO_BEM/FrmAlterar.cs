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

namespace CadastroDoacoes
{
    public partial class FrmAlterar : Form
    {
        public static NpgsqlConnection cn = new NpgsqlConnection();
        private string tipo;
        public FrmAlterar()
        {
            InitializeComponent();

            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
            string comandoSQL;
            comandoSQL = ("select tipo_item,item,valor,data_add,ano,qtde from itens where id=@cod;");


            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("cod", NpgsqlTypes.NpgsqlDbType.Integer).Value = FrmConsulta.cod;
            NpgsqlDataReader dr = null;



            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tipo = dr["tipo_item"].ToString();
                if (tipo == "Dinheiro")
                {
                    radio_dinheiro.Checked = true;
                    radio_alimento.Checked = false;
                }
                if (tipo == "Alimento")
                {
                    radio_dinheiro.Checked = false;
                    radio_alimento.Checked = true;
                }
                txt_alimento.Text = dr["item"].ToString();
                txt_valor.Text = dr["valor"].ToString();
                mtxt_data.Text = dr["data_add"].ToString();
                numericUpDown1.Value = int.Parse(dr["ano"].ToString());
                qtde.Value = int.Parse(dr["qtde"].ToString());
            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            cn.Open();


            string sql = "UPDATE itens SET item=@item,tipo_item=@tipo,valor=@valor,data_add=@data,ano=@ano,qtde=@qtde, total=(@valor * @qtde) where id = @cod;";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.Add("cod", NpgsqlTypes.NpgsqlDbType.Integer).Value = FrmConsulta.cod;
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
            // float sub = float.Parse(txt_valor.Text);
            cmd.Parameters.Add("data", NpgsqlTypes.NpgsqlDbType.Date).Value = mtxt_data.Text;
            cmd.Parameters.Add("ano", NpgsqlTypes.NpgsqlDbType.Numeric).Value = numericUpDown1.Value;
            cmd.Parameters.Add("qtde", NpgsqlTypes.NpgsqlDbType.Numeric).Value = qtde.Value;
            // int quantidade = (int)qtde.Value;

            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Doação cadastrada com sucesso!!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();





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
            if (radio_dinheiro.Checked == true)
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
