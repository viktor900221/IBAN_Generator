
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Für MYSQL CONNECTION


namespace IBAN
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
                
                //Eingabe der Bankleitzahl und der Kontonummer die IBAN ermittelt und ausgibt.
                //für mindestens vier Länder auszulegen landesspezifischen Längen für Bankleitzahl und Kontonummer zu berücksichtigen.
                //Plausibilitätsprüfung der Eingabe
                //Fehleingaben abzufangen
                //Das Programm ist laufend wiederholbar (ohne Neustart) und kann durch einen Beendigungsbefehl verlassen werden.
                //Für eine 100% Lösung kommuniziert Ihr Programm mit einer eigenen Datenbank und kann die IBAN - Nummern abspeichern und einlesen.

                // using Mysl Datenbank -> anmelde daten wie bei php -> Iban Nummern abspeichern und einlesen



                //DEUTSCHLAND IBAN AUFBAU:
                //Längercode(LL): Konstant "DE"
                //Prüfziffer(PZ): 2-stellig, Modulus 97-10 (ISO 7064) BSP:21
                //Bankleitzahl(BLZ): Konstant 8-stellig, Bankidentifikation entsprechend deutschem Bankleitzahlenverzeichnis BSP: 30120400
                //Kontonummer(KTO): Konstant 10-stellig (ggf. mit vorangestellten Nullen) Kunden-Kontonummer BSP: 15228

                /*Die IBAN für unser Beispiel würde also lauten:

                DE21 3012 0400 0000 0152 28 (Papierformat)*/

                const string LL = "DE";


                //DATENBANK für die AKTUELLE BLZ Nummer angelegt: von der 'www.bundesbank.de' die blz-aktuell-xlsx datei runtergeladen und in SQL Format konvertiert. 


                //Eingabe für die Name der Kunde
                Console.WriteLine("\t" + "Bitte Name der Kunde eingeben!" + "\n");
                string kundename = Console.ReadLine();



                ////////////////Eingabe Bankleitzahl + Kontonummer//////////////////

                //Bankleitzahl:

                var Bankleitzahl_Global = 0; //Für Mysql muss var sein
                int Bankleitzahl_check_erg;



                do
                {
                    Console.WriteLine("\t" + "Bankleitzahl Eingeben: Bitte exakt 8 Ziffern eingeben!" + "\n"); // Darf max 8 Stellig sein und nur Ziffern!
                    Console.WriteLine();

                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.WriteLine("{0,1}", ".");

                    int Bankleitzahl = int.Parse(Console.ReadLine());
                    string Bankleitzahl_umwandeln = Bankleitzahl.ToString();
                    string Bankleitzahl_check = Bankleitzahl_umwandeln.Length.ToString();
                    Bankleitzahl_check_erg = int.Parse(Bankleitzahl_check);


                    if (Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 8)
                    {
                        Console.WriteLine("\t" + "\t" + "Ungültiges Bankleitzahl!" + "\n");
                    }
                    else {
                        Bankleitzahl_Global = Bankleitzahl;
                        Console.WriteLine("\t" + "\t" + "Die Bankleitzahl: " + Bankleitzahl_Global + "\n");

                    }


                } while (Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 8);



                //Kontonummer:

                long Kontonummer;
                int Kontonummer_check_erg;
                //string Kontonummer_Global_string;

               

                do
                {
                    Console.WriteLine("\t" + "Kontonummer Eingeben: Bitte maximum 10 Stellig! \n'*' Weniger als 10 Stellig wird automatisch mit Nullen aufgefüllt" + "\n"); // Darf max 10 Stellig sein und nur Ziffern!
                    Console.WriteLine();

                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.WriteLine("{0,1}", ".");



                    Kontonummer = long.Parse(Console.ReadLine());
                    string Kontonummer_umwandeln = Kontonummer.ToString();
                    string Kontonummer_check = Kontonummer_umwandeln.Length.ToString();
                    Kontonummer_check_erg = int.Parse(Kontonummer_check);
                    
                    Console.WriteLine(Kontonummer_check_erg);

                    //int test = Kontonummer * 1000;
                   // Console.WriteLine(test);

                    if (Kontonummer_check_erg > 10 || Kontonummer_check_erg < 1)
                    {
                        Console.WriteLine("\t" + "\t" + "Ungültiges Kontonummer!" + "\n");
                    }
                    else
                    {
                       
                        if (Kontonummer_check_erg < 10) {

                            //int kontonummer2 = Kontonummer;

                            //Hier soll er die Kontonummer mit Nullen ergänzen 
                            switch (Kontonummer_check_erg) {

                                case 1: Kontonummer = (long)(Kontonummer * 10000000000);
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 2:
                                    Kontonummer = Kontonummer * 100000000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 3:
                                    Kontonummer = Kontonummer * 10000000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 4:
                                    Kontonummer = Kontonummer * 1000000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 5:
                                    Kontonummer = Kontonummer * 100000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 6:
                                    Kontonummer = Kontonummer * 10000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 7:
                                    Kontonummer = Kontonummer * 1000;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 8:
                                    Kontonummer = Kontonummer * 100;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 9:
                                    Kontonummer = Kontonummer * 10;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                                case 10:
                                    Kontonummer = Kontonummer * 1;
                                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer + "\n");
                                    break;
                            } 
                     

                        }
                       
                    }


                } while (Kontonummer_check_erg > 10 || Kontonummer_check_erg < 1);

                //MYSQL CONNECTION

                //This is my connection string i have assigned the database file address path  
                string connStr = "server=localhost;user=root;database=blz_bundesbank;port=3306;password=";

                var BLZ = 0;
                var PZ = 0;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {


                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = "select * from blz_bundesbank.table_name where Bankleitzahl;";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    //read the data
                    while (rdr.Read())
                    {
                        //BLZ = rdr.GetInt32(0);
                        BLZ = rdr.GetInt32(0);
                        PZ = rdr.GetInt32(8); //Prüfziffer
                        if (BLZ == Bankleitzahl_Global) {
                            Console.WriteLine(rdr[2] + " -- " + BLZ + " gefunden");
                            //Bankleitzahl_Global_string = BLZ.ToString();
                            break;
                        }
                    }
                    rdr.Close();


                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }

                conn.Close();
                Console.WriteLine("Connection Closed. Press any key to exit...");
                Console.Read();

                //MYSQL CONNECTION CLOSED
            
                string BLZ2 = BLZ.ToString();
                string PZ2 = PZ.ToString();
                string Kontonummer_String2 = Kontonummer.ToString();

                string[] Iban_Array = new string[] { LL, PZ2, BLZ2, Kontonummer_String2};
                //string[,] Iban_Array = new string[4, 1] {{LL}, {PZ2}, {BLZ2}, {Kontonummer_String}};
                string Iban_Array_ergebnis = Iban_Array[0] + Iban_Array[1] + Iban_Array[2] + Iban_Array[3];
                
                double Iban_ergebnis = Convert.ToDouble(Iban_Array_ergebnis);
                
    ///////////////Ich möchte jetzt die Name in meine Tabelle in MYSQL speichern!///////////

                //MYSQL CONNECTION

                //This is my connection string i have assigned the database file address path  
                string conn2Str = "server=localhost;user=root;database=blz_bundesbank;port=3306;password=";
               

               var Name = kundename;
              MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(conn2Str);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO kunden_daten(Kunden_Name, Iban_nummer) VALUES(@Kunden_name, @Iban_nummer)";
                   // cmd.Prepare();
 
                    cmd.Parameters.AddWithValue("@Kunden_name", Name);
                    cmd.Parameters.AddWithValue("@Iban_nummer", Iban_ergebnis);
                    cmd.ExecuteNonQuery();    
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }

               
                Console.WriteLine("Connection Closed. Press any key to exit...");
                Console.Read();

                //MYSQL CONNECTION CLOSED

                Console.WriteLine("Ihre Iban Nummer lautet " + Iban_Array_ergebnis);

           Console.ReadKey();

        }
    }
}
