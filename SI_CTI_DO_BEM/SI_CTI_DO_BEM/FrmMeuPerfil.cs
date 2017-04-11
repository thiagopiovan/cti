using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDoacoes
{
    public partial class FrmMeuPerfil : Form
    {
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public string login, senha, nome, sexo,senha_crip;
        public static Boolean nt = true;
        public static Boolean cript = false;
        public static Boolean testa = false;

        public static string ususexist;

        public FrmMeuPerfil(string loginnn)
        {
            InitializeComponent();




            string comandoSQL;
            comandoSQL = ("select nome,sexo,tipo,login,senha from usuario where login=@login;");
            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            NpgsqlDataReader dr = null;
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = loginnn;

            dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                txt_nome.Text = dr["nome"].ToString();
                cmb_sexo.Text = dr["sexo"].ToString();
                cmb_tipo.Text = dr["tipo"].ToString();
                txt_senha.Text = dr["senha"].ToString();
                conf_senha.Text = dr["senha"].ToString();
                txt_usu.Text = dr["login"].ToString();
                login = dr["login"].ToString();
                senha = dr["senha"].ToString();
                nome = dr["nome"].ToString();
                sexo = dr["sexo"].ToString();
            }


            cn.Close();
        }

        private void btn_senha_Click(object sender, EventArgs e)
        {
            cript = true;
            btn_senha.Visible = false;
            txt_senha.Visible = true;
            txt_senha.Text = "";
            conf_senha.Text = "";
            conf_senha.Visible = true;
            label4.Visible = true;
            conf_senha.Visible = true;
            label4.Visible = true;
            txt_senha.Enabled = true;

        }

        private void btn_usu_Click(object sender, EventArgs e)
        {
            testa = true;
            txt_usu.Enabled = true;

        }

        private void btn_tipo_Click(object sender, EventArgs e)
        {
            cmb_tipo.Enabled = true;
        }

        private void btn_nome_Click(object sender, EventArgs e)
        {
            cmb_sexo.Enabled = true;
            txt_nome.Enabled = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //if()
            string comandoSQL;
            comandoSQL = ("select login,senha from usuario where login=@login;");


            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_usu.Text;
            NpgsqlDataReader dr = null;



            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ususexist = dr["login"].ToString();

            }
            cn.Close();
            
            if (txt_usu.Text == ususexist && testa == true)
            {
                MessageBox.Show("Nome de usuário já existe!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txt_senha.Text == conf_senha.Text)
                {
                    nt = false;
                    cn.Open();


                    string sql = "UPDATE usuario SET login=@loginn,senha=@senhaa,nome=@nome,sexo=@sexo where login = @loginatual;";
                    NpgsqlCommand alterar = new NpgsqlCommand(sql, cn);

                    alterar.Parameters.Add("nome", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_nome.Text;
                    alterar.Parameters.Add("sexo", NpgsqlTypes.NpgsqlDbType.Text).Value = cmb_sexo.Text;
                    alterar.Parameters.Add("loginn", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_usu.Text;
                    if (cript == true)
                    {
                        senha_crip = txt_senha.Text;
                        crip(senha_crip);
                        alterar.Parameters.Add("senhaa", NpgsqlTypes.NpgsqlDbType.Text).Value = senha_crip;
                    }
                    if (cript == false)
                    {
                        alterar.Parameters.Add("senhaa", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_senha.Text;
                    }

                    
                    alterar.Parameters.Add("loginatual", NpgsqlTypes.NpgsqlDbType.Text).Value = login;
                    alterar.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Dados alterados com sucesso!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_senha.Enabled = false;
                    txt_usu.Enabled = false;
                    MessageBox.Show("Estamos te redirecionando para o form de login!", "Faça o login novamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmInicio fechar1 = new FrmInicio();
                    fechar1.Close();
                    FrmMeuPerfil fechar = new FrmMeuPerfil("");
                    fechar.Close();
                    FrmLogin abrir = new FrmLogin();
                    abrir.Show();
                }
                else
                {
                    nt = true;
                    MessageBox.Show("Senhas não conferem!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }






        }
        public void crip(string senha)
        {
            MD5 senhaHash = MD5.Create();
            Byte[] vetorHash = senhaHash.ComputeHash(Encoding.Default.GetBytes(senha));
            StringBuilder stringHash = new StringBuilder();
            for (int i = 0; i < vetorHash.Length; i++)
                stringHash.Append(vetorHash[i].ToString("x2"));
            senha_crip = stringHash.ToString();
        }

        private void FrmMeuPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (MessageBox.Show("Deseja fechar sem alterar?", "SI - CTI DO BEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                FrmMeuPerfil fechar = new FrmMeuPerfil("");
                fechar.Close();

                cn.Close();
            }
            else
            {
                e.Cancel = true;
            }



        }

        private void txt_usu_TextChanged(object sender, EventArgs e)
        {
            if (txt_usu.Text == login || txt_senha.Text == senha || cmb_sexo.Text == sexo || txt_nome.Text == nome)
            {
                button1.Enabled = true;
            }

        }

        private void txt_usu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            if (txt_usu.Text == login || txt_senha.Text == senha || cmb_sexo.Text == sexo || txt_nome.Text == nome)
            {
                button1.Enabled = true;
            }
        }

        private void cmb_sexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_usu.Text == login || txt_senha.Text == senha || cmb_sexo.Text == sexo || txt_nome.Text == nome)
            {
                button1.Enabled = true;
            }
        }





        private void conf_senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            cmb_sexo.Enabled = true;

        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {

            if (txt_usu.Text == login || txt_senha.Text == senha || cmb_sexo.Text == sexo || txt_nome.Text == nome)
            {
                button1.Enabled = true;
            }
        }
    }
}
