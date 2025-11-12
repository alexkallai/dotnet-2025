using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalWindowsTray.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
        {
            private string _currentTime;
            private double _bottomGridHeight = 50;

            public string CurrentTime
            {
                get => _currentTime;
                set
                {
                    _currentTime = value;
                    OnPropertyChanged(nameof(CurrentTime));
                }
            }

            public double BottomGridHeight
            {
                get => _bottomGridHeight;
                set
                {
                    _bottomGridHeight = value;
                    OnPropertyChanged(nameof(BottomGridHeight));
                }
            }

            public MainViewModel()
            {

            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


}
