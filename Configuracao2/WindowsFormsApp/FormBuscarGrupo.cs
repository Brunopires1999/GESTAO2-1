﻿using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormBuscarGrupo : Form
    {
        public FormBuscarGrupo()
        {
            InitializeComponent();
        }

        private void buttonBuscarGrupo_Click(object sender, EventArgs e)
        {
            try
            {

                    GrupoUsuarioBLL grupoUsuarioBLL = new GrupoUsuarioBLL();
                if (radioButtonBuscarTodos.Checked)
                {

                    grupoUsuarioBindingSource.DataSource = grupoUsuarioBLL.BuscarTodosGrupos();
                }
                else if (radioButtonBuscarNome.Checked)
                {

                    grupoUsuarioBindingSource.DataSource = grupoUsuarioBLL.BuscarGrupoPorNome(textBox1.Text);
                }
                else if (radioButtonBuscarID.Checked)
                {
                    grupoUsuarioBindingSource.DataSource = grupoUsuarioBLL.BuscarGrupoPor_Id(Convert.ToInt32(textBox1.Text));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonAdicionarGrupo_Click(object sender, EventArgs e)
        {
            using(FormCadastrarGrupo frm = new FormCadastrarGrupo())
            {
                frm.ShowDialog();
            }
        }
    }
}
