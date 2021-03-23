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
    public partial class Form2 : Form
    {
        private OleDbConnection connectionDB = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();
            
        }

        private void cleandata()  //CLEAR FUNCTION
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Refresh button
        {
            cleandata();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            connectionDB.ConnectionString = (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\drima\Documents\SOS_DB.mdb;
Persist Security Info=False");

            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox1.Text == "" || comboBox3.Text == "")  // ALL FIELDS * CONDITION
                MessageBox.Show("!!!!Preencha todos os campos com * !!!!");

            else
            {
                try
                {
                    string strline = comboBox3.Text.ToString();
                    string strEquip = comboBox1.Text.ToString();
                    string strDefect = comboBox2.Text.ToString();
                    string strData = dateTimePicker1.Text.ToString();
                    string strHour = textBox1.Text.ToString();
                    string strOBS = textBox2.Text.ToString();

                    connectionDB.Open();
                    OleDbCommand command = connectionDB.CreateCommand();
                    command.CommandType = CommandType.Text;                
                    command.CommandText = "insert into SOS_DB (LINE, EQUIP, DEFECT, DATAOPEN, HOUROPEN, OBS) VALUES ('"+ comboBox3.Text  + "', '" + strEquip + "','" + strDefect + "','" + strData + "','" + strHour + "','" + strOBS + "')";
                    command.ExecuteNonQuery();
                    connectionDB.Close();
                    MessageBox.Show("CHAMADO ABERTO COM SUCESSO!!!");
                    
                    cleandata();



                }
                catch (Exception exe)
                {
                    MessageBox.Show("ERROR" + exe);
                
                }

            }
        }
    }
}
