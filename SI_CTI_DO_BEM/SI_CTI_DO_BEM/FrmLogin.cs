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
using System.Security.Cryptography;

namespace CadastroDoacoes
{
    public partial class FrmLogin : Form
    {
       
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public static string login;
        public static string senha;
        public static string senha_crip;


        public FrmLogin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            


            login = txt_nome.Text;
            string comandoSQL;
            comandoSQL = ("select login,senha from usuario where login=@login;");


            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = login;
            NpgsqlDataReader dr = null;

            

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                login = dr["login"].ToString();
                senha = dr["senha"].ToString();
                
            }
            senha_crip = txt_senha.Text;
            crip(senha_crip);
            if (txt_nome.Text == login && senha_crip == senha)
            {
                this.Visible = false;
                FrmInicio abrir = new FrmInicio();
                abrir.Show();
                
                
            }
            else if (txt_nome.Text != login || senha_crip != senha)
            {
                MessageBox.Show("Nome de usuário ou senha incorreta!", "SI - CTI DO BEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();



        }

        public void crip(string senh)
        {
            MD5 senhaHash = MD5.Create();
            Byte[] vetorHash = senhaHash.ComputeHash(Encoding.Default.GetBytes(senh));
            StringBuilder stringHash = new StringBuilder();
            for (int i = 0; i < vetorHash.Length; i++)
                stringHash.Append(vetorHash[i].ToString("x2"));
            senha_crip = stringHash.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            label3.Text = "Você pode se cadastrar como visitante e você terá acesso\n a todos os dados, poderá fazer consultas e impressões.";



        }

       

       

        private void txt_senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_entrar.PerformClick();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmCadastraUsu.visitante = true;
            FrmCadastraUsu abrir = new FrmCadastraUsu();
            abrir.Show();
        }
    }
}
