using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPLab.Model;
using Windows.UI.Xaml.Controls;

namespace UWPLab.Util
{


    public class Setting
    {
        public readonly List<MenuBase> menus = new List<MenuBase>
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
    }
}
