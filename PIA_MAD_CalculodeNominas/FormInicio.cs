using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormInicio : Form
    {

        private NominasDAL dal = new NominasDAL();


        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {


        }


        
        private void gbAnuncio_Enter(object sender, EventArgs e)
        {
        }
    }
}