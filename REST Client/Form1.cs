using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace REST_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //creates a new instance of the restClient class
            restClient rClient = new restClient();
            //Set a variable within the class to be equal to the text in the URL textbox
            rClient.endPoint = txtUrl.Text;

            //Create a string
            string strResponse = string.Empty;
            //Make the variable equal to the value returned from rClient's makeRequest funtion
            strResponse = rClient.makeRequest();

            //Dsiplay strResponse in the response textbox
            txtResponse.Text = strResponse;
        }
    }
}
