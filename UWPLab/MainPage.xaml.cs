using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace UWPLab
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Init
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

        public readonly List<MenuBase> navList = new List<MenuBase>
        {
                new MenuHeader{ Content="Page" },
                new MenuItem{ Icon= Symbol.Home, Content="Home", Tag="Home", Page=typeof(Dashboard) },
                new MenuItem{ Icon= Symbol.TwoPage, Content="Hub", Tag="Hub", Page=typeof(Hub)},
                new MenuSeparator{ },
                new MenuHeader{ Content="Lab" },
                new MenuItem{ Icon= Symbol.Map, Content="Map", Tag="Map", Page=typeof(Dashboard), Enable=false},
                new MenuItem{ Icon= Symbol.Find, Content="Find", Tag="Find", Page=typeof(Dashboard),Enable=false},
                new MenuSeparator{ }
            };
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
        }

         private void Nav_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in navList)
            {
                Nav.MenuItems.Add(item.Add());
            }
        }

        private void Nav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var navItemTag = Nav.MenuItems
                .OfType<NavigationViewItem>()
                .First(i => args.InvokedItem.Equals(i.Content))
                .Tag.ToString();

            var targetPage = navList
                .Where(c => Equals(c.GetType(), typeof(MenuItem))).ToList()
                .ConvertAll(c => (MenuItem)c).First(c => c.Tag.Equals(navItemTag))
                .Page;
            Page.Navigate(targetPage);
        }
    }
}
