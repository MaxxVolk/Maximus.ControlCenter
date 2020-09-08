namespace Maximus.ControlCenter.UI.Control
{
  partial class TasksTabView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tcCategories = new System.Windows.Forms.TabControl();
      this.tpServices = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tcCategories.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // tcCategories
      // 
      this.tcCategories.Controls.Add(this.tpServices);
      this.tcCategories.Controls.Add(this.tabPage2);
      this.tcCategories.Controls.Add(this.tabPage3);
      this.tcCategories.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcCategories.Location = new System.Drawing.Point(0, 0);
      this.tcCategories.Name = "tcCategories";
      this.tcCategories.SelectedIndex = 0;
      this.tcCategories.Size = new System.Drawing.Size(1270, 424);
      this.tcCategories.TabIndex = 0;
      // 
      // tpServices
      // 
      this.tpServices.Location = new System.Drawing.Point(4, 22);
      this.tpServices.Name = "tpServices";
      this.tpServices.Padding = new System.Windows.Forms.Padding(3);
      this.tpServices.Size = new System.Drawing.Size(1262, 398);
      this.tpServices.TabIndex = 0;
      this.tpServices.Text = "Services";
      this.tpServices.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1262, 398);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(1262, 398);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // TasksTabView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tcCategories);
      this.Name = "TasksTabView";
      this.Size = new System.Drawing.Size(1270, 424);
      this.tcCategories.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tcCategories;
    private System.Windows.Forms.TabPage tpServices;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
  }
}
