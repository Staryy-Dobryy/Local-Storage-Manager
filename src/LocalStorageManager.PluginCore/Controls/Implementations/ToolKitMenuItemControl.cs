using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.PluginCore.Controls.Interfaces;
using LocalStorageManager.PluginCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Controls.Implementations
{
    public class ToolKitMenuItemControl : BasePluginCoreControl, IPluginCoreControl, IConfigurableControl
    {
        /// <summary>
        /// Gets the width of the element.
        /// </summary>
        public new double Width
        {
            get { return GetValue(WidthProperty); }
            private set { SetValue(WidthProperty, value); }
        }

        /// <summary>
        /// Gets the height of the element.
        /// </summary>
        public new double Height
        {
            get { return GetValue(HeightProperty); }
            private set { SetValue(HeightProperty, value); }
        }
        public void ConfigureControl()
        {
            Width = ToolKitMenuConstants.MENU_ITEM_WIDTH;
            Height = ToolKitMenuConstants.MENU_ITEM_HEIGHT;
        }
    }
}
