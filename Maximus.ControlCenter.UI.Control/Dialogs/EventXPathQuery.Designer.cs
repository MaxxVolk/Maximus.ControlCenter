namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  partial class EventXPathQueryForm
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
      this.rbPreDefined = new System.Windows.Forms.RadioButton();
      this.rbFilter = new System.Windows.Forms.RadioButton();
      this.rbManual = new System.Windows.Forms.RadioButton();
      this.tbQueryText = new System.Windows.Forms.RichTextBox();
      this.cbPreDefQueryPicker = new System.Windows.Forms.ComboBox();
      this.gbFilterConditions = new System.Windows.Forms.GroupBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbInformation = new System.Windows.Forms.CheckBox();
      this.cbError = new System.Windows.Forms.CheckBox();
      this.cbVerbose = new System.Windows.Forms.CheckBox();
      this.cbWarning = new System.Windows.Forms.CheckBox();
      this.cbCritical = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbTimeRange = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.dtpFrom = new System.Windows.Forms.DateTimePicker();
      this.dtpTo = new System.Windows.Forms.DateTimePicker();
      this.rbByLog = new System.Windows.Forms.RadioButton();
      this.rbBySource = new System.Windows.Forms.RadioButton();
      this.cbEventLog = new System.Windows.Forms.ComboBox();
      this.cbEventSource = new System.Windows.Forms.ComboBox();
      this.gbFilterConditions.SuspendLayout();
      this.SuspendLayout();
      // 
      // rbPreDefined
      // 
      this.rbPreDefined.AutoSize = true;
      this.rbPreDefined.Checked = true;
      this.rbPreDefined.Location = new System.Drawing.Point(12, 12);
      this.rbPreDefined.Name = "rbPreDefined";
      this.rbPreDefined.Size = new System.Drawing.Size(139, 17);
      this.rbPreDefined.TabIndex = 0;
      this.rbPreDefined.TabStop = true;
      this.rbPreDefined.Text = "Predefined XPath Query";
      this.rbPreDefined.UseVisualStyleBackColor = true;
      this.rbPreDefined.CheckedChanged += new System.EventHandler(this.rbPreDefined_CheckedChanged);
      // 
      // rbFilter
      // 
      this.rbFilter.AutoSize = true;
      this.rbFilter.Enabled = false;
      this.rbFilter.Location = new System.Drawing.Point(12, 62);
      this.rbFilter.Name = "rbFilter";
      this.rbFilter.Size = new System.Drawing.Size(87, 17);
      this.rbFilter.TabIndex = 1;
      this.rbFilter.Text = "Create Query";
      this.rbFilter.UseVisualStyleBackColor = true;
      this.rbFilter.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
      // 
      // rbManual
      // 
      this.rbManual.AutoSize = true;
      this.rbManual.Location = new System.Drawing.Point(12, 230);
      this.rbManual.Name = "rbManual";
      this.rbManual.Size = new System.Drawing.Size(91, 17);
      this.rbManual.TabIndex = 2;
      this.rbManual.Text = "Manual Query";
      this.rbManual.UseVisualStyleBackColor = true;
      this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
      // 
      // tbQueryText
      // 
      this.tbQueryText.Location = new System.Drawing.Point(12, 253);
      this.tbQueryText.Name = "tbQueryText";
      this.tbQueryText.ReadOnly = true;
      this.tbQueryText.Size = new System.Drawing.Size(660, 187);
      this.tbQueryText.TabIndex = 3;
      this.tbQueryText.Text = "";
      // 
      // cbPreDefQueryPicker
      // 
      this.cbPreDefQueryPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPreDefQueryPicker.FormattingEnabled = true;
      this.cbPreDefQueryPicker.Location = new System.Drawing.Point(12, 35);
      this.cbPreDefQueryPicker.Name = "cbPreDefQueryPicker";
      this.cbPreDefQueryPicker.Size = new System.Drawing.Size(660, 21);
      this.cbPreDefQueryPicker.TabIndex = 4;
      this.cbPreDefQueryPicker.SelectionChangeCommitted += new System.EventHandler(this.cbPreDefQueryPicker_SelectionChangeCommitted);
      // 
      // gbFilterConditions
      // 
      this.gbFilterConditions.Controls.Add(this.cbEventSource);
      this.gbFilterConditions.Controls.Add(this.cbEventLog);
      this.gbFilterConditions.Controls.Add(this.rbBySource);
      this.gbFilterConditions.Controls.Add(this.rbByLog);
      this.gbFilterConditions.Controls.Add(this.dtpTo);
      this.gbFilterConditions.Controls.Add(this.dtpFrom);
      this.gbFilterConditions.Controls.Add(this.textBox3);
      this.gbFilterConditions.Controls.Add(this.label5);
      this.gbFilterConditions.Controls.Add(this.cbInformation);
      this.gbFilterConditions.Controls.Add(this.cbError);
      this.gbFilterConditions.Controls.Add(this.cbVerbose);
      this.gbFilterConditions.Controls.Add(this.cbWarning);
      this.gbFilterConditions.Controls.Add(this.cbCritical);
      this.gbFilterConditions.Controls.Add(this.label2);
      this.gbFilterConditions.Controls.Add(this.cbTimeRange);
      this.gbFilterConditions.Controls.Add(this.label1);
      this.gbFilterConditions.Location = new System.Drawing.Point(12, 85);
      this.gbFilterConditions.Name = "gbFilterConditions";
      this.gbFilterConditions.Size = new System.Drawing.Size(660, 139);
      this.gbFilterConditions.TabIndex = 5;
      this.gbFilterConditions.TabStop = false;
      this.gbFilterConditions.Text = "Filter";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(92, 113);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(224, 20);
      this.textBox3.TabIndex = 13;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 116);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(57, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Event IDs:";
      // 
      // cbInformation
      // 
      this.cbInformation.AutoSize = true;
      this.cbInformation.Location = new System.Drawing.Point(155, 67);
      this.cbInformation.Name = "cbInformation";
      this.cbInformation.Size = new System.Drawing.Size(78, 17);
      this.cbInformation.TabIndex = 7;
      this.cbInformation.Text = "Information";
      this.cbInformation.UseVisualStyleBackColor = true;
      // 
      // cbError
      // 
      this.cbError.AutoSize = true;
      this.cbError.Location = new System.Drawing.Point(92, 67);
      this.cbError.Name = "cbError";
      this.cbError.Size = new System.Drawing.Size(48, 17);
      this.cbError.TabIndex = 6;
      this.cbError.Text = "Error";
      this.cbError.UseVisualStyleBackColor = true;
      // 
      // cbVerbose
      // 
      this.cbVerbose.AutoSize = true;
      this.cbVerbose.Location = new System.Drawing.Point(238, 44);
      this.cbVerbose.Name = "cbVerbose";
      this.cbVerbose.Size = new System.Drawing.Size(65, 17);
      this.cbVerbose.TabIndex = 5;
      this.cbVerbose.Text = "Verbose";
      this.cbVerbose.UseVisualStyleBackColor = true;
      // 
      // cbWarning
      // 
      this.cbWarning.AutoSize = true;
      this.cbWarning.Location = new System.Drawing.Point(155, 44);
      this.cbWarning.Name = "cbWarning";
      this.cbWarning.Size = new System.Drawing.Size(66, 17);
      this.cbWarning.TabIndex = 4;
      this.cbWarning.Text = "Warning";
      this.cbWarning.UseVisualStyleBackColor = true;
      // 
      // cbCritical
      // 
      this.cbCritical.AutoSize = true;
      this.cbCritical.Location = new System.Drawing.Point(92, 44);
      this.cbCritical.Name = "cbCritical";
      this.cbCritical.Size = new System.Drawing.Size(57, 17);
      this.cbCritical.TabIndex = 3;
      this.cbCritical.Text = "Critical";
      this.cbCritical.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Event level:";
      // 
      // cbTimeRange
      // 
      this.cbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTimeRange.FormattingEnabled = true;
      this.cbTimeRange.Items.AddRange(new object[] {
            "Any time",
            "Last hour",
            "Last 12 hours",
            "Last 24 hours",
            "Last 7 days",
            "Last 30 days",
            "Custom range..."});
      this.cbTimeRange.Location = new System.Drawing.Point(92, 17);
      this.cbTimeRange.Name = "cbTimeRange";
      this.cbTimeRange.Size = new System.Drawing.Size(224, 21);
      this.cbTimeRange.TabIndex = 1;
      this.cbTimeRange.SelectionChangeCommitted += new System.EventHandler(this.cbTimeRange_SelectionChangeCommitted);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Logged:";
      // 
      // btCancel
      // 
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Location = new System.Drawing.Point(570, 446);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(102, 23);
      this.btCancel.TabIndex = 6;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // btOK
      // 
      this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btOK.Location = new System.Drawing.Point(462, 446);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(102, 23);
      this.btOK.TabIndex = 7;
      this.btOK.Text = "OK";
      this.btOK.UseVisualStyleBackColor = true;
      // 
      // dtpFrom
      // 
      this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpFrom.Enabled = false;
      this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpFrom.Location = new System.Drawing.Point(322, 18);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new System.Drawing.Size(162, 20);
      this.dtpFrom.TabIndex = 16;
      // 
      // dtpTo
      // 
      this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpTo.Enabled = false;
      this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTo.Location = new System.Drawing.Point(490, 18);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new System.Drawing.Size(164, 20);
      this.dtpTo.TabIndex = 17;
      // 
      // rbByLog
      // 
      this.rbByLog.AutoSize = true;
      this.rbByLog.Location = new System.Drawing.Point(9, 90);
      this.rbByLog.Name = "rbByLog";
      this.rbByLog.Size = new System.Drawing.Size(78, 17);
      this.rbByLog.TabIndex = 18;
      this.rbByLog.TabStop = true;
      this.rbByLog.Text = "Event logs:";
      this.rbByLog.UseVisualStyleBackColor = true;
      // 
      // rbBySource
      // 
      this.rbBySource.AutoSize = true;
      this.rbBySource.Location = new System.Drawing.Point(324, 90);
      this.rbBySource.Name = "rbBySource";
      this.rbBySource.Size = new System.Drawing.Size(96, 17);
      this.rbBySource.TabIndex = 19;
      this.rbBySource.TabStop = true;
      this.rbBySource.Text = "Event sources:";
      this.rbBySource.UseVisualStyleBackColor = true;
      // 
      // cbEventLog
      // 
      this.cbEventLog.FormattingEnabled = true;
      this.cbEventLog.Location = new System.Drawing.Point(92, 86);
      this.cbEventLog.Name = "cbEventLog";
      this.cbEventLog.Size = new System.Drawing.Size(224, 21);
      this.cbEventLog.TabIndex = 20;
      // 
      // cbEventSource
      // 
      this.cbEventSource.FormattingEnabled = true;
      this.cbEventSource.Location = new System.Drawing.Point(426, 86);
      this.cbEventSource.Name = "cbEventSource";
      this.cbEventSource.Size = new System.Drawing.Size(224, 21);
      this.cbEventSource.TabIndex = 21;
      // 
      // EventXPathQueryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(686, 482);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.gbFilterConditions);
      this.Controls.Add(this.cbPreDefQueryPicker);
      this.Controls.Add(this.tbQueryText);
      this.Controls.Add(this.rbManual);
      this.Controls.Add(this.rbFilter);
      this.Controls.Add(this.rbPreDefined);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EventXPathQueryForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "EventXPathQuery";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventXPathQueryForm_FormClosing);
      this.Load += new System.EventHandler(this.EventXPathQueryForm_Load);
      this.Shown += new System.EventHandler(this.EventXPathQueryForm_Shown);
      this.gbFilterConditions.ResumeLayout(false);
      this.gbFilterConditions.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbPreDefined;
    private System.Windows.Forms.RadioButton rbFilter;
    private System.Windows.Forms.RadioButton rbManual;
    private System.Windows.Forms.RichTextBox tbQueryText;
    private System.Windows.Forms.ComboBox cbPreDefQueryPicker;
    private System.Windows.Forms.GroupBox gbFilterConditions;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox cbInformation;
    private System.Windows.Forms.CheckBox cbError;
    private System.Windows.Forms.CheckBox cbVerbose;
    private System.Windows.Forms.CheckBox cbWarning;
    private System.Windows.Forms.CheckBox cbCritical;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbTimeRange;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.ComboBox cbEventSource;
    private System.Windows.Forms.ComboBox cbEventLog;
    private System.Windows.Forms.RadioButton rbBySource;
    private System.Windows.Forms.RadioButton rbByLog;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.DateTimePicker dtpFrom;
  }
}