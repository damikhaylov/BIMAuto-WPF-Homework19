using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.Models;

namespace Task1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double circleLength;

        public double CircleLength
        {
            get => circleLength;
            set
            {
                circleLength = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcCommand { get; }
        private void OnCalcCommandExecute(object p)
        {
            CircleLength = Geom.GetCircleLengthByRadius(Radius);
        }
        private bool CanCalcCommandExecuted(object p)
        {
            if (Radius > 0)
            {
                return true;
            }
            else
            {
                CircleLength = 0;
                return false;
            }
        }

        public MainWindowViewModel()
        {
            CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecuted);
        }
    }
}