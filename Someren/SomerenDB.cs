using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Someren
{
    class SomerenDB
    {  
        //DB shizzle
        private static SqlConnection openConnectieDB()
        {
            string host = "den1.mssql4.gear.host";
            string db = "projectgroepa3";
            string user = "projectgroepa3";
            string password = "Zi9F5-~ksuPn";
            //string port = "3306";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                
                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }            
        }

        private static void sluitConnectieDB(SqlConnection connection)
        {
            connection.Close();
        }

        public static void DB_TVBegeleiders(string ActiviteitNaam, int Docentnummmer)
        {
            int nummer = 0;
            SqlConnection connection = openConnectieDB();
            openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT Activiteitnummer FROM ACTIVITEITENLIJST WHERE ActiviteitNaam like '" + ActiviteitNaam + "';");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nummer = (int)reader["Activiteitnummer"];
            }
            reader.Close();
            sluitConnectieDB(connection);

            //tweede query

            SqlConnection connection1 = openConnectieDB();
            openConnectieDB();

            StringBuilder sbquery1 = new StringBuilder();
            sbquery1.Append("INSERT INTO DBO.ACTIVITEITENBEGELEIDER(Activiteitennummer, Docentnummer) VALUES(" + nummer + "," + Docentnummmer + ");");
            String sql1 = sbquery1.ToString();

            SqlCommand command1 = new SqlCommand(sql1, connection1);
            command1.ExecuteNonQuery();

            sluitConnectieDB(connection1);
        }
        //verwijderen van begeleiders
        public static void DB_VWBegeleiders(string ActiviteitNaam, int Docentnummmer)
        {
            int nummer = 0;
            SqlConnection connection = openConnectieDB();
            openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT Activiteitnummer FROM ACTIVITEITENLIJST WHERE ActiviteitNaam like '" + ActiviteitNaam + "';");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nummer = (int)reader["Activiteitnummer"];
            }
            reader.Close();
            sluitConnectieDB(connection);

            //tweede query

            SqlConnection connection1 = openConnectieDB();
            openConnectieDB();

            StringBuilder sbquery1 = new StringBuilder();
            sbquery1.Append("DELETE FROM DBO.ACTIVITEITENBEGELEIDER WHERE Activiteitennummer = " + nummer + " AND Docentnummer = " + Docentnummmer + ";");
            String sql1 = sbquery1.ToString();

            SqlCommand command1 = new SqlCommand(sql1, connection1);
            command1.ExecuteNonQuery();

            sluitConnectieDB(connection1);
        }
        //het ophalen van begeleiders
        public static List<SomerenModel.Begeleiders.begeleiderstruct> DB_getBegeleiders(List<SomerenModel.Begeleiders.begeleiderstruct> begeleiderlijst)
        {
            SqlConnection connection = openConnectieDB();
            openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT AL.Activiteitnummer, AL.Datum, AL.ActiviteitNaam,AB.Docentnummer, D.Voornaam, D.Achternaam FROM[projectgroepa3].[dbo].[ACTIVITEITENLIJST] AS AL JOIN[projectgroepa3].[dbo].[ACTIVITEITENBEGELEIDER] AS AB ON AB.Activiteitennummer = AL.Activiteitnummer JOIN[projectgroepa3].[dbo].[DOCENT] AS D ON AB.Docentnummer = D.Docentnummer; ");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SomerenModel.Begeleiders.begeleiderstruct begeleider = LeesBegeleider(reader);
                begeleiderlijst.Add(begeleider);
            }

            reader.Close();
            sluitConnectieDB(connection);
            return begeleiderlijst;
        }
        //het plaatsen van deze begeleiders in een struct/list
        public static SomerenModel.Begeleiders.begeleiderstruct LeesBegeleider(SqlDataReader reader)
        {
            SomerenModel.Begeleiders.begeleiderstruct begeleider;

            begeleider.Actviteitnummer = (int)reader["Activiteitnummer"];
            begeleider.Datum = (DateTime)reader["Datum"];
            begeleider.ActiviteitNaam = (string)reader["ActiviteitNaam"];
            begeleider.Docentnummer = (int)reader["Docentnummer"];
            begeleider.Voornaam = (string)reader["Voornaam"];
            begeleider.Achternaam = (string)reader["Achternaam"];

            return begeleider;
        }

        //student
        public class Student
        {
            public static List<SomerenModel.Student> DB_getStudents(List<SomerenModel.Student> Studenten)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT Studentnummer, Voornaam, Achternaam, Taal, Kamernummer FROM STUDENT");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SomerenModel.Student student = LeesStudent(reader);
                    Studenten.Add(student);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return Studenten;
            }

            public static SomerenModel.Student LeesStudent(SqlDataReader reader)
            {
                SomerenModel.Student student = new SomerenModel.Student();

                student.Studentnummer = (int)reader["Studentnummer"];
                student.Voornaam = (string)reader["Voornaam"];
                student.Achternaam = (string)reader["Achternaam"];
                student.Taal = (string)reader["Taal"];
                student.Kamernummer = (int)reader["Kamernummer"];

                return student;
            }
        }

        //docent
        public class Docent
        {
            public static List<SomerenModel.Docent> DB_getdocents(List<SomerenModel.Docent> Docenten)
            {
                SqlConnection connection = openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT Docentnummer, Voornaam, Achternaam, Vak, Telefoonnummer, Kamernummer, Begeleider FROM DOCENT");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    SomerenModel.Docent docent = LeesDocent(reader);
                    Docenten.Add(docent);
                }
                reader.Close();
                sluitConnectieDB(connection);
                return Docenten;
            }

            public static SomerenModel.Docent LeesDocent(SqlDataReader reader)
            {
                SomerenModel.Docent docent = new SomerenModel.Docent();

                docent.Docentnummer = (int)reader["Docentnummer"];
                docent.Voornaam = (string)reader["Voornaam"];
                docent.Achternaam = (string)reader["Achternaam"];
                docent.Vak = (string)reader["Vak"];
                if (reader.IsDBNull(4))
                {
                    docent.Telefoonnummer = " ";
                }
                else
                {
                    docent.Telefoonnummer = (string)reader["Telefoonnummer"];
                }
                docent.Kamernummer = (int)reader["Kamernummer"];
                //docent.Telefoonnummer = (string)reader["Telefoonnummer"];
                docent.Kamernummer = (int)reader["Kamernummer"];
                docent.begeleider = (string)reader["Begeleider"];

                return docent;
            }
        }
        
        //kamer
        public class Kamer
        {
            public static List<SomerenModel.Kamer> DB_getkamers(List<SomerenModel.Kamer> Kamers)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT Kamernummer, Kamercapaciteit FROM KAMER");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    SomerenModel.Kamer kamer = LeesKamer(reader);
                    Kamers.Add(kamer);
                }
                reader.Close();
                sluitConnectieDB(connection);
                return Kamers;
            }

            public static SomerenModel.Kamer LeesKamer(SqlDataReader reader)
            {
                SomerenModel.Kamer kamer = new SomerenModel.Kamer();

                kamer.Kamernummer = (int)reader["Kamernummer"];
                kamer.Kamercapaciteit = (int)reader["Kamercapaciteit"];

                return kamer;
            }
        }

        //omzetrapportage
        public class OmzetRapportage
        {
                public static List<double> DB_getAfzet(List<double> VerkochtteDrank, string beginDatumSQL, string eindDatumSQL)
                {
                    SqlConnection connection = openConnectieDB();

                    openConnectieDB();

                    StringBuilder sbquery = new StringBuilder();
                    sbquery.Append("SELECT Datum, aantalDrank FROM KASSA WHERE Datum BETWEEN '" + beginDatumSQL + "' AND '" + eindDatumSQL + "'");
                    String sql = sbquery.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        double verkochtteDrank = LeesVerkochtteDrank(reader);
                        VerkochtteDrank.Add(verkochtteDrank);
                    }

                    reader.Close();
                    sluitConnectieDB(connection);
                    return VerkochtteDrank;
                }

                public static double LeesVerkochtteDrank(SqlDataReader reader)
                {
                double verkocht = Convert.ToDouble(reader["aantalDrank"]);

                return verkocht;
                }

            public static List<double> DB_getOmzet(List<double> omzetList, string beginDatumSQL, string eindDatumSQL)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT aantalDrank * TotalePrijs AS Omzet FROM KASSA WHERE Datum BETWEEN '" + beginDatumSQL + "' AND '" + eindDatumSQL + "'");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    double omzet = LeesOmzet(reader);
                    omzetList.Add(omzet);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return omzetList;
            }

            public static double LeesOmzet(SqlDataReader reader)
            {
                decimal omzetDecimal = (decimal)reader["Omzet"];
                double omzet = (double)omzetDecimal;

                return omzet;
            }

            public static int DB_getAantalKlanten()
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT COUNT(DISTINCT Studentnummer) AS totS FROM Kassa");

                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                int aantalKlanten = 0;

                if (reader.Read())
                {
                    aantalKlanten = (int)reader["totS"];
                }
                ;

                reader.Close();
                sluitConnectieDB(connection);
                return aantalKlanten;
            }

            public static List<SomerenModel.OmzetRapportage> DB_getKassa(List<SomerenModel.OmzetRapportage> Kassa, string beginDatumSQL, string eindDatumSQL) 
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT * FROM KASSA WHERE Datum BETWEEN '" + beginDatumSQL + "' AND '" + eindDatumSQL + "';");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SomerenModel.OmzetRapportage kassa = LeesKassa(reader);
                    Kassa.Add(kassa);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return Kassa;
            }

            public static SomerenModel.OmzetRapportage LeesKassa(SqlDataReader reader)
            {
                SomerenModel.OmzetRapportage kassa = new SomerenModel.OmzetRapportage();

                kassa.Transactienummer = (int)reader["Transactienummer"];
                kassa.Studentnummer = (int)reader["Studentnummer"];
                //kassa.Datum = Convert.ToString(reader["Datum"]);
                kassa.Datum = ((DateTime)reader["Datum"]).ToString("dd-MM-yyyy");
                kassa.Dranknaam = (string)reader["Dranknaam"];
                kassa.aantalDrank = Convert.ToDouble(reader["aantalDrank"]);
                kassa.TotalePrijs = Convert.ToDouble(reader["TotalePrijs"]);

                return kassa;
            }
        }

        //Kassa
        public class Kassa
        {
            public static List<SomerenModel.Kassa.Drankjes> DB_getKassaDrankvoorraad(List<SomerenModel.Kassa.Drankjes> KassaDrank)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT [NaamDrank],[VerkoopPrijs],[Voorraad] FROM DRANKVOORRAAD");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SomerenModel.Kassa.Drankjes Drankvoorraad = LeesDrankvoorraad(reader);
                    KassaDrank.Add(Drankvoorraad);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return KassaDrank;
            }
            public static SomerenModel.Kassa.Drankjes LeesDrankvoorraad(SqlDataReader reader)
            {
                SomerenModel.Kassa.Drankjes Drankvoorraad;

                Drankvoorraad.drankNaam = (string)reader["NaamDrank"];
                Drankvoorraad.Prijs = (decimal)reader["VerkoopPrijs"];
                Drankvoorraad.Voorraad = (int)reader["Voorraad"];

                return Drankvoorraad;
            }

            public static void DB_updateDrankVoorraad(int drankaantal, string geselecteerdedrankje, string datum, decimal nwprijs)
            {
                string studentnummer = SomerenModel.Kassa.Gkstudent.Studentnummer;
                //decimal nieuwprijs = (nwprijs.ToString(CultureInfo.CreateSpecificCulture("en-GB")));


                //Convert.ToChar(geselecteerdedrankje);
                SqlConnection connection = openConnectieDB();
                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("UPDATE DBO.DRANKVOORRAAD SET Voorraad = Voorraad -" + drankaantal + " WHERE NaamDrank = '" + geselecteerdedrankje + "';" + "INSERT INTO KASSA(Studentnummer, Datum, Dranknaam, aantalDrank, TotalePrijs) VALUES(" + studentnummer + ",'" + datum + "', '" + geselecteerdedrankje + "'," + drankaantal + "," + nwprijs + ");");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                reader.Close();
                sluitConnectieDB(connection);
            }
        }

        //Drankvoorraad
        public class Drankvoorraad
        {
            public static List<SomerenModel.Drankvoorraad.DrankvoorraadS> Getdrankvoorraden(List<SomerenModel.Drankvoorraad.DrankvoorraadS> Drankvoorraden)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT * FROM Drankvoorraad WHERE Voorraad > 1 AND Verkoopprijs > 1 ORDER BY Voorraad, Inkoopprijs, verkocht");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    SomerenModel.Drankvoorraad.DrankvoorraadS drankvoorraad = LeesDrankvoorraad(reader);
                    Drankvoorraden.Add(drankvoorraad);
                }
                reader.Close();
                sluitConnectieDB(connection);
                return Drankvoorraden;
            }

            public static SomerenModel.Drankvoorraad.DrankvoorraadS LeesDrankvoorraad(SqlDataReader reader)
            {
                SomerenModel.Drankvoorraad.DrankvoorraadS drankvoorraad;

                drankvoorraad.Dranknummer = (int)reader["Dranknummer"];
                drankvoorraad.NaamDrank = (string)reader["NaamDrank"];
                drankvoorraad.Voorraad = (int)reader["Voorraad"];
                drankvoorraad.Opvoorraad = (string)reader["Opvoorraad"];


                if (drankvoorraad.Voorraad > 10)
                {
                    drankvoorraad.Opvoorraad = "Op Voorraad";
                }

                if (drankvoorraad.Voorraad < 1)
                {
                    drankvoorraad.Opvoorraad = "Niet Voorraad";
                }

                return drankvoorraad;
            }

            // Drank Toevoegen

            public static void DrankToevoegen(string NaamDrankToevoegen, string VoorraadToevoegen, string InkoopPrijsToevoegen, string VerkoopPrijsToevoegen)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();
                //string B = txtDrankNaamToevoegen.Text;
                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("insert into drankvoorraad (NaamDrank, Voorraad, InkoopPrijs, VerkoopPrijs, Verkocht, Opvoorraad ) values ('" + NaamDrankToevoegen + "', '" + VoorraadToevoegen + "', '" + InkoopPrijsToevoegen + "', '" + VerkoopPrijsToevoegen + "', '0', 'a')");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                sluitConnectieDB(connection);
                System.Windows.Forms.MessageBox.Show("Toegevoegd!");
            }

        }

        //Weekrooster
        public class WeekRoosterMaandag 
        {
            public static List<SomerenModel.WeekRooster> DB_getWeekRoosterMaandag(List<SomerenModel.WeekRooster> WeekRoosterMaandag)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT * FROM ACTIVITEITENLIJST WHERE Datum = '2018-04-11' OR Datum = '2018-11-04'");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SomerenModel.WeekRooster rooster = LeesRooster(reader);
                    WeekRoosterMaandag.Add(rooster);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return WeekRoosterMaandag;
            }

            public static SomerenModel.WeekRooster LeesRooster(SqlDataReader reader)
            {
                SomerenModel.WeekRooster rooster = new SomerenModel.WeekRooster();

                rooster.activiteitnummer = (int)reader["Activiteitnummer"];
                rooster.activiteitNaam = (string)reader["ActiviteitNaam"];
                rooster.datum = ((DateTime)reader["Datum"]).ToString("dd-MM-yyyy");
                //rooster.beginTijd2 = ((TimeSpan)reader["BeginTijd"]);
                rooster.beginTijd = Convert.ToString(reader["BeginTijd"]);
                rooster.eindTijd = Convert.ToString(reader["EindTijd"]);
                rooster.studentCapaciteit = (int)reader["StudentCapaciteit"];
                if (reader.IsDBNull(6))
                {
                    rooster.begeleiderCapaciteit = "Onbegeleid".ToString();
                }
                else
                {
                    rooster.begeleiderCapaciteit = (string)reader["BegeleiderCapaciteit"];
                }

                //rooster.begeleiderCapaciteit = (int)reader["BegeleiderCapaciteit"];

                return rooster;
            }

            public static List<SomerenModel.WeekRooster> DB_getWeekRoosterDinsdag(List<SomerenModel.WeekRooster> WeekRoosterDinsdag)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT * FROM ACTIVITEITENLIJST WHERE Datum = '2018-04-12'");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SomerenModel.WeekRooster rooster = LeesRooster(reader);
                    WeekRoosterDinsdag.Add(rooster);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return WeekRoosterDinsdag;
            }


            public static void DB_getWeekRoosterUpdate(DataTable DT)
            {
                SqlConnection connection = openConnectieDB();

                openConnectieDB();

                // Perform an initial count on the destination table.
                SqlCommand commandRowCount = new SqlCommand(
                "SELECT COUNT(*) FROM " + "ACTIVITEITENLIJST;", connection);
                long countStart = System.Convert.ToInt32(commandRowCount.ExecuteScalar());

                //sluitConnectieDB(connection);

                openConnectieDB();

                for (int x = 0; x < countStart; x++)
                {
                    try
                    {
                        int activiteitnummer = Convert.ToInt32(DT.Rows[x][0]);
                        string activiteitnaam = (string)DT.Rows[x][1];
                        //DateTime datum = Convert.ToDateTime(Convert.ToDateTime(DT.Rows[x][2]).ToString("yyyy-MM-dd");
                        DateTime thisday = Convert.ToDateTime(DT.Rows[x][2]);
                        string datum = thisday.ToString("yyyy-dd-MM");
                        TimeSpan beginTijd = TimeSpan.Parse((string)DT.Rows[x][3]);
                        TimeSpan eindTijd = TimeSpan.Parse((string)DT.Rows[x][4]);
                        int studentCapaciteit = Int32.Parse((string)DT.Rows[x][5]);
                        string begeleidercapaciteit = (string)DT.Rows[x][6];

                        StringBuilder sbquery = new StringBuilder();
                        sbquery.Append("UPDATE DBO.ACTIVITEITENLIJST SET Activiteitnummer = " + activiteitnummer + ", ActiviteitNaam = '" + activiteitnaam + "', Datum = '" + datum + "', BeginTijd = '" + beginTijd + "', EindTijd = '" + eindTijd + "', StudentCapaciteit = " + studentCapaciteit + ", BegeleiderCapaciteit = '" + begeleidercapaciteit + "' WHERE Activiteitnummer = " + activiteitnummer + "; ");
                        String sql = sbquery.ToString();

                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        SomerenUI.ToonWeekRooster.lbl_UpdateFeedbackM.Text = "";
                    }

                }

                //long countEnd = System.Convert.ToInt32(
                //commandRowCount.ExecuteScalar());
                //int addedRows = (int)countEnd - (int)countStart;
                //string tekst = "Ending row count = " + " " + countEnd + "\nrows " + addedRows + " were added ";
                //SomerenUI.ToonWeekRooster.lbl_UpdateFeedbackM.Text = tekst;

                sluitConnectieDB(connection);
                //reader.Close();
            }

        }

        //Activiteitenlijst
        public class Activiteitenlijst
        {
            public static List<SomerenModel.ActiviteitenlijstC.Activiteitenlijst> Getactiviteitenlijsten(List<SomerenModel.ActiviteitenlijstC.Activiteitenlijst> Activiteitenlijsten)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();

                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("SELECT * FROM Activiteitenlijst2");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    SomerenModel.ActiviteitenlijstC.Activiteitenlijst activiteitenlijst = LeesActiviteitenlijst(reader);
                    Activiteitenlijsten.Add(activiteitenlijst);
                }

                reader.Close();
                sluitConnectieDB(connection);
                return Activiteitenlijsten;
            }

            public static SomerenModel.ActiviteitenlijstC.Activiteitenlijst LeesActiviteitenlijst(SqlDataReader reader)
            {
                SomerenModel.ActiviteitenlijstC.Activiteitenlijst activiteitenlijst;

                activiteitenlijst.Activiteitnummer = (int)reader["Activiteitnummer"];
                activiteitenlijst.Activiteitnaam = (string)reader["Activiteitnaam"];
                activiteitenlijst.Datum = (string)reader["Datum"];
                activiteitenlijst.BeginTijd = (string)reader["BeginTijd"];
                activiteitenlijst.EindTijd = (string)reader["EindTijd"];
                activiteitenlijst.StudentCapaciteit = (int)reader["StudentCapaciteit"];
                activiteitenlijst.BegeleiderCapaciteit = (string)reader["BegeleiderCapaciteit"];

                return activiteitenlijst;
            }

            // Activiteit Verwijderen

            public static void ActiviteitVerwijderen(string ActiviteitVerwijderen)
            {
                if ((MessageBox.Show("Weet je zeker dat je dit activiteit wilt verwijderen?", "Melding",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    SqlConnection connection = openConnectieDB();
                    //connection.Open();
                    //string B = txtDrankNaamToevoegen.Text;
                    StringBuilder sbquery = new StringBuilder();
                    sbquery.Append("Delete from ACTIVITEITENLIJST2 where ActiviteitNaam = ('" + ActiviteitVerwijderen + "')");
                    String sql = sbquery.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    sluitConnectieDB(connection);
                    System.Windows.Forms.MessageBox.Show("Verwijderd!");
                }
            }

            // Activiteit Toevoegen

            public static void ActiviteitToevoegen(string ActiviteitNummerToevoegen, string ActiviteitNaamToevoegen, string ActiviteitDatumToevoegen, string ActiviteitBeginTijdToevoegen, string ActiviteitEindTijdToevoegen, string ActiviteitStudentCapaciteitToevoegen, string ActiviteitBegeleiderCapaciteitToevoegen)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();
                //string B = txtDrankNaamToevoegen.Text;
                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("insert into ACTIVITEITENLIJST2 (Activiteitnummer, Activiteitnaam, Datum, BeginTijd, EindTijd, StudentCapaciteit, BegeleiderCapaciteit ) values ('" + ActiviteitNummerToevoegen + "', '" + ActiviteitNaamToevoegen + "', '" + ActiviteitDatumToevoegen + "', '" + ActiviteitBeginTijdToevoegen + "', '" + ActiviteitEindTijdToevoegen + "', '" + ActiviteitStudentCapaciteitToevoegen + "', '" + ActiviteitBegeleiderCapaciteitToevoegen + "')");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                sluitConnectieDB(connection);
                System.Windows.Forms.MessageBox.Show("Toegevoegd!");
            }

            // Activiteit Wijzigen

            public static void ActiviteitWijzigen(string ActiviteitNaamWijzigen, string ActiviteitDatumWijzigen, string ActiviteitBeginTijdWijzigen, string ActiviteitEindTijdWijzigen, string ActiviteitStudentCapaciteitWijzigen, string ActiviteitBegeleiderCapaciteitWijzigen)
            {
                SqlConnection connection = openConnectieDB();
                //connection.Open();
                //string B = txtDrankNaamToevoegen.Text;
                StringBuilder sbquery = new StringBuilder();
                sbquery.Append("UPDATE ACTIVITEITENLIJST2 SET Datum = ('" + ActiviteitDatumWijzigen + "'), BeginTijd = ('" + ActiviteitBeginTijdWijzigen + "'), EindTijd = ('" + ActiviteitEindTijdWijzigen + "'), StudentCapaciteit = ('" + ActiviteitStudentCapaciteitWijzigen + "'), BegeleiderCapaciteit = ('" + ActiviteitBegeleiderCapaciteitWijzigen + "') WHERE ActiviteitNaam = ('" + ActiviteitNaamWijzigen + "')");
                String sql = sbquery.ToString();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                sluitConnectieDB(connection);
                System.Windows.Forms.MessageBox.Show("Gewijzigd!");
            }
        }
    }
}   

