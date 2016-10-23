using DirectoryVisualizer.ViewModels;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer
{
    class DirectoryVisualizerViewModel : ViewModelBase
    {

        private string _baseDirectory;

        public DirectoryVisualizerViewModel()
        {
                     
        }


        #region "Properties"

        public ObservableCollection<DirectoryViewModel> Directories
        {
            get;
            set;
        }

        public string BaseDirectory
        {
            get
            {
                return _baseDirectory;
            }

            set
            {
                _baseDirectory = value;
                RaisePropertyChanged(nameof(BaseDirectory));          
            }
        }
        #endregion
    }   
}
