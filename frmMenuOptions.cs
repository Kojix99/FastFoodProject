using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodProject
{
    public partial class frmMenuOptions : Form
    {
        private string _FirstName;
        private string _LastName;
        public frmMenuOptions(string FirstName, string LastName)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            InitializeComponent();
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            Form PizzaForm = new frmPizza(_FirstName, _LastName);
            PizzaForm.Show();
            this.Close();
        }
    }
}
