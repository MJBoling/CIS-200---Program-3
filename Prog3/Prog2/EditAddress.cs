using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp

{
    public partial class EditAddress : Form
    {
        private List<Address> addressList;
        public const int MIN_ADDRESSES = 1;
        public const int index = -1;

        public EditAddress(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        internal int AddressCBIndex
        {
            get
            {
                return comboBox1.SelectedIndex;
            }

            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    comboBox1.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("DestinationAddressIndex", value,
                        "Index must be valid");
            }
        }

        private void EditAddress_Load(object sender, EventArgs e)
        {
            if (addressList.Count < MIN_ADDRESSES)
            {
                MessageBox.Show("To edit an address, there must be at least one address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                foreach (Address a in addressList)
                {
                    comboBox1.Items.Add(a.Name);
                }
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                errorProvider1.SetError(comboBox1, "You must select an address!");
                e.Cancel = true;
            }
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                errorProvider1.SetError(comboBox1, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                index = comboBox1.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                /**AddressForm addressForm = new AddressForm();
                DialogResult result = addressForm.ShowDialog();
             
                
                if (result == DialogResult.OK)
                {

                }**/
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
