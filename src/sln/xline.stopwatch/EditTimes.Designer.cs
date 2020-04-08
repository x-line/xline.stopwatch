namespace xline.stopwatch.View
{
  partial class EditTimes
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTimes));
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.fluentBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.stoppedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.StartAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EndAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DurationInMins = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.taskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.fluentBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // btnSave
      // 
      this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnSave.Location = new System.Drawing.Point(377, 386);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 33);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Close";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(696, 386);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 33);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Visible = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stoppedDataGridViewCheckBoxColumn,
            this.StartAsString,
            this.EndAsString,
            this.DurationInMins,
            this.taskDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.fluentBindingSource;
      this.dataGridView1.Location = new System.Drawing.Point(22, 57);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(749, 305);
      this.dataGridView1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(18, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(111, 23);
      this.label1.TabIndex = 3;
      this.label1.Text = "Edit Times";
      // 
      // fluentBindingSource
      // 
      this.fluentBindingSource.DataSource = typeof(xline.stopwatch.Model.Fluent);
      // 
      // stoppedDataGridViewCheckBoxColumn
      // 
      this.stoppedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.stoppedDataGridViewCheckBoxColumn.DataPropertyName = "Stopped";
      this.stoppedDataGridViewCheckBoxColumn.HeaderText = "Stopped";
      this.stoppedDataGridViewCheckBoxColumn.Name = "stoppedDataGridViewCheckBoxColumn";
      this.stoppedDataGridViewCheckBoxColumn.ReadOnly = true;
      this.stoppedDataGridViewCheckBoxColumn.Width = 53;
      // 
      // StartAsString
      // 
      this.StartAsString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.StartAsString.DataPropertyName = "StartAsString";
      this.StartAsString.HeaderText = "Start";
      this.StartAsString.Name = "StartAsString";
      this.StartAsString.Width = 54;
      // 
      // EndAsString
      // 
      this.EndAsString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.EndAsString.DataPropertyName = "EndAsString";
      this.EndAsString.HeaderText = "Stop";
      this.EndAsString.Name = "EndAsString";
      this.EndAsString.Width = 54;
      // 
      // DurationInMins
      // 
      this.DurationInMins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.DurationInMins.DataPropertyName = "DurationInMins";
      this.DurationInMins.HeaderText = "Duration In Mins";
      this.DurationInMins.Name = "DurationInMins";
      this.DurationInMins.ReadOnly = true;
      this.DurationInMins.Width = 80;
      // 
      // taskDataGridViewTextBoxColumn
      // 
      this.taskDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.taskDataGridViewTextBoxColumn.DataPropertyName = "Task";
      this.taskDataGridViewTextBoxColumn.HeaderText = "Notes";
      this.taskDataGridViewTextBoxColumn.Name = "taskDataGridViewTextBoxColumn";
      this.taskDataGridViewTextBoxColumn.Width = 60;
      // 
      // EditTimes
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(793, 431);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "EditTimes";
      this.Text = "EditTimes";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.fluentBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource fluentBindingSource;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn stoppedDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn StartAsString;
    private System.Windows.Forms.DataGridViewTextBoxColumn EndAsString;
    private System.Windows.Forms.DataGridViewTextBoxColumn DurationInMins;
    private System.Windows.Forms.DataGridViewTextBoxColumn taskDataGridViewTextBoxColumn;
  }
}