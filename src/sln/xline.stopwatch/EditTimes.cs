using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xline.stopwatch.Model;
using Timer = xline.stopwatch.Model.Timer;

namespace xline.stopwatch.View
{
  public partial class EditTimes : Form
  {
    private Timer timer = null;
    public static DialogResult EditTimesModal(Timer t, System.Windows.Forms.IWin32Window owner)
    {

      if (t == null) return DialogResult.Cancel;
      EditTimes f = new EditTimes();
      f.setTimer(t);
      return f.ShowDialog(owner);
    }

    public EditTimes()
    {
      InitializeComponent();
    }

    private Timer getTimer()
    {
      return timer;
    }
    
    private void setTimer(Timer timer)
    {
      this.timer = timer;
      fluentBindingSource.DataSource = timer.GetLaps();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
