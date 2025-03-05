using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.ViewModels.Controls
{
    public class TitleBarViewModel : ObservableObject
    {
        private string _title = "Local Storage Manager";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
