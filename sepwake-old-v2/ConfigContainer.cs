using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sepWake2
{
    public class ConfigContainer
    {
        public List<ConfigGroup> Items = new List<ConfigGroup>() { };

        public ConfigGroup FindItem(string name)
        {
            foreach (ConfigGroup i in Items)
            {
                if (i.GroupName == name) return i;
            }

            return null;
        }

    }
}