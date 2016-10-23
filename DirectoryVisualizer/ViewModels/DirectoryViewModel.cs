using DirectoryVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer.ViewModels
{
    class DirectoryViewModel
    {

        private string _path;
        private string _name;

        private ObservableCollection<DirectorySeries> _selectedSeries;

        public DirectoryViewModel(string absolutePath)
        {
            _path = Path.GetDirectoryName(absolutePath);
            _name = new DirectoryInfo(absolutePath).Name;
        }

        /// <summary>
        /// The selecteed DirectorySeries wrapped with an ObservableCollection
        /// </summary>
        public ObservableCollection<DirectorySeries> SelectedSeries
        {
            get
            {
                return _selectedSeries;
            }

        }

        private Collection<DirectorySeries> SeriesCollection { get; set; }
    }
}
