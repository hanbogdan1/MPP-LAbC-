using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P3_Mpp_Lab1.Cntrl;
using P3_Mpp_Lab1.Domain;
using System.Data.SQLite;

namespace P3_Mpp_Lab1
{
    public partial class Admin_window : Form
    {
        private Controller contrl;

        public Admin_window()
        {
            this.contrl = new Controller();
            InitializeComponent();
            load_data();
            combo_box_spinner_initialize();
            
        }

        private void combo_box_spinner_initialize()
        {
            comboBoxDistanta.Items.Add("50");
            comboBoxDistanta.Items.Add("200");
            comboBoxDistanta.Items.Add("800");
            comboBoxDistanta.Items.Add("1500");

            comboBoxStil.Items.Add("liber");
            comboBoxStil.Items.Add("spate");
            comboBoxStil.Items.Add("fluture");
            comboBoxStil.Items.Add("mixt");

            numericUpDownVarsta.Minimum = 18;
            numericUpDownVarsta.Maximum = 75;
            numericUpDownVarsta.Increment = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

            //contrl.get_participanti_probe(comboBoxStil.SelectedText.ToString, comboBoxStil.SelectedText.ToString()){

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = DBUtils.DBUtils.getConnection();
            try
            {
                if (comboBoxDistanta.SelectedIndex > -1 && comboBoxStil.SelectedIndex > -1)
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {
                        string sqlStr = String.Format("select nume,varsta,stil,Distanta,Nr_participanti from (select * from probe where probe.stil = '{0}' and probe.distanta = " + comboBoxDistanta.Text + " ) as A inner join Programari B on A.id = B.id_proba inner join Participanti C on c.id = B.id_participant", comboBoxStil.Text.ToString());
                        cmd.CommandText = sqlStr;

                        Console.WriteLine(sqlStr);
                        SQLiteDataAdapter dataAdap = new SQLiteDataAdapter(cmd.CommandText, con);
                        DataSet ds = new DataSet();
                        dataAdap.Fill(ds);
                        dataGridCautare.DataSource = ds.Tables[0].DefaultView;
                    }

                }
                else
                    MessageBox.Show("Alegeti stilul si distanta probei ! \n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void load_data()
        {
            dataGridView1.ReadOnly = true;

            List<Proba> x = contrl.get_all_probe();
            dataGridView1.DataSource =  contrl.get_all_probe();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBoxNume.Text == "")
            {
                MessageBox.Show("Introduceti nume !");
                return;
            }
    
            try
            {

                Participant x = new Participant();
                x.Varsta = Int32.Parse(numericUpDownVarsta.Value.ToString());
                x.Nume = textBoxNume.Text;
                if (contrl.find_participant(x)==false)
                {
                    dataGridCautare.AutoSize = true;
                    dataGridView1.AutoSize = true;
                    if (contrl.id_of_participant(x) == -1)
                    {
                        MessageBox.Show("Participantul introdus nu exista !");
                        return;
                    }
                    else
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {

                            contrl.add_programare(contrl.id_of_participant(x), Int32.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString()));
                            load_data();
                            if (comboBoxDistanta.SelectedIndex > -1 && comboBoxStil.SelectedIndex > -1 )
                            {
                                SQLiteConnection con = DBUtils.DBUtils.getConnection();
                                con.Open();
                                using (SQLiteCommand cmd = new SQLiteCommand(con))
                                {
                                    string sqlStr = String.Format("select nume,varsta,stil,Distanta,Nr_participanti from (select * from probe where probe.stil = '{0}' and probe.distanta = " + comboBoxDistanta.Text + " ) as A inner join Programari B on A.id = B.id_proba inner join Participanti C on c.id = B.id_participant", comboBoxStil.Text.ToString());
                                    cmd.CommandText = sqlStr;

                                    Console.WriteLine(sqlStr);
                                    SQLiteDataAdapter dataAdap = new SQLiteDataAdapter(cmd.CommandText, con);
                                    DataSet ds = new DataSet();
                                    dataAdap.Fill(ds);
                                    dataGridCautare.DataSource = ds.Tables[0].DefaultView;
                                }
                                con.Close();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Alege o proba");
                            return;
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Date Incorecte! \n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Admin_window_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
