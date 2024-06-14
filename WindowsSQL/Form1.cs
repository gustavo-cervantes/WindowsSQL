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


namespace WindowsSQL
{

    public partial class Form1 : Form
    {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=gustavoroldao;Database=CadastroDB;";


        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO cadastro (texto, numero) VALUES (@texto, @numero)", conn))
                {
                    cmd.Parameters.AddWithValue("texto", txtTexto.Text);
                    cmd.Parameters.AddWithValue("numero", int.Parse(txtNumero.Text));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE cadastro SET texto = @texto WHERE numero = @numero", conn))
                {
                    cmd.Parameters.AddWithValue("texto", txtTexto.Text);
                    cmd.Parameters.AddWithValue("numero", int.Parse(txtNumero.Text));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM cadastro WHERE numero = @numero", conn))
                {
                    cmd.Parameters.AddWithValue("numero", int.Parse(txtNumero.Text));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
