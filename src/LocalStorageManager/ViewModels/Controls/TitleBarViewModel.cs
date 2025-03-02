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
        public string Title { get; private set; } = "Local Storage Manager";
    }
}
