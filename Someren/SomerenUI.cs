using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Drawing;

namespace Someren
{
    public static class SomerenUI
    {
        static ListView begeleiderlistview = new ListView();
        static ListView student = new ListView();
        static ListView docent = new ListView();
        static ListView kamer = new ListView();
        public static ListView c = new ListView();

        //UI Toon Studenten
        public class ToonStudenten
        {
            public static Control StudentOphalen(int nummer)
            {
                List<SomerenModel.Student> Studenten = new List<SomerenModel.Student>();
                SomerenDB.Student.DB_getStudents(Studenten);
                var c = ShowStudents(Studenten, nummer);
                return c;
            }

            public static Control ShowStudents(List<SomerenModel.Student> Studenten, int nummer)
            {
                student.Clear();
                student.View = View.Details;
                student.FullRowSelect = true;

                int aantal = SomerenModel.Student.Zoekstudent.Hoeveelheidstudenten(Studenten);
                if (nummer == 1)
                {
                    student.Height = 450;
                    student.Width = 800;
                    for (int i = 0; i < aantal; i++)
                    {
                        var row = new string[]
                        {
                        SomerenModel.Student.Zoekstudent.Studentnummer(i,Studenten).ToString(),
                        SomerenModel.Student.Zoekstudent.Voornaam(i,Studenten),
                        SomerenModel.Student.Zoekstudent.Achternaam(i,Studenten),
                        SomerenModel.Student.Zoekstudent.Taal(i,Studenten),
                        SomerenModel.Student.Zoekstudent.Kamernummer(i,Studenten).ToString(),
                        };
                        var lvi = new ListViewItem(row);
                        student.Items.Add(lvi);

                    }
                    student.Columns.Add("Studentnummer");
                    student.Columns.Add("Voornaam");
                    student.Columns.Add("Achternaam");
                    student.Columns.Add("Taal");
                    student.Columns.Add("Kamernummer");

                    student.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    student.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    return student;
                }

                else
                {
                    student.Height = 350;
                    student.Width = 248;
                    for (int i = 0; i < aantal; i++)
                    {
                        var row = new string[]
                        {
                        SomerenModel.Student.Zoekstudent.Studentnummer(i,Studenten).ToString(),
                        SomerenModel.Student.Zoekstudent.Voornaam(i,Studenten),
                        SomerenModel.Student.Zoekstudent.Achternaam(i,Studenten),
                        };
                        var lvi = new ListViewItem(row);
                        student.Items.Add(lvi);
                    }

                    student.Columns.Add("Studentnummer");
                    student.Columns.Add("Voornaam");
                    student.Columns.Add("Achternaam");

                    student.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    student.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    return student;
                }
            }
        }

        //UI Toon Docenten
        public class ToonDocenten
        {
            public static Control DocentOphalen(int nummer)
            {
                List<SomerenModel.Docent> Docenten = new List<SomerenModel.Docent>();
                SomerenModel.Docent.MainDocent(Docenten);
                //ListView d = new ListView();
                var c = ShowDocenten(Docenten, nummer);
                return c;
            }


            public static Control ShowDocenten(List<SomerenModel.Docent> Docenten, int nummer)
            {
                if (nummer == 1)
                {
                    if (docent.IsDisposed == true)
                    {
                        docent = new ListView();
                    }

                    docent.Clear();
                    docent.View = View.Details;
                    docent.FullRowSelect = true;
                    docent.Height = 400;
                    docent.Width = 700;

                    int aantal = SomerenModel.Docent.Zoekdocent.Hoeveelheiddocenten(Docenten);
                    for (int i = 0; i < aantal; i++)
                    {
                        if (SomerenModel.Docent.Zoekdocent.Begeleider(i, Docenten).ToString() == "Nee")
                        {
                            continue;
                        }
                        else
                        {
                            var row = new string[]
                            {
                            SomerenModel.Docent.Zoekdocent.Docentnummer(i,Docenten).ToString(),
                            SomerenModel.Docent.Zoekdocent.Voornaam(i,Docenten),
                            SomerenModel.Docent.Zoekdocent.Achternaam(i,Docenten),
                            SomerenModel.Docent.Zoekdocent.Vak(i,Docenten),
                            SomerenModel.Docent.Zoekdocent.Telefoonnummer(i,Docenten),
                            SomerenModel.Docent.Zoekdocent.Kamernummer(i,Docenten).ToString(),
                            SomerenModel.Docent.Zoekdocent.Begeleider(i,Docenten).ToString(),
                            };
                            var lvi = new ListViewItem(row);
                            docent.Items.Add(lvi);
                        }
                    }

                    docent.Columns.Add("Docentnummer");
                    docent.Columns.Add("Voornaam");
                    docent.Columns.Add("Achternaam");
                    docent.Columns.Add("Vak");
                    docent.Columns.Add("Telefoonnummer");
                    docent.Columns.Add("Kamernummer");
                    docent.Columns.Add("Begeleider");

                    docent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    docent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    return docent;
                }
                else
                {
                    if (docent.IsDisposed == true)
                    {
                        docent = new ListView();
                    }

                    docent.Clear();
                    docent.View = View.Details;
                    docent.FullRowSelect = true;
                    docent.Height = 400;
                    docent.Width = 700;

                    int aantal = SomerenModel.Docent.Zoekdocent.Hoeveelheiddocenten(Docenten);
                    for (int i = 0; i < aantal; i++)
                    {
                        var row = new string[]
                        {
                    SomerenModel.Docent.Zoekdocent.Docentnummer(i,Docenten).ToString(),
                    SomerenModel.Docent.Zoekdocent.Voornaam(i,Docenten),
                    SomerenModel.Docent.Zoekdocent.Achternaam(i,Docenten),
                    SomerenModel.Docent.Zoekdocent.Vak(i,Docenten),
                    SomerenModel.Docent.Zoekdocent.Telefoonnummer(i,Docenten),
                    SomerenModel.Docent.Zoekdocent.Kamernummer(i,Docenten).ToString(),
                    SomerenModel.Docent.Zoekdocent.Begeleider(i,Docenten),
                        };
                        var lvi = new ListViewItem(row);
                        docent.Items.Add(lvi);
                    }

                    docent.Columns.Add("Docentnummer");
                    docent.Columns.Add("Voornaam");
                    docent.Columns.Add("Achternaam");
                    docent.Columns.Add("Vak");
                    docent.Columns.Add("Telefoonnummer");
                    docent.Columns.Add("Kamernummer");
                    docent.Columns.Add("Begeleider");

                    docent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    docent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    return docent;
                }

            }
        }
            //UI Toon Kamers
        public class ToonKamers
        {
            public static Control KamersOphalen()
            {
                List<SomerenModel.Kamer> Kamers = new List<SomerenModel.Kamer>();
                SomerenModel.Kamer.MainKamer(Kamers);
                var c = ShowKamers(Kamers);
                return c;
            }

            public static Control ShowKamers(List<SomerenModel.Kamer> Kamers)
            {
                ListView c = new ListView();
                c.View = View.Details;
                c.FullRowSelect = true;
                c.Height = 1143;
                c.Width = 731;

                int aantal = SomerenModel.Kamer.Zoekkamer.Hoeveelheidkamers(Kamers);

                for (int i = 0; i < aantal; i++)
                {
                    var row = new string[] {
                                        SomerenModel.Kamer.Zoekkamer.Kamernummer(i,Kamers).ToString(),
                                        SomerenModel.Kamer.Zoekkamer.Kamercapaciteit(i,Kamers).ToString(),
                                        SomerenModel.Kamer.Zoekkamer.Studentnummer(i,Kamers).ToString(),
                                        SomerenModel.Kamer.Zoekkamer.Docentnummer(i,Kamers).ToString()
                                        };
                    var lvi = new ListViewItem(row);
                    c.Items.Add(lvi);
                }
                c.Columns.Add("Kamernummer", -2);
                c.Columns.Add("Kamercapaciteit", -2);

                return c;
            }
        }

        //UI Omzetrapportage
        public class OmzetRapportage
        {
            static Label lbl_kiesDatum = new Label();
            static Label lbl_gekozenDatum = new Label();
            static Button btn_toonOmzetrapportage = new Button();
            static public MonthCalendar mc_startDatum = new MonthCalendar();
            static Label lbl_afzet = new Label();
            static Label lbl_omzet = new Label();
            static Label lbl_aantalKlanten = new Label();
            static Label lbl_toonafzet = new Label();
            static Label lbl_toonomzet = new Label();
            static Label lbl_toonaantalKlanten = new Label();


            static List<SomerenModel.OmzetRapportage> Kassa = new List<SomerenModel.OmzetRapportage>();

            public static Panel omzetrapportagePanel = new Panel();
            public static Panel ListviewPanel = new Panel();

            public static Control ShowOmzetrapportageUI()
            {

                //Maak afzet LABEL
                lbl_afzet.Text = "Afzet: ";
                lbl_afzet.Size = new System.Drawing.Size(100, 20);
                lbl_afzet.Location = new System.Drawing.Point(0, 300);

                //Maak omzetLABEL
                lbl_omzet.Text = "Omzet: ";
                lbl_omzet.Size = new System.Drawing.Size(100, 20);
                lbl_omzet.Location = new System.Drawing.Point(0, 320);

                //Maak aantalKlanten LABEL
                lbl_aantalKlanten.Text = "Aantal Klanten: ";
                lbl_aantalKlanten.Size = new System.Drawing.Size(100, 20);
                lbl_aantalKlanten.Location = new System.Drawing.Point(0, 340);

                //Maak Toonafzet LABEL
                lbl_toonafzet.Size = new System.Drawing.Size(100, 20);
                lbl_toonafzet.Location = new System.Drawing.Point(150, 300);

                //Maak Toonomzet LABEL
                lbl_toonomzet.Size = new System.Drawing.Size(100, 20);
                lbl_toonomzet.Location = new System.Drawing.Point(150, 320);

                //Maak ToonaantalKlanten LABEL
                lbl_toonaantalKlanten.Size = new System.Drawing.Size(100, 20);
                lbl_toonaantalKlanten.Location = new System.Drawing.Point(150, 340);

                //Maak Toonstartdatum MonthCalendar LABEL
                lbl_kiesDatum.Text = "Kies datum:";
                lbl_kiesDatum.Size = new System.Drawing.Size(100, 30);
                lbl_kiesDatum.Location = new System.Drawing.Point(8, 0);

                //Maak einddatum MonthCalendar LABEL
                lbl_gekozenDatum.Size = new System.Drawing.Size(400, 30);
                lbl_gekozenDatum.Location = new System.Drawing.Point(250, 0);

                //Maak startdatum MonthCalendar
                mc_startDatum.Size = new System.Drawing.Size(50, 50);
                mc_startDatum.Location = new System.Drawing.Point(8, 30);
                mc_startDatum.MaxDate = DateTime.Today;

                //Maak Omzetrapportage button
                btn_toonOmzetrapportage.Text = "Toon Omzetrapportage";
                btn_toonOmzetrapportage.Size = new System.Drawing.Size(230, 50);
                btn_toonOmzetrapportage.Location = new System.Drawing.Point(8, 230); //x,y
                btn_toonOmzetrapportage.Click += btn_toonOmzetrapportage_Click;

                //OmzetrapportagePanel
                omzetrapportagePanel.Size = new System.Drawing.Size(730, 430);
                omzetrapportagePanel.Location = new System.Drawing.Point(0, 10);
                omzetrapportagePanel.Controls.Add(lbl_kiesDatum);
                omzetrapportagePanel.Controls.Add(lbl_gekozenDatum);
                omzetrapportagePanel.Controls.Add(btn_toonOmzetrapportage);
                omzetrapportagePanel.Controls.Add(mc_startDatum);
                omzetrapportagePanel.Controls.Add(lbl_afzet);
                omzetrapportagePanel.Controls.Add(lbl_omzet);
                omzetrapportagePanel.Controls.Add(lbl_aantalKlanten);
                omzetrapportagePanel.Controls.Add(lbl_toonafzet);
                omzetrapportagePanel.Controls.Add(lbl_toonomzet);
                omzetrapportagePanel.Controls.Add(lbl_toonaantalKlanten);
                omzetrapportagePanel.Controls.Add(ListviewPanel);

                ListviewPanel.Size = new System.Drawing.Size(500, 480);
                ListviewPanel.Location = new System.Drawing.Point(250, 30);
                ListviewPanel.Controls.Add(KassaOphalen());

                c.ColumnClick += c_ColumnClick;

                return omzetrapportagePanel;
            }

            public static double PrintAfzet(double afzet)
            {
                lbl_toonafzet.Text = afzet.ToString();
                return afzet;
            }

            public static double PrintOmzet(double omzet)
            {
                lbl_toonomzet.Text = "€ " + omzet.ToString("0.00");

                return omzet;
            }

            public static int PrintAantalKlanten(int aantalKlanten)
            {
                lbl_toonaantalKlanten.Text = aantalKlanten.ToString();

                return aantalKlanten;
            }

            public static void PrintSelectionRange(string beginDatum, string eindDatum)
            {
                string datum = beginDatum + " - " + eindDatum;
                lbl_gekozenDatum.Text = "Gekozen data: " + datum;
            }

            static void btn_toonOmzetrapportage_Click(object sender, EventArgs e)
            {
                SomerenUI.OmzetRapportage.mc_startDatum.MaxDate = DateTime.Today;
                mc_startDatum.MaxSelectionCount = 9999;

                string beginDatum = SomerenUI.OmzetRapportage.mc_startDatum.SelectionStart.ToString("dd/MM/yyyy");
                string eindDatum = SomerenUI.OmzetRapportage.mc_startDatum.SelectionEnd.ToString("dd/MM/yyyy");

                string beginDatumSQL = SomerenUI.OmzetRapportage.mc_startDatum.SelectionStart.ToString("MM/dd/yyyy");
                string eindDatumSQL = SomerenUI.OmzetRapportage.mc_startDatum.SelectionEnd.ToString("MM/dd/yyyy");

                PrintSelectionRange(beginDatum, eindDatum);
                double afzet = SomerenModel.OmzetRapportage.MainAfzet(beginDatumSQL, eindDatumSQL);
                double omzet = SomerenModel.OmzetRapportage.MainOmzet(beginDatumSQL, eindDatumSQL);
                int aantalKlanten = SomerenModel.OmzetRapportage.MainAantalKlanten(beginDatumSQL, eindDatumSQL);

                ListviewPanel.Controls.Clear();
                ListviewPanel.Controls.Add(KassaOphalen());
                //SomerenUI.OmzetRapportage.omzetrapportagePanel.Controls.Add(KassaOphalen());

                PrintAfzet(afzet);
                PrintOmzet(omzet);
                PrintAantalKlanten(aantalKlanten);

            }

            public static Control KassaOphalen()
            {
                string beginDatumSQL = SomerenUI.OmzetRapportage.mc_startDatum.SelectionStart.ToString("MM/dd/yyyy");
                string eindDatumSQL = SomerenUI.OmzetRapportage.mc_startDatum.SelectionEnd.ToString("MM/dd/yyyy");

                List<SomerenModel.OmzetRapportage> Kassa = new List<SomerenModel.OmzetRapportage>();
                SomerenModel.OmzetRapportage.MainKassa(Kassa, beginDatumSQL, eindDatumSQL);

                var c = ShowKassa(Kassa);
                return c;
            }

            public static Control ShowKassa(List<SomerenModel.OmzetRapportage> KassaFilled)
            {

                c.View = View.Details;
                c.FullRowSelect = true;
                c.Location = new System.Drawing.Point(0, 0);
                c.Height = 400;
                c.Width = 480;

                int aantal = SomerenModel.OmzetRapportage.Zoekkassa.Hoeveelheidtrans(KassaFilled);

                for (int i = 0; i < aantal; i++)
                {
                    var row = new string[]
                    {
                SomerenModel.OmzetRapportage.Zoekkassa.Transactienummer(i, KassaFilled).ToString(),
                SomerenModel.OmzetRapportage.Zoekkassa.Studentnummer(i, KassaFilled).ToString(),
                SomerenModel.OmzetRapportage.Zoekkassa.Datum(i, KassaFilled).ToString(),
                SomerenModel.OmzetRapportage.Zoekkassa.Dranknaam(i, KassaFilled).ToString(),
                SomerenModel.OmzetRapportage.Zoekkassa.aantalDrank(i, KassaFilled).ToString(),
                SomerenModel.OmzetRapportage.Zoekkassa.TotalePrijs(i, KassaFilled).ToString(),
                    };
                    var lvi = new ListViewItem(row);
                    c.Items.Add(lvi);
                }
                c.Columns.Add("Transactienummer", -2);
                c.Columns.Add("Studentnummer", -2);
                c.Columns.Add("Datum", -2);
                c.Columns.Add("Dranknaam", -2);
                c.Columns.Add("aantalDrank", -2);
                c.Columns.Add("TotalePrijs", -2);

                return c;
            }

        }

        //UI Kassa
        public class ToonKassa
        {
            //algemene variabelen die aangemaakt moeten worden gebruikt voor alle methodes

            public static ListView KassaDrankview = new ListView();
            static Label studenten = new Label();
            public static Label dranklabel = new Label();
            public static Label aantaldrank = new Label();
            public static Label prijsdrank = new Label();
            static Panel afrekenpanel = new Panel();
            public static Button plusbutton = new Button();
            public static Button minbutton = new Button();
            public static Button afrekenbutton = new Button();
            public static int check = 0;
            public static Panel overlappend = new Panel();
            public static Panel studentenpanel = new Panel();
            public static Panel drankpanel = new Panel();

            //-----------------------------------------------------------------------------------------

            //panel voor de het laten zien van de button en welke student
            public static Control Afrekenpanel()
            {

                Panel Afrekenpanel = new Panel();
                Afrekenpanel.Size = new System.Drawing.Size(250, 450);
                Afrekenpanel.Location = new System.Drawing.Point(0, 0);

                studenten.Size = new System.Drawing.Size(220, 60);
                studenten.Location = new System.Drawing.Point(0, 0);
                studenten.Font = new System.Drawing.Font("Bahnschrift Semibold", 12.0f);
                Afrekenpanel.Controls.Add(studenten);
                student.Click += student_Click;
                student.ColumnClick += student_ColumnClick;

                dranklabel.Size = new System.Drawing.Size(250, 20);
                dranklabel.Location = new System.Drawing.Point(0, 70);
                dranklabel.Font = new System.Drawing.Font("Bahnschrift Semibold", 12.0f);

                prijsdrank.Size = new System.Drawing.Size(250, 20);
                prijsdrank.Location = new System.Drawing.Point(0, 95);
                prijsdrank.Font = new System.Drawing.Font("Bahnschrift Semibold", 12.0f);

                aantaldrank.Size = new System.Drawing.Size(250, 20);
                aantaldrank.Location = new System.Drawing.Point(0, 125);
                aantaldrank.Font = new System.Drawing.Font("Bahnschrift Semibold", 12.0f);

                afrekenbutton.Size = new System.Drawing.Size(250, 60);
                afrekenbutton.Text = "Afrekenen";
                afrekenbutton.Location = new System.Drawing.Point(0, 293);
                afrekenbutton.Font = new System.Drawing.Font("Bahnschrift Semibold", 12.0f);
                afrekenbutton.Click += afrekenbutton_Click;

                Afrekenpanel.Controls.Add(dranklabel);
                Afrekenpanel.Controls.Add(prijsdrank);
                Afrekenpanel.Controls.Add(aantaldrank);
                Afrekenpanel.Controls.Add(afrekenbutton);

                return Afrekenpanel;
            }
            //als er op knop gedrukt moet hij de student tonen en het bedrag bereken
            static void student_Click(object sender, EventArgs e)
            {
                string item1 = student.SelectedItems[0].SubItems[0].Text.ToString();
                SomerenModel.Kassa.Gkstudent.Studentnummer = item1;
                string item2 = student.SelectedItems[0].SubItems[1].Text.ToString();
                SomerenModel.Kassa.Gkstudent.Voornaam = item2;
                string item3 = student.SelectedItems[0].SubItems[2].Text.ToString();
                SomerenModel.Kassa.Gkstudent.Achternaam = item3;

                studenten.Text = ("Studentnummer: " + SomerenModel.Kassa.Gkstudent.Studentnummer +
                                    "\nVoornaam: " + SomerenModel.Kassa.Gkstudent.Voornaam +
                                    "\nAchternaam: " + SomerenModel.Kassa.Gkstudent.Achternaam);
                check++;
            }

            public static void afrekenbutton_Click(object sender, EventArgs e)
            {
                SomerenModel.Kassa.selectdrank();
            }


            //-----------------------------------------------------------------------------------------

            //algemene kassa panels
            public static Control ShowKassa()
            {
                dranklabel.Controls.Clear();
                studenten.Controls.Clear();
                student.Controls.Clear();
                docent.Controls.Clear();
                kamer.Controls.Clear();
                KassaDrankview.Controls.Clear();
                studenten.Controls.Clear();
                aantaldrank.Controls.Clear();
                prijsdrank.Controls.Clear();
                afrekenpanel.Controls.Clear();
                plusbutton.Controls.Clear();
                minbutton.Controls.Clear();
                afrekenbutton.Controls.Clear();
                studentenpanel.Controls.Clear();
                drankpanel.Controls.Clear();


                dranklabel.ResetText();
                studenten.ResetText();
                student.ResetText();
                docent.ResetText();
                kamer.ResetText();
                KassaDrankview.ResetText();
                studenten.ResetText();
                aantaldrank.ResetText();
                prijsdrank.ResetText();
                afrekenpanel.ResetText();
                check = 0;

                overlappend.Refresh();
                plusbutton.Controls.Clear();
                minbutton.Controls.Clear();
                afrekenbutton.Controls.Clear();
                drankpanel.Refresh();

                overlappend.Controls.Add(studentenpanel);
                overlappend.Controls.Add(drankpanel);
                overlappend.Controls.Add(afrekenpanel);
                overlappend.Size = new System.Drawing.Size(990, 450);

                studentenpanel.Controls.Add(Studentenlijst());
                studentenpanel.Size = new System.Drawing.Size(250, 450);
                studentenpanel.BorderStyle = BorderStyle.FixedSingle;

                drankpanel.Controls.Add(KassaDrank());
                drankpanel.Size = new System.Drawing.Size(400, 450);
                drankpanel.Location = new System.Drawing.Point(270, 0);
                drankpanel.Controls.Add(Dranktabel());
                drankpanel.BorderStyle = BorderStyle.FixedSingle;

                afrekenpanel.Size = new System.Drawing.Size(600, 400);
                afrekenpanel.Location = new System.Drawing.Point(690, 0);
                afrekenpanel.Controls.Add(Afrekenpanel());

                return overlappend;
            }

            //-----------------------------------------------------------------------------------------

            //studentenlijst printen
            public static Control Studentenlijst()
            {
                Panel studentenlijst = new Panel();

                studentenlijst.Size = new System.Drawing.Size(250, 450);
                studentenlijst.Location = new System.Drawing.Point(0, 0);
                int nummer = 2;

                Label naam = new Label();
                naam.Location = new System.Drawing.Point(0, 0);
                naam.Size = new System.Drawing.Size(250, 35);
                naam.Text = "Studenten keuze lijst";
                naam.Font = new System.Drawing.Font("Bahnschrift Semibold", 16.0f);

                studentenlijst.Controls.Add(naam);
                var studenophalen = SomerenUI.ToonStudenten.StudentOphalen(nummer);
                studenophalen.Location = new System.Drawing.Point(0, 40);
                studentenlijst.Controls.Add(ToonStudenten.StudentOphalen(nummer));

                return studentenlijst;
            }

            //-----------------------------------------------------------------------------------------

            //de dranktabel printen met daarbij het drankje tonen (en de buttons voor omhoog en omlaag)
            public static Control Dranktabel()
            {
                Panel drankpanel = new Panel();
                drankpanel.Size = new System.Drawing.Size(400, 450);
                drankpanel.Location = new System.Drawing.Point(0, 200);

                KassaDrankview.Click += KassaDrankview_Click;
                KassaDrankview.ColumnClick += KassaDrankview_ColumnClick;




                plusbutton.Text = "Plus";
                minbutton.Text = "Min";
                plusbutton.Size = new System.Drawing.Size(398, 60);
                minbutton.Size = new System.Drawing.Size(398, 60);
                plusbutton.Location = new System.Drawing.Point(0, 20);
                minbutton.Location = new System.Drawing.Point(0, 90);

                plusbutton.Click += SomerenModel.Kassa.plusbutton_Click;
                minbutton.Click += SomerenModel.Kassa.minbutton_Click;

                drankpanel.Controls.Add(plusbutton);
                drankpanel.Controls.Add(minbutton);

                return drankpanel;
            }

            static void KassaDrankview_Click(object sender, EventArgs e)
            {

                string geselecteerdedrankje = KassaDrankview.SelectedItems[0].SubItems[0].Text.ToString();
                decimal prijs = decimal.Parse(KassaDrankview.SelectedItems[0].SubItems[1].Text);
                SomerenModel.Kassa.prijsdrankje = prijs;
                SomerenModel.Kassa.geselecteerdedrankje = geselecteerdedrankje;
                dranklabel.Text = ("Geselecteerde drankje: " + geselecteerdedrankje);
                prijsdrank.Text = ("Prijs: " + prijs.ToString());
                check++;
            }

            //-----------------------------------------------------------------------------------------

            public static Control KassaDrank()
            {
                List<SomerenModel.Kassa.Drankjes> KassaDrank = new List<SomerenModel.Kassa.Drankjes>();
                SomerenDB.Kassa.DB_getKassaDrankvoorraad(KassaDrank);

                var c = ShowKassaDrank(KassaDrank);
                return c;
            }


            //kassa drank
            public static Control ShowKassaDrank(List<SomerenModel.Kassa.Drankjes> KassaDrank)
            {

                KassaDrankview.Clear();
                KassaDrankview.View = View.Details;
                KassaDrankview.FullRowSelect = true;
                KassaDrankview.Height = 200;
                KassaDrankview.Width = 400;

                int aantal = KassaDrank.Count;

                for (int i = 0; i < aantal; i++)
                {
                    var row = new string[]
                    {
                        KassaDrank[i].drankNaam.ToString(),
                        KassaDrank[i].Prijs.ToString(),
                        KassaDrank[i].Voorraad.ToString(),

                    };
                    var lvi = new ListViewItem(row);
                    KassaDrankview.Items.Add(lvi);

                }
                KassaDrankview.Columns.Add("Naam drank");
                KassaDrankview.Columns.Add("Prijs");
                KassaDrankview.Columns.Add("Voorraad");

                KassaDrankview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                KassaDrankview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                return KassaDrankview;

            }

        }

        //UI Drankvoorraad 
        public class ToonDrankvoorraad
        {
            public static Control showDrankvoorraden()
            {
                ListView c = new ListView();
                c.View = View.Details;
                c.FullRowSelect = true;
                //c.AutoArrange = true;
                //c.GridLines = true;
                //c.Sorting = SortOrder.Ascending;
                c.Height = 565;
                c.Width = 800;

                int aantal = SomerenModel.Drankvoorraad.Zoekdrankvoorraad.Hoeveeldrankvoorraden();

                for (int i = 0; i < aantal; i++)
                {
                    var row = new string[] {
                                        SomerenModel.Drankvoorraad.Zoekdrankvoorraad.Dranknummer(i).ToString(),
                                        SomerenModel.Drankvoorraad.Zoekdrankvoorraad.NaamDrank(i).ToString(),
                                        SomerenModel.Drankvoorraad.Zoekdrankvoorraad.Voorraad(i).ToString(),
                                        SomerenModel.Drankvoorraad.Zoekdrankvoorraad.Opvoorraad(i).ToString()
                                        };
                    var lvi = new ListViewItem(row);
                    c.Items.Add(lvi);

                }
                c.Columns.Add("Dranknummer", -2);
                c.Columns.Add("NaamDrank", -2);
                c.Columns.Add("Voorraad", -2);
                c.Columns.Add("Opvoorraad", -2);

                return c;
            }
        }


        //UI Weekrooster
        public class ToonWeekRooster
        {
            public static Panel WeekroosterPanel = new Panel();
            public static DataGridView GridMaandag = new DataGridView();
            public static DataGridView GridDinsdag = new DataGridView();

            public static DataTable Maandag = new DataTable();
            public static DataTable Dinsdag = new DataTable();

            static Label lbl_maandag = new Label();
            static Label lbl_dinsdag = new Label();
            static Button btn_enable = new Button();
            static Button btn_UpdateDB = new Button();
            static public Label lbl_UpdateFeedbackM = new Label();

            public static List<SomerenModel.WeekRooster> WeekRoosterMaandag = new List<SomerenModel.WeekRooster>();
            public static List<SomerenModel.WeekRooster> WeekRoosterDinsdag = new List<SomerenModel.WeekRooster>();



            public static Control ShowWeekRoosterUI()
            {
                Maandag.Clear();
                Dinsdag.Clear();
                WeekRoosterMaandag.Clear();
                WeekRoosterDinsdag.Clear();

                //Maandag LABEL
                lbl_maandag.Text = "maandag 11 april";
                lbl_maandag.Size = new System.Drawing.Size(100, 20);
                lbl_maandag.Location = new System.Drawing.Point(0, 0);

                //Dinsdag LABEL
                lbl_dinsdag.Text = "dinsdag 12 april";
                lbl_dinsdag.Size = new System.Drawing.Size(100, 20);
                lbl_dinsdag.Location = new System.Drawing.Point(0, 200);

                //FeedbackM
                lbl_UpdateFeedbackM.Text = "M-";
                lbl_UpdateFeedbackM.Size = new System.Drawing.Size(150, 40);
                lbl_UpdateFeedbackM.Location = new System.Drawing.Point(400, 390);

                //DataGrid GridMaandag
                GridMaandag.Size = new System.Drawing.Size(730, 150);
                GridMaandag.Location = new System.Drawing.Point(0, 30);
                GridMaandag.DataSource = WeekRoosterMaandagOphalen();


                //DataGrid GridDinsdag
                GridDinsdag.Size = new System.Drawing.Size(730, 150);
                GridDinsdag.Location = new System.Drawing.Point(0, 230);
                GridDinsdag.DataSource = WeekRoosterDinsdagOphalen();

                //enable button
                btn_enable.Text = "Reload Database";
                btn_enable.Size = new System.Drawing.Size(150, 40);
                btn_enable.Location = new System.Drawing.Point(200, 390); //x,y
                btn_enable.Click += btn_enable_Click;

                //UpdateDB button
                btn_UpdateDB.Text = "Update DataBase";
                btn_UpdateDB.Size = new System.Drawing.Size(150, 40);
                btn_UpdateDB.Location = new System.Drawing.Point(0, 390); //x,y
                btn_UpdateDB.Click += btn_UpdateDB_Click;

                //WeekroosterPanel
                WeekroosterPanel.Size = new System.Drawing.Size(730, 430);
                WeekroosterPanel.Location = new System.Drawing.Point(0, 10);
                //WeekroosterPanel.BackColor = System.Drawing.Color.Red;

                WeekroosterPanel.Controls.Add(lbl_maandag);
                WeekroosterPanel.Controls.Add(lbl_dinsdag);
                WeekroosterPanel.Controls.Add(lbl_UpdateFeedbackM);
                WeekroosterPanel.Controls.Add(btn_enable);
                WeekroosterPanel.Controls.Add(btn_UpdateDB);
                WeekroosterPanel.Controls.Add(GridMaandag);
                WeekroosterPanel.Controls.Add(GridDinsdag);

               

                return WeekroosterPanel;

            }

            public static DataTable WeekRoosterMaandagOphalen()
            {
                SomerenModel.WeekRooster.MainWeekRoosterMaandag(WeekRoosterMaandag);

                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dataTable = converter.ToDataTable(WeekRoosterMaandag);
                return dataTable;
            }

            public static DataTable WeekRoosterDinsdagOphalen()
            {
                SomerenModel.WeekRooster.MainWeekRoosterDinsdag(WeekRoosterDinsdag);

                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dataTable = converter.ToDataTable(WeekRoosterDinsdag);
                return dataTable;
            }

            static void btn_UpdateDB_Click(object sender, EventArgs e)
            {
                //BindingSource bs = (BindingSource)GridMaandag.DataSource;  
                //DataTable tCxC = (DataTable)bs.DataSource; 
                DataTable DT = (DataTable)GridMaandag.DataSource;
                DataTable DTD = (DataTable)GridDinsdag.DataSource;

                SomerenDB.WeekRoosterMaandag.DB_getWeekRoosterUpdate(DT);
                SomerenDB.WeekRoosterMaandag.DB_getWeekRoosterUpdate(DTD);
                btn_UpdateDB.Text = "Database Updated";
                btn_UpdateDB.BackColor = Color.Green;
            }

            static void btn_enable_Click(object sender, EventArgs e)
            {
                Maandag.Clear();
                Dinsdag.Clear();
                ShowWeekRoosterUI();
            }

            public class ListtoDataTableConverter
            {
                public DataTable ToDataTable<T>(List<T> items)
                {
                    DataTable dataTable = new DataTable(typeof(T).Name);
                    //Get all the properties
                    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    foreach (PropertyInfo prop in Props)
                    {
                        //Setting column names as Property names
                        dataTable.Columns.Add(prop.Name);
                    }

                    foreach (T item in items)
                    {
                        var values = new object[Props.Length];
                        for (int i = 0; i < Props.Length; i++)
                        {
                            //inserting property values to datatable rows
                            values[i] = Props[i].GetValue(item, null);
                        }
                        dataTable.Rows.Add(values);
                    }

                    //put a breakpoint here and check datatable
                    return dataTable;
                }
            }
        }

        //BegeleiderUI
        public class BegeleiderUI
        {
            public static int VW_TVNummer = 0;
            //aanmaken van panels en buttons die door meerdere methodes aangeroepen moeten worden binnen deze class
            public static Panel overlappend = new Panel();
            public static Button Terug = new Button();
            public static Button Toevoegen = new Button();
            public static Button Verwijderen = new Button();
            static Form popupform = new Form();
            static Label GkDocent = new Label();
            static Panel info = new Panel();
            public static ComboBox combolijst = new ComboBox();
            public static List<SomerenModel.Begeleiders.begeleiderstruct> begeleiderlijst = new List<SomerenModel.Begeleiders.begeleiderstruct>();
            static Button Verstuur = new Button();
            static Panel begeleiderpanelview = new Panel();
            static Label begeleiderviewtxt = new Label();
            static Label uitleg = new Label();

            //wanneer de pagina herladen moet worden
            public static void updatepanel()
            {
                info.Visible = false;
                Verstuur.Visible = false;
                Verwijderen.Visible = true;
                Toevoegen.Visible = true;
                Terug.Visible = false;
                VW_TVNummer = 0;

                overlappend.Controls.Remove(begeleiderpanelview);
                begeleiderlijst.Clear();
                begeleiderlistview.Clear();
                showActiviteitenbegeleider();
                overlappend.Controls.Add(begeleiderpanelview);

            }

            public static Control Showbegeleiders()
            {
                overlappend.Size = new Size(990, 450);
                overlappend.Location = new Point(0, 0);

                //panel voor listview van begeleiders

                begeleiderviewtxt.Size = new Size(400, 35);
                begeleiderviewtxt.Location = new Point(0, 0);
                begeleiderviewtxt.Text = "Begeleiderslijst:";
                begeleiderviewtxt.Font = new System.Drawing.Font("Bahnschrift Semibold", 14.0f);

                begeleiderpanelview.Controls.Add(begeleiderviewtxt);
                begeleiderpanelview.Size = new Size(450, 450);
                begeleiderpanelview.Location = new Point(0, 0);
                begeleiderpanelview.BorderStyle = BorderStyle.FixedSingle;
                begeleiderpanelview.Controls.Add(showActiviteitenbegeleider());
                begeleiderlistview.ColumnClick += begeleiderlistview_ColumnClick;

                //buttons 
                //terug button
                Terug.Size = new Size(150, 50);
                Terug.Location = new Point(480, 0);
                Terug.Text = "Terug";
                Terug.Visible = false;
                Terug.Click += Terug_Click;

                //toevoeg button
                Toevoegen.Size = new Size(150, 50);
                Toevoegen.Location = new Point(650, 0);
                Toevoegen.Text = "Toevoegen";
                Toevoegen.Click += Toevoegen_Click;
                Toevoegen.Visible = true;

                //verwijder button
                Verwijderen.Size = new Size(150, 50);
                Verwijderen.Location = new Point(820, 0);
                Verwijderen.Text = "Verwijderen";
                Verwijderen.Click += Verwijderen_Click;
                Verwijderen.Visible = true;

                //panel voor informatie na klikken van buttons
                info.Size = new Size(480, 480);
                info.Location = new Point(480, 70);
                info.Visible = false;

                uitleg.Size = new Size(480, 30);
                uitleg.Location = new Point(0, 0);
                uitleg.Text = "Het toevoegen/verwijderen van een docent aan de begeleiderslijst:";
                uitleg.Font = new System.Drawing.Font("Arial", 12.0f, FontStyle.Bold);
                info.Controls.Add(uitleg);

                combolijst.Size = new Size(200, 300);
                combolijst.Location = new Point(0, 90);
                combolijst.Visible = true;
                info.Controls.Add(combolijst);
                combolijst.Click += combolijst_Click;

                Verstuur.Size = new Size(150, 50);
                Verstuur.Location = new Point(300, 80);
                Verstuur.Text = "versturen";
                info.Controls.Add(Verstuur);
                Verstuur.Visible = false;
                Verstuur.Click += Verstuur_Click;

                //toevoegen van controls 
                overlappend.Controls.Add(info);
                overlappend.Controls.Add(begeleiderpanelview);
                overlappend.Controls.Add(Terug);
                overlappend.Controls.Add(Toevoegen);
                overlappend.Controls.Add(Verwijderen);

                return overlappend;
            }

            //als je op terug button klikt
            public static void Terug_Click(object sender, EventArgs e)
            {
                info.Visible = false;
                GkDocent.ResetText();
                Terug.Visible = false;
                Toevoegen.Visible = true;
                Verwijderen.Visible = true;
            }

            //als je op toevoeg button klikt
            public static void Toevoegen_Click(object sender, EventArgs e)
            {
                if (popupform.IsDisposed == true)
                {
                    popupform = new Form();
                }
                popupform.Size = new Size(800, 400);
                popupform.BackColor = Color.Gray;
                popupform.StartPosition = FormStartPosition.CenterScreen;

                int nummer = 1;
                var docentenlijst = ToonDocenten.DocentOphalen(nummer);
                popupform.Controls.Add(docentenlijst);
                docent.Click += docent_Click;
                VW_TVNummer = 1;

                popupform.Show();
                SomerenModel.Begeleiders.ComboBox();

                info.Visible = true;
                Terug.Visible = true;
                Toevoegen.Visible = false;
                Verwijderen.Visible = false;
            }

            //als je op verwijder button klikt
            public static void Verwijderen_Click(object sender, EventArgs e)
            {
                if (popupform.IsDisposed == true)
                {
                    popupform = new Form();
                }
                popupform.Size = new Size(800, 400);
                popupform.BackColor = Color.Gray;
                popupform.StartPosition = FormStartPosition.CenterScreen;

                int nummer = 1;
                var docentenlijst = ToonDocenten.DocentOphalen(nummer);
                popupform.Controls.Add(docentenlijst);
                docent.Click += docent_Click;
                VW_TVNummer = 2;

                popupform.Show();
                SomerenModel.Begeleiders.ComboBox();

                info.Visible = true;
                Terug.Visible = true;
                Toevoegen.Visible = false;

            }

            //wanneer je op verstuur button klikt
            public static void Verstuur_Click(object sender, EventArgs e)
            {
                if (VW_TVNummer == 1)
                {
                    SomerenDB.DB_TVBegeleiders(SomerenModel.Begeleiders.tvbegeleider.ActiviteitNaam, SomerenModel.Begeleiders.tvbegeleider.Docentnummer);
                    updatepanel();
                }
                else
                {
                    string message = "Weet je het zeker dat je een begeleider verwijderen?";
                    string caption = "Zeker weten?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Laat message box zien

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        SomerenDB.DB_VWBegeleiders(SomerenModel.Begeleiders.tvbegeleider.ActiviteitNaam, SomerenModel.Begeleiders.tvbegeleider.Docentnummer);
                        updatepanel();
                    }
                }
            }
            //als je op de combobox klikt
            public static void combolijst_Click(object sender, EventArgs e)
            {
                string item1 = combolijst.Items[0].ToString();
                SomerenModel.Begeleiders.tvbegeleider.ActiviteitNaam = item1;
                Verstuur.Visible = true;
            }
            //wanneer je opde listview van docent klikt
            public static void docent_Click(object sender, EventArgs e)
            {
                int item1 = Int32.Parse(docent.SelectedItems[0].SubItems[0].Text);
                SomerenModel.Begeleiders.tvbegeleider.Docentnummer = item1;
                string item2 = docent.SelectedItems[0].SubItems[1].Text.ToString();
                string item3 = docent.SelectedItems[0].SubItems[2].Text.ToString();

                GkDocent.Text = ("Docentnummer: " + SomerenModel.Begeleiders.tvbegeleider.Docentnummer +
                                    "\nVoornaam: " + item2 + "\nAchternaam: " + item3);

                GkDocent.Size = new Size(200, 200);
                GkDocent.Location = new Point(0, 30);
                GkDocent.Font = new System.Drawing.Font("Arial", 10.0f);
                info.Controls.Add(GkDocent);
                popupform.Close();
            }

            //wordt de activiteitenlijst geladen
            public static Control showActiviteitenbegeleider()
            {
                SomerenDB.DB_getBegeleiders(begeleiderlijst);
                //ListView d = new ListView();
                var c = Begeleiderlistviewaanmaak(begeleiderlijst);
                return c;
            }

            //de begeleiderlistview wordt aangemaakt
            public static Control Begeleiderlistviewaanmaak(List<SomerenModel.Begeleiders.begeleiderstruct> begeleiderlijst)
            {
                begeleiderlistview.Clear();
                begeleiderlistview.Scrollable = true;
                begeleiderlistview.View = View.Details;
                begeleiderlistview.FullRowSelect = true;
                begeleiderlistview.Height = 420;
                begeleiderlistview.Width = 450;
                begeleiderlistview.Location = new Point(0, 40);

                for (int i = 0; i < begeleiderlijst.Count; i++)
                {
                    var row = new string[]
                    {
                        begeleiderlijst[i].Actviteitnummer.ToString(),
                        begeleiderlijst[i].Datum.ToString("d"),
                        begeleiderlijst[i].ActiviteitNaam,
                        begeleiderlijst[i].Docentnummer.ToString(),
                        begeleiderlijst[i].Voornaam,
                        begeleiderlijst[i].Achternaam,
                    };
                    var lvi = new ListViewItem(row);
                    begeleiderlistview.Items.Add(lvi);

                }
                begeleiderlistview.Columns.Add("Actnummer");
                begeleiderlistview.Columns.Add("Datum");
                begeleiderlistview.Columns.Add("Activiteitnaam");
                begeleiderlistview.Columns.Add("Docentnummer");
                begeleiderlistview.Columns.Add("Voornaam");
                begeleiderlistview.Columns.Add("Achternaam");

                begeleiderlistview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                begeleiderlistview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                return begeleiderlistview;
            }

        }

        //UI Activiteitenlijst
        public class ToonActiviteitenlijst
        {
            public static Control showActiviteitenlijsten()
            {
                ListView c = new ListView();
                c.View = View.Details;
                c.FullRowSelect = true;
                c.Height = 565;
                c.Width = 800;

                int aantal = SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.Hoeveelactiviteitenlijsten();

                for (int i = 0; i < aantal; i++)
                {
                    var row = new string[] {
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.Activiteitnummer(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.Activiteitnaam(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.Datum(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.BeginTijd(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.EindTijd(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.StudentCapaciteit(i).ToString(),
                                        SomerenModel.ActiviteitenlijstC.Zoekactiviteitenlijst.BegeleiderCapaciteit(i).ToString()
                                        };
                    var lvi = new ListViewItem(row);
                    c.Items.Add(lvi);

                }
                c.Columns.Add("Activiteitnummer", -2);
                c.Columns.Add("Activiteitnaam", -2);
                c.Columns.Add("Datum", -2);
                c.Columns.Add("BeginTijd", -2);
                c.Columns.Add("EindTijd", -2);
                c.Columns.Add("StudentCapaciteit", -2);
                c.Columns.Add("BegeleiderCapaciteit", -2);

                return c;
            }
        }

        //SORT
        private static void begeleiderlistview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = begeleiderlistview.ListViewItemSorter as ItemComparer;

            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                begeleiderlistview.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            begeleiderlistview.Sort();
        }        
        private static void student_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = student.ListViewItemSorter as ItemComparer;

            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                student.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            student.Sort();
        }
        private static void KassaDrankview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = ToonKassa.KassaDrankview.ListViewItemSorter as ItemComparer;

            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                ToonKassa.KassaDrankview.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            ToonKassa.KassaDrankview.Sort();
        }
        private static void c_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = c.ListViewItemSorter as ItemComparer;

            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                c.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            c.Sort();
        }
    }
}
