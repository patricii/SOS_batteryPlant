//**********************************************************************************************************//
//**********************************************************************************************************//
//*******************************Developed by Adriano Patricio Nov 2019*************************************//
//**********************************************************************************************************//
//**********************************************************************************************************//


using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb; // Database

namespace SOS_Battery_Plant
{
    public partial class Form3 : Form
    {

        private OleDbConnection connectionDB = new OleDbConnection();
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)  //LISTA DE O.S
        {
            connectionDB.ConnectionString = (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\drima\Documents\SOS_DB.mdb;
Persist Security Info=False");

            connectionDB.Open();
            OleDbCommand command = connectionDB.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = " SELECT * FROM SOS_DB";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter DBSOS = new OleDbDataAdapter(command);
            DBSOS.Fill(dt);
            dataGridView1.DataSource = dt;
            connectionDB.Close();
            MessageBox.Show("LISTA DE O.S ATUALIZADA COM SUCESSO!!!");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();

        }

        private void button4_Click(object sender, EventArgs e) //EXIT BUTTON
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //CLOSE O.S BUTTON
        {
            connectionDB.ConnectionString = (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\drima\Documents\SOS_DB.mdb;
Persist Security Info=False");


            if (comboBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "")
                MessageBox.Show(" Preencha todos os campos !!!");

            else
            {

                try
                {
                    OleDbDataAdapter DBS = new OleDbDataAdapter();

                    connectionDB.Open();

                    string query = "UPDATE [SOS_DB] SET [STATUS] = ? WHERE id = ?";
                    string query2 = "UPDATE [SOS_DB] SET [HOURCLOSE] = ? WHERE id = ?";
                    string query3 = "UPDATE [SOS_DB] SET [OBS2] = ? WHERE id = ?";
                    var accessUpdateCommand = new OleDbCommand(query, connectionDB);
                    accessUpdateCommand.Parameters.AddWithValue("STATUS", comboBox1.Text);
                    accessUpdateCommand.Parameters.AddWithValue("ID", textBox1.Text);
                    DBS.UpdateCommand = accessUpdateCommand;
                    DBS.UpdateCommand.ExecuteNonQuery();

                    var accessUpdateCommand2 = new OleDbCommand(query2, connectionDB);
                    accessUpdateCommand2.Parameters.AddWithValue("HOURCLOSE", textBox3.Text);
                    accessUpdateCommand2.Parameters.AddWithValue("ID", textBox1.Text);
                    DBS.UpdateCommand = accessUpdateCommand2;
                    DBS.UpdateCommand.ExecuteNonQuery();


                    var accessUpdateCommand3 = new OleDbCommand(query3, connectionDB);
                    accessUpdateCommand3.Parameters.AddWithValue("OBS2", textBox2.Text);
                    accessUpdateCommand3.Parameters.AddWithValue("ID", textBox1.Text);
                    DBS.UpdateCommand = accessUpdateCommand3;
                    DBS.UpdateCommand.ExecuteNonQuery();


                    connectionDB.Close();
                    MessageBox.Show("O.S FECHADA COM SUCESSO!!!");

                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR" + ex);
                }
            }

        }
    }
}
