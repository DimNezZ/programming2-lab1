using Buyer;

namespace BuyerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            loyaltyCardNumberTextBox.Controls.RemoveAt(0);
            numericUpDown2.Controls.RemoveAt(0);
            numericUpDown3.Controls.RemoveAt(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showInformation();
        }

        private void showInformation()
        {
            Customer customer = new Customer(nameTextBox.Text, homeAddressTextBox.Text, (int)loyaltyCardNumberTextBox.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value);

            richTextBox1.Text = customer.GetInformation();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            showInformation();
        }

        private void homeAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            showInformation();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bool isDiscountEnabled = loyaltyCardNumberTextBox.Value != -1;
            numericUpDown2.Enabled = isDiscountEnabled;
            trackBar1.Enabled = isDiscountEnabled;

            if (!isDiscountEnabled)
            {
                numericUpDown2.Value = 0;
            }

            showInformation();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(numericUpDown2.Value * 10);

            showInformation();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = new decimal(trackBar1.Value / 10.0);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            showInformation();
        }
    }
}