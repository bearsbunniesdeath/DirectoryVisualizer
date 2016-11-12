using DirectoryVisualizer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace DirectoryVisualizer.ViewModels
{
    class DirectorySeriesViewModel : ViewModelBase
    {
        private string _name;
        private ICollection<DirectoryInfoProxy> _directories;
        private ObservableCollection<NameAndValuePair> _directoryData;

        public DirectorySeriesViewModel(string name, ICollection<DirectoryInfoProxy> directoryCollection) 
        {
            _name = name;
            _directories = directoryCollection;
            _directoryData = new ObservableCollection<NameAndValuePair>();

            RebuildData();
        }

        public string Name
        {
            get
            {
                return _name;
            }
           
        }

        public ObservableCollection<NameAndValuePair> DirectoryData
        {
            get
            {
                return _directoryData;
            }
        }

        public void RebuildData()
        {
            DirectoryData.Clear();

            //TODO: Make an enum
            if (_name == "Directory Size")
            {
                foreach(DirectoryInfoProxy dir in _directories)
                {
                    NameAndValuePair dirItem = new NameAndValuePair();
                    dirItem.DisplayName = dir.Name;
                    dirItem.DisplayValue = dir.CalculateDirectorySize();
                    DirectoryData.Add(dirItem);
                }
            }
        }                 
    }
}
