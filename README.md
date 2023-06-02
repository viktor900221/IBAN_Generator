# IBAN_Generator

Wilkommen beim IBAN-Generator, entwickelt von Viktor Legradi-Göhring.

Dieses Programm ermöglicht es, eine IBAN (International Bank Account Number) für Kunden zu generieren. Die IBAN ist eine standardisierte internationale Kontonummer, die für Transaktionen zwischen verschiedenen Ländern verwendet wird.

# Funktionalitäten
- Eingabe des Kundenname: Der Benutzer wird aufgefordert, den Namen des Kunden einzugeben.
- Eingabe der Bankleitzahl und Kontonummer: Der Benutzer gibt die Bankleitzahl und Kontonummer des Kunden ein. Es wird überprüft, ob die eingegebene Bankleitzahl gültig ist, indem sie mit einer Datenbank von Bankleitzahlen abgeglichen wird.
- Generierung der IBAN: Basierend auf der eingegebenen Bankleitzahl und Kontonummer wird die entsprechende IBAN generiert.
- Speicherung der Kundendaten: Die generierte IBAN und der Name des Kunden werden in einer Datenbank gespeichert.

# Voraussetzungen
- C#-Entwicklungsumgebung
- MySQL-Datenbank

# Installation
- Klone das Repository auf deinen lokalen Computer.
- Stelle sicher, dass du eine MySQL-Datenbank eingerichtet hast und die Verbindungsdaten in den Code einfügst.
- Baue das Projekt in der C#-Entwicklungsumgebung.
- Führe die generierte ausführbare Datei aus.

# Verwendung
- Gib den Namen des Kunden ein, für den du eine IBAN generieren möchtest.
- Gib die Bankleitzahl und Kontonummer des Kunden ein.
- Die generierte IBAN wird angezeigt und in der Datenbank gespeichert.
- Du kannst auch die bisher angelegten Kunden und ihre IBANs ausgeben lassen.

# Autoren
Viktor Legradi-Göhring

# Screenshots
## Datenbank
![MySql_DB_blz-bundesbank](https://github.com/viktor900221/IBAN_Generator/assets/79362660/90da0dc5-6c66-4b13-9d3f-8abdcdce5799)
## Kunden
![Kunden](https://github.com/viktor900221/IBAN_Generator/assets/79362660/9536e266-f352-4ef6-984f-3f5702420dd3)
## Bundesbank
![Bundesbank_DB](https://github.com/viktor900221/IBAN_Generator/assets/79362660/1be82120-bceb-4d68-a8c3-cd92d4271091)
## Anwendung 
### TestUser2 anlegen und IBAN geben
![Anwendung](https://github.com/viktor900221/IBAN_Generator/assets/79362660/7d8ab9ff-894d-4612-887a-b20098fdee10)
### TestUser 2 angelegt und IBAN für den User generiert aus PAN, BLZ, Prüfziffer und aus dem gewählten Kontonummer
![Anwendung2](https://github.com/viktor900221/IBAN_Generator/assets/79362660/c30f6627-d8b7-4ec7-9904-c08a1adfeb85)
![Datenbank2](https://github.com/viktor900221/IBAN_Generator/assets/79362660/0b0bd529-3474-492d-8ee8-0265194c9e9c)
