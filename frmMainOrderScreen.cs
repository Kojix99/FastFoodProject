/*
* Project: Fast Food Ordering System
* File: frmMainOrderScreen.cs
* Author: Sohail Zoraibi
* Date of Publication: July 21, 2025
* Description: 
*     Main entry form for the Fast Food Ordering System.
*     Allows users to enter their first and last name and begin an order.
*/


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
    public partial class frmMainOrderScreen : Form
    {
        public frmMainOrderScreen()
        {
            InitializeComponent();
            ApplyStyling();
        }

        private void ApplyStyling()
        {
            Styling.MakeButtonRounded(btnCommandNow, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = tbFirstName.Text.Trim();
            string LastName = tbLastName.Text.Trim();
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                tbFirstName.Text = string.Empty;
                tbLastName.Text = string.Empty;
                MessageBox.Show("You Need To Enter First Name and Second Name Before Continue.", "Informations Request.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Form MainMenuForm = new frmMenuOptions(FirstName, LastName);
                tbFirstName.Text = string.Empty;
                tbLastName.Text = string.Empty;
                MainMenuForm.Show();
            }
        }
    }
}