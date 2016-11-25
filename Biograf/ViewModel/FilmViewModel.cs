using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Biograf.Model;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.UI.Popups;
using System.IO;

namespace Biograf.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        public Model.FilmList Filmliste { get; set; }
        private Model.FilmNavn selectedFilm;

        //Jeg laver objekter af RelayCommand for at genbruge kode
        public RelayCommand AddFilmRelayCommand { get; set; }
        public RelayCommand RemoveFilmRelayCommand { get; set; }
        public RelayCommand SaveFilmCommand { get; private set; }
        public RelayCommand DeleteAllFilmCommand { get; private set; }
        public RelayCommand HentDataCommand { get; private set; }

        StorageFolder localfolder = null;

        private readonly string filnavn = "JsonText.jsonNY1";

        // Eksempel til brug af klasser til commands
        //public AddFilmCommand AddFilmCommand { get; set; }
        // public RemoveFilmCommand RemoveFilmCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public Model.FilmNavn SelectedFilm
        {
            get { return selectedFilm; }
            set
            {
                selectedFilm = value;
                OnPropertyChanged(nameof(SelectedFilm));
            }
        }

        public Model.FilmNavn NewFilm { get; set; }


        public FilmViewModel()
        {
            Filmliste = new Model.FilmList();
            selectedFilm = new Model.FilmNavn();
            AddFilmRelayCommand = new RelayCommand(AddNewFilm);
            RemoveFilmRelayCommand = new RelayCommand(RemoveNewFilm);

            SaveFilmCommand = new RelayCommand(GemDataTilDiskAsync);
            HentDataCommand = new RelayCommand(HentdataFraDiskAsync);

            DeleteAllFilmCommand = new RelayCommand(() => this.Filmliste.Clear());

            NewFilm = new Model.FilmNavn();

            // Eksempel til brug af klasser til commands
            // AddFilmCommand = new AddFilmCommand(AddNewFilm);
            // RemoveFilmCommand = new RemoveFilmCommand(RemoveNewFilm);

            localfolder = ApplicationData.Current.LocalFolder;

        }

        public async void HentdataFraDiskAsync()
        {
            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                this.Filmliste.Clear();
                Filmliste.IndsætJson(jsonText);
            }
            catch (FileNotFoundException)
            {
                MessageDialog messageDialog = new MessageDialog("Har du husket at gemme?", "Fil ikke fundet");
                await messageDialog.ShowAsync();
            }

        }

        // Gemmer json data fra liste i localfolder
        public async void GemDataTilDiskAsync()
        {


            string jsonText = this.Filmliste.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }




        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


        public void AddNewFilm()
        {
            Filmliste.Add(NewFilm);
        }

        public void RemoveNewFilm()
        {
            Filmliste.Remove(SelectedFilm);
        }
    }
}
