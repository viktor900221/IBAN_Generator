
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
                //*Als erstes Herr Rust: bitte unten bei MYSQL CONNECTION string connStr mit ihre Verbindungsdaten anpassen
                
                //Globale Variablen
                const string LL = "DE";
                var leere = 1; // 
                var BLZ = 0; //var ist bevorzugt für unsere MYSQL TRY CATCH //BLZ = Bankleitzahl
                var PZ = 0; //PZ = Prüfziffer
                long Kontonummer; //long vs int -> Long hat ein größeren Bereich. 
               

        
                //Eingabe:Kundenname:
                Console.WriteLine("\n" + "\t" + "Bitte Name der Kunde eingeben!" + "\n");
                string kundename = Console.ReadLine();
          
              do { //diese do-while Schleife hilft uns bei falschen BLZ Eingabe wieder die Möglichkeit es zu korrigieren.   
                
                //Eingabe Bankleitzahl + Kontonummer:

                //Bankleitzahl: (Hier wird erstmal nur die Stellenlänge geprüft nicht den Wert)

                var Bankleitzahl_Global = 0; //Für MYSQL sollte man 'var' benutzen sonst können Probleme auftreten innerhalb unser Try Catch von MYSQL.
                int Bankleitzahl_check_erg;
                
                //do-while Schleife: Wird solange ablaufen bis der User als Bankleitzahl kleiner oder größer als 8 stellige Ziffern eingibt. Muss exakt 8 stellig sein! Dann wird unser Wert gespeichert. 
                do
                {
                    Console.WriteLine("\n" + "\t" + "Bankleitzahl Eingeben: Bitte exakt 8 Ziffern eingeben!" + "\n"); // Darf max 8 Stellig sein und nur Ziffern!
                    Console.WriteLine();
                    //Hilfe bei der Eingabe für die Orientation. 
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.Write("{0,1}", ".");
                    Console.WriteLine("{0,1}", ".");
                    //
                    int Bankleitzahl = int.Parse(Console.ReadLine()); //Die Eingabe wird als Integer gespeichert (da wir in unsere if else als Integer für Bankleitzahl_Global weitergeben wollen)
                    string Bankleitzahl_umwandeln = Bankleitzahl.ToString(); //Umwandeln in eine String
                    string Bankleitzahl_check = Bankleitzahl_umwandeln.Length.ToString(); //Für die Überprüfüng von der Länge der Eingabe-> brauche ich die Length von der String 
                    Bankleitzahl_check_erg = int.Parse(Bankleitzahl_check); //Das Ergebnis von der Länge der String speichere ich als int in 'Bankleitzahl_check_erg'

                    //Hier in if lasse ich 'Bankleitzahl_check_erg' abchecken: wenn es größer oder kleiner als 8 ist dann ist es ungültig. 
                    if (Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 8)
                    {
                        Console.WriteLine("\t" + "\t" + "Ungültiges Bankleitzahl!" + "\n");
                    }
                    else {// Ansonsten wird unsere int Bankleitzahl in Bankleitzahl_Global gespeichert.
                        Bankleitzahl_Global = Bankleitzahl;
                        Console.WriteLine("\t" + "\t" + "Die Bankleitzahl: " + Bankleitzahl_Global + "\n");
                    }

                } while (Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 8);

                //Kontonummer:

                
                int Kontonummer_check_erg; 
             
                //do-while Schleife: Wird solange ablaufen bis der User kleiner als 1 stellige Ziffern oder größer als 10 stellige Ziffern eingibt. 
                do
                {
                    Console.WriteLine("\t" + "Kontonummer Eingeben: Bitte maximum 10 Stellig! \n'*' Weniger als 10 Stellig wird automatisch mit Nullen aufgefüllt" + "\n"); // Darf max 10 Stellig sein und nur Ziffern!
                    Console.WriteLine();
                    //Hilfe bei der Eingabe für die Orientation. 
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
                    //


                    Kontonummer = long.Parse(Console.ReadLine());//Die Eingabe wird als long gespeichert 
                    string Kontonummer_umwandeln = Kontonummer.ToString();//Umwandeln in eine String
                    string Kontonummer_check = Kontonummer_umwandeln.Length.ToString();//Für die Überprüfüng von der Länge der Eingabe-> brauche ich die Length von der String 
                    Kontonummer_check_erg = int.Parse(Kontonummer_check);//Das Ergebnis von der Länge der String speichere ich als int in 'Kontonummer_check_erg'

                    //Hier in if lasse ich 'Kontonummer_check_erg' abchecken: wenn es größer als 10 stellig ist dann ist es ungültig.   
                    if (Kontonummer_check_erg > 10)
                    {
                        Console.WriteLine("\t" + "\t" + "Ungültiges Kontonummer!" + "\n");
                    }
                    else
                    {
                        
                            //Wenn es kleiner als 10 stellig ist dann soll in Switch-case mit Nullen aufgefüllt werden   
                   
                            switch (Kontonummer_check_erg) {

                                case 1: Kontonummer = (long)(Kontonummer * 1000000000); //Deswegen ist wichtig long und nicht int als Datentyp eingeben sonst würden wir falsches Ergebnis bekommen.
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

                } while (Kontonummer_check_erg > 10 || Kontonummer_check_erg < 1);

                
            
                //MYSQL Verbindung
          
                //connStr ist mein String für die Verbindung: Zugewiesen wurde die Verbindungsdaten von meiner Datenbank.  
                string connStr = "server=localhost;user=root;database=blz_bundesbank;port=3306;password=";
                
               
              
                MySqlConnection conn = new MySqlConnection(connStr); 
                try
                {

                    //Verbindung wird aufgebaut
                    conn.Open(); 
                    //
                    //SQL Abfrage 
                    string sql = "select * from blz_bundesbank.table_name where Bankleitzahl;";
                    //MySqlCommand Methode (Wir übergeben 2 Parameter) (sql=die Abfrage, conn=unsere Verbindung)
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //Der MySqlDataReader rdr bekommt die in cmd gespeicherte Abfrage und Verbindung und ist bereit unsere Daten auszugeben. 
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    //Lese die Daten:
                    
                    while (rdr.Read()) //Die While schleife läuft von oben bis unten in unsere Spalte ab bis er zutreffende Ziffer oder Ergebnis findet.
                    {
                        //table_name(die name unsere tabelle):und die Spalten:--+--Bankleitzhal--+--Merkmal--+--Prfzifferberechnungsmethode--+--
                        //Die Spalten sind in ein Array von 0-12 Werte von links nach rechts.   
                        BLZ = rdr.GetInt32(0); //Bankleitzahl (ist unsere erste Spalte deswegen ist es (0))
                        PZ = rdr.GetInt32(8); //Prüfziffer (ist unsere erste Spalte deswegen ist es (8))
                        //Und die Werte werden in BLZ und PZ gespeichert. 
                        
                        //Jetzt wird überprüft ob unsere Bankleitzahl in unsere Spalte Bankleitzahl (0) gefunden wird. Hier wird der Wert geprüft!
                        if (BLZ == Bankleitzahl_Global) {
                            Console.WriteLine(rdr[2] + " -- " + BLZ + " Bankleitzahl ist eine gültige BLZ");
                            //Wenn ja wird uns die Bezeichnung das wäre die '2' Spalte (0-1-2) und BLZ Nummer ausgegeben.
                            leere = 1;                            
                            break;
                            
                        }else if(BLZ !=Bankleitzahl_Global){
                            leere = 0; //Wenn er nichts findet dann soll er 0 als Wert speichern
                            break; 
                        }

                    }
                    if(leere==0){Console.WriteLine("Keine gültige Bankleitzahl gefunden bitte erneut eingeben");}; //Falls er keine gültige BLZ findet.
                    rdr.Close();
                   

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }

                conn.Close(); //MYSQL Verbindung Geschlossen
              }while(leere != 1);
                
                Console.WriteLine("Bitte Enter drücken um die neue IBAN für ihre Kunde zu erfahren...");
                Console.Read();
               
                //Wir möchten die eingegebene Daten in eine string Array speichern!
                //Dafür wandeln wir die Datentypen in String um:
                string BLZ2 = BLZ.ToString(); 
                string PZ2 = PZ.ToString();
                string Kontonummer_String2 = Kontonummer.ToString();
                //
                string[] Iban_Array = new string[] { LL, PZ2, BLZ2, Kontonummer_String2}; //neue string Array     
                string Iban_Array_ergebnis = Iban_Array[0] + Iban_Array[1] + Iban_Array[2] + Iban_Array[3]; //Die values von meinem Array speichern wir in eine String!
                
                
                //Wir möchten gerne das Ergebnis von Iban_Array_ergebnis in unsere Tabelle(kunden_daten) speichern   
                
                //MYSQL Verbindung

                //conn2Str ist mein String für die Verbindung: Zugewiesen wurde die Verbindungsdaten meiner Datenbank .    
                string conn2Str = "server=localhost;user=root;database=blz_bundesbank;port=3306;password=";
               
               //Die Value von kundenname speichern wir in variable Name
               var Name = kundename;
              MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(conn2Str);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    //Kleiner Unterschied im Vergleich mit Oben: Jetzt möchten wir gerne Daten einfügen und nicht nur auslesen! 
                    cmd.CommandText = "INSERT INTO kunden_daten(Kunden_Name, Iban_nummer) VALUES(@Kunden_name, @Iban_nummer)"; 
 
                    cmd.Parameters.AddWithValue("@Kunden_name", Name); //Die Value von Name wird zur Spalte Kunden_name gegeben.
                    cmd.Parameters.AddWithValue("@Iban_nummer", Iban_Array_ergebnis); //Die Value von Iban_Array_ergebnis wird zur Spalte Iban_nummer gegeben.

                    cmd.ExecuteNonQuery();    
                }
                finally
                {
                    if (connection != null)
                        connection.Close(); //MYSQL Verbindung Geschlossen
                }
                
                //Das Ergebnis wird ausgegeben und in unsere Datenbank Tabelle der Kunde + IBAN angelegt. 
                Console.WriteLine("Für den Kunde: " + Name + ": lautet die IBAN Nummer: " + Iban_Array_ergebnis + "\n");
                
                
                
                
              //Möchte die vorhandendenen Kunden ausgeben  

              string conn3Str = "server=localhost;user=root;database=blz_bundesbank;port=3306;password=";

              MySqlConnection conn3 = new MySqlConnection(conn3Str); 
                try
                {

                    //Verbindung wird aufgebaut
                    conn3.Open(); 
                    //
                    //SQL Abfrage 
                    string sql3 = "select * from blz_bundesbank.kunden_daten;";
                    //MySqlCommand Methode (Wir übergeben 2 Parameter) (sql=die Abfrage, conn=unsere Verbindung)
                    MySqlCommand cmd3 = new MySqlCommand(sql3, conn3);
                    //Der MySqlDataReader rdr bekommt die in cmd gespeicherte Abfrage und Verbindung und ist bereit unsere Daten auszugeben. 
                    MySqlDataReader rdr3 = cmd3.ExecuteReader();

                    //Lese die Daten:
                   Console.WriteLine("\n" + "Bisher angelegte Kunden:");
                    while (rdr3.Read()) //Die While schleife läuft von oben bis unten in unsere Spalte ab bis er zutreffende Ziffer oder Ergebnis findet.
                    {
                        Console.WriteLine("\n" + rdr3[0] + " -- " + rdr3[1]);
                    }
                   
                    rdr3.Close();
                   

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }

            Console.ReadKey();
        }
    }
}
