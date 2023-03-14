using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_SGBD
{
    public partial class Form1 : Form
    {
        SqlConnection cs = new SqlConnection("Data Source = DESKTOP-DV079PR\\SQLEXPRESS;" +
            " Initial Catalog = Bolt_Food; Integrated Security = True");
        SqlDataAdapter da = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            da.SelectCommand = new SqlCommand("SELECT * FROM Meniu", cs);
            ds.Clear();
            da.Fill(ds);
            dataGridViewParent.DataSource = ds.Tables[0];
            bs.DataSource = ds.Tables[0];
            //txtFirstName.DataBindings.Add("Text", bs, "FirstName");
            //txtLastName.DataBindings.Add("Text", bs, "LastName");
            // Conection between texbox and the record from the Binding Source
            //last parameter is the name of the field of the table.
            // always will be inserted the first line in the TextBox-es
            // to move to next rows or others, can be use the methods MoveFirst(), MoveNext(), MovePrevious(),
            bs.MoveLast();
            // there is no need to populate the Text Box-es for each method, because it works automattically
        }

        private void dataGridViewParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewParent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;


            string Id_Meniu = dataGridViewParent.Rows[e.RowIndex].Cells[0].Value.ToString();


            //Fel_De_Mancare
            BindingSource bs = new BindingSource();
            da.SelectCommand = new SqlCommand("SELECT * from Fel_De_Mancare " +
                    "where Fel_De_Mancare.Id_Meniu = " + Id_Meniu + "; ", cs);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            dataGridViewChild.DataSource = ds.Tables[0];
            bs.DataSource = ds.Tables[0];
        }
    }
}