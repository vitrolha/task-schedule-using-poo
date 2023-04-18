using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaSQLPOO
{
    public partial class Form1 : Form
    {

        TarefasComandos comandos = new TarefasComandos();
        
        public Form1()
        {
            InitializeComponent();

            listaTarefas.View = View.Details;
            listaTarefas.LabelEdit = true;
            listaTarefas.AllowColumnReorder = true;
            listaTarefas.FullRowSelect = true;
            listaTarefas.GridLines = true;

            listaTarefas.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listaTarefas.Columns.Add("Tarefa", 500, HorizontalAlignment.Left);

            comandos.exibirTarefas(listaTarefas);
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if(txtBox_AdicionarTarefas.Text != "")
            {
                try
                {
                    comandos.adicionarTarefa(txtBox_AdicionarTarefas.Text, listaTarefas);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Escreva alguma tarefa");
            }
            
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Deseja realmente Excluir a tarefa?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    if (listaTarefas.SelectedItems.Count > 0)
                    {   
                        // Obtém a linha selecionada
                        ListViewItem linhaSelecionada = listaTarefas.SelectedItems[0];

                        // Obtém o valor da coluna "Id"
                        int Id = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);

                        comandos.excluirTarefa(Id,listaTarefas);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //comandos.exibirTarefas(listaTarefas);
                }
                
            }
            
        }

        //TODO botão de atualizar e suas funções
        private void btn_Atualizar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Deseja realmente Atualizar a tarefa?", "Atualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if(confirmar == DialogResult.Yes)
            {
                if(txtBox_AdicionarTarefas.Text != "")
                {
                    try
                    {
                        if(listaTarefas.SelectedItems.Count > 0)
                        {
                            // Obtém a linha selecionada
                            ListViewItem linhaSelecionada = listaTarefas.SelectedItems[0];

                            // Obtém o valor da coluna "Id"
                            int Id = Convert.ToInt32(linhaSelecionada.SubItems[0].Text);

                            comandos.atualizarTarefa(txtBox_AdicionarTarefas.Text, Id, listaTarefas);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Escreva algo para Atualizar");
                }
            }
        }
        
    }
}
