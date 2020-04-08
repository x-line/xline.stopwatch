using Int32 = System.Int32;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;
using DialogResult = System.Windows.Forms.DialogResult;
using xline.stopwatch.Model;

namespace xline.stopwatch.View
{
	/// <summary>
	/// Summary description for AddLap.
	/// </summary>
	public class AddLap : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnRecord;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.RadioButton rEndingNow;
		private System.Windows.Forms.DateTimePicker dtEndPicker;
		private System.Windows.Forms.DateTimePicker dtStartPicker;
		private System.Windows.Forms.Label lblDuration;
		private Timer timer;
		private TimeSpan duration;
		private System.Windows.Forms.RadioButton rStartingAt;
		private System.Windows.Forms.RadioButton rStartingNow;
		private System.Windows.Forms.RadioButton rEndingAt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTasks;
        private System.Windows.Forms.ComboBox cboTask;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public static DialogResult AddLapModal(Timer t, System.Windows.Forms.IWin32Window owner)
		{
			if (t == null) return DialogResult.Cancel;
			AddLap a = new AddLap();
			a.timer = t;
            a.cboTask.Items.Clear();
            a.cboTask.Items.AddRange(t.GetTaskList().ToArray());
			return a.ShowDialog(owner);
		}

		public AddLap()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLap));
      this.btnRecord = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.lbl = new System.Windows.Forms.Label();
      this.rEndingNow = new System.Windows.Forms.RadioButton();
      this.rEndingAt = new System.Windows.Forms.RadioButton();
      this.rStartingAt = new System.Windows.Forms.RadioButton();
      this.rStartingNow = new System.Windows.Forms.RadioButton();
      this.dtEndPicker = new System.Windows.Forms.DateTimePicker();
      this.dtStartPicker = new System.Windows.Forms.DateTimePicker();
      this.lblDuration = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cboTask = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnRecord
      // 
      this.btnRecord.Location = new System.Drawing.Point(64, 264);
      this.btnRecord.Name = "btnRecord";
      this.btnRecord.Size = new System.Drawing.Size(96, 32);
      this.btnRecord.TabIndex = 0;
      this.btnRecord.Text = "Record";
      this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(192, 264);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(96, 32);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // txtInput
      // 
      this.txtInput.Location = new System.Drawing.Point(174, 54);
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(136, 21);
      this.txtInput.TabIndex = 2;
      this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
      // 
      // lbl
      // 
      this.lbl.AutoSize = true;
      this.lbl.Location = new System.Drawing.Point(30, 62);
      this.lbl.Name = "lbl";
      this.lbl.Size = new System.Drawing.Size(115, 13);
      this.lbl.TabIndex = 3;
      this.lbl.Text = "Enter the duration:";
      // 
      // rEndingNow
      // 
      this.rEndingNow.Checked = true;
      this.rEndingNow.Location = new System.Drawing.Point(62, 118);
      this.rEndingNow.Name = "rEndingNow";
      this.rEndingNow.Size = new System.Drawing.Size(120, 32);
      this.rEndingNow.TabIndex = 4;
      this.rEndingNow.TabStop = true;
      this.rEndingNow.Text = "Ending Now";
      this.rEndingNow.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
      // 
      // rEndingAt
      // 
      this.rEndingAt.Location = new System.Drawing.Point(62, 150);
      this.rEndingAt.Name = "rEndingAt";
      this.rEndingAt.Size = new System.Drawing.Size(120, 32);
      this.rEndingAt.TabIndex = 5;
      this.rEndingAt.Text = "Ending:";
      this.rEndingAt.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
      // 
      // rStartingAt
      // 
      this.rStartingAt.Location = new System.Drawing.Point(62, 214);
      this.rStartingAt.Name = "rStartingAt";
      this.rStartingAt.Size = new System.Drawing.Size(120, 32);
      this.rStartingAt.TabIndex = 6;
      this.rStartingAt.Text = "Starting at:";
      this.rStartingAt.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
      // 
      // rStartingNow
      // 
      this.rStartingNow.Location = new System.Drawing.Point(62, 182);
      this.rStartingNow.Name = "rStartingNow";
      this.rStartingNow.Size = new System.Drawing.Size(120, 32);
      this.rStartingNow.TabIndex = 7;
      this.rStartingNow.Text = "Starting Now";
      this.rStartingNow.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
      // 
      // dtEndPicker
      // 
      this.dtEndPicker.CustomFormat = "ddMMMMMyyyy   HH:mm:ss";
      this.dtEndPicker.Enabled = false;
      this.dtEndPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtEndPicker.Location = new System.Drawing.Point(174, 150);
      this.dtEndPicker.Name = "dtEndPicker";
      this.dtEndPicker.Size = new System.Drawing.Size(208, 21);
      this.dtEndPicker.TabIndex = 8;
      this.dtEndPicker.Value = new System.DateTime(2005, 8, 23, 14, 57, 0, 0);
      // 
      // dtStartPicker
      // 
      this.dtStartPicker.CustomFormat = "ddMMMMMyyyy   HH:mm:ss";
      this.dtStartPicker.Enabled = false;
      this.dtStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtStartPicker.Location = new System.Drawing.Point(174, 222);
      this.dtStartPicker.Name = "dtStartPicker";
      this.dtStartPicker.Size = new System.Drawing.Size(208, 21);
      this.dtStartPicker.TabIndex = 9;
      // 
      // lblDuration
      // 
      this.lblDuration.Location = new System.Drawing.Point(174, 86);
      this.lblDuration.Name = "lblDuration";
      this.lblDuration.Size = new System.Drawing.Size(224, 24);
      this.lblDuration.TabIndex = 10;
      this.lblDuration.Text = "...";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Task Description";
      // 
      // cboTask
      // 
      this.cboTask.FormattingEnabled = true;
      this.cboTask.Location = new System.Drawing.Point(174, 22);
      this.cboTask.Name = "cboTask";
      this.cboTask.Size = new System.Drawing.Size(208, 21);
      this.cboTask.TabIndex = 11;
      // 
      // AddLap
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
      this.ClientSize = new System.Drawing.Size(432, 326);
      this.Controls.Add(this.cboTask);
      this.Controls.Add(this.lblDuration);
      this.Controls.Add(this.dtStartPicker);
      this.Controls.Add(this.dtEndPicker);
      this.Controls.Add(this.rStartingNow);
      this.Controls.Add(this.rStartingAt);
      this.Controls.Add(this.rEndingAt);
      this.Controls.Add(this.rEndingNow);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lbl);
      this.Controls.Add(this.txtInput);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnRecord);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AddLap";
      this.Text = "Add Lap";
      this.ResumeLayout(false);
      this.PerformLayout();

		}
		#endregion

		private void txtInput_TextChanged(object sender, System.EventArgs e)
		{
			TimeSpan ts;
			try
			{
				 string s = this.txtInput.Text;
				
				if (s.ToLower().IndexOf("min") > 0)
				{
					int i = s.ToLower().IndexOf("min");
					string temp = s.Substring(0, i);
					int number = Int32.Parse(temp);
					ts = new TimeSpan(0,number,0);


				}
				else
				{
					ts = TimeSpan.Parse(s);
				}

				duration = ts;
				this.lblDuration.Text = ts.ToString();
				btnRecord.Enabled = true;
			}
			catch
			{
				duration = new TimeSpan(0);
				lblDuration.Text = "Not understood";
				btnRecord.Enabled = false;
			}


		}

		private void btnRecord_Click(object sender, System.EventArgs e)
		{
			DateTime start, end;

			if (this.rEndingNow.Checked)
			{
				end = DateTime.Now;
				start = end.Subtract(duration);
			}
			else if (this.rEndingAt.Checked)
			{
				end = this.dtEndPicker.Value;
				start = end.Subtract(duration);
			}
			else if (this.rStartingNow.Checked)
			{
				start = DateTime.Now;
				end = start.Add(duration);
			}
			else // (this.rStartingAt.Checked)
			{
				start = this.dtStartPicker.Value;
				end = start.Add(duration);
			}
			timer.AddFluent(start, end, cboTask.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void RadioButtonChanged(object sender, System.EventArgs e)
		{
			this.dtStartPicker.Enabled = this.rStartingAt.Checked;
			this.dtEndPicker.Enabled = this.rEndingAt.Checked;
		}
	}
}
