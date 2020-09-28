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
      this.tpNewName = new System.Windows.Forms.TabPage();
      this.tp = new System.Windows.Forms.TabPage();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tbNewName = new System.Windows.Forms.TextBox();
      this.tcPages.SuspendLayout();
      this.tpNewName.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcPages
      // 
      this.tcPages.Controls.Add(this.tpNewName);
      this.tcPages.Controls.Add(this.tp);
      this.tcPages.Location = new System.Drawing.Point(12, 12);
      this.tcPages.Name = "tcPages";
      this.tcPages.SelectedIndex = 0;
      this.tcPages.Size = new System.Drawing.Size(416, 224);
      this.tcPages.TabIndex = 0;
      // 
      // tpNewName
      // 
      this.tpNewName.Controls.Add(this.tbNewName);
      this.tpNewName.Controls.Add(this.label1);
      this.tpNewName.Location = new System.Drawing.Point(4, 22);
      this.tpNewName.Name = "tpNewName";
      this.tpNewName.Padding = new System.Windows.Forms.Padding(3);
      this.tpNewName.Size = new System.Drawing.Size(408, 198);
      this.tpNewName.TabIndex = 0;
      this.tpNewName.Text = "tabPage1";
      this.tpNewName.UseVisualStyleBackColor = true;
      // 
      // tp
      // 
      this.tp.Location = new System.Drawing.Point(4, 22);
      this.tp.Name = "tp";
      this.tp.Padding = new System.Windows.Forms.Padding(3);
      this.tp.Size = new System.Drawing.Size(408, 198);
      this.tp.TabIndex = 1;
      this.tp.Text = "tabPage2";
      this.tp.UseVisualStyleBackColor = true;
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Enter new name:";
      // 
      // tbNewName
      // 
      this.tbNewName.Location = new System.Drawing.Point(9, 19);
      this.tbNewName.Name = "tbNewName";
      this.tbNewName.Size = new System.Drawing.Size(228, 20);
      this.tbNewName.TabIndex = 1;
      // 
      // RegistryEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(440, 281);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.tcPages);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RegistryEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Registry Edit";
      this.tcPages.ResumeLayout(false);
      this.tpNewName.ResumeLayout(false);
      this.tpNewName.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tcPages;
    private System.Windows.Forms.TabPage tpNewName;
    private System.Windows.Forms.TextBox tbNewName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tp;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
  }
}