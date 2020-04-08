using ArrayList = System.Collections.ArrayList;
using DateTime = System.DateTime;
using Path = System.IO.Path;
using File = System.IO.File;
using Encoding = System.Text.Encoding;
using System.Collections.Generic;
using System.Globalization;
using xline.stopwatch.Model;

namespace xline.stopwatch.Controller
{

	/// <summary>
	/// Summary description for Timers.
	/// </summary>
	public class Timers
	{
		private System.Collections.Specialized.HybridDictionary list = new System.Collections.Specialized.HybridDictionary();
		System.IO.FileSystemWatcher fileSystemWatcher;
        private List<TimerGroup> Groups = new List<TimerGroup>();

		public Timers()
		{
			//Add a watcher to reload
			string file = GetPathName();
			string path = Path.GetDirectoryName(file);
			string filename = Path.GetFileName(file);

			fileSystemWatcher = new System.IO.FileSystemWatcher(path, filename);
			fileSystemWatcher.Changed +=new System.IO.FileSystemEventHandler(fileSystemWatcher_Changed);
			fileSystemWatcher.EnableRaisingEvents = true;
		}

		private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			System.IO.WatcherChangeTypes w = e.ChangeType ;
			System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("The timer database has been changed. Would you like to reload it?", "Reload", System.Windows.Forms.MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
				Reload();
		}

		public bool TimerExists(string name)
		{
			return list.Contains(name);
		}

		public Timer Create(string name)
		{
			Timer timer = (Timer)list[name];
			if (timer != null) return timer;
			timer = new Timer(name);
			list[name] = timer;
			return timer;
		}

		public Timer GetTimer(string name)
		{
			return (Timer)list[name];
		}

		public void Delete(string name)
		{
			list.Remove(name);
		}

		public Timer[] GetTimers()
		{
			ArrayList t = new ArrayList();
			foreach (Timer timer in list.Values)
				t.Add(timer);
			return (Timer[])t.ToArray(typeof(Timer));
		}

        public List<TimerGroup> GetTimerGroups()
        {
            return Groups;
        }

		public void Save()
		{
			fileSystemWatcher.EnableRaisingEvents = false;
			System.Xml.XmlTextWriter x = new System.Xml.XmlTextWriter(GetPathName(), Encoding.Unicode);
			x.WriteStartDocument();
            x.WriteWhitespace("\r\n");
			x.WriteStartElement("Timers");
            x.WriteWhitespace("\r\n");
			foreach (Timer timer in GetTimers())
			{
                x.WriteWhitespace("\t");
				x.WriteStartElement("Timer");
				x.WriteAttributeString("name", timer.Name);
                x.WriteWhitespace("\r\n");
				foreach (Fluent fluent in timer.GetLaps())
				{
                    x.WriteWhitespace("\t\t");
					x.WriteStartElement("lap");
					x.WriteAttributeString("start", fluent.Start.ToString(GetCulture()));
					if (fluent.Stopped)
						x.WriteAttributeString("end", fluent.End.ToString(GetCulture()));
                    if (fluent.Task != null && fluent.Task.Length > 0)
                        x.WriteAttributeString("task", fluent.Task);
					x.WriteEndElement();
                    x.WriteWhitespace("\r\n");
				}
                x.WriteWhitespace("\t");
				x.WriteEndElement();
                x.WriteWhitespace("\r\n");
			}
            foreach (TimerGroup group in Groups)
            {
                group.Save(x);
            }
			x.WriteEndElement();
			x.WriteEndDocument();
			x.Close();
			fileSystemWatcher.EnableRaisingEvents = true;
		}

		public void Reload()
		{
            
			list = new System.Collections.Specialized.HybridDictionary();

			System.Xml.XmlDocument x = new System.Xml.XmlDocument();
			if (!File.Exists(GetPathName())) return; //Nothing to load

			x.Load(GetPathName());
			foreach (System.Xml.XmlNode node in x.SelectNodes("//Timer"))
			{
				if (node.Attributes["name"] == null) continue;

				string name = node.Attributes["name"].Value;
				if (name == null) continue;
				Timer timer = Create(name);

				foreach (System.Xml.XmlNode lap in node.SelectNodes("lap"))
				{
					string startText = (lap.Attributes["start"] != null) ? lap.Attributes["start"].Value : null;
                    DateTime start = DateTime.Parse(startText, GetCulture());
                    string task = (lap.Attributes["task"] != null) ? lap.Attributes["task"].Value : null;

					if (lap.Attributes["end"] == null)
					{
						timer.AddFluent(start, task);
					}
					else
					{
						string endText = lap.Attributes["end"].Value;
						DateTime end  = DateTime.Parse(endText, GetCulture()); 
						timer.AddFluent(start, end, task);
					}
				}
			}

            foreach (System.Xml.XmlNode node in x.SelectNodes("//Group"))
            {
                Groups.Add(TimerGroup.Parse(node, this));
            }

		}

		internal string GetPathName()
		{
			string path = typeof(Timers).Assembly.Location;
			path = System.IO.Path.GetDirectoryName(path);
			path = System.IO.Path.Combine(path, "Timers v.1.xml");
			return path;
		}

        internal CultureInfo GetCulture()
        {
            return new CultureInfo("en-GB");
        }
	}
}
