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

namespace Parking
{
    public partial class Form1 : Form
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }
        //public System.Windows.Forms.ComboBox.ObjectCollection Items { get; }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            actualizaDatos();

            con = new SqlConnection("server=DESKTOP-ENVH225; Initial Catalog=autos;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Marca";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Nombre"]);
            }
            con.Close();

        }
        
        private void actualizaDatos()
        {
            con = new SqlConnection("server=DESKTOP-ENVH225; Initial Catalog=autos;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT id_registro, Placa, Tipo, Entrada, costoTotal FROM Registro WHERE isInside=1";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=DESKTOP-ENVH225; Initial Catalog=autos;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Registro (isInside, Placa, Entrada, Tipo) VALUES ('" + 1 + "','" + textBoxPlaca.Text + "','" + DateTime.Now.ToShortTimeString() + "','" + comboBoxTipo.SelectedItem.ToString()+ "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registrado", "Auto entrando", MessageBoxButtons.OK);
            clearFields();
            actualizaDatos();
        }
        private void clearFields()
        {
            textBoxPlaca.Clear();
            //textBoxColor.Clear();
            comboBox1.SelectedIndex = -1;
            comboBoxTipo.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            comboBoxTipo.ResetText();
            textBoxPlaca.Text = dataGridView1.SelectedCells[1].Value.ToString();
            //comboBox1.SelectedText = dataGridView1.SelectedCells[3].Value.ToString();            
            comboBoxTipo.SelectedText = dataGridView1.SelectedCells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentId = 0;
            string startTimeStr;
            DateTime startTime;
            DateTimeConverter convertir = new DateTimeConverter();
           
            con = new SqlConnection("server=DESKTOP-ENVH225; Initial Catalog=autos;Integrated Security=SSPI");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            currentId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            cmd.CommandText = "UPDATE Registro SET isInside=0, Salida='" + DateTime.Now.ToShortTimeString() + "'WHERE id_registro='" + dataGridView1.SelectedCells[0].Value + "'";
            cmd.ExecuteNonQuery();
            //cmd.CommandText= "SELECT Entrada FROM Registro WHERE id_registro='" + currentId + "'";
            //startTimeStr = Convert.ToString(cmd.ExecuteNonQuery());
            //Console.WriteLine(startTimeStr);
            //startTime = (DateTime)convertir.ConvertFromString(startTimeStr);
            //MessageBox.Show(startTime.ToShortTimeString());
            con.Close();
            MessageBox.Show("Registrado", "Costo a pagar: ", MessageBoxButtons.OK);
            currentId = 0;
            clearFields();
            actualizaDatos();
        }
    }
}
