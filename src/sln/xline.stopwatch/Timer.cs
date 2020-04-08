using System.Collections.Generic;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;
using DayOfWeek = System.DayOfWeek;
using StringList = System.Collections.Generic.List<string>;

namespace xline.stopwatch.Model
{
    /// <summary>
    /// A Named Timer for a particular task or project.
    /// </summary>
    public class Timer
    {
        private string name;
        private List<Fluent> laps = new List<Fluent>();

        public Timer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        private Fluent GetLastFluent()
        {
            if (laps == null || laps.Count == 0)
                return null;
            else
                return (Fluent)laps[laps.Count - 1];
        }

        public List<Fluent> GetLaps()
        {
            return laps;
        }

        public bool Started
        {
            get
            {
                Fluent f = GetLastFluent();
                if (f == null) return false;
                return !f.Stopped;
            }
        }


        internal void AddFluent(DateTime start, string task)
        {
            laps.Add(Fluent.Create(start, task));
        }

        internal void AddFluent(DateTime start, DateTime end, string task)
        {
            laps.Add(Fluent.Create(start, end, task));
        }

        public void Start()
        {
            //If it is already started do nothing.
            Fluent fluent = GetLastFluent();
            if (fluent != null && fluent.Stopped == false) return;

            fluent = Fluent.CreateStart();
            laps.Add(fluent);
        }

        public void Lap(string task)
        {
            Stop(task);
            Start();
        }

        public void Stop(string task)
        {
            //If no last lap or already stopped do nothing
            Fluent fluent = GetLastFluent();
            if (fluent == null) return;
            if (fluent.Stopped) return;
            fluent.Stop();
            fluent.Task = task;
        }

        public TimeSpan GetTotal()
        {
            TimeSpan ts = new TimeSpan(0);
            foreach (Fluent fluent in laps)
                ts = ts.Add(fluent.GetTimeSpan());
            return ts;
        }

        public TimeSpan GetLastLap()
        {
            if (laps == null || laps.Count == 0)
                return new TimeSpan(0);

            Fluent f = (Fluent)laps[laps.Count - 1];
            return f.GetTimeSpan();
        }

        public TimeSpan GetTotalToday()
        {
            DateTime start = DateTime.Today;
            DateTime end = start.AddDays(1);
            return GetTotal(start, end);
        }

        public TimeSpan GetTotalThisWeek()
        {
            DateTime start = DateTime.Today;
            while (start.DayOfWeek != DayOfWeek.Sunday)
                start = start.AddDays(-1);
            DateTime end = start.AddDays(7);
            return GetTotal(start, end);
        }

        public TimeSpan GetWorkweekAverage()
        {
            /*
             * Calculate the Time Worked this week (which may include a sunday)
             * and divide by the number of days worked (but assume we only start work on a monday
             * This gives the Workweek (i.e. Mon-Fri) average
             */

            DateTime start = DateTime.Today;
            while (start.DayOfWeek != DayOfWeek.Sunday)
                start = start.AddDays(-1);
            DateTime end = start.AddDays(7);

            TimeSpan ts = GetTotal(start, end);
            double DaysOfTheWorkWeek = DateTime.Today.Subtract(start).TotalDays;
            int Days = System.Convert.ToInt16(DaysOfTheWorkWeek);
            if (Days == 0) Days++;
            ts = new TimeSpan(ts.Ticks / Days);
            return ts;
        }


        public TimeSpan GetTotalThisMonth()
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime end = start.AddMonths(1);
            return GetTotal(start, end);
        }

        public TimeSpan GetMonthlyAverage()
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime end = start.AddMonths(1);
            TimeSpan monthTotal = GetTotal(start, end);
            int workingDays = 0;
            DateTime today = DateTime.Today;
            for (DateTime index = start; index <= today; index = index.AddDays(1))
                if (index.DayOfWeek != DayOfWeek.Saturday && index.DayOfWeek != DayOfWeek.Sunday)
                    workingDays++;
            return new TimeSpan(monthTotal.Ticks / workingDays);
        }


        public TimeSpan GetTotalYesterday()
        {
            DateTime end = DateTime.Today;
            DateTime start = end.AddDays(-1);
            return GetTotal(start, end);
        }


        public TimeSpan GetTotalLastWeek()
        {
            DateTime start = DateTime.Today;
            start = start.AddDays(-7);
            while (start.DayOfWeek != DayOfWeek.Sunday)
                start = start.AddDays(-1);
            DateTime end = start.AddDays(7);
            return GetTotal(start, end);
        }

        public TimeSpan GetTotalLastMonth()
        {
            DateTime start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            start = start.AddMonths(-1);
            DateTime end = start.AddMonths(1);
            return GetTotal(start, end);
        }

        public TimeSpan GetDailyTotal(DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day);
            DateTime end = start.AddDays(1);
            return GetTotal(start, end);
        }


        public TimeSpan GetTotal(DateTime start, DateTime end)
        {
            TimeSpan ts = new TimeSpan(0);
            foreach (Fluent fluent in laps)
            {
                if (fluent.Start > end) continue;
                if (fluent.Stopped && fluent.End < start) continue;

                DateTime effectiveStart = (start > fluent.Start) ? start : fluent.Start;
                DateTime effectiveEnd = (end < fluent.End) ? end : fluent.End;
                if (!fluent.Stopped) effectiveEnd = DateTime.Now;
                if (effectiveStart > effectiveEnd) continue;
                ts = ts.Add(effectiveEnd.Subtract(effectiveStart));
            }
            return ts;
        }


        /// <summary>
        /// Returns a discrete list of Exist Tasks. The last timer used will always be the last one in the list.
        /// </summary>
        /// <returns></returns>
        internal StringList GetTaskList()
        {
            string lastTask = null;
            StringList list = new StringList();
            foreach (Fluent fluent in laps)
            {
                lastTask = fluent.Task;
                if (fluent.Task == null || fluent.Task.Length == 0) continue;
                if (!list.Contains(fluent.Task))
                    list.Add(fluent.Task);
            }

            //Put the last task to be last in the list.
            if (lastTask != null)
            {
                list.Remove(lastTask);
                list.Add(lastTask);
            }
            else
                list.Add("");

            return list;
        }
    }
}
