using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WATR_GUI
{
    public partial class WATRConfigurationForm : Form
    {
        //Keep track of the mage number, I'm doing this form barbaricly...
        int _pageNumber = 1;

        //Need the page anchor for the other pages when I show them
        Point pageAnchor = new Point(186, 12);

        public WATRConfigurationForm()
        {
            InitializeComponent();

            //Get port names on startup
            this.comboBox1.Items.AddRange(SerialPort.GetPortNames());

            //Reset the size of the form back to normal
            this.Size = new Size(702, 521);

            //Give all the pages their proper anchors
            page1.Location = pageAnchor;
            page2.Location = pageAnchor;
            finalPage.Location = pageAnchor;


            //Update the UI
            updateUI();
        }

        //Property for our other form to get the com port
        public string SelectedComPort
        {
            get
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    return comboBox1.Items[comboBox1.SelectedIndex].ToString();
                }
                else
                {
                    return " ";
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            //Increase the page number
            _pageNumber++;

            //Update the UI
            updateUI();
        }

        //handles most of the heavy work involved in the form
        private void updateUI()
        {
            //Select a page number, call the function of the page
            switch (_pageNumber)
            {
                case 1:
                    pageOne();
                    break;
                case 2:
                    pageTwo();
                    break;
                case 3:
                    lastPage();
                    break;
                default:
                    errorPage();
                    break;
            }

            //Parse the GUI buttons based on the page number
            if (_pageNumber > 1)
            {
                backButton.Enabled = true;
                if (_pageNumber == 3)
                {
                    nextButton.Visible = false;
                    finishButton.Location = nextButton.Location;
                    finishButton.Size = nextButton.Size;
                    finishButton.Visible = true;
                    finishButton.Enabled = true;
                }
                else
                {
                    nextButton.Visible = true;
                    finishButton.Visible = false;
                }
            }
            else
            {
                backButton.Enabled = false;
            }
        }

        private void pageOne()
        {
            page1.Visible = true;
            page2.Visible = false;
            finalPage.Visible = false;
        }

        private void pageTwo()
        {
            page1.Visible = false;
            page2.Visible = true;
            finalPage.Visible = false;
        }

        private void lastPage()
        {
            page1.Visible = false;
            page2.Visible = false;
            finalPage.Visible = true;
        }

        private void errorPage()
        {
            MessageBox.Show("How did you seriously fuck this up?", "WTF");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //I chose no fallback on the int subtraction here because the updateUI function
            //should prevent from this from EVER reaching either 0 or a negative number.

            //Decrease the page number
            _pageNumber--;

            //Update the GUI
            updateUI();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //Refresh the combo box by clearing the items and re-calling the getportnames function
            comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            //Close the form (finally)!
            this.Close();
        }
    }
}
