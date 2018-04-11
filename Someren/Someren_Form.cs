using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Someren
{
    public partial class Someren_Form : Form
    {
       
        public static Someren_Form instance;

        public Someren_Form() { InitializeComponent(); }

        public static Someren_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Someren_Form();
                }
                return instance;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showDashboard();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            ClearGroupbox();
            groupBox1.Visible = true;
        }

        private void showDashboard()
        {
            panel1.Controls.Clear();
            
            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "-bierfust controleren";
            l.Text += "\r\n-kamerindeling maken";
            panel1.Controls.Add(l);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // toon hier een message "Weet je zeker dat je wilt afsluiten?"
            // Message msg = new Message();
            if ((MessageBox.Show("Weet je zeker dat je SomerenAdministratie wilt afsluiten?", "SomerenAdministratie Afsluiten?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                Application.Exit();
            }
           
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }
        private void overSomerenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            panel1.Controls.Clear();

            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 800;
            l.Text = "Deze applicatie is ontwikkeld voor 1.3 Project Databases, opleiding Informatica, Hogeschool Inholland Haarlem";
            
            panel1.Controls.Add(l);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // er gebeurt niks als je op de menustrip drukt
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Studenten";
            int nummer = 1;
            this.panel1.Controls.Add(SomerenUI.ToonStudenten.StudentOphalen(nummer));
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void docentenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Docenten";
            int nummer = 2;
            this.panel1.Controls.Add(SomerenUI.ToonDocenten.DocentOphalen(nummer));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Kamers";
            this.panel1.Controls.Add(SomerenUI.ToonKamers.KamersOphalen());
        }

        public void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Omzetrapportage";
            //this.panel1.Controls.Add(SomerenUI.OmzetRapportage.ShowKassa());

            panel1.Controls.Clear();
            panel1.Controls.Add(SomerenUI.OmzetRapportage.ShowOmzetrapportageUI());
        }

        private void activiteitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ClearGroupbox()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBoxActiviteiten.Visible = false;
            groupBoxActiviteitTonen.Visible = false;
            groupBoxActiviteitVerwijderen.Visible = false;
            groupBoxActiviteitToevoegen.Visible = false;
            groupBoxActiviteitWijzigen.Visible = false;
        }


        private void kassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Kassa";
            this.groupBox1.Size = new System.Drawing.Size(1000, 500);
            this.panel1.Size = new System.Drawing.Size(990, 450);
            this.pictureBox1.Location = new System.Drawing.Point(1050, 33);
            this.panel1.Controls.Add(SomerenUI.ToonKassa.ShowKassa());
        }

        private void drankToevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void drankvoorraadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Drankvoorraad";
            SomerenModel.Drankvoorraad.maindrankvoorraad();
            this.panel1.Controls.Add(SomerenUI.ToonDrankvoorraad.showDrankvoorraden());
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void btnDrankToevoegen_Click(object sender, EventArgs e)
        {
            string NaamDrankToevoegen = txtDrankNaamToevoegen.Text, VoorraadToevoegen = txtDrankVoorraadToevoegen.Text, InkoopPrijsToevoegen = txtDrankInkoopPrijsToevoegen.Text, VerkoopPrijsToevoegen = txtDrankVerkoopPrijsToevoegen.Text;
            SomerenDB.Drankvoorraad.DrankToevoegen(NaamDrankToevoegen, VoorraadToevoegen, InkoopPrijsToevoegen, VerkoopPrijsToevoegen);
        }

        private void roosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Rooster";
            this.panel1.Controls.Add(SomerenUI.ToonWeekRooster.ShowWeekRoosterUI());
        }

        private void activiteitenlijstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            ClearGroupbox();
            groupBox2.Visible = true;
            groupBoxActiviteiten.Visible = true;
        }

        private void btnActiviteitTonen_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Activiteitenlijst";
            SomerenModel.ActiviteitenlijstC.mainactiviteitenlijst();
            this.panel1.Controls.Add(SomerenUI.ToonActiviteitenlijst.showActiviteitenlijsten());
            ClearGroupbox();
            groupBox1.Visible = true;
        }

        private void btnActiviteitAanpassen_Click_1(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            ClearGroupbox();
            groupBoxActiviteitWijzigen.Visible = true;
        }

        private void btnActiviteitToevoegen_Click_1(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            ClearGroupbox();
            groupBoxActiviteitVerwijderen.Visible = true;
            groupBoxActiviteitToevoegen.Visible = true;
        }

        private void btnActiviteitVerwijderen_Click_1(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            ClearGroupbox();
            groupBoxActiviteitVerwijderen.Visible = true;
        }

        private void btnActiviteitToevoegenButton_Click(object sender, EventArgs e)
        {
            string ActiviteitNummerToevoegen = txtActiviteitnummerToevoegen.Text, ActiviteitNaamToevoegen = txtActiviteitnaamToevoegen.Text, ActiviteitDatumToevoegen = txtDatumToevoegen.Text, ActiviteitBeginTijdToevoegen = txtBegintijdToevoegen.Text, ActiviteitEindTijdToevoegen = txtEindtijdToevoegen.Text, ActiviteitStudentCapaciteitToevoegen = txtStudentCapaciteitToevoegen.Text, ActiviteitBegeleiderCapaciteitToevoegen = txtBegintijdToevoegen.Text;
            SomerenDB.Activiteitenlijst.ActiviteitToevoegen(ActiviteitNummerToevoegen, ActiviteitNaamToevoegen, ActiviteitDatumToevoegen, ActiviteitBeginTijdToevoegen, ActiviteitEindTijdToevoegen, ActiviteitStudentCapaciteitToevoegen, ActiviteitBegeleiderCapaciteitToevoegen);
        }

        private void btnActiviteitWijzigen_Click(object sender, EventArgs e)
        {
            string ActiviteitNaamWijzigen = txtActiviteitNaamWijzigen.Text, ActiviteitDatumWijzigen = txtActiviteitDatumWijzigen.Text, ActiviteitBeginTijdWijzigen = txtActiviteitBegintijdWijzigen.Text, ActiviteitEindTijdWijzigen = txtActiviteitEindtijdWijzigen.Text, ActiviteitStudentCapaciteitWijzigen = txtActiviteitStudentcapaciteitWijzigen.Text, ActiviteitBegeleiderCapaciteitWijzigen = txtActiviteitBegeleidercapaciteitWijzigen.Text;
            SomerenDB.Activiteitenlijst.ActiviteitWijzigen(ActiviteitNaamWijzigen, ActiviteitDatumWijzigen, ActiviteitBeginTijdWijzigen, ActiviteitEindTijdWijzigen, ActiviteitStudentCapaciteitWijzigen, ActiviteitBegeleiderCapaciteitWijzigen);
        }

        private void begeleidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Begeleiders";
            this.groupBox1.Size = new System.Drawing.Size(1000, 480);
            this.panel1.Size = new System.Drawing.Size(990, 450);
            this.pictureBox1.Location = new System.Drawing.Point(1050, 33);
            this.panel1.Controls.Add(SomerenUI.BegeleiderUI.Showbegeleiders());
        }

    }
}

