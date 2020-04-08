using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;

namespace xline.stopwatch.Model
{
  /// <summary>
  /// Summary description for Fluent.
  /// </summary>
  public class Fluent
  {
    private DateTime start;
    private DateTime end;
    private string task = null;

    public static Fluent Create(DateTime start, string task)
    {
      Fluent f = new Fluent();
      f.start = start;
      if (task != null && task.Length > 0) f.task = task;
      return f;
    }

    public static Fluent Create(DateTime start, DateTime end, string task)
    {
      Fluent f = new Fluent();
      f.start = start;
      f.end = end;
      if (task != null && task.Length > 0) f.task = task;
      return f;
    }

    public static Fluent CreateStart()
    {
      Fluent fluent = new Fluent();
      fluent.start = DateTime.Now;
      return fluent;
    }

    public void Stop()
    {
      end = DateTime.Now;
    }

    public bool Stopped
    {
      get { return end.Ticks != 0; }
    }

    public DateTime Start
    {
      get { return start; }
      set { start = value; }
    }

    public DateTime End
    {
      get { return end; }
      set { end = value; }
    }

    public string Task
    {
      get { return task; }
      set
      {
        if (value != null && value.Length == 0)
          task = null;
        else
          task = value;
      }
    }

    public TimeSpan GetTimeSpan()
    {
      if (end < start) //It has not stopped
        return DateTime.Now.Subtract(start);
      else
        return end.Subtract(start);
    }

    public string StartAsString
    {
        get { return (start == DateTime.MinValue) ? "" : start.ToString("yyyy/MM/dd HH:mm:ss"); }
        set { DateTime.TryParse(value, out start); }
    }

    public string EndAsString
    {
        get { return (end == DateTime.MinValue) ? "" : end.ToString("yyyy/MM/dd HH:mm:ss"); }
        set { DateTime.TryParse(value, out end); }
    }

    public string DurationInMins
    {
      get 
      { 
        return (start == DateTime.MinValue || end == DateTime.MinValue) 
          ? ""
          : end.Subtract(start).TotalMinutes.ToString("# ###");
      }
    }

  }
}
