using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using xline.stopwatch.Controller;

namespace xline.stopwatch.Model
{
    //A container for one or more timers to allow reporting when the timers add up to some goal
    //e.g. Multiple timers for a single client
    public class TimerGroup
    {
        public String Name;
        public List<Timer> Timers = new List<Timer>();
        public List<Target> Targets = new List<Target>();
        public List<Rate> Rates = new List<Rate>();

        public class Rate
        {
            public Single Value = 0;
            public String Format = "0";

            public Rate(float value, string mask)
            {
                this.Value = value;
                this.Format = mask;
            }
        }

        public class Target
        {
            public Single Value = 0;
            public String Period = "daily";
            public bool ExcludeWeekend = true;

            public Target(float value, string period, bool excludeweekend)
            {
                this.Value = value;
                this.Period = period;
                this.ExcludeWeekend = excludeweekend;
            }
        }


        public static TimerGroup Parse(XmlNode node, Timers timers)
        {
            TimerGroup group = new TimerGroup();

            string name = node.Attributes["name"].Value;
            if (name != null) group.Name = name;

            foreach (System.Xml.XmlNode timer in node.SelectNodes("timer"))
            {
                name = timer.Attributes["name"].Value;
                Timer t = timers.GetTimer(name);
                if (t != null) group.Timers.Add(t);
            }

            foreach (System.Xml.XmlNode rate in node.SelectNodes("rate"))
            {
                Single value = (rate.Attributes["value"] != null) ? Single.Parse(rate.Attributes["value"].Value) : 0;
                string mask = (rate.Attributes["format"] != null) ? rate.Attributes["format"].Value : "0";
                group.Rates.Add(new Rate(value, mask));
            }

            foreach (System.Xml.XmlNode target in node.SelectNodes("target"))
            {
                Single value = (target.Attributes["value"] != null) ? Single.Parse(target.Attributes["value"].Value) : 0;
                String period = (target.Attributes["period"] != null) ? target.Attributes["period"].Value : "day";
                bool excludeweekend = (target.Attributes["exclude-weekends"] != null)
                    ? Boolean.Parse(target.Attributes["exclude-weekends"].Value)
                    : true;
                group.Targets.Add(new Target(value, period, excludeweekend));
            }

            return group;
        }

        public void Save(System.Xml.XmlTextWriter x)
        {
                x.WriteWhitespace("\t");
                x.WriteStartElement("Group");
                x.WriteAttributeString("name", Name);
                x.WriteWhitespace("\r\n");
                foreach (Timer timer in Timers)
                {
                    x.WriteWhitespace("\t\t");
                    x.WriteStartElement("timer");
                    x.WriteAttributeString("name", timer.Name);
                    x.WriteEndElement();
                    x.WriteWhitespace("\r\n");
                }
                foreach (Rate rate in Rates)
                {
                    x.WriteWhitespace("\t\t");
                    x.WriteStartElement("rate");
                    x.WriteAttributeString("value", rate.Value.ToString());
                    x.WriteAttributeString("format", rate.Format);
                    x.WriteEndElement();
                    x.WriteWhitespace("\r\n");
                }
                foreach (Target target in Targets)
                {
                    x.WriteWhitespace("\t\t");
                    x.WriteStartElement("target");
                    x.WriteAttributeString("value", target.Value.ToString());
                    x.WriteAttributeString("period", target.Period);
                    x.WriteAttributeString("exclude-weekends", target.ExcludeWeekend.ToString());
                    x.WriteEndElement();
                    x.WriteWhitespace("\r\n");
                }
                x.WriteWhitespace("\t");
                x.WriteEndElement();
                x.WriteWhitespace("\r\n");
        }
    }
}
