using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodProject
{
    public partial class frmPizzaCard : Form
    {
        public frmPizzaCard(string FirstName, string LastName, string Size, string Toppings, string CrustType, string WhereToEat, string Price)
        {
            InitializeComponent();
            InitializeStyle();
            lbFullName.Text = FirstName.Trim() + " " + LastName.Trim();
            lbSize.Text = Size;
            lbToppings.Text = Toppings;
            lbCrystType.Text = CrustType;
            lbWhereToEat.Text = WhereToEat;
            lbPrice.Text = Price;
        }

        private void InitializeStyle()
        {
            Styling.MakeButtonRounded(btnCancelCommand, 10);
            Styling.MakeButtonRounded(btnConfirmOrder, 10);
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Get a Set Number And Gave It With This Card To The Cachier.", "Dammand Accepted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelCommand_Click(object sender, EventArgs e)
        {
            var MessageBoxResult = MessageBox.Show("Are You Sure You Want To Cancel This Command.", "Command Cancel Request", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
            if (MessageBoxResult)
            {
                MessageBox.Show("Command Canceled.", "Cancel Command", MessageBoxButtons.OK);
                this.Close();
            }
            else
                MessageBox.Show("Command Does Not Canceled.");
        }
    }
}
