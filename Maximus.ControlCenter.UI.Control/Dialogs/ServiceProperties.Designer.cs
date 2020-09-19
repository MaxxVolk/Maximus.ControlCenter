namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  partial class ServicePropertiesForm
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Refresh Service to list parameters.");
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tpGeneral = new System.Windows.Forms.TabPage();
      this.tpLogOn = new System.Windows.Forms.TabPage();
      this.tpDependencies = new System.Windows.Forms.TabPage();
      this.btApply = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.lName = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.tbDisplayName = new System.Windows.Forms.TextBox();
      this.tbDescription = new System.Windows.Forms.TextBox();
      this.tbPathToExecute = new System.Windows.Forms.TextBox();
      this.cbStartupType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lDescription = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btStart = new System.Windows.Forms.Button();
      this.btStop = new System.Windows.Forms.Button();
      this.btRefresh = new System.Windows.Forms.Button();
      this.btPause = new System.Windows.Forms.Button();
      this.btResume = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.tpParameters = new System.Windows.Forms.TabPage();
      this.cbDelayed = new System.Windows.Forms.CheckBox();
      this.cbTriggerStart = new System.Windows.Forms.CheckBox();
      this.lStatus = new System.Windows.Forms.Label();
      this.lLogOnAs = new System.Windows.Forms.Label();
      this.tbObjectName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tbServiceType = new System.Windows.Forms.TextBox();
      this.tpCluster = new System.Windows.Forms.TabPage();
      this.tvDependsOn = new System.Windows.Forms.TreeView();
      this.tbDepending = new System.Windows.Forms.TreeView();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lvParameters = new System.Windows.Forms.ListView();
      this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label8 = new System.Windows.Forms.Label();
      this.tbClusterNode = new System.Windows.Forms.TextBox();
      this.tabControl1.SuspendLayout();
      this.tpGeneral.SuspendLayout();
      this.tpLogOn.SuspendLayout();
      this.tpDependencies.SuspendLayout();
      this.tpParameters.SuspendLayout();
      this.tpCluster.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tpGeneral);
      this.tabControl1.Controls.Add(this.tpLogOn);
      this.tabControl1.Controls.Add(this.tpDependencies);
      this.tabControl1.Controls.Add(this.tpParameters);
      this.tabControl1.Controls.Add(this.tpCluster);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(426, 326);
      this.tabControl1.TabIndex = 0;
      // 
      // tpGeneral
      // 
      this.tpGeneral.Controls.Add(this.tbServiceType);
      this.tpGeneral.Controls.Add(this.label5);
      this.tpGeneral.Controls.Add(this.lStatus);
      this.tpGeneral.Controls.Add(this.cbTriggerStart);
      this.tpGeneral.Controls.Add(this.cbDelayed);
      this.tpGeneral.Controls.Add(this.label2);
      this.tpGeneral.Controls.Add(this.btResume);
      this.tpGeneral.Controls.Add(this.btPause);
      this.tpGeneral.Controls.Add(this.btStop);
      this.tpGeneral.Controls.Add(this.btStart);
      this.tpGeneral.Controls.Add(this.label4);
      this.tpGeneral.Controls.Add(this.label3);
      this.tpGeneral.Controls.Add(this.lDescription);
      this.tpGeneral.Controls.Add(this.label1);
      this.tpGeneral.Controls.Add(this.cbStartupType);
      this.tpGeneral.Controls.Add(this.tbPathToExecute);
      this.tpGeneral.Controls.Add(this.tbDescription);
      this.tpGeneral.Controls.Add(this.tbDisplayName);
      this.tpGeneral.Controls.Add(this.tbName);
      this.tpGeneral.Controls.Add(this.lName);
      this.tpGeneral.Location = new System.Drawing.Point(4, 22);
      this.tpGeneral.Name = "tpGeneral";
      this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tpGeneral.Size = new System.Drawing.Size(418, 300);
      this.tpGeneral.TabIndex = 0;
      this.tpGeneral.Text = "General";
      this.tpGeneral.UseVisualStyleBackColor = true;
      // 
      // tpLogOn
      // 
      this.tpLogOn.Controls.Add(this.tbObjectName);
      this.tpLogOn.Controls.Add(this.lLogOnAs);
      this.tpLogOn.Location = new System.Drawing.Point(4, 22);
      this.tpLogOn.Name = "tpLogOn";
      this.tpLogOn.Padding = new System.Windows.Forms.Padding(3);
      this.tpLogOn.Size = new System.Drawing.Size(418, 300);
      this.tpLogOn.TabIndex = 1;
      this.tpLogOn.Text = "Log On";
      this.tpLogOn.UseVisualStyleBackColor = true;
      // 
      // tpDependencies
      // 
      this.tpDependencies.Controls.Add(this.label7);
      this.tpDependencies.Controls.Add(this.label6);
      this.tpDependencies.Controls.Add(this.tbDepending);
      this.tpDependencies.Controls.Add(this.tvDependsOn);
      this.tpDependencies.Location = new System.Drawing.Point(4, 22);
      this.tpDependencies.Name = "tpDependencies";
      this.tpDependencies.Padding = new System.Windows.Forms.Padding(3);
      this.tpDependencies.Size = new System.Drawing.Size(418, 300);
      this.tpDependencies.TabIndex = 2;
      this.tpDependencies.Text = "Dependencies";
      this.tpDependencies.UseVisualStyleBackColor = true;
      // 
      // btApply
      // 
      this.btApply.Location = new System.Drawing.Point(339, 344);
      this.btApply.Name = "btApply";
      this.btApply.Size = new System.Drawing.Size(95, 23);
      this.btApply.TabIndex = 1;
      this.btApply.Text = "Apply";
      this.btApply.UseVisualStyleBackColor = true;
      // 
      // btOK
      // 
      this.btOK.Location = new System.Drawing.Point(137, 344);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(95, 23);
      this.btOK.TabIndex = 2;
      this.btOK.Text = "OK";
      this.btOK.UseVisualStyleBackColor = true;
      // 
      // btCancel
      // 
      this.btCancel.Location = new System.Drawing.Point(238, 344);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(95, 23);
      this.btCancel.TabIndex = 3;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // lName
      // 
      this.lName.AutoSize = true;
      this.lName.Location = new System.Drawing.Point(6, 12);
      this.lName.Name = "lName";
      this.lName.Size = new System.Drawing.Size(75, 13);
      this.lName.TabIndex = 0;
      this.lName.Text = "Service name:";
      // 
      // tbName
      // 
      this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbName.Location = new System.Drawing.Point(96, 12);
      this.tbName.Name = "tbName";
      this.tbName.ReadOnly = true;
      this.tbName.Size = new System.Drawing.Size(311, 13);
      this.tbName.TabIndex = 1;
      // 
      // tbDisplayName
      // 
      this.tbDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbDisplayName.Location = new System.Drawing.Point(96, 31);
      this.tbDisplayName.Name = "tbDisplayName";
      this.tbDisplayName.ReadOnly = true;
      this.tbDisplayName.Size = new System.Drawing.Size(311, 13);
      this.tbDisplayName.TabIndex = 2;
      // 
      // tbDescription
      // 
      this.tbDescription.Location = new System.Drawing.Point(96, 50);
      this.tbDescription.Multiline = true;
      this.tbDescription.Name = "tbDescription";
      this.tbDescription.ReadOnly = true;
      this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbDescription.Size = new System.Drawing.Size(311, 50);
      this.tbDescription.TabIndex = 3;
      // 
      // tbPathToExecute
      // 
      this.tbPathToExecute.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbPathToExecute.Location = new System.Drawing.Point(9, 124);
      this.tbPathToExecute.Name = "tbPathToExecute";
      this.tbPathToExecute.ReadOnly = true;
      this.tbPathToExecute.Size = new System.Drawing.Size(398, 13);
      this.tbPathToExecute.TabIndex = 4;
      // 
      // cbStartupType
      // 
      this.cbStartupType.DisplayMember = "Description";
      this.cbStartupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbStartupType.FormattingEnabled = true;
      this.cbStartupType.Location = new System.Drawing.Point(96, 143);
      this.cbStartupType.Name = "cbStartupType";
      this.cbStartupType.Size = new System.Drawing.Size(311, 21);
      this.cbStartupType.TabIndex = 5;
      this.cbStartupType.ValueMember = "NativeValue";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Display name:";
      // 
      // lDescription
      // 
      this.lDescription.AutoSize = true;
      this.lDescription.Location = new System.Drawing.Point(6, 53);
      this.lDescription.Name = "lDescription";
      this.lDescription.Size = new System.Drawing.Size(63, 13);
      this.lDescription.TabIndex = 7;
      this.lDescription.Text = "Description:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(85, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Path to execute:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 151);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(67, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Startup type:";
      // 
      // btStart
      // 
      this.btStart.Location = new System.Drawing.Point(9, 267);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(95, 23);
      this.btStart.TabIndex = 10;
      this.btStart.Text = "Start";
      this.btStart.UseVisualStyleBackColor = true;
      // 
      // btStop
      // 
      this.btStop.Location = new System.Drawing.Point(110, 267);
      this.btStop.Name = "btStop";
      this.btStop.Size = new System.Drawing.Size(95, 23);
      this.btStop.TabIndex = 11;
      this.btStop.Text = "Stop";
      this.btStop.UseVisualStyleBackColor = true;
      // 
      // btRefresh
      // 
      this.btRefresh.Location = new System.Drawing.Point(12, 344);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(95, 23);
      this.btRefresh.TabIndex = 12;
      this.btRefresh.Text = "Refresh";
      this.btRefresh.UseVisualStyleBackColor = true;
      this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
      // 
      // btPause
      // 
      this.btPause.Location = new System.Drawing.Point(211, 267);
      this.btPause.Name = "btPause";
      this.btPause.Size = new System.Drawing.Size(95, 23);
      this.btPause.TabIndex = 13;
      this.btPause.Text = "Pause";
      this.btPause.UseVisualStyleBackColor = true;
      // 
      // btResume
      // 
      this.btResume.Location = new System.Drawing.Point(312, 267);
      this.btResume.Name = "btResume";
      this.btResume.Size = new System.Drawing.Size(95, 23);
      this.btResume.TabIndex = 14;
      this.btResume.Text = "Resume";
      this.btResume.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 222);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(77, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Service status:";
      // 
      // tpParameters
      // 
      this.tpParameters.Controls.Add(this.lvParameters);
      this.tpParameters.Location = new System.Drawing.Point(4, 22);
      this.tpParameters.Name = "tpParameters";
      this.tpParameters.Padding = new System.Windows.Forms.Padding(3);
      this.tpParameters.Size = new System.Drawing.Size(418, 300);
      this.tpParameters.TabIndex = 3;
      this.tpParameters.Text = "Parameters";
      this.tpParameters.UseVisualStyleBackColor = true;
      // 
      // cbDelayed
      // 
      this.cbDelayed.AutoSize = true;
      this.cbDelayed.Location = new System.Drawing.Point(96, 170);
      this.cbDelayed.Name = "cbDelayed";
      this.cbDelayed.Size = new System.Drawing.Size(65, 17);
      this.cbDelayed.TabIndex = 16;
      this.cbDelayed.Text = "Delayed";
      this.cbDelayed.UseVisualStyleBackColor = true;
      // 
      // cbTriggerStart
      // 
      this.cbTriggerStart.AutoSize = true;
      this.cbTriggerStart.Location = new System.Drawing.Point(193, 170);
      this.cbTriggerStart.Name = "cbTriggerStart";
      this.cbTriggerStart.Size = new System.Drawing.Size(82, 17);
      this.cbTriggerStart.TabIndex = 17;
      this.cbTriggerStart.Text = "Trigger start";
      this.cbTriggerStart.UseVisualStyleBackColor = true;
      // 
      // lStatus
      // 
      this.lStatus.AutoSize = true;
      this.lStatus.Location = new System.Drawing.Point(8, 240);
      this.lStatus.Name = "lStatus";
      this.lStatus.Size = new System.Drawing.Size(0, 13);
      this.lStatus.TabIndex = 18;
      // 
      // lLogOnAs
      // 
      this.lLogOnAs.AutoSize = true;
      this.lLogOnAs.Location = new System.Drawing.Point(6, 12);
      this.lLogOnAs.Name = "lLogOnAs";
      this.lLogOnAs.Size = new System.Drawing.Size(57, 13);
      this.lLogOnAs.TabIndex = 1;
      this.lLogOnAs.Text = "Log on as:";
      // 
      // tbObjectName
      // 
      this.tbObjectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbObjectName.Location = new System.Drawing.Point(69, 12);
      this.tbObjectName.Name = "tbObjectName";
      this.tbObjectName.ReadOnly = true;
      this.tbObjectName.Size = new System.Drawing.Size(343, 13);
      this.tbObjectName.TabIndex = 2;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 196);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "Service type:";
      // 
      // tbServiceType
      // 
      this.tbServiceType.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbServiceType.Location = new System.Drawing.Point(96, 196);
      this.tbServiceType.Name = "tbServiceType";
      this.tbServiceType.ReadOnly = true;
      this.tbServiceType.Size = new System.Drawing.Size(311, 13);
      this.tbServiceType.TabIndex = 20;
      // 
      // tpCluster
      // 
      this.tpCluster.Controls.Add(this.tbClusterNode);
      this.tpCluster.Controls.Add(this.label8);
      this.tpCluster.Location = new System.Drawing.Point(4, 22);
      this.tpCluster.Name = "tpCluster";
      this.tpCluster.Padding = new System.Windows.Forms.Padding(3);
      this.tpCluster.Size = new System.Drawing.Size(418, 300);
      this.tpCluster.TabIndex = 4;
      this.tpCluster.Text = "Cluster";
      this.tpCluster.UseVisualStyleBackColor = true;
      // 
      // tvDependsOn
      // 
      this.tvDependsOn.Location = new System.Drawing.Point(9, 29);
      this.tvDependsOn.Name = "tvDependsOn";
      this.tvDependsOn.Size = new System.Drawing.Size(403, 119);
      this.tvDependsOn.TabIndex = 0;
      // 
      // tbDepending
      // 
      this.tbDepending.Location = new System.Drawing.Point(9, 168);
      this.tbDepending.Name = "tbDepending";
      this.tbDepending.Size = new System.Drawing.Size(403, 119);
      this.tbDepending.TabIndex = 1;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 12);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(284, 13);
      this.label6.TabIndex = 2;
      this.label6.Text = "This service depends on the following system components:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 151);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(282, 13);
      this.label7.TabIndex = 3;
      this.label7.Text = "The forllowing system components depend on this service:";
      // 
      // lvParameters
      // 
      this.lvParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath,
            this.chType,
            this.chValue});
      this.lvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvParameters.FullRowSelect = true;
      this.lvParameters.GridLines = true;
      this.lvParameters.HideSelection = false;
      this.lvParameters.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
      this.lvParameters.Location = new System.Drawing.Point(3, 3);
      this.lvParameters.Name = "lvParameters";
      this.lvParameters.Size = new System.Drawing.Size(412, 294);
      this.lvParameters.TabIndex = 0;
      this.lvParameters.UseCompatibleStateImageBehavior = false;
      this.lvParameters.View = System.Windows.Forms.View.Details;
      // 
      // chPath
      // 
      this.chPath.Text = "Path";
      this.chPath.Width = 178;
      // 
      // chType
      // 
      this.chType.Text = "Type";
      this.chType.Width = 68;
      // 
      // chValue
      // 
      this.chValue.Text = "Value";
      this.chValue.Width = 146;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 12);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(69, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "Cluster node:";
      // 
      // tbClusterNode
      // 
      this.tbClusterNode.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbClusterNode.Location = new System.Drawing.Point(81, 12);
      this.tbClusterNode.Name = "tbClusterNode";
      this.tbClusterNode.ReadOnly = true;
      this.tbClusterNode.Size = new System.Drawing.Size(331, 13);
      this.tbClusterNode.TabIndex = 1;
      // 
      // ServicePropertiesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(452, 385);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btApply);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.btRefresh);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ServicePropertiesForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ServiceProperties";
      this.Load += new System.EventHandler(this.ServicePropertiesForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tpGeneral.ResumeLayout(false);
      this.tpGeneral.PerformLayout();
      this.tpLogOn.ResumeLayout(false);
      this.tpLogOn.PerformLayout();
      this.tpDependencies.ResumeLayout(false);
      this.tpDependencies.PerformLayout();
      this.tpParameters.ResumeLayout(false);
      this.tpCluster.ResumeLayout(false);
      this.tpCluster.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tpGeneral;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btResume;
    private System.Windows.Forms.Button btPause;
    private System.Windows.Forms.Button btRefresh;
    private System.Windows.Forms.Button btStop;
    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lDescription;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbStartupType;
    private System.Windows.Forms.TextBox tbPathToExecute;
    private System.Windows.Forms.TextBox tbDescription;
    private System.Windows.Forms.TextBox tbDisplayName;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Label lName;
    private System.Windows.Forms.TabPage tpLogOn;
    private System.Windows.Forms.TabPage tpDependencies;
    private System.Windows.Forms.Button btApply;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.TabPage tpParameters;
    private System.Windows.Forms.CheckBox cbTriggerStart;
    private System.Windows.Forms.CheckBox cbDelayed;
    private System.Windows.Forms.Label lStatus;
    private System.Windows.Forms.TextBox tbObjectName;
    private System.Windows.Forms.Label lLogOnAs;
    private System.Windows.Forms.TextBox tbServiceType;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TabPage tpCluster;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TreeView tbDepending;
    private System.Windows.Forms.TreeView tvDependsOn;
    private System.Windows.Forms.ListView lvParameters;
    private System.Windows.Forms.ColumnHeader chPath;
    private System.Windows.Forms.ColumnHeader chType;
    private System.Windows.Forms.ColumnHeader chValue;
    private System.Windows.Forms.TextBox tbClusterNode;
    private System.Windows.Forms.Label label8;
  }
}