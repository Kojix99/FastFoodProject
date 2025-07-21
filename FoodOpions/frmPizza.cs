using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodProject
{
    public partial class frmPizza : Form
    {
        private readonly string NULL_TOPPINGS = "No Toppings";
        private string _FirstName;
        private string _LastName;

        decimal _Price = new decimal();
        List<string> Toppings = new List<string>();

        public frmPizza(string firstName, string lastName)
        {
            InitializeComponent();
            ApplyStyling();
            InitializeDefault();
            _FirstName = firstName;
            _LastName = lastName;
        }

        public void InitializeDefault()
        {
            rbMedium.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;
        }

        private void ApplyStyling()
        {
            Styling.MakeButtonRounded(btnOrderPizza, 15);
            Styling.MakeButtonRounded(btnResetForm, 15);
        }

        private void PizzaPrice(RadioButton tempRadio)
        {
            if (tempRadio.Checked)
            {
                _Price += Convert.ToDecimal(tempRadio.Tag);
            }
            else
            {
                _Price -= Convert.ToDecimal(tempRadio.Tag);
            }
            lbPrice.Text = $"$ {_Price}";
        }

        private void AdjustTopppingsData(CheckBox tempCheckBox)
        {
            if(tempCheckBox.Checked)
            {
                Toppings.Add(tempCheckBox.Text);
                _Price += Convert.ToDecimal(tempCheckBox.Tag);
            }
            else
            {
                Toppings.Remove(tempCheckBox.Text);
                _Price -= Convert.ToDecimal(tempCheckBox.Tag);
            }
            lbPrice.Text = $"$ {_Price}";
        }

        private void DisplayToppings()
        {
            if (Toppings.Count == 0)
            {
                lbToppings.Text = NULL_TOPPINGS;
                return;
            }
            lbToppings.Text = string.Empty;
            for (int i = 0; i < Toppings.Count; i++)
            {
                lbToppings.Text += Toppings[i];

                if (i + 1 != Toppings.Count)
                {
                    lbToppings.Text += ',';
                }

                if((i + 1) % 2 == 0)
                {
                    lbToppings.Text += Environment.NewLine;
                }
            }
        }

        private void AdjustToppings(CheckBox tempCheckBox)
        {
            AdjustTopppingsData(tempCheckBox);
            DisplayToppings();
        }

        private void rSmall_CheckedChanged(object sender, EventArgs e)
        {
            PizzaPrice(rbSmall);
        }

        private void rMedium_CheckedChanged(object sender, EventArgs e)
        {
            PizzaPrice(rbMedium);
        }

        private void rLarg_CheckedChanged(object sender, EventArgs e)
        {
            PizzaPrice(rbLarge);
        }

        private void rThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            PizzaPrice(rbThinCrust);
        }

        private void rThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            PizzaPrice(rbThinkCrust);
        }

        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEatIn.Checked) lbWhereToEat.Text = rbEatIn.Text;
        }

        private void rdTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTakeOut.Checked) lbWhereToEat.Text = rbTakeOut.Text;
        }

        private void chbExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbExtraChees);
        }

        private void chbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbExtraChees);
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbTomatoes);
        }

        private void chbOnion_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbOnion);
        }

        private void chbOlives_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbOlives);
        }

        private void chbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            AdjustToppings(chbGreenPeppers);
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            rbMedium.Checked = true;
            rbThinCrust.Checked = true;
            chbExtraChees.Checked = false;
            chbMushrooms.Checked = false;
            chbTomatoes.Checked = false;
            chbOnion.Checked = false;
            chbOlives.Checked = false;
            chbGreenPeppers.Checked = false;
            rbEatIn.Checked = true;
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            Form PizzaCard = new frmPizzaCard(_FirstName, _LastName,lbSize.Text, lbToppings.Text, lbCrustType.Text, lbWhereToEat.Text, lbPrice.Text);
            PizzaCard.Show();
            this.Close();
        }
    }
}