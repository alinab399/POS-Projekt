# **PrecensLog Sport**

## Projektgruppe: Aleksandra Vidovic & Alina Bischof
## Klasse: 2AHIF
## Jahr: 2025








## Betreuer: Lukas Diem, David Bechtold                                                                                    
## Kurzbeschreibung: Programm für Sportvereine zur Unterstützung der Anwesenheitskontrolle und Trainingsvorbereitung.


Collage mit mindestens zwei Screenshots 







Relevanter Programmcode:
for (int i = 0; i < ausgangswerte.Length; i++)
{
      double omega0 = eingangswerte[i] + t1 * a1 + t2 * a2;
      ausgangswerte[i] = omega0 * b0 + t1 * b1 + t2 * b2;
      t2 = t1;
      t1 = omega0;
}


1	Inhaltsverzeichnis







2	Projektzeitplan
|    Datum    |   Aufgabe  | Bearbeiter | Status (%) |
| ----------- | ---------- | ---------- | ---------- |
|  14.05.2025 | Personen-Klasse | Aleksandra Vidovic | 50% |
|  14.05.2025 | Personen-Collection-Klasse | Aleksandra Vidovic | 50% |
|  14.05.2025 | Trainingsgruppe-Collection-Klasse | Aleksandra Vidovic | 50% |
|  14.05.2025 | Startseite GUI | Aleksandra Vidovic | 15% |
|  14.05.2025 | UserControl GUI | Aleksandra Vidovic | 100% |
|  14.05.2025 | Trainingsgruppe-Klasse | Alina Bischof| 50% |
|  14.05.2025 | Library mit Klassen erstellt | Alina Bischof| 100% |
|  14.05.2025 | Analysepage & Anwesenheitspage erstellt | Alina Bischof| 10% |
|  16.05.2025 | Trainingsgruppe erstellen Button Click_Event erstellt | Aleksandra Vidovic | 50% |
|  16.05.2025 | TrainingsgruppenErstellen Window aufgebaut | Aleksandra Vidovic | 60% |
|  16.05.2025 | Personen Klasse Methode: Serialize und Deserialize | Alina Bischof | 80% |
|  16.05.2025 | PersonenCollection Klasse-Methode: Load from CSV | Alina Bischof | 90% |
|  17.05.2025 | Person-Klasse und PersonenCollection alle Methoden implementiert mit Fehlerbehandlung bei Laden und Speichern einer Datei | Alina Bischof | 100% |
|  21.05.2025 | Trainingsgruppe erstellen (GUI) aufgebaut| Aleksandra Vidovic und Alina Bischof | 100% |
|  21.05.2025 | AnwesenheitsPage GUI aufgebaut | Alina Bischof | 100% |
|  21.05.2025 | OK_Button programmiert | Aleksandra Vidovic| 100% |
|  21.05.2025 | Abbrechen_Button programmiert | Aleksandra Vidovic | 100% |
|  21.05.2025 | AnwesenheitsPage Tabelle Binding | Alina Bischof | 10%  |
|  26.05.2025 | die unten beschriebenen Probleme gelöst und ausgebessert | Alina Bischof | 10% |
|  28.05.2025 | Beim OK Button wurde Daten hinzugefügt | Aleksandra Vidovic | 100% |
|  28.05.2025 | AbwesendBegruendung Window erstellt und formartiert | Alina Bischof | 80% |
|  28.05.2025 | AnwesenheitsPage Anwesend/Abwesend Button: Hintergrundfarbe und dass nur einer angeklickt werden kann | Alina Bischof | 100% |
|  03.06.2025 | Begründung kann eingegeben werden aber wird noch nicht zur richtigen Person gespeichert. | Alina Bischof | 80% |
|  03.06.2025 | AbAnwesenheitKlasse erstellt. Deshalb gibt es noch bugs.| Alina Bischof | 70% |
|  04.06.2025 | Home-Button und Analyse-Buttons erstellt | Aleksandra Vidovic | 100% |
|  04.06.2025 | Bugs gefixed. AbAnwesenheit Klasse funktioniert jetzt.| Alina Bischof | 100% |
|  04.06.2025 | Anwesenheitspage Begründung funktioniert. | Alina Bischof | 100% |
|  04.06.2025 | MainWindow mit Trainingsgruppen anzeigen in arbeit. | Alina Bischof | 20% |
|  05.06.2025 | Im MainWindow Trainingsgruppe erstellen und mit DatePicker anzeigen lassen weiterprogrammiert. | Alina Bischof | 70% |
|  06.06.2025 | Home Button für die Analyse-Page erstellt| Aleksandra Vidovic | 100% |
|  06.06.2025 | Home Button wurde gecodet | Aleksandra Vidovic | 100 % |
|  06.06.2025 | Personenhinzufuegen Fenster erstellt | Aleksandra Vidovic | 50% |
|  06.06.2025 | + Button für Personen hinzufügen erstellt | Aleksandra Vidovic | 100% |
|  06.06.2025 | Mit der Checkbox angehakte Personen werden der Trainingsgruppe hinzugefügt. | Alina Bischof | 100% |
|  07.06.2025 | Personhinzufuegen GUI und Code behind wo alles Eingegebene gespeichert wird. | Alina Bischof | 100% |
|  07.06.2025 | Neu erstellte Person wird in Listview von TrainingsgruppeErstellen angezeigt. | Alina Bischof | 100% |
|  07.06.2025 | Alle Personen die jemals hinzugefügt wurden werden in der ListView angezeigt. | Alina Bischof | 100% |
|  07.06.2025 | Alle Trainingsgruppen werden in Json Format gespeichert und können geladen werden. | Alina Bischof | 100% |
|  07.06.2025 | Problem mit DatePicker in MainWindow und Trainingsgruppen werden nicht angezeigt gelöst. | Alina Bischof | 100% |
|  07.06.2025 | Eine StartPage erstellt und den Code vom MainWindow.xaml in die StartPage kopiert, damit im MainWindow nur der Frame steht. | Alina Bischof | 100% |
|  07.06.2025 | Mit doppelklick auf ein TrainingsgruppeUserControl auf der StartPage öffnet sich die AnwesenheitsPage. | Alina Bischof | 100% |
|  08.06.2025 | Problem mit gespeichertePersonen.txt Datei eingetragen und gelöst. | Alina Bischof | 100% |
|  08.06.2025 | AnwesenheitsPage und AnalysePage Buttons für "nächste-" und "vorherige Seite" eingebaut. | Alina Bischof | 100% |
|  08.06.2025 | AnalysePage übernimmt Personen der ausgewählten Trainingsgruppe und eine ProgressBar zeigt die Anzahl der Anwesen- und Abwesenheiten an. | Alina Bischof | 100% |
| 10.06.2025 | Textbox Fehlerbehandlung bei Begründungsfenster | Aleksandra Vidovic | 100% |
| 10.06.2025 | Startdatum und Enddatum Fehlerbehandlung bei TrainingsgruppeErstellen.XAML.cs | Aleksandra Vidovic | 100% | 
| 10.06.2025 | Wochentage Fehlerbehandlung bei TrainingsgruppeErstellen.XAML.cs | Aleksandra Vidovic | 100% |


ANWESENHEIT WIRD NOCH NICHT RICHTIG GESPEICHERT!!!!!!!!!!!!!!!





3	Lastenheft (Kurzbeschreibung, Funktionsumfang, Skizzen)
2.1. Kurzbeschreibung 
Spielprinzip mit einigen Sätzen erklären
2.2. Skizzen
Spielprinzip genau erklären
2.3. Funktionsumfang
Alle Funktionen genau erklären.
Must-Haves und Nice-To-Haves beschreiben (Punkteliste). Must-Haves müssen umgesetzt werden.
Beispiele: 

Taste D	Bewegt die Spielerfigur um 5 Pixel nach rechts
Taste S	Speichert aktuellen Zustand des Spiels (Save)
Mausklick	Zerstört Sprite unter dem Cursor
	


 
4	Pflichtenheft
4.1	Interner Programmaufbau (Programmlogik)
Klassendiagramme, um die Klassen abzubilden.
Wie arbeiten die Klassen miteinander? Hier könnt ihr beispielsweise Flussdiagramme verwenden, um dies abzubilden.
4.2	Umsetzungsdetails
Detaillierte Beschreibung der Umsetzung mit möglichen Fehlern und Lösungen
|    Datum    |   Fehler   | Lösung | Bearbeiter |
| ----------- | ---------- | ---------- | ---------- |
|  26.05.2025 |  kein Zugriff auf Properties | Properties öffentlich machen | Alina Bischof |
|  26.05.2025 |  Property einmal Geburtsdatum und einmal Geburtstag benannt | alles auf Geburtsdatum geändert | Alina Bischof |
|  04.06.2025 |  Home-Button (Bild) konnte nicht richtig hinzugefügt werden | Mit dem <Image Source="Bilder/name des bildes"> verändert und damit das Foto in dem Home-Button drinnen ist, tut man das zwischen <Button><Image Source.../></Button> hinzufügen. | Aleksandra Vidovic |  
|  04.06.2025 |  Es öffnen sich die falschen Fenster, wenn man auf die button drückt, obwohl die richtigen fenster angegeben worden sind | | Aleksandra Vidovic |
|  04.06.2025 |  Wenn ich einen Titel eingebe und diesen speichern möchte, erscheint es nicht im MainWindow Fenster |  | Aleksandra Vidovic |
|  07.06.2025 |  Wenn mit dem DatePicker im MainWindow ein Datum ausgewählt wird, wo eigentlich eine Trainingsgruppe gespeichert ist, ist keine Trainingsgruppe vorhanden. | Mit debuggen habe ich herausgefunden, dass eine leere Wochentag-Liste aus der gespeicherten Datei geladen wird, weil System.Text.Json ignoriert Felder standardmäßig. Und die Wochentag-Liste war ein öffentliches Feld und kein Property. | Alina Bischof |
|  07.06.2024 |  Sobald eine neue Trainingsgruppe erstellt wird, werden in der Json-Datei die Personen aus den anderen, schon gespeicherten Trainingsgruppen gelöscht. | Wir hatten zwei unterschiedliche Serializer/Deserializer eingebaut. Einmal den von Newtonsoft und einmal den von .NET. Das hat zu Problemen geführt. Jetzt wird immer Deserialize von Newtonsoft verwendet.| Alina Bischof |
|  08.06.2024 |  Wenn auf den "+" Button geklickt wird um eine Person hinzuzufügen, wird in der .txt-Datei eine lehre Person hinzugefügt. | Nicht vor sonder in dem if wo man prüft ob das Fenster mit dem Button "Okay" oder "Abbrechen" beendet worden ist. | Alina Bischof |

4.3	Ergebnisse, Interpretation (Tests)
Wie läuft das Programm?
Welche Schwachstellen hat es?   (z.B. Programmlauf nicht flüssig)
 
5	Anleitung
5.1	Installationsanleitung
Was muss alles installiert werden 
5.2	Bedienungsanleitung
Muss so genau sein, dass auch ein neuer, unbedarfter Benutzer damit zurechtkommt.



6	Bekannte Bugs, Probleme
Welche Bugs liegen noch vor? Warum konnten sie nicht behoben werden?





 
7	Erweiterungsmöglichkeiten
Wenn ihr noch Zeit hättet, was würdet ihr verbessern oder erweitern?
 
8	Info

•	Der Zeitplan ist wöchentlich auszufüllen!
•	Endabgabe: dieses Dokument und Projektverzeichnis per Teams abgeben
•	Projektbenotung: Neben dem Endprodukt werden vor allem der Projektfortgang, die Arbeitsweise und die Termintreue benotet (keine Projekte, die in der letzten Nacht fertiggestellt werden!) Der Code soll möglichst übersichtlich gehalten werden (Einsatz von Funktionen und Klassen).

Viel Spaß und happy coding!

   
