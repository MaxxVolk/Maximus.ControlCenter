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
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbCritical = new System.Windows.Forms.CheckBox();
      this.cbWarning = new System.Windows.Forms.CheckBox();
      this.cbVerbose = new System.Windows.Forms.CheckBox();
      this.cbError = new System.Windows.Forms.CheckBox();
      this.cbInformation = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
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
      this.rbManual.Location = new System.Drawing.Point(12, 271);
      this.rbManual.Name = "rbManual";
      this.rbManual.Size = new System.Drawing.Size(91, 17);
      this.rbManual.TabIndex = 2;
      this.rbManual.Text = "Manual Query";
      this.rbManual.UseVisualStyleBackColor = true;
      this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
      // 
      // tbQueryText
      // 
      this.tbQueryText.Location = new System.Drawing.Point(12, 294);
      this.tbQueryText.Name = "tbQueryText";
      this.tbQueryText.ReadOnly = true;
      this.tbQueryText.Size = new System.Drawing.Size(660, 146);
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
      this.gbFilterConditions.Controls.Add(this.textBox4);
      this.gbFilterConditions.Controls.Add(this.label6);
      this.gbFilterConditions.Controls.Add(this.textBox3);
      this.gbFilterConditions.Controls.Add(this.label5);
      this.gbFilterConditions.Controls.Add(this.textBox2);
      this.gbFilterConditions.Controls.Add(this.textBox1);
      this.gbFilterConditions.Controls.Add(this.label4);
      this.gbFilterConditions.Controls.Add(this.label3);
      this.gbFilterConditions.Controls.Add(this.cbInformation);
      this.gbFilterConditions.Controls.Add(this.cbError);
      this.gbFilterConditions.Controls.Add(this.cbVerbose);
      this.gbFilterConditions.Controls.Add(this.cbWarning);
      this.gbFilterConditions.Controls.Add(this.cbCritical);
      this.gbFilterConditions.Controls.Add(this.label2);
      this.gbFilterConditions.Controls.Add(this.comboBox2);
      this.gbFilterConditions.Controls.Add(this.label1);
      this.gbFilterConditions.Location = new System.Drawing.Point(12, 85);
      this.gbFilterConditions.Name = "gbFilterConditions";
      this.gbFilterConditions.Size = new System.Drawing.Size(660, 180);
      this.gbFilterConditions.TabIndex = 5;
      this.gbFilterConditions.TabStop = false;
      this.gbFilterConditions.Text = "Filter";
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Logged:";
      // 
      // comboBox2
      // 
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new System.Drawing.Point(47, 17);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(121, 21);
      this.comboBox2.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Event level:";
      // 
      // cbCritical
      // 
      this.cbCritical.AutoSize = true;
      this.cbCritical.Location = new System.Drawing.Point(6, 57);
      this.cbCritical.Name = "cbCritical";
      this.cbCritical.Size = new System.Drawing.Size(57, 17);
      this.cbCritical.TabIndex = 3;
      this.cbCritical.Text = "Critical";
      this.cbCritical.UseVisualStyleBackColor = true;
      // 
      // cbWarning
      // 
      this.cbWarning.AutoSize = true;
      this.cbWarning.Location = new System.Drawing.Point(82, 57);
      this.cbWarning.Name = "cbWarning";
      this.cbWarning.Size = new System.Drawing.Size(66, 17);
      this.cbWarning.TabIndex = 4;
      this.cbWarning.Text = "Warning";
      this.cbWarning.UseVisualStyleBackColor = true;
      // 
      // cbVerbose
      // 
      this.cbVerbose.AutoSize = true;
      this.cbVerbose.Location = new System.Drawing.Point(327, 57);
      this.cbVerbose.Name = "cbVerbose";
      this.cbVerbose.Size = new System.Drawing.Size(65, 17);
      this.cbVerbose.TabIndex = 5;
      this.cbVerbose.Text = "Verbose";
      this.cbVerbose.UseVisualStyleBackColor = true;
      // 
      // cbError
      // 
      this.cbError.AutoSize = true;
      this.cbError.Location = new System.Drawing.Point(165, 57);
      this.cbError.Name = "cbError";
      this.cbError.Size = new System.Drawing.Size(48, 17);
      this.cbError.TabIndex = 6;
      this.cbError.Text = "Error";
      this.cbError.UseVisualStyleBackColor = true;
      // 
      // cbInformation
      // 
      this.cbInformation.AutoSize = true;
      this.cbInformation.Location = new System.Drawing.Point(228, 57);
      this.cbInformation.Name = "cbInformation";
      this.cbInformation.Size = new System.Drawing.Size(78, 17);
      this.cbInformation.TabIndex = 7;
      this.cbInformation.Text = "Information";
      this.cbInformation.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 86);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Event logs:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(204, 86);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(78, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Event sources:";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(72, 80);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 10;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(292, 83);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 20);
      this.textBox2.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 115);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(57, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Event IDs:";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(72, 112);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(100, 20);
      this.textBox3.TabIndex = 13;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(13, 135);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(78, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "Task category:";
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(97, 138);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(100, 20);
      this.textBox4.TabIndex = 15;
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
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox cbInformation;
    private System.Windows.Forms.CheckBox cbError;
    private System.Windows.Forms.CheckBox cbVerbose;
    private System.Windows.Forms.CheckBox cbWarning;
    private System.Windows.Forms.CheckBox cbCritical;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
  }
}