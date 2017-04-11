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
    public partial class FrmCadastraUsu : Form
    {
        public string senha_crip;
        public static Boolean visitante;
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public static string login;

        public static FrmCadastraUsu abrir = new FrmCadastraUsu();
        public FrmCadastraUsu()
        {
            InitializeComponent();
            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
        }

        private void button1_Click(object sender, EventArgs e)
        {




            
            string comandoSQL;
            comandoSQL = ("select login,senha from usuario where login=@login;");


            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_usu.Text;
            NpgsqlDataReader dr = null;



            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                login = dr["login"].ToString();
                
            }
            cn.Close();
            if (txt_usu.Text == login)
            {

                MessageBox.Show("Nome de usuário já existe!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txt_senha.Text != conf_senha.Text)
            {
                MessageBox.Show("Senhas não conferem!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(txt_nome.Text == "" || txt_senha.Text == "" || conf_senha.Text =="" || txt_usu.Text =="" || cmb_tipo.Text =="" || cmb_sexo.Text =="")
            {
                MessageBox.Show("Preencha todos os campos!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                if (visitante == false)
                {
                    cn.Open();


                    string sql = "INSERT INTO usuario (login,senha,nome,sexo,tipo) VALUES (@login,@senha,@nome,@sexo,@tipo);";
                    NpgsqlCommand inserir = new NpgsqlCommand(sql, cn);


                    inserir.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_usu.Text;
                    senha_crip = txt_senha.Text;
                    crip(senha_crip);
                    inserir.Parameters.Add("senha", NpgsqlTypes.NpgsqlDbType.Text).Value = senha_crip;
                    inserir.Parameters.Add("nome", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_nome.Text;
                    inserir.Parameters.Add("sexo", NpgsqlTypes.NpgsqlDbType.Text).Value = cmb_sexo.Text;
                    inserir.Parameters.Add("tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = cmb_tipo.Text;
                    inserir.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Usuário adicionado com sucesso!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_nome.Clear();
                    txt_senha.Clear();
                    conf_senha.Clear();
                    txt_usu.Clear();
                    cmb_sexo.ResetText();
                    cmb_tipo.ResetText();
                }
                else if (visitante == true)
                {
                    cn.Open();


                    string sql = "INSERT INTO usuario (login,senha,nome,sexo,tipo) VALUES (@login,@senha,@nome,@sexo,@tipo);";
                    NpgsqlCommand inserir = new NpgsqlCommand(sql, cn);


                    inserir.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_usu.Text;
                    senha_crip = txt_senha.Text;
                    crip(senha_crip);
                    inserir.Parameters.Add("senha", NpgsqlTypes.NpgsqlDbType.Text).Value = senha_crip;
                    inserir.Parameters.Add("nome", NpgsqlTypes.NpgsqlDbType.Text).Value = txt_nome.Text;
                    inserir.Parameters.Add("sexo", NpgsqlTypes.NpgsqlDbType.Text).Value = cmb_sexo.Text;
                    inserir.Parameters.Add("tipo", NpgsqlTypes.NpgsqlDbType.Text).Value = cmb_tipo.Text;
                    inserir.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Usuário adicionado com sucesso!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_nome.Clear();
                    txt_senha.Clear();
                    conf_senha.Clear();
                    txt_usu.Clear();
                    cmb_sexo.ResetText();
                    cmb_tipo.ResetText();

                    
                    MessageBox.Show("Estamos te redirecionando para o form de login!", "Faça o login novamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }    
                
            }
            cn.Close();

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
       

        private void button2_Click(object sender, EventArgs e)
        {
            txt_nome.Clear();
            txt_senha.Clear();
            conf_senha.Clear();
            txt_usu.Clear();
            cmb_sexo.ResetText();
            cmb_tipo.ResetText();
            cn.Close();
            if (MessageBox.Show("Deseja fechar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();


            }
            else
            {

                FrmCadastraUsu fechar = new FrmCadastraUsu();
                fechar.Close();
            }
        }

        private void FrmCadastraUsu_Load(object sender, EventArgs e)
        {
            if(visitante == true)
            {
                visitante = true;
                cmb_tipo.Text = "Visitante";
                cmb_tipo.Enabled = false;
                
               


            }
            else if(visitante == false)
            {
                visitante = false;
                cmb_tipo.ResetText();
                cmb_tipo.Enabled = true;
            }
        }
    }
}
