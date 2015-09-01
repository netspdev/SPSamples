using System;
using System.Windows.Forms;

namespace Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EmployeesDataSet.Employees' table. You can move, or remove it, as needed.
            this.EmployeesTableAdapter.Fill(this.EmployeesDataSet.Employees);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void EmployeesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}