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
   
    public partial class FrmInicio : Form
    {
        public static string nome,sexo,tipo,login;
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public FrmInicio()
        {
            InitializeComponent();
            cn.ConnectionString = "Host=200.145.153.173;Database=72c_18_20_21;Username=a72c2016;Password=alunocti72c;";
            string comandoSQL = ("select login\"Nome de Usuário\",Nome\"Nome Completo\",sexo\"Sexo\",tipo\"Tipo do Usuário\" from usuario ORDER BY login;");




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

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.WindowState = FormWindowState.Maximized;
           

            



            string comandoSQL;
            comandoSQL = ("select nome,sexo,tipo,login from usuario where login=@login;");

            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(comandoSQL, cn);
            cmd.Parameters.Add("login", NpgsqlTypes.NpgsqlDbType.Text).Value = FrmLogin.login;
            NpgsqlDataReader dr = null;

          

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                sexo = dr["sexo"].ToString();
                tipo = dr["tipo"].ToString();
                login = dr["login"].ToString();
                    
                   
                    toolStripStatusLabel3.Text = nome;
                    toolStripStatusLabel1.Text = "(" + tipo + ")";
                    

                
                
                cn.Close();
                if(tipo == "Profissional")
                {
                    btn_add.Enabled = false;
                    dataGridView1.Visible = false;
                    groupBox4.Visible = false;
                    
                }
                if(tipo == "Visitante")
                {
                    btn_cadastra.BackColor = Color.White;
                    btn_cadastra.Enabled = false;
                    btn_add.Enabled = false;
                    dataGridView1.Visible = false;
                    groupBox4.Visible = false;

                }
            }
            
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            FrmLogin abrir = new FrmLogin();
            abrir.Visible = true;
            this.Visible = false;
            cn.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmCadastraUsu.visitante = false;
            FrmCadastraUsu abrir = new FrmCadastraUsu();
            abrir.Show();
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void FrmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Encerrar a Aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(0);
                FrmCadastraDoacao fechar = new FrmCadastraDoacao();
                fechar.Close();
                FrmConsulta fechar1 = new FrmConsulta();
                fechar1.Close();
                cn.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmAlterar abrir = new FrmAlterar();
            //abrir.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string login = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FrmAdmUsu abrir = new FrmAdmUsu(login);
            abrir.Show();
           
        }

        private void btn_perfil_Click(object sender, EventArgs e)
        {
            FrmMeuPerfil abrir = new FrmMeuPerfil(login);
            abrir.Show();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            FrmConsulta abrir = new FrmConsulta();
            abrir.Show();
        }

        private void btn_cadastra_Click(object sender, EventArgs e)
        {
            
            FrmCadastraDoacao abrir = new FrmCadastraDoacao();
            abrir.Show();
        }

        

      
    }
}
