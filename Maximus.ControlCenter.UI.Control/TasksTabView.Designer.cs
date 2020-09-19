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
      this.dgvServices = new System.Windows.Forms.DataGridView();
      this.cServiceDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceIsTriggered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.cServiceIsDelayed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.cServiceObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pControls = new System.Windows.Forms.Panel();
      this.btServicesRefresh = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tcCategories.SuspendLayout();
      this.tpServices.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
      this.pControls.SuspendLayout();
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
      this.tpServices.Controls.Add(this.dgvServices);
      this.tpServices.Controls.Add(this.pControls);
      this.tpServices.Location = new System.Drawing.Point(4, 22);
      this.tpServices.Name = "tpServices";
      this.tpServices.Padding = new System.Windows.Forms.Padding(3);
      this.tpServices.Size = new System.Drawing.Size(1262, 398);
      this.tpServices.TabIndex = 0;
      this.tpServices.Text = "Services";
      this.tpServices.UseVisualStyleBackColor = true;
      // 
      // dgvServices
      // 
      this.dgvServices.AllowUserToAddRows = false;
      this.dgvServices.AllowUserToDeleteRows = false;
      this.dgvServices.AllowUserToOrderColumns = true;
      this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cServiceDisplayName,
            this.cServiceStatus,
            this.cServiceStart,
            this.cServiceIsTriggered,
            this.cServiceIsDelayed,
            this.cServiceObjectName});
      this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvServices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dgvServices.Location = new System.Drawing.Point(203, 3);
      this.dgvServices.MultiSelect = false;
      this.dgvServices.Name = "dgvServices";
      this.dgvServices.ReadOnly = true;
      this.dgvServices.RowHeadersVisible = false;
      this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvServices.Size = new System.Drawing.Size(1056, 392);
      this.dgvServices.TabIndex = 1;
      this.dgvServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellDoubleClick);
      this.dgvServices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvServices_KeyPress);
      // 
      // cServiceDisplayName
      // 
      this.cServiceDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cServiceDisplayName.DataPropertyName = "DisplayName";
      this.cServiceDisplayName.HeaderText = "Name";
      this.cServiceDisplayName.Name = "cServiceDisplayName";
      this.cServiceDisplayName.ReadOnly = true;
      // 
      // cServiceStatus
      // 
      this.cServiceStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cServiceStatus.DataPropertyName = "Status";
      this.cServiceStatus.FillWeight = 40F;
      this.cServiceStatus.HeaderText = "Status";
      this.cServiceStatus.Name = "cServiceStatus";
      this.cServiceStatus.ReadOnly = true;
      // 
      // cServiceStart
      // 
      this.cServiceStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cServiceStart.DataPropertyName = "Start";
      this.cServiceStart.FillWeight = 40F;
      this.cServiceStart.HeaderText = "Startup Type";
      this.cServiceStart.Name = "cServiceStart";
      this.cServiceStart.ReadOnly = true;
      // 
      // cServiceIsTriggered
      // 
      this.cServiceIsTriggered.DataPropertyName = "IsTriggered";
      this.cServiceIsTriggered.HeaderText = "Triggered";
      this.cServiceIsTriggered.Name = "cServiceIsTriggered";
      this.cServiceIsTriggered.ReadOnly = true;
      this.cServiceIsTriggered.Width = 55;
      // 
      // cServiceIsDelayed
      // 
      this.cServiceIsDelayed.DataPropertyName = "IsDelayed";
      this.cServiceIsDelayed.HeaderText = "Delayed";
      this.cServiceIsDelayed.Name = "cServiceIsDelayed";
      this.cServiceIsDelayed.ReadOnly = true;
      this.cServiceIsDelayed.Width = 55;
      // 
      // cServiceObjectName
      // 
      this.cServiceObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cServiceObjectName.DataPropertyName = "ObjectName";
      this.cServiceObjectName.FillWeight = 50F;
      this.cServiceObjectName.HeaderText = "Log On As";
      this.cServiceObjectName.Name = "cServiceObjectName";
      this.cServiceObjectName.ReadOnly = true;
      // 
      // pControls
      // 
      this.pControls.Controls.Add(this.btServicesRefresh);
      this.pControls.Dock = System.Windows.Forms.DockStyle.Left;
      this.pControls.Location = new System.Drawing.Point(3, 3);
      this.pControls.Name = "pControls";
      this.pControls.Size = new System.Drawing.Size(200, 392);
      this.pControls.TabIndex = 0;
      // 
      // btServicesRefresh
      // 
      this.btServicesRefresh.Location = new System.Drawing.Point(3, 3);
      this.btServicesRefresh.Name = "btServicesRefresh";
      this.btServicesRefresh.Size = new System.Drawing.Size(191, 23);
      this.btServicesRefresh.TabIndex = 0;
      this.btServicesRefresh.Text = "Load / Refresh";
      this.btServicesRefresh.UseVisualStyleBackColor = true;
      this.btServicesRefresh.Click += new System.EventHandler(this.btServicesRefresh_Click);
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
      this.tpServices.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
      this.pControls.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tcCategories;
    private System.Windows.Forms.TabPage tpServices;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.DataGridView dgvServices;
    private System.Windows.Forms.Panel pControls;
    private System.Windows.Forms.Button btServicesRefresh;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceDisplayName;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceStart;
    private System.Windows.Forms.DataGridViewCheckBoxColumn cServiceIsTriggered;
    private System.Windows.Forms.DataGridViewCheckBoxColumn cServiceIsDelayed;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceObjectName;
  }
}
