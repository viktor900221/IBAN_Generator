
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace IBAN
{
    internal class Program
    {
        static void Main(string[] args)
        {

          /*  MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=null;database=testdb";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }*/



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

            ////////////////Eingabe Bankleitzahl + Kontonummer//////////////////
            
            //Bankleitzahl:

            int Bankleitzahl_Global;
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


            } while ( Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 8);


            //Kontonummer:

            int Kontonummer_Global;
            int Kontonummer_check_erg;

           
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



                int Kontonummer = int.Parse(Console.ReadLine());
                string Kontonummer_umwandeln = Kontonummer.ToString();
                string Kontonummer_check = Kontonummer_umwandeln.Length.ToString();
                Kontonummer_check_erg = int.Parse(Kontonummer_check);


                if (Kontonummer_check_erg > 10 || Kontonummer_check_erg < 1)
                {
                    Console.WriteLine("\t" + "\t" + "Ungültiges Kontonummer!" + "\n");
                }
                else
                {
                    Kontonummer_Global = Kontonummer;
                    Console.WriteLine("\t" + "\t" + "Die Kontonummer: " + Kontonummer_Global + "\n");
                }


            } while (Kontonummer_check_erg > 10 || Kontonummer_check_erg < 1);



            Console.ReadKey();








        }
    }
}
