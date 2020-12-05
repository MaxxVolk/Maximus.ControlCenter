﻿namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  partial class RegistryEditForm
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
      this.tcPages = new System.Windows.Forms.TabControl();
      this.tpStringValue = new System.Windows.Forms.TabPage();
      this.tbStringValue = new System.Windows.Forms.TextBox();
      this.tpNumeric = new System.Windows.Forms.TabPage();
      this.nudIntegerValue = new System.Windows.Forms.NumericUpDown();
      this.tpMultiString = new System.Windows.Forms.TabPage();
      this.tbMultiStringValue = new System.Windows.Forms.TextBox();
      this.tpBinary = new System.Windows.Forms.TabPage();
      this.tbBinaryValue = new System.Windows.Forms.TextBox();
      this.tbNewName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.tcPages.SuspendLayout();
      this.tpStringValue.SuspendLayout();
      this.tpNumeric.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudIntegerValue)).BeginInit();
      this.tpMultiString.SuspendLayout();
      this.tpBinary.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcPages
      // 
      this.tcPages.Controls.Add(this.tpStringValue);
      this.tcPages.Controls.Add(this.tpNumeric);
      this.tcPages.Controls.Add(this.tpMultiString);
      this.tcPages.Controls.Add(this.tpBinary);
      this.tcPages.Location = new System.Drawing.Point(15, 51);
      this.tcPages.Name = "tcPages";
      this.tcPages.SelectedIndex = 0;
      this.tcPages.Size = new System.Drawing.Size(409, 185);
      this.tcPages.TabIndex = 0;
      // 
      // tpStringValue
      // 
      this.tpStringValue.Controls.Add(this.tbStringValue);
      this.tpStringValue.Location = new System.Drawing.Point(4, 22);
      this.tpStringValue.Name = "tpStringValue";
      this.tpStringValue.Padding = new System.Windows.Forms.Padding(3);
      this.tpStringValue.Size = new System.Drawing.Size(401, 159);
      this.tpStringValue.TabIndex = 0;
      this.tpStringValue.Text = "String";
      this.tpStringValue.UseVisualStyleBackColor = true;
      // 
      // tbStringValue
      // 
      this.tbStringValue.Location = new System.Drawing.Point(6, 6);
      this.tbStringValue.Name = "tbStringValue";
      this.tbStringValue.Size = new System.Drawing.Size(389, 20);
      this.tbStringValue.TabIndex = 0;
      // 
      // tpNumeric
      // 
      this.tpNumeric.Controls.Add(this.nudIntegerValue);
      this.tpNumeric.Location = new System.Drawing.Point(4, 22);
      this.tpNumeric.Name = "tpNumeric";
      this.tpNumeric.Padding = new System.Windows.Forms.Padding(3);
      this.tpNumeric.Size = new System.Drawing.Size(401, 159);
      this.tpNumeric.TabIndex = 1;
      this.tpNumeric.Text = "D/Q-Word";
      this.tpNumeric.UseVisualStyleBackColor = true;
      // 
      // nudIntegerValue
      // 
      this.nudIntegerValue.Location = new System.Drawing.Point(6, 6);
      this.nudIntegerValue.Name = "nudIntegerValue";
      this.nudIntegerValue.Size = new System.Drawing.Size(389, 20);
      this.nudIntegerValue.TabIndex = 0;
      // 
      // tpMultiString
      // 
      this.tpMultiString.Controls.Add(this.tbMultiStringValue);
      this.tpMultiString.Location = new System.Drawing.Point(4, 22);
      this.tpMultiString.Name = "tpMultiString";
      this.tpMultiString.Padding = new System.Windows.Forms.Padding(3);
      this.tpMultiString.Size = new System.Drawing.Size(401, 159);
      this.tpMultiString.TabIndex = 2;
      this.tpMultiString.Text = "Multi Stirng";
      this.tpMultiString.UseVisualStyleBackColor = true;
      // 
      // tbMultiStringValue
      // 
      this.tbMultiStringValue.AcceptsReturn = true;
      this.tbMultiStringValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbMultiStringValue.Location = new System.Drawing.Point(3, 3);
      this.tbMultiStringValue.Multiline = true;
      this.tbMultiStringValue.Name = "tbMultiStringValue";
      this.tbMultiStringValue.Size = new System.Drawing.Size(395, 153);
      this.tbMultiStringValue.TabIndex = 0;
      // 
      // tpBinary
      // 
      this.tpBinary.Controls.Add(this.tbBinaryValue);
      this.tpBinary.Location = new System.Drawing.Point(4, 22);
      this.tpBinary.Name = "tpBinary";
      this.tpBinary.Padding = new System.Windows.Forms.Padding(3);
      this.tpBinary.Size = new System.Drawing.Size(401, 159);
      this.tpBinary.TabIndex = 3;
      this.tpBinary.Text = "Binary";
      this.tpBinary.UseVisualStyleBackColor = true;
      // 
      // tbBinaryValue
      // 
      this.tbBinaryValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.tbBinaryValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbBinaryValue.Location = new System.Drawing.Point(3, 3);
      this.tbBinaryValue.Multiline = true;
      this.tbBinaryValue.Name = "tbBinaryValue";
      this.tbBinaryValue.Size = new System.Drawing.Size(395, 153);
      this.tbBinaryValue.TabIndex = 0;
      this.tbBinaryValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBinaryValue_KeyPress);
      this.tbBinaryValue.Validating += new System.ComponentModel.CancelEventHandler(this.tbBinaryValue_Validating);
      // 
      // tbNewName
      // 
      this.tbNewName.Location = new System.Drawing.Point(15, 25);
      this.tbNewName.Name = "tbNewName";
      this.tbNewName.Size = new System.Drawing.Size(402, 20);
      this.tbNewName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Value name:";
      // 
      // btCancel
      // 
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Location = new System.Drawing.Point(349, 242);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 23);
      this.btCancel.TabIndex = 1;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // btOK
      // 
      this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btOK.Location = new System.Drawing.Point(268, 242);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(75, 23);
      this.btOK.TabIndex = 2;
      this.btOK.Text = "OK";
      this.btOK.UseVisualStyleBackColor = true;
      // 
      // RegistryEditForm
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(437, 278);
      this.Controls.Add(this.tbNewName);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.tcPages);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RegistryEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Registry Edit";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistryEditForm_FormClosing);
      this.tcPages.ResumeLayout(false);
      this.tpStringValue.ResumeLayout(false);
      this.tpStringValue.PerformLayout();
      this.tpNumeric.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudIntegerValue)).EndInit();
      this.tpMultiString.ResumeLayout(false);
      this.tpMultiString.PerformLayout();
      this.tpBinary.ResumeLayout(false);
      this.tpBinary.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tcPages;
    private System.Windows.Forms.TabPage tpStringValue;
    private System.Windows.Forms.TextBox tbNewName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tpNumeric;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.TextBox tbStringValue;
    private System.Windows.Forms.TabPage tpMultiString;
    private System.Windows.Forms.TabPage tpBinary;
    private System.Windows.Forms.NumericUpDown nudIntegerValue;
    private System.Windows.Forms.TextBox tbMultiStringValue;
    private System.Windows.Forms.TextBox tbBinaryValue;
  }
}