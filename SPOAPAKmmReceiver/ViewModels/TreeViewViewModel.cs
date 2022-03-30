using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.ViewModels.Base;
using Microsoft.VisualStudio.Modeling;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class TreeViewViewModel : ViewModel
    {
        public ObservableCollection<TreeViewItemViewModel> TopLevelItems { get; private set; }

        public TreeViewItemViewModel SelectedItem
        {
            get
            {
                var v = Traverse(item: TopLevelItems => TopLevelItems.)

                return TopLevelItems.Traverse()
            }
        }

        public static IEnumerable<T> Traverse<T>(T item, Func<T, IEnumerable<T>> childSelector)
        {
            var stack = new Stack<T>();
            stack.Push(item);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                foreach (var child in childSelector(next))
                    stack.Push(child);
            }
        }
    }
}
