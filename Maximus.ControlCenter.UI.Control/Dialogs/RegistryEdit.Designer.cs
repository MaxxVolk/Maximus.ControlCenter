namespace Maximus.ControlCenter.UI.Control.Dialogs
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
      this.tbNewName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tpNumeric = new System.Windows.Forms.TabPage();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.tpMultiString = new System.Windows.Forms.TabPage();
      this.tpBinary = new System.Windows.Forms.TabPage();
      this.tbStringValue = new System.Windows.Forms.TextBox();
      this.tcPages.SuspendLayout();
      this.tpStringValue.SuspendLayout();
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
      // tbNewName
      // 
      this.tbNewName.Location = new System.Drawing.Point(15, 25);
      this.tbNewName.Name = "tbNewName";
      this.tbNewName.Size = new System.Drawing.Size(228, 20);
      this.tbNewName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter new name:";
      // 
      // tpNumeric
      // 
      this.tpNumeric.Location = new System.Drawing.Point(4, 22);
      this.tpNumeric.Name = "tpNumeric";
      this.tpNumeric.Padding = new System.Windows.Forms.Padding(3);
      this.tpNumeric.Size = new System.Drawing.Size(401, 159);
      this.tpNumeric.TabIndex = 1;
      this.tpNumeric.Text = "D/Q-Word";
      this.tpNumeric.UseVisualStyleBackColor = true;
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
      // tpMultiString
      // 
      this.tpMultiString.Location = new System.Drawing.Point(4, 22);
      this.tpMultiString.Name = "tpMultiString";
      this.tpMultiString.Padding = new System.Windows.Forms.Padding(3);
      this.tpMultiString.Size = new System.Drawing.Size(401, 159);
      this.tpMultiString.TabIndex = 2;
      this.tpMultiString.Text = "Multi Stirng";
      this.tpMultiString.UseVisualStyleBackColor = true;
      // 
      // tpBinary
      // 
      this.tpBinary.Location = new System.Drawing.Point(4, 22);
      this.tpBinary.Name = "tpBinary";
      this.tpBinary.Padding = new System.Windows.Forms.Padding(3);
      this.tpBinary.Size = new System.Drawing.Size(401, 159);
      this.tpBinary.TabIndex = 3;
      this.tpBinary.Text = "Binary";
      this.tpBinary.UseVisualStyleBackColor = true;
      // 
      // tbStringValue
      // 
      this.tbStringValue.Location = new System.Drawing.Point(6, 6);
      this.tbStringValue.Name = "tbStringValue";
      this.tbStringValue.Size = new System.Drawing.Size(389, 20);
      this.tbStringValue.TabIndex = 0;
      // 
      // RegistryEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
      this.tcPages.ResumeLayout(false);
      this.tpStringValue.ResumeLayout(false);
      this.tpStringValue.PerformLayout();
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
  }
}