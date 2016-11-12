using DirectoryVisualizer.Models;
using DirectoryVisualizer.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using DirectoryVisualizer.ViewModels;
using GalaSoft.MvvmLight.Command;
using System.Windows.Forms;

namespace DirectoryVisualizer
{
    class DirectoryVisualizerViewModel : ViewModelBase
    {

        private string _baseDirectory;
        private ObservableCollection<DirectorySeriesViewModel> _seriesCollection;

        //_baseDirectory = "D:/Documents/EA Games/The Sims™ 2 Ultimate Collection";    

        public DirectoryVisualizerViewModel()
        {

            SelectDirectory = new RelayCommand(
                        () =>
                        {
                            FolderBrowserDialog directorySelector = new FolderBrowserDialog();
                            DialogResult result;
                            directorySelector.ShowNewFolderButton = false;
                            result = directorySelector.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                BaseDirectory = directorySelector.SelectedPath;
                                LoadSeriesCollection();
                            }
                        });
           
            SeriesCollection = new ObservableCollection<DirectorySeriesViewModel>();                   
        }


        #region "Properties"

        public ObservableCollection<DirectorySeriesViewModel> SeriesCollection
        {
            get
            {
                return _seriesCollection;
            }
            set
            {
                _seriesCollection = value;
                RaisePropertyChanged(nameof(SeriesCollection));
            }
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

        #region "Commands"
        public RelayCommand SelectDirectory { get; set; }        
        #endregion

        private void LoadSeriesCollection()
        {
            DirectoryInfoProvider baseProvider = new DirectoryInfoProvider(_baseDirectory);
            ObservableCollection<DirectoryInfoProxy> directories = new ObservableCollection<DirectoryInfoProxy>();
            foreach (var childDirName in baseProvider.GetListOfDirectories())
            {
                string childDirPath = System.IO.Path.Combine(_baseDirectory, childDirName);
                DirectoryInfoProxy childDir = new DirectoryInfoProxy(childDirPath);

                directories.Add(childDir);
            }

            DirectorySeriesViewModel directorySizeSeries = new DirectorySeriesViewModel("Directory Size", directories);

            SeriesCollection.Add(directorySizeSeries);
            RaisePropertyChanged(nameof (SeriesCollection));
        }
    }
}
