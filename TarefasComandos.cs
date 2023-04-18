using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaSQLPOO
{
    internal class TarefasComandos
    {
        MySqlCommand comandos = new MySqlCommand();

        ConectarBD con = new ConectarBD();

        public void exibirTarefas(ListView listaTarefas)
        {
            string sql = "select * from tarefas";

            comandos.CommandText = sql;

            try
            {
                comandos.Connection = con.conectar();

                MySqlDataReader reader = comandos.ExecuteReader();

                listaTarefas.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1)
                    };

                    var linha_listview = new ListViewItem(row);
                    listaTarefas.Items.Add(linha_listview);
                }
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.desconectar();
            }

        }

        public void adicionarTarefa(string conteudo, ListView listaTarefas)
        {
            string sql = $"insert into tarefas (conteudo) values ('{conteudo}')";

            comandos.CommandText = sql;

            try
            {
                comandos.Connection = con.conectar();
                comandos.ExecuteReader();

            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Tarefa Adicionada");
                con.desconectar();
                exibirTarefas(listaTarefas);
            }
        }

        public void excluirTarefa(int id, ListView listaTarefas)
        {
            string sql = $"delete from tarefas where tarefa_id = {id}";

            comandos.CommandText = sql;

            try
            {
                comandos.Connection = con.conectar();
                comandos.ExecuteReader();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //MessageBox.Show("Tarefa Excluida");
                con.desconectar();
                exibirTarefas(listaTarefas);
            }
        }

        //TODO comando para atualizar a tarefa que ja esta salva no banco
        public void atualizarTarefa(string conteudo, int Id, ListView listaTarefas)
        {
            string sql = $"update tarefas set conteudo = '{conteudo}' where tarefa_id = {Id}";

            comandos.CommandText = sql;

            try 
            {
                comandos.Connection = con.conectar();
                comandos.ExecuteReader();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.desconectar();
                exibirTarefas(listaTarefas);
            }
        }
    }
}
