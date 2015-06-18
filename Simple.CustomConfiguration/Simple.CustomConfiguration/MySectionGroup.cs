using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.CustomConfiguration
{
    public class MySectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("Section1")]
        public MySection MySection1
        {
            get { return (MySection)this.Sections["Section1"]; }
        }

        [ConfigurationProperty("Section2")]
        public MySection MySection2
        {
            get { return (MySection)this.Sections["Section2"]; }
        }
    }
}