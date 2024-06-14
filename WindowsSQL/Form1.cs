using Npgsql;
using System;
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

        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o número já existe na tabela antes de inserir
                if (NumeroJaExiste(int.Parse(txtNumero.Text)))
                {
                    MessageBox.Show("Não foi possível realizar o seu registro, pois o número já existe na tabela. Por favor, insira um número válido.", "Número já Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("INSERT INTO cadastro (texto, numero) VALUES (@texto, @numero)", conn))
                    {
                        cmd.Parameters.AddWithValue("texto", txtTexto.Text);
                        cmd.Parameters.AddWithValue("numero", int.Parse(txtNumero.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro inserido com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar inserir o registro: {ex.Message}", "Erro de Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool NumeroJaExiste(int numero)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM cadastro WHERE numero = @numero", conn))
                {
                    cmd.Parameters.AddWithValue("numero", numero);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("UPDATE cadastro SET texto = @texto WHERE numero = @numero", conn))
                    {
                        cmd.Parameters.AddWithValue("@texto", txtTexto.Text);
                        cmd.Parameters.AddWithValue("@numero", int.Parse(txtNumero.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registro atualizado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM cadastro WHERE numero = @numero", conn))
                    {
                        cmd.Parameters.AddWithValue("@numero", int.Parse(txtNumero.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Registro deletado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtTexto.Text = "";
            txtNumero.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aqui você pode carregar dados iniciais ou configurar o formulário
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
