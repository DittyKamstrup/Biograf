using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Biograf.Model
{
    public class FilmList : ObservableCollection<FilmNavn>
    {
        public FilmList() : base()
        {
            // Tilføj film til programmet
            this.Add(new FilmNavn() { filmNavn = "Moulin Rouge", pris = 29.95, releaseDato = new DateTime(2001,05, 09), description = "All time best love story", sal = "Sal 5", rating = 10.0 });
            this.Add(new FilmNavn() { filmNavn = "Mr. Nobody", pris = 39.95, releaseDato = new DateTime(2010, 12, 25), description = "So much rabdom, it's awesome", sal = "Sal 7", rating = 8.5 });
        }


        // Giver mig Jsonformat for FilmList object

        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }


        // metode som modtager en string af json og desorialiserer til objekter af film

        /// <param name="jsonText"></param>
        public void IndsætJson(string jsonText)
        {
            List<FilmNavn> nyListe = JsonConvert.DeserializeObject<List<FilmNavn>>(jsonText);

            foreach (var film in nyListe)
            {
                this.Add(film);
            }


        }
    }
}
