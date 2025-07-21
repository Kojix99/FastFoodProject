//This isn't My Library i just get it from GitHub

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastFoodProject
{
    public static class Styling
    {
        #region Button Styling

        /// <summary>
        /// Makes a button have rounded corners
        /// </summary>
        /// <param name="button">The button to round</param>
        /// <param name="radius">Corner radius (default: 15)</param>
        public static void MakeButtonRounded(Button button, int radius = 15)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Applies modern styling to a button (rounded + colors)
        /// </summary>
        /// <param name="button">Button to style</param>
        /// <param name="backColor">Background color</param>
        /// <param name="foreColor">Text color</param>
        /// <param name="radius">Corner radius</param>
        public static void ApplyModernButtonStyle(Button button, Color backColor, Color foreColor, int radius = 15)
        {
            MakeButtonRounded(button, radius);
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Quick styling presets for common button types
        /// </summary>
        public static void ApplyPrimaryButtonStyle(Button button, int radius = 15)
        {
            ApplyModernButtonStyle(button, Color.FromArgb(41, 128, 185), Color.White, radius); // Blue
        }

        public static void ApplySuccessButtonStyle(Button button, int radius = 15)
        {
            ApplyModernButtonStyle(button, Color.FromArgb(46, 204, 113), Color.White, radius); // Green
        }

        public static void ApplyDangerButtonStyle(Button button, int radius = 15)
        {
            ApplyModernButtonStyle(button, Color.FromArgb(231, 76, 60), Color.White, radius); // Red
        }

        public static void ApplyWarningButtonStyle(Button button, int radius = 15)
        {
            ApplyModernButtonStyle(button, Color.FromArgb(241, 196, 15), Color.White, radius); // Yellow/Orange
        }

        public static void ApplySecondaryButtonStyle(Button button, int radius = 15)
        {
            ApplyModernButtonStyle(button, Color.FromArgb(108, 122, 137), Color.White, radius); // Gray
        }

        #endregion

        #region TextBox Styling

        /// <summary>
        /// Makes a TextBox have rounded corners
        /// </summary>
        /// <param name="textBox">The TextBox to round</param>
        /// <param name="radius">Corner radius (default: 10)</param>
        public static void MakeTextBoxRounded(TextBox textBox, int radius = 10)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(textBox.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(textBox.Width - radius, textBox.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, textBox.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            textBox.Region = new Region(path);
            textBox.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Applies modern styling to a TextBox (rounded + colors)
        /// </summary>
        /// <param name="textBox">TextBox to style</param>
        /// <param name="backColor">Background color</param>
        /// <param name="foreColor">Text color</param>
        /// <param name="radius">Corner radius</param>
        public static void ApplyModernTextBoxStyle(TextBox textBox, Color backColor, Color foreColor, int radius = 10)
        {
            MakeTextBoxRounded(textBox, radius);
            textBox.BackColor = backColor;
            textBox.ForeColor = foreColor;
            textBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            // Add some padding by setting the margin
            textBox.Padding = new Padding(5);
        }

        /// <summary>
        /// Applies default modern styling to a TextBox
        /// </summary>
        /// <param name="textBox">TextBox to style</param>
        /// <param name="radius">Corner radius</param>
        public static void ApplyDefaultTextBoxStyle(TextBox textBox, int radius = 10)
        {
            ApplyModernTextBoxStyle(textBox, Color.White, Color.FromArgb(52, 73, 94), radius);
        }

        #endregion

        #region Form Styling

        /// <summary>
        /// Applies modern styling to a form
        /// </summary>
        public static void ApplyModernFormStyle(Form form)
        {
            form.BackColor = Color.FromArgb(236, 240, 241); // Light gray background
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        /// <summary>
        /// Rounds all buttons in a form automatically
        /// </summary>
        /// <param name="form">The form containing buttons</param>
        /// <param name="radius">Corner radius for all buttons</param>
        public static void RoundAllButtons(Form form, int radius = 15)
        {
            foreach (Control control in GetAllControls(form))
            {
                if (control is Button button)
                {
                    MakeButtonRounded(button, radius);
                }
            }
        }

        /// <summary>
        /// Rounds all TextBoxes in a form automatically
        /// </summary>
        /// <param name="form">The form containing TextBoxes</param>
        /// <param name="radius">Corner radius for all TextBoxes</param>
        public static void RoundAllTextBoxes(Form form, int radius = 10)
        {
            foreach (Control control in GetAllControls(form))
            {
                if (control is TextBox textBox)
                {
                    MakeTextBoxRounded(textBox, radius);
                }
            }
        }

        /// <summary>
        /// Applies modern styling to all controls in a form
        /// </summary>
        /// <param name="form">The form to style</param>
        /// <param name="buttonRadius">Corner radius for buttons</param>
        /// <param name="textBoxRadius">Corner radius for TextBoxes</param>
        public static void ApplyModernStyleToAll(Form form, int buttonRadius = 15, int textBoxRadius = 10)
        {
            ApplyModernFormStyle(form);

            foreach (Control control in GetAllControls(form))
            {
                if (control is Button button)
                {
                    MakeButtonRounded(button, buttonRadius);
                }
                else if (control is TextBox textBox)
                {
                    ApplyDefaultTextBoxStyle(textBox, textBoxRadius);
                }
            }
        }

        // Helper method to get all controls recursively (including those in panels, groupboxes, etc.)
        private static System.Collections.Generic.IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = new System.Collections.Generic.List<Control>();
            foreach (Control control in container.Controls)
            {
                controls.Add(control);
                controls.AddRange(GetAllControls(control));
            }
            return controls;
        }

        #endregion

        #region Panel and Control Styling

        /// <summary>
        /// Makes a panel have rounded corners
        /// </summary>
        public static void MakePanelRounded(Panel panel, int radius = 10)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        /// <summary>
        /// Applies card-like styling to a panel
        /// </summary>
        public static void ApplyCardStyle(Panel panel, int radius = 10)
        {
            MakePanelRounded(panel, radius);
            panel.BackColor = Color.White;
            // Note: Drop shadow would require custom painting
        }

        #endregion
    }
}