using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Common
{
    public class PieChartData
    {
        string label;

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}