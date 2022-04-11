using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Info
    {
        private static Info instance;
        public string AppName { get; private set; }
        public string BackColor { get; private set; }
        public string Font { get; private set; }

        protected Info(string appName, string backColor, string font)
        {
            AppName = appName;
            BackColor = backColor;
            Font = font;
        }

        public static Info getInstance(string appName, string backColor, string font)
        {
            if(instance == null)
            {
                instance = new Info(appName, backColor, font);
            }
            return instance;
        }
    }
}
