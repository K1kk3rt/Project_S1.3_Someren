using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    public static class SomerenModel
    {
        //student
        public class Student
        {
            //variablen based db table STUDENT
            public int Studentnummer;
            public string Voornaam;
            public string Achternaam;
            public string Taal;
            public int Kamernummer;

            public static List<Student> MainStudent(List<Student> Studenten)
            {
                SomerenDB.Student.DB_getStudents(Studenten);
                return Studenten;
            }

            public class Zoekstudent
            {
                public static int Hoeveelheidstudenten(List<Student> Studenten)
                {
                    int aantal = Studenten.Count;
                    return aantal;
                }

                public static int Studentnummer(int i, List<Student> Studenten)
                {
                    int Studentnummer = Studenten[i].Studentnummer;
                    return Studentnummer;
                }
                public static string Voornaam(int i, List<Student> Studenten)
                {
                    string Voornaam = Studenten[i].Voornaam;
                    return Voornaam;
                }
                public static string Achternaam(int i, List<Student> Studenten)
                {
                    string Achternaam = Studenten[i].Achternaam;
                    return Achternaam;
                }
                public static string Taal(int i, List<Student> Studenten)
                {
                    string Taal = Studenten[i].Taal;
                    return Taal;
                }
                public static int Kamernummer(int i, List<Student> Studenten)
                {
                    int Kamernummer = Studenten[i].Kamernummer;
                    return Kamernummer;
                }
            }

        }

        public class Begeleiders
        {
            public struct begeleiderstruct
            {
                public int Actviteitnummer;
                public DateTime Datum;
                public string ActiviteitNaam;
                public int Docentnummer;
                public string Voornaam;
                public string Achternaam;
            }
            public struct activiteit
            {
                public string Activiteitnaam;
            }
            public struct tvbegeleider
            {
                public static string ActiviteitNaam;
                public static int Docentnummer;
            }

            public static void ComboBox()
            {
                SomerenUI.BegeleiderUI.combolijst.Items.Clear();
                string[] activiteiten = new string[SomerenUI.BegeleiderUI.begeleiderlijst.Count];
                for (int i = 1; i < SomerenUI.BegeleiderUI.begeleiderlijst.Count; i++)
                {
                    if (i == 1)
                    {
                        activiteiten[i] = SomerenUI.BegeleiderUI.begeleiderlijst[i].ActiviteitNaam;
                    }
                    else
                    {
                        string act = SomerenUI.BegeleiderUI.begeleiderlijst[i].ActiviteitNaam;
                        for (int j = 1; j < SomerenUI.BegeleiderUI.begeleiderlijst.Count; j++)
                        {
                            string actarray = activiteiten[j];
                            if (actarray == act)
                            {
                                string leeg = "leeg";
                                activiteiten[j] = leeg;
                                continue;
                            }
                            else
                            {
                                activiteiten[i] = act;
                            }
                        }
                    }
                }
                for (int k = 1; k < activiteiten.Length; k++)
                {
                    string leeg = "leeg";
                    if (activiteiten[k] == leeg)
                    {
                        continue;
                    }
                    else
                    {
                        string act = activiteiten[k];
                        SomerenUI.BegeleiderUI.combolijst.Items.Add(act);
                    }
                }
            }
        }

            //docent
        public class Docent
        {

            public int Docentnummer;
            public int Begeleidersnummer;
            public string Voornaam;
            public string Achternaam;
            public string Vak;
            public string Telefoonnummer;
            public int Kamernummer;
            public string begeleider;


            public static List<Docent> MainDocent(List<Docent> Docenten)
            {
                SomerenDB.Docent.DB_getdocents(Docenten);
                return Docenten;
            }

            public class Zoekdocent
            {
                public static int Hoeveelheiddocenten(List<Docent> Docenten)
                {
                    int aantal = Docenten.Count;
                    return aantal;
                }

                public static int Docentnummer(int i, List<Docent> Docenten)
                {
                    int Docentnummer = Docenten[i].Docentnummer;
                    return Docentnummer;
                }
                public static string Voornaam(int i, List<Docent> Docenten)
                {
                    string Voornaam = Docenten[i].Voornaam;
                    return Voornaam;
                }
                public static string Achternaam(int i, List<Docent> Docenten)
                {
                    string Achternaam = Docenten[i].Achternaam;
                    return Achternaam;
                }
                public static string Vak(int i, List<Docent> Docenten)
                {
                    string Vak = Docenten[i].Vak;
                    return Vak;
                }
                public static string Telefoonnummer(int i, List<Docent> Docenten)
                {
                    string Telefoonnummer = Docenten[i].Telefoonnummer;
                    return Telefoonnummer;
                }
                public static int Kamernummer(int i, List<Docent> Docenten)
                {
                    int Kamernummer = Docenten[i].Kamernummer;
                    return Kamernummer;
                }
                public static string Begeleider(int i, List<Docent> Docenten)
                {
                    string begeleider = Docenten[i].begeleider;
                    return begeleider;
                }
            }
        }

        //kamer
        public class Kamer
        {
            public int Kamernummer;
            public int Kamercapaciteit;
            public int Studentnummer;
            public int Docentnummer;

            public static List<Kamer> MainKamer(List<SomerenModel.Kamer> Kamers)
            {
                SomerenDB.Kamer.DB_getkamers(Kamers);
                return Kamers;
            }

            public class Zoekkamer
            {
                public static int Hoeveelheidkamers(List<Kamer> Kamers)
                {
                    int aantal = Kamers.Count;
                    return aantal;
                }

                public static int Kamernummer(int i, List<Kamer> Kamers)
                {
                    int Kamernummer = Kamers[i].Kamernummer;
                    return Kamernummer;
                }
                public static int Kamercapaciteit(int i, List<Kamer> Kamers)
                {
                    int Kamercapaciteit = Kamers[i].Kamercapaciteit;
                    return Kamercapaciteit;
                }
                public static int Studentnummer(int i, List<Kamer> Kamers)
                {
                    int Studentnummer = Kamers[i].Studentnummer;
                    return Studentnummer;
                }
                public static int Docentnummer(int i, List<Kamer> Kamers)
                {
                    int Docentnummer = Kamers[i].Docentnummer;
                    return Docentnummer;
                }
            }
        }

        //omzetrapportage
        public class OmzetRapportage
        {
            public int Verkocht;

            public static double MainAfzet(string beginDatumSQL, string eindDatumSQL)
            {
                List<double> VerkochtteDrank = new List<double>();
                VerkochtteDrank = SomerenDB.OmzetRapportage.DB_getAfzet(VerkochtteDrank, beginDatumSQL, eindDatumSQL);
                double afzet = BerekenAfzet(VerkochtteDrank);
                return afzet;
            }

            public static double MainOmzet(string beginDatumSQL, string eindDatumSQL)
            {
                List<double> omzetList = new List<double>();
                SomerenDB.OmzetRapportage.DB_getOmzet(omzetList, beginDatumSQL, eindDatumSQL);
                double omzet = BerekenOmzet(omzetList);
                return omzet;
            }

            public static int MainAantalKlanten(string beginDatumSQL, string eindDatumSQL)
            {
                int aantalKlanten = SomerenDB.OmzetRapportage.DB_getAantalKlanten();
                return aantalKlanten;
            }

            public static double BerekenAfzet(List<double> VerkochtteDrank)
            {
                double afzet = 0;

                for (int index = 0; index < VerkochtteDrank.Count(); index++)
                {
                    double aantalVerkocht = VerkochtteDrank[index];
                    afzet = afzet + aantalVerkocht;
                }

                return afzet;
            }

            public static double BerekenOmzet(List<double> omzetList)
            {
                double omzet = 0;

                for (int index = 0; index < omzetList.Count(); index++)
                {
                    double omzetPDrankje = omzetList[index];
                    omzet = omzet + omzetPDrankje;
                }

                return omzet;
            }

            //variablen based db table STUDENT
            public int Transactienummer;
            public int Studentnummer;
            public string Datum;
            public string Dranknaam;
            public double aantalDrank;
            public double TotalePrijs;

            public static List<OmzetRapportage> MainKassa(List<OmzetRapportage> Kassa, string beginDatumSQL, string eindDatumSQL)
            {
                SomerenDB.OmzetRapportage.DB_getKassa(Kassa, beginDatumSQL, eindDatumSQL);
                return Kassa;
            }

            public class Zoekkassa
            {
                public static int Hoeveelheidtrans(List<OmzetRapportage> Kassa)
                {
                    int aantal = Kassa.Count;
                    return aantal;
                }

                public static int Transactienummer(int i, List<OmzetRapportage> Kassa)
                {
                    int Transactienummer = Kassa[i].Transactienummer;
                    return Transactienummer;
                }
                public static int Studentnummer(int i, List<OmzetRapportage> Kassa)
                {
                    int Studentnummer = Kassa[i].Studentnummer;
                    return Studentnummer;
                }
                public static string Datum(int i, List<OmzetRapportage> Kassa)
                {
                    string Datum = Kassa[i].Datum;
                    return Datum;
                }
                public static double aantalDrank(int i, List<OmzetRapportage> Kassa)
                {
                    double aantalDrank = Kassa[i].aantalDrank;
                    return aantalDrank;
                }
                public static string Dranknaam(int i, List<OmzetRapportage> Kassa)
                {
                    string Dranknaam = Kassa[i].Dranknaam;
                    return Dranknaam;
                }
                public static double TotalePrijs(int i, List<OmzetRapportage> Kassa)
                {
                    double TotalePrijs = Kassa[i].TotalePrijs;
                    return TotalePrijs;
                }


            }
        }

        //kassa
        public class Kassa
        {
            public static int drankaantal = 0;
            public static decimal prijsdrankje = 0;
            public static string geselecteerdedrankje = " ";
            //public static int aantal = 0;

            public struct Drankjes
            {
                public string drankNaam;
                public decimal Prijs;
                public decimal Voorraad;
            }
            public struct Gkstudent
            {
                public static string Studentnummer;
                public static string Voornaam;
                public static string Achternaam;
            }

            public static void selectdrank()
            {
                decimal nwprijs = prijsdrankje * drankaantal;

                DateTime thisday = DateTime.Today;
                string datum = thisday.ToString("d");

                SomerenDB.Kassa.DB_updateDrankVoorraad(drankaantal, geselecteerdedrankje, datum, nwprijs);
                //Someren_Form.panel1.Controls.Clear();

                SomerenUI.ToonKassa.afrekenbutton.Click -= SomerenUI.ToonKassa.afrekenbutton_Click;
                SomerenUI.ToonKassa.plusbutton.Click -= SomerenModel.Kassa.plusbutton_Click;
                SomerenUI.ToonKassa.minbutton.Click -= SomerenModel.Kassa.minbutton_Click;


                Kassa.drankaantal = 0;

                SomerenUI.ToonKassa.ShowKassa();
            }

            public static void plusbutton_Click(object sender, EventArgs e)
            {
                drankaantal = drankaantal + 1;
                //aantal = drankaantal + 1;
                //drankaantal = drankaantal + 1;

                decimal totprijs = prijsdrankje * drankaantal;
                SomerenUI.ToonKassa.prijsdrank.Text = ("Prijs: " + totprijs.ToString());
                SomerenUI.ToonKassa.aantaldrank.Text = ("Aantal: " + drankaantal);
                if (drankaantal > 0)
                {
                    SomerenUI.ToonKassa.minbutton.Enabled = true;
                }
                SomerenUI.ToonKassa.check++;
            }

            public static void minbutton_Click(object sender, EventArgs e)
            {
                drankaantal = drankaantal - 1;
                //aantal = drankaantal - 1;

                decimal totprijs = prijsdrankje * drankaantal;
                SomerenUI.ToonKassa.prijsdrank.Text = ("Prijs: " + totprijs.ToString());
                SomerenUI.ToonKassa.aantaldrank.Text = ("Aantal: " + drankaantal);

                if (drankaantal <= 1)
                {
                    SomerenUI.ToonKassa.minbutton.Enabled = false;
                }

                SomerenUI.ToonKassa.check++;

            }

        }

        //Drankvoorraad
        public class Drankvoorraad
        {
            public struct DrankvoorraadS
            {
                public int Dranknummer;
                public string NaamDrank;
                public int Voorraad;
                public string Opvoorraad;

            }

            static List<Drankvoorraad.DrankvoorraadS> Drankvoorraden = new List<Drankvoorraad.DrankvoorraadS>();

            public static void maindrankvoorraad()
            {
                SomerenDB.Drankvoorraad.Getdrankvoorraden(Drankvoorraden);
                SomerenUI.ToonDrankvoorraad.showDrankvoorraden();
            }

            public class Zoekdrankvoorraad
            {
                public static int Hoeveeldrankvoorraden()
                {
                    int aantal = Drankvoorraden.Count;
                    return aantal;
                }

                public static int Dranknummer(int i)
                {
                    int Dranknummer = Drankvoorraden[i].Dranknummer;
                    return Dranknummer;
                }
                public static string NaamDrank(int i)
                {
                    string NaamDrank = Drankvoorraden[i].NaamDrank;
                    return NaamDrank;
                }
                public static int Voorraad(int i)
                {
                    int Voorraad = Drankvoorraden[i].Voorraad;
                    return Voorraad;
                }
                public static string Opvoorraad(int i)
                {
                    string Opvoorraad = Drankvoorraden[i].Opvoorraad;
                    return Opvoorraad;
                }
            }
        }

        //WeekRooster
        public class WeekRooster
        {
            //variablen based db table ACTIVITEITENLIJST
            public int activiteitnummer { get; set; }
            public string activiteitNaam { get; set; }
            public string datum { get; set; }
            public string beginTijd { get; set; }
            //public TimeSpan beginTijd2 { get; set; }
            public string eindTijd { get; set; }
            public int studentCapaciteit { get; set; }
            public string begeleiderCapaciteit { get; set; }

            public static List<WeekRooster> MainWeekRoosterMaandag(List<WeekRooster> WeekRoosterMaandag)
            {
                SomerenDB.WeekRoosterMaandag.DB_getWeekRoosterMaandag(WeekRoosterMaandag);
                return WeekRoosterMaandag;
            }

            public static List<WeekRooster> MainWeekRoosterDinsdag(List<WeekRooster> WeekRoosterDinsdag)
            {
                SomerenDB.WeekRoosterMaandag.DB_getWeekRoosterDinsdag(WeekRoosterDinsdag);
                return WeekRoosterDinsdag;
            }

            public class Zoekstudent
            {
                public static int Hoeveelheidactiviteiten(List<WeekRooster> WeekRoosterMaandag)
                {
                    int aantal = WeekRoosterMaandag.Count;
                    return aantal;
                }

                public static int Activiteitnummer(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    int Activiteitnummer = WeekRoosterMaandag[i].activiteitnummer;
                    return Activiteitnummer;
                }
                public static string ActiviteitNaam(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    string ActiviteitNaam = WeekRoosterMaandag[i].activiteitNaam;
                    return ActiviteitNaam;
                }
                public static string Datum(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    string Datum = WeekRoosterMaandag[i].datum;
                    return Datum;
                }
                public static string BeginTijd(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    string BeginTijd = WeekRoosterMaandag[i].beginTijd;
                    return BeginTijd;
                }
                public static string EindTijd(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    string EindTijd = WeekRoosterMaandag[i].beginTijd;
                    return EindTijd;
                }

                public static int StudentCapaciteit(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    int StudentCapaciteit = WeekRoosterMaandag[i].studentCapaciteit;
                    return StudentCapaciteit;
                }
                public static string BegeleiderCapaciteit(int i, List<WeekRooster> WeekRoosterMaandag)
                {
                    string BegeleiderCapaciteit = WeekRoosterMaandag[i].begeleiderCapaciteit;
                    return BegeleiderCapaciteit;
                }
            }
        }

        //Activiteitenlijst
        public class ActiviteitenlijstC
        {
            public struct Activiteitenlijst
            {
                public int Activiteitnummer;
                public string Activiteitnaam;
                public string Datum;
                public string BeginTijd;
                public string EindTijd;
                public int StudentCapaciteit;
                public string BegeleiderCapaciteit;
            }

            static List<Activiteitenlijst> Activiteitenlijsten = new List<Activiteitenlijst>();

            public static void mainactiviteitenlijst()
            {
                SomerenDB.Activiteitenlijst.Getactiviteitenlijsten(Activiteitenlijsten);

                SomerenUI.ToonActiviteitenlijst.showActiviteitenlijsten();
            }

            public class Zoekactiviteitenlijst
            {
                public static int Hoeveelactiviteitenlijsten()
                {
                    int aantal = Activiteitenlijsten.Count;
                    return aantal;
                }

                public static int Activiteitnummer(int i)
                {
                    int Activiteitnummer = Activiteitenlijsten[i].Activiteitnummer;
                    return Activiteitnummer;
                }
                public static string Activiteitnaam(int i)
                {
                    string Activiteitnaam = Activiteitenlijsten[i].Activiteitnaam;
                    return Activiteitnaam;
                }
                public static string Datum(int i)
                {
                    string Datum = Activiteitenlijsten[i].Datum;
                    return Datum;
                }

                public static string BeginTijd(int i)
                {
                    string BeginTijd = Activiteitenlijsten[i].BeginTijd;
                    return BeginTijd;
                }

                public static string EindTijd(int i)
                {
                    string EindTijd = Activiteitenlijsten[i].EindTijd;
                    return EindTijd;
                }

                public static int StudentCapaciteit(int i)
                {
                    int StudentCapaciteit = Activiteitenlijsten[i].StudentCapaciteit;
                    return StudentCapaciteit;
                }

                public static string BegeleiderCapaciteit(int i)
                {
                    string BegeleiderCapaciteit = Activiteitenlijsten[i].BegeleiderCapaciteit;
                    return BegeleiderCapaciteit;
                }
            }
        }
    }
}
