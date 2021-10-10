using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laminatte.Resources
{
    public static class Core
    {
        public static LaminateEntities DB = new LaminateEntities();

        public static Users activeUser;
    }
}
