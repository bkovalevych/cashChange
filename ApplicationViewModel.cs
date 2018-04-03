using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace CashChange
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private City selectedCity;

        public ObservableCollection<City> ArrayCity { get; set; }
        
        private RelayCommand addCity;
        public RelayCommand AddCity
        {
            get
            {
                return addCity ??
                  (addCity = new RelayCommand(obj =>
                  {
                      City city = new City("", 0, 0);
                      ArrayCity.Insert(0, city);
                      SelectedCity = city;
                  }));
            }
        }

        private RelayCommand removeCity;
        public RelayCommand RemoveCity
        {
            get
            {
                return removeCity ??
                (removeCity = new RelayCommand(obj =>
                {
                    City city = obj as City;
                    if (city != null)
                    {
                        ArrayCity.Remove(city);
                    }
                },
                (obj) => ArrayCity.Count > 0));
            }
        }


        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public ApplicationViewModel()
        {
            ArrayCity = new ObservableCollection<City>(City.GetCity());
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
