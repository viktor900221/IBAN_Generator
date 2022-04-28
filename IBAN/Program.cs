﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Eingabe Bankleitzahl + Kontonummer -> IBAN Ermittlung

            int Bankleitzahl_Global;
            int Bankleitzahl_check_erg;

            do
            {
                Console.WriteLine("Bankleitzahl"); // Darf max 8 Stellig sein und nur Ziffern!
                int Bankleitzahl = int.Parse(Console.ReadLine());
                string Bankleitzahl_umwandeln = Bankleitzahl.ToString();
                string Bankleitzahl_check = Bankleitzahl_umwandeln.Length.ToString();
                Bankleitzahl_check_erg = int.Parse(Bankleitzahl_check);


                if (Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 1)
                {
                    Console.WriteLine("Ungültiges Bankleitzahl!");
                }
                else {
                    Bankleitzahl_Global = Bankleitzahl;
                    Console.WriteLine("Die Bankleitzahl: " + Bankleitzahl_Global);
                }


            } while ( Bankleitzahl_check_erg > 8 || Bankleitzahl_check_erg < 1);


       
            Console.WriteLine("Kontonummer");
            int Kontonummer = int.Parse(Console.ReadLine());








        }
    }
}