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

        public DirectoryVisualizerViewModel()
        {
            Directories = new ObservableCollection<SingleGroup>();
            SingleGroup group = new SingleGroup();
            DummyDirectory item = new DummyDirectory { Name = "MyDirectory1", Size = 100 };
            DummyDirectory item2 = new DummyDirectory { Name = "MyDirectory2", Size = 200 };
            group.Items = new ObservableCollection<DummyDirectory>();
            group.Items.Add(item2);
            group.Items.Add(item);

            Directories.Add(group);          
        }

        public ObservableCollection<SingleGroup> Directories
        {
            get;
            set;
        }
    }

    class SingleGroup
    {       
        public ObservableCollection<DummyDirectory> Items { get; set; }
    }

    class DummyDirectory
    {
        public string Name { get; set; }
        public double Size { get; set; }
    }
}
