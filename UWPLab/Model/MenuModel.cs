using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UWPLab.Model
{
    public class MenuBase
    {
        public virtual NavigationViewItemBase Add()
        {
            return null;
        }
    }
    public class MenuSeparator : MenuBase
    {
        public override NavigationViewItemBase Add()
        {
            return new NavigationViewItemSeparator { };
        }
    }
    public class MenuHeader : MenuBase
    {
        public string Content { get; set; } = null;
        public override NavigationViewItemBase Add()
        {
            return new NavigationViewItemHeader
            {
                Content = Content
            };
        }
    }
    public class MenuItem : MenuHeader
    {
        public Symbol Icon { get; set; }
        public string Tag { get; set; } = null;
        public Type Page { get; set; } = null;
        public bool Enable { get; set; } = true;
        public override NavigationViewItemBase Add()
        {
            return new NavigationViewItem
            {
                Content = Content,
                Tag = Tag,
                Icon = new SymbolIcon(Icon = Icon),
                IsEnabled = Enable
            };
        }
    }
}
