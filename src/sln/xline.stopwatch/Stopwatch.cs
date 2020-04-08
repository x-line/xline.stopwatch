using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;
using Exception = System.Exception;
using DialogResult = System.Windows.Forms.DialogResult;
using Application = System.Windows.Forms.Application;
using InputBoxResult = xline.Windows.Forms.InputBoxResult;
using InputBox = xline.Windows.Forms.InputBox;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using StringList = System.Collections.Generic.List<string>;
using String = System.String;
using xline.stopwatch.Model;
using xline.stopwatch.Controller;

namespace xline.stopwatch.View
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class Stopwatch : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listTimers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.DateTimePicker dtFromFilter;
        private System.Windows.Forms.DateTimePicker dtToPicker;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteTimer;
        private Timers timers = new Timers();
        private System.Collections.ArrayList listTimerValues = new System.Collections.ArrayList();
        private System.Windows.Forms.Timer Formtimer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnAddLap;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuExportPeriodByDay;
        private System.Windows.Forms.ComboBox cboTasks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuItem mnuNewTimer;
        private System.Windows.Forms.MenuItem mnuEditTimes;
        private System.Windows.Forms.MenuItem mnuDeleteTimer;
        private System.Windows.Forms.MenuItem mnuOpenContainingFolder;
        private System.Windows.Forms.MenuItem mnuExport;
        private System.Windows.Forms.MenuItem mnuExportSalesForce;
        private System.ComponentModel.IContainer components;

        public Stopwatch()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            timers.Reload();
            cboPeriod.Text = "Total"; //This will cause a refresh on the scren
            dtFromFilter.Value = DateTime.Today;
            dtToPicker.Value = DateTime.Today;
            btnStop.Left = btnStart.Left;
            cboPeriod.Text = "Today";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stopwatch));
            this.label1 = new System.Windows.Forms.Label();
            this.listTimers = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.dtFromFilter = new System.Windows.Forms.DateTimePicker();
            this.dtToPicker = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteTimer = new System.Windows.Forms.Button();
            this.Formtimer = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnAddLap = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuNewTimer = new System.Windows.Forms.MenuItem();
            this.mnuEditTimes = new System.Windows.Forms.MenuItem();
            this.mnuExportPeriodByDay = new System.Windows.Forms.MenuItem();
            this.mnuDeleteTimer = new System.Windows.Forms.MenuItem();
            this.mnuOpenContainingFolder = new System.Windows.Forms.MenuItem();
            this.cboTasks = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mnuExport = new System.Windows.Forms.MenuItem();
            this.mnuExportSalesForce = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stopwatch";
            // 
            // listTimers
            // 
            this.listTimers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTimers.Location = new System.Drawing.Point(16, 112);
            this.listTimers.Name = "listTimers";
            this.listTimers.Size = new System.Drawing.Size(409, 160);
            this.listTimers.TabIndex = 1;
            this.listTimers.SelectedIndexChanged += new System.EventHandler(this.listTimers_SelectedIndexChanged);
            this.listTimers.DoubleClick += new System.EventHandler(this.listTimers_DoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(16, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 42);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.Start);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(155, 338);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 42);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.Stop);
            // 
            // btnLap
            // 
            this.btnLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLap.Enabled = false;
            this.btnLap.Location = new System.Drawing.Point(85, 338);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(64, 42);
            this.btnLap.TabIndex = 5;
            this.btnLap.Text = "New Lap";
            this.btnLap.Visible = false;
            this.btnLap.Click += new System.EventHandler(this.Lap);
            // 
            // cboPeriod
            // 
            this.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriod.Items.AddRange(new object[] {
            "Total",
            "Last Lap",
            "Today",
            "This Week",
            "Workweek Average",
            "This Month",
            "Monthly Average",
            "Yesterday",
            "Last Week",
            "Last Month",
            "Daily",
            "Custom"});
            this.cboPeriod.Location = new System.Drawing.Point(16, 81);
            this.cboPeriod.MaxDropDownItems = 15;
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(160, 21);
            this.cboPeriod.TabIndex = 6;
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged);
            // 
            // dtFromFilter
            // 
            this.dtFromFilter.CustomFormat = "dd MMM yyyy   HH:mm";
            this.dtFromFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromFilter.Location = new System.Drawing.Point(249, 57);
            this.dtFromFilter.Name = "dtFromFilter";
            this.dtFromFilter.Size = new System.Drawing.Size(175, 21);
            this.dtFromFilter.TabIndex = 7;
            this.dtFromFilter.Value = new System.DateTime(2007, 8, 22, 0, 0, 0, 0);
            this.dtFromFilter.Visible = false;
            // 
            // dtToPicker
            // 
            this.dtToPicker.CustomFormat = "dd MMM yyyy   HH:mm";
            this.dtToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToPicker.Location = new System.Drawing.Point(249, 81);
            this.dtToPicker.Name = "dtToPicker";
            this.dtToPicker.Size = new System.Drawing.Size(175, 21);
            this.dtToPicker.TabIndex = 8;
            this.dtToPicker.Value = new System.DateTime(2007, 8, 22, 0, 0, 0, 0);
            this.dtToPicker.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(206, 84);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 13);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To";
            this.lblTo.Visible = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(206, 65);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 13);
            this.lblFrom.TabIndex = 10;
            this.lblFrom.Text = "From";
            this.lblFrom.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Show Timers:";
            // 
            // btnDeleteTimer
            // 
            this.btnDeleteTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTimer.Enabled = false;
            this.btnDeleteTimer.Location = new System.Drawing.Point(361, 338);
            this.btnDeleteTimer.Name = "btnDeleteTimer";
            this.btnDeleteTimer.Size = new System.Drawing.Size(64, 42);
            this.btnDeleteTimer.TabIndex = 13;
            this.btnDeleteTimer.Text = "Delete Timer";
            this.btnDeleteTimer.Click += new System.EventHandler(this.DeleteTimer);
            // 
            // Formtimer
            // 
            this.Formtimer.Enabled = true;
            this.Formtimer.Interval = 1000;
            this.Formtimer.Tick += new System.EventHandler(this.Formtimer_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(13, 394);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(412, 17);
            this.lblMessage.TabIndex = 16;
            this.lblMessage.Text = "Format String:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMessage.Visible = false;
            // 
            // btnAddLap
            // 
            this.btnAddLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLap.Enabled = false;
            this.btnAddLap.Location = new System.Drawing.Point(291, 338);
            this.btnAddLap.Name = "btnAddLap";
            this.btnAddLap.Size = new System.Drawing.Size(64, 42);
            this.btnAddLap.TabIndex = 17;
            this.btnAddLap.Text = "Add Lap";
            this.btnAddLap.Visible = false;
            this.btnAddLap.Click += new System.EventHandler(this.btnAddLap_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.mnuExport});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNewTimer,
            this.mnuEditTimes,
            this.mnuDeleteTimer,
            this.mnuOpenContainingFolder});
            this.menuItem1.Text = "File";
            // 
            // mnuNewTimer
            // 
            this.mnuNewTimer.Index = 0;
            this.mnuNewTimer.Text = "New Timer";
            this.mnuNewTimer.Click += new System.EventHandler(this.mnuNewTimer_Click);
            // 
            // mnuEditTimes
            // 
            this.mnuEditTimes.Index = 1;
            this.mnuEditTimes.Text = "Edit Times";
            this.mnuEditTimes.Click += new System.EventHandler(this.mnuEditTimes_Click);
            // 
            // mnuExportPeriodByDay
            // 
            this.mnuExportPeriodByDay.Index = 1;
            this.mnuExportPeriodByDay.Text = "Export Period By Day";
            this.mnuExportPeriodByDay.Click += new System.EventHandler(this.mnuExportPeriodByDay_Click);
            // 
            // mnuDeleteTimer
            // 
            this.mnuDeleteTimer.Index = 2;
            this.mnuDeleteTimer.Text = "Delete Timer";
            this.mnuDeleteTimer.Click += new System.EventHandler(this.DeleteTimer);
            // 
            // mnuOpenContainingFolder
            // 
            this.mnuOpenContainingFolder.Index = 3;
            this.mnuOpenContainingFolder.Text = "Open Containing Folder";
            this.mnuOpenContainingFolder.Click += new System.EventHandler(this.mnuOpenContainingFolder_Click);
            // 
            // cboTasks
            // 
            this.cboTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTasks.FormattingEnabled = true;
            this.cboTasks.Location = new System.Drawing.Point(160, 294);
            this.cboTasks.Name = "cboTasks";
            this.cboTasks.Size = new System.Drawing.Size(265, 21);
            this.cboTasks.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Currently working on:";
            // 
            // mnuExport
            // 
            this.mnuExport.Index = 1;
            this.mnuExport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExportSalesForce,
            this.mnuExportPeriodByDay});
            this.mnuExport.Text = "Export";
            // 
            // mnuExportSalesForce
            // 
            this.mnuExportSalesForce.Index = 0;
            this.mnuExportSalesForce.Text = "Sales Force";
            this.mnuExportSalesForce.Click += new System.EventHandler(this.mnuExportSalesForce_Click);
            // 
            // Stopwatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(444, 420);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTasks);
            this.Controls.Add(this.btnAddLap);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteTimer);
            this.Controls.Add(this.dtToPicker);
            this.Controls.Add(this.dtFromFilter);
            this.Controls.Add(this.cboPeriod);
            this.Controls.Add(this.btnLap);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listTimers);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(452, 335);
            this.Name = "Stopwatch";
            this.Text = "Stopwatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Stopwatch());
            //Application.Run(new ExportSalesForce());
        }

        private void cboPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool b = cboPeriod.Text == "Custom";
            bool b2 = cboPeriod.Text == "Daily";

            lblFrom.Visible = b;
            lblTo.Visible = b || b2;
            lblTo.Text = (b2 ? "On" : "To");

            this.dtFromFilter.Visible = b;
            this.dtToPicker.Visible = b || b2;
            this.dtToPicker.CustomFormat = (b2) ? "dd MMM yyyy" : "dd MMM yyyy   HH:mm";
            RefreshList();
        }

        private Timer GetSelectedTimer()
        {
            int i = listTimers.SelectedIndex;
            if (i < 0) return null;
            return listTimerValues[i] as Timer;
        }

        private void Start(object sender, System.EventArgs e)
        {
            Timer timer = GetSelectedTimer();
            if (timer == null) return;
            timer.Start();
            timers.Save();
            RefreshList();
            UpdateButtons();
        }

        private void Stop(object sender, System.EventArgs e)
        {
            Timer timer = GetSelectedTimer();
            if (timer == null) return;
            string task = cboTasks.Text;
            timer.Stop(task);
            timers.Save();
            RefreshList();
            UpdateButtons();
        }

        private void Lap(object sender, System.EventArgs e)
        {
            Timer timer = GetSelectedTimer();
            if (timer == null) return;
            string task = cboTasks.Text;
            timer.Lap(task);
            timers.Save();
        }

        private void mnuNewTimer_Click(object sender, System.EventArgs e)
        {
            InputBoxResult ir = InputBox.Show("Please enter the name of the new timer", "New Timer");
            if (!ir.OK) return;
            timers.Create(ir.Text);
            timers.Save();
            RefreshList();
            UpdateButtons();

        }

        private void DeleteTimer(object sender, System.EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you wish to delete this timer?", "Confirm", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;
            Timer timer = GetSelectedTimer();
            listTimers.SelectedIndex = -1;
            if (timer == null) return;
            timers.Delete(timer.Name);
            timers.Save();
            RefreshList();
        }

        public TimeSpan GetTimeSpan(Timer timer)
        {
            switch (cboPeriod.Text)
            {
                case "Total": return timer.GetTotal();
                case "Last Lap": return timer.GetLastLap();
                case "Today": return timer.GetTotalToday();
                case "This Week": return timer.GetTotalThisWeek();
                case "Workweek Average": return timer.GetWorkweekAverage();
                case "This Month": return timer.GetTotalThisMonth();
                case "Monthly Average": return timer.GetMonthlyAverage();
                case "Yesterday": return timer.GetTotalYesterday();
                case "Last Week": return timer.GetTotalLastWeek();
                case "Last Month": return timer.GetTotalLastMonth();
                case "Daily": return timer.GetDailyTotal(dtToPicker.Value);
                case "Custom": return timer.GetTotal(dtFromFilter.Value, this.dtToPicker.Value);
            }
            throw new Exception("Invalid value in cboPeriod");
        }

        public String GetTimeSpanString(TimeSpan tsDuration)
        {
            String duration;
            duration = (tsDuration.Days * 24 + tsDuration.Hours).ToString().PadLeft(2, '0');
            duration += ":" + tsDuration.Minutes.ToString().PadLeft(2, '0');
            duration += ":" + tsDuration.Seconds.ToString().PadLeft(2, '0');
            duration = " (" + duration + ")";
            return duration;
        }

        public String GetRateString(TimeSpan duration, TimerGroup group)
        {
            String s = "";
            foreach (xline.stopwatch.Model.TimerGroup.Rate rate in group.Rates)
            {
                s += " ";
                s += (duration.TotalHours * rate.Value).ToString(rate.Format);
            }
            return s;
        }

        public void UpdateTimes_doesnotseemtobeused()
        {
            listTimers.BeginUpdate();
            for (int i = 0; i < listTimerValues.Count; i++)
            {
                Timer timer = (Timer)listTimerValues[i];

                string duration = "";
                try
                {
                    TimeSpan tsDuration = GetTimeSpan(timer);
                    duration = (tsDuration.Days * 24 + tsDuration.Hours).ToString().PadLeft(2, '0');
                    duration += ":" + tsDuration.Minutes.ToString().PadLeft(2, '0');
                    duration += ":" + tsDuration.Seconds.ToString().PadLeft(2, '0');
                    duration = " (" + duration + ")";
                    ClearMessage();
                }
                catch
                {
                    ShowMessage("Incorrect format string");
                }


                string text = timer.Name + duration;
                if (timer.Started) text = "* " + text + " Started";
                listTimers.Items[i] = text;
            }
            listTimers.EndUpdate();
        }


        public void RefreshList()
        {
            listTimers.BeginUpdate();
            int lastSelectedIndex = listTimers.SelectedIndex;

            listTimers.Items.Clear();
            this.listTimerValues.Clear();
            foreach (Timer timer in timers.GetTimers())
            {
                try
                {
                    string duration = GetTimeSpanString(GetTimeSpan(timer));
                    string text = timer.Name + duration;
                    if (timer.Started) text = "* " + text + " Started";
                    listTimers.Items.Add(text);
                    listTimerValues.Add(timer);
                    ClearMessage();
                }
                catch
                {
                    ShowMessage("Incorrect format string");
                }
            }

            if (timers.GetTimerGroups().Count > 0)
            {
                //Add spacer
                listTimers.Items.Add("");
                listTimerValues.Add(null);
            }

            foreach (TimerGroup group in timers.GetTimerGroups())
            {
                try
                {
                    TimeSpan ts = new TimeSpan(0);
                    bool started = false;
                    foreach (Timer timer in group.Timers)
                    {
                        ts = ts.Add(GetTimeSpan(timer));
                        if (timer.Started) started = true;
                    }

                    string duration = GetTimeSpanString(ts) + GetRateString(ts, group);
                    string text = group.Name + duration;
                    if (started) text = "* " + text + " Started";
                    listTimers.Items.Add(text);
                    listTimerValues.Add(group);
                    ClearMessage();
                }
                catch
                {
                    ShowMessage("Incorrect format string");
                }
            }


            listTimers.SelectedIndex = lastSelectedIndex;
            listTimers.EndUpdate();
        }

        private void Formtimer_Tick(object sender, System.EventArgs e)
        {
            //UpdateTimes();
            RefreshList();
        }

        private void ShowMessage(string text)
        {
            lblMessage.Text = text;
            lblMessage.Visible = true;
        }
        private void ClearMessage()
        {
            lblMessage.Visible = false;
        }

        Timer lastSelectedTimer = null;
        private void listTimers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Timer timer = this.GetSelectedTimer();
            if (timer == lastSelectedTimer) return;
            lastSelectedTimer = timer;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            Timer timer = this.GetSelectedTimer();
            if (timer == null)
            {
                this.btnStart.Enabled = false;
                btnStop.Enabled = false;
                this.btnLap.Enabled = false;
                this.btnDeleteTimer.Enabled = false;
                this.btnAddLap.Enabled = false;

                this.btnStart.Visible = false;
                btnStop.Visible = false;
                this.btnLap.Visible = false;
                this.btnDeleteTimer.Visible = false;
                this.btnAddLap.Visible = false;

                this.mnuEditTimes.Visible = false;
                this.mnuDeleteTimer.Visible = false;
            }
            else
            {
                btnStart.Enabled = !timer.Started;
                btnStart.Visible = !timer.Started;
                btnStop.Enabled = timer.Started;
                btnStop.Visible = timer.Started;
                btnLap.Enabled = timer.Started;
                btnLap.Visible = timer.Started;
                btnDeleteTimer.Enabled = true;
                btnDeleteTimer.Visible = true;
                btnAddLap.Enabled = true;
                btnAddLap.Visible = true;
                UpdateTaskList(timer);

                this.mnuEditTimes.Visible = (timer.GetLaps().Count > 0);
                this.mnuDeleteTimer.Visible = true;
            }
        }

        private void UpdateTaskList(Timer timer)
        {
            if (timer == null) return;
            StringList tasks = timer.GetTaskList();
            cboTasks.BeginUpdate();
            cboTasks.Items.Clear();
            cboTasks.Items.AddRange(tasks.ToArray());
            if (tasks.Count > 0)
                cboTasks.Text = tasks[tasks.Count - 1];
            else
                cboTasks.Text = "";
            cboTasks.EndUpdate();
        }

        private void listTimers_DoubleClick(object sender, System.EventArgs e)
        {
            Timer t = this.GetSelectedTimer();
            if (t == null) return;
            if (t.Started)
            {
                string task = cboTasks.Text;
                t.Stop(task);
            }
            else
                t.Start();
            timers.Save();
        }

        private void btnAddLap_Click(object sender, System.EventArgs e)
        {
            Timer t = this.GetSelectedTimer();
            if (t == null) return;
            DialogResult dr = AddLap.AddLapModal(t, this);
            if (dr != DialogResult.OK) return;
            timers.Save();
        }

        private void mnuExportPeriodByDay_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (cboPeriod.Text != "Custom")
                {
                    MessageBox.Show("This summary is only valid for the Custom view");
                    return;
                }

                Timer timer = this.GetSelectedTimer();
                if (timer == null) return;

                DateTime start = dtFromFilter.Value;
                DateTime end = this.dtToPicker.Value;

                System.IO.StringWriter sw = new System.IO.StringWriter();
                while (start < end)
                {
                    TimeSpan duration = timer.GetTotal(start, start.AddDays(1));
                    sw.WriteLine(start.ToString() + "\t" + duration.ToString());


                    start = start.AddDays(1);
                }

                System.Windows.Forms.Clipboard.SetDataObject(sw.ToString(), true);
                MessageBox.Show("The data has been successfully copied to the clipboard");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void mnuEditTimes_Click(object sender, System.EventArgs e)
        {
            Timer t = this.GetSelectedTimer();
            if (t == null) return;
            DialogResult dr = EditTimes.EditTimesModal(t, this);
            if (dr != DialogResult.OK) return;
            timers.Save();
        }

        private void mnuOpenContainingFolder_Click(object sender, System.EventArgs e)
        {
            string file = timers.GetPathName();
            string folder = System.IO.Path.GetDirectoryName(file);
            System.Diagnostics.Process.Start(folder);
        }

        private void mnuExportSalesForce_Click(object sender, System.EventArgs e)
        {
            ExportSalesForce.Display(timers, this);
        }
    }
}
