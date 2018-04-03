using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.IO;

namespace CashChange
{
    public class City : INotifyPropertyChanged
    {
        private string name;
        private double xCoords;
        private double yCoords;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
   
            }
        }
        public double XCoords
        {
            get { return xCoords; }
            set
            {
                xCoords = value;
                OnPropertyChanged("XCoords");
            }
        }
        public double YCoords
        {
            get { return yCoords; }
            set
            {
                yCoords = value;
                OnPropertyChanged("YCoords");
            }
        }
        public City(string name, double x, double y)
        {
            Name = name;
            XCoords = x;
            YCoords = y;
        }
        static public City[] GetCity()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(@"C:\Users\Bohdan\source\repos\CashChange\CashChange\City.txt");
                string text = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<City[]>(text);
            }
            finally
            {
                reader.Close();
            }
            
           
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
