using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDesktop.Helpers
{
    internal interface IAppNavigation
    {
        public object ActiveViewModel { get; set; }
    }
}
