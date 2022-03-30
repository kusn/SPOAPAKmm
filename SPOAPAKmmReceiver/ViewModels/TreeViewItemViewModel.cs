using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.ViewModels.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class TreeViewItemViewModel : ViewModel
    {
        private string _name;
        bool _isExpanded;
        bool _isSelected;

        public ObservableCollection<TreeViewItemViewModel> Children { get; set; }

        public string Name
        {
            get { return _name; }
            set => Set(ref _name, value);
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => Set(ref _isExpanded, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);

        }

        public TreeViewItemViewModel()
        {
            Children = new ObservableCollection<TreeViewItemViewModel>();
        }

    }
}
