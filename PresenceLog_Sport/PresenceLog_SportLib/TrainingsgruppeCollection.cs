using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace PresenceLog_SportLib
{
    public class TrainingsgruppeCollection
    {
        public List<Trainingsgruppe> Trainingsgruppen = new List<Trainingsgruppe>();

        public TrainingsgruppeCollection()
        {

        }

        public TrainingsgruppeCollection(List<Trainingsgruppe> trainingsgruppen)
        {
            this.Trainingsgruppen = trainingsgruppen;
        }
        
        public void TrainingsgruppenHinzufuegen(Trainingsgruppe trainingsgruppe)
        {
            Trainingsgruppen.Add(trainingsgruppe);
        }

        public void Laden(string filename)
        {
            // Zuerst eine leere Liste initialisieren, um sicherzustellen, dass Trainingsgruppen immer eine gültige Liste ist
            Trainingsgruppen = new List<Trainingsgruppe>();
            try
            {
                if (File.Exists(filename))
                {
                    string json = File.ReadAllText(filename);

                    var geladeneDaten = JsonConvert.DeserializeObject<List<Trainingsgruppe>>(json);

                    if (geladeneDaten != null)
                    {
                        Trainingsgruppen = geladeneDaten;
                    }
                }
                Log.Logger.Information("TrainingsgruppeCollection erfolgreich geladen");
            }
            catch (IOException exception)
            {
                MessageBox.Show($"Fehler beim Laden der Datei: {exception.Message}");
                Log.Logger.Fatal($"Fehler beim Laden der Datei: {exception.Message}");
            }

        }

        public void Speichern(string filename)
        {
            try
            {
                string directory = Path.GetDirectoryName(filename);
                Directory.CreateDirectory(directory);

                string json = JsonConvert.SerializeObject(this.Trainingsgruppen, Newtonsoft.Json.Formatting.Indented); // Formatting.Indented ... macht Einrückungen und Zeilenumbrüche damit es besser lesebar ist
                File.WriteAllText(filename, json);
                Log.Logger.Information("TrainingsgruppeCollection erfolgreich gespeichert");
            }
            catch (IOException exception)
            {
                MessageBox.Show($"Fehler beim Speichern der Datei: {exception.Message}");
                Log.Logger.Fatal($"Fehler beim Speichern der Datei: {exception.Message}");
            }

        }
    }
}

