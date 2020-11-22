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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksTabView));
      this.tcCategories = new System.Windows.Forms.TabControl();
      this.tpServices = new System.Windows.Forms.TabPage();
      this.dgvServices = new System.Windows.Forms.DataGridView();
      this.cServiceDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cServiceIsTriggered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.cServiceIsDelayed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.cServiceObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pServiceControls = new System.Windows.Forms.Panel();
      this.btServicesRefresh = new System.Windows.Forms.Button();
      this.tpEvents = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.dgvEventsMain = new System.Windows.Forms.DataGridView();
      this.cLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cLogged = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cEventId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cTaskCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tvEventDetails = new System.Windows.Forms.TabControl();
      this.tpEventGeneral = new System.Windows.Forms.TabPage();
      this.tbEventText = new System.Windows.Forms.RichTextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.tbEventLevel = new System.Windows.Forms.TextBox();
      this.tbEventUser = new System.Windows.Forms.TextBox();
      this.tbEventLogName = new System.Windows.Forms.TextBox();
      this.tbEventComputer = new System.Windows.Forms.TextBox();
      this.tbEventKeywords = new System.Windows.Forms.TextBox();
      this.tbEventEventCatrgory = new System.Windows.Forms.TextBox();
      this.tbEventLogged = new System.Windows.Forms.TextBox();
      this.tbEventEventId = new System.Windows.Forms.TextBox();
      this.tbEventSource = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tpDetails = new System.Windows.Forms.TabPage();
      this.wbEventXML = new System.Windows.Forms.WebBrowser();
      this.pEventControls = new System.Windows.Forms.Panel();
      this.tbMaxEvents = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.btEventMakeXPathQuery = new System.Windows.Forms.Button();
      this.cbEventSelectLog = new System.Windows.Forms.ComboBox();
      this.tbEventXPathQuery = new System.Windows.Forms.TextBox();
      this.tbMaxSearchEvents = new System.Windows.Forms.TextBox();
      this.cbEventSearchRegExp = new System.Windows.Forms.CheckBox();
      this.tbEventSearchExpression = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.rbEventFilter = new System.Windows.Forms.RadioButton();
      this.btEventsRefresh = new System.Windows.Forms.Button();
      this.rbSearch = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.rbLastEvents = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.btBrowseLogs = new System.Windows.Forms.Button();
      this.tpRegistry = new System.Windows.Forms.TabPage();
      this.lvRegItems = new System.Windows.Forms.ListView();
      this.chRegName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chRegType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chRegData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.cmRegEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.stringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dWORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.qWORDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.multiStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.expandableStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ilRegIcons = new System.Windows.Forms.ImageList(this.components);
      this.pRegistryControls = new System.Windows.Forms.Panel();
      this.btRegGo = new System.Windows.Forms.Button();
      this.tbRegPath = new System.Windows.Forms.TextBox();
      this.label18 = new System.Windows.Forms.Label();
      this.cbRegRootKey = new System.Windows.Forms.ComboBox();
      this.label13 = new System.Windows.Forms.Label();
      this.tpPerformance = new System.Windows.Forms.TabPage();
      this.tpSystemInfo = new System.Windows.Forms.TabPage();
      this.tpStorage = new System.Windows.Forms.TabPage();
      this.tpPtocesses = new System.Windows.Forms.TabPage();
      this.tpShares = new System.Windows.Forms.TabPage();
      this.tpLocalUsers = new System.Windows.Forms.TabPage();
      this.tbComputerCertificates = new System.Windows.Forms.TabPage();
      this.tpFirewall = new System.Windows.Forms.TabPage();
      this.lCurrentTasks = new System.Windows.Forms.Label();
      this.tcCategories.SuspendLayout();
      this.tpServices.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
      this.pServiceControls.SuspendLayout();
      this.tpEvents.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvEventsMain)).BeginInit();
      this.tvEventDetails.SuspendLayout();
      this.tpEventGeneral.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tpDetails.SuspendLayout();
      this.pEventControls.SuspendLayout();
      this.tpRegistry.SuspendLayout();
      this.cmRegEditMenu.SuspendLayout();
      this.pRegistryControls.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // tcCategories
      // 
      this.tcCategories.Controls.Add(this.tpServices);
      this.tcCategories.Controls.Add(this.tpEvents);
      this.tcCategories.Controls.Add(this.tpRegistry);
      this.tcCategories.Controls.Add(this.tpPerformance);
      this.tcCategories.Controls.Add(this.tpSystemInfo);
      this.tcCategories.Controls.Add(this.tpStorage);
      this.tcCategories.Controls.Add(this.tpPtocesses);
      this.tcCategories.Controls.Add(this.tpShares);
      this.tcCategories.Controls.Add(this.tpLocalUsers);
      this.tcCategories.Controls.Add(this.tbComputerCertificates);
      this.tcCategories.Controls.Add(this.tpFirewall);
      this.tcCategories.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcCategories.Location = new System.Drawing.Point(0, 0);
      this.tcCategories.Name = "tcCategories";
      this.tcCategories.SelectedIndex = 0;
      this.tcCategories.Size = new System.Drawing.Size(1111, 411);
      this.tcCategories.TabIndex = 0;
      // 
      // tpServices
      // 
      this.tpServices.Controls.Add(this.dgvServices);
      this.tpServices.Controls.Add(this.pServiceControls);
      this.tpServices.Location = new System.Drawing.Point(4, 22);
      this.tpServices.Name = "tpServices";
      this.tpServices.Padding = new System.Windows.Forms.Padding(3);
      this.tpServices.Size = new System.Drawing.Size(1103, 385);
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
      this.dgvServices.Size = new System.Drawing.Size(897, 379);
      this.dgvServices.TabIndex = 1;
      this.dgvServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellDoubleClick);
      this.dgvServices.SelectionChanged += new System.EventHandler(this.dgvServices_SelectionChanged);
      this.dgvServices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServices_KeyDown);
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
      // pServiceControls
      // 
      this.pServiceControls.AutoScroll = true;
      this.pServiceControls.Controls.Add(this.btServicesRefresh);
      this.pServiceControls.Dock = System.Windows.Forms.DockStyle.Left;
      this.pServiceControls.Location = new System.Drawing.Point(3, 3);
      this.pServiceControls.Name = "pServiceControls";
      this.pServiceControls.Size = new System.Drawing.Size(200, 379);
      this.pServiceControls.TabIndex = 0;
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
      // tpEvents
      // 
      this.tpEvents.Controls.Add(this.splitContainer1);
      this.tpEvents.Controls.Add(this.pEventControls);
      this.tpEvents.Location = new System.Drawing.Point(4, 22);
      this.tpEvents.Name = "tpEvents";
      this.tpEvents.Padding = new System.Windows.Forms.Padding(3);
      this.tpEvents.Size = new System.Drawing.Size(1103, 385);
      this.tpEvents.TabIndex = 1;
      this.tpEvents.Text = "Events";
      this.tpEvents.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(203, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.dgvEventsMain);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tvEventDetails);
      this.splitContainer1.Size = new System.Drawing.Size(897, 379);
      this.splitContainer1.SplitterDistance = 403;
      this.splitContainer1.TabIndex = 2;
      // 
      // dgvEventsMain
      // 
      this.dgvEventsMain.AllowUserToAddRows = false;
      this.dgvEventsMain.AllowUserToDeleteRows = false;
      this.dgvEventsMain.AllowUserToOrderColumns = true;
      this.dgvEventsMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvEventsMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLevel,
            this.cLogged,
            this.cSource,
            this.cEventId,
            this.cTaskCategory});
      this.dgvEventsMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvEventsMain.Location = new System.Drawing.Point(0, 0);
      this.dgvEventsMain.Name = "dgvEventsMain";
      this.dgvEventsMain.ReadOnly = true;
      this.dgvEventsMain.RowHeadersVisible = false;
      this.dgvEventsMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvEventsMain.Size = new System.Drawing.Size(403, 379);
      this.dgvEventsMain.TabIndex = 0;
      this.dgvEventsMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvEventsMain_RowPrePaint);
      // 
      // cLevel
      // 
      this.cLevel.DataPropertyName = "Level";
      this.cLevel.HeaderText = "Level";
      this.cLevel.Name = "cLevel";
      this.cLevel.ReadOnly = true;
      // 
      // cLogged
      // 
      this.cLogged.DataPropertyName = "Logged";
      this.cLogged.HeaderText = "Date and Time";
      this.cLogged.Name = "cLogged";
      this.cLogged.ReadOnly = true;
      // 
      // cSource
      // 
      this.cSource.DataPropertyName = "Source";
      this.cSource.HeaderText = "Source";
      this.cSource.Name = "cSource";
      this.cSource.ReadOnly = true;
      // 
      // cEventId
      // 
      this.cEventId.DataPropertyName = "EventId";
      this.cEventId.HeaderText = "Event ID";
      this.cEventId.Name = "cEventId";
      this.cEventId.ReadOnly = true;
      // 
      // cTaskCategory
      // 
      this.cTaskCategory.DataPropertyName = "TaskCategory";
      this.cTaskCategory.HeaderText = "Task Category";
      this.cTaskCategory.Name = "cTaskCategory";
      this.cTaskCategory.ReadOnly = true;
      // 
      // tvEventDetails
      // 
      this.tvEventDetails.Controls.Add(this.tpEventGeneral);
      this.tvEventDetails.Controls.Add(this.tpDetails);
      this.tvEventDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvEventDetails.Location = new System.Drawing.Point(0, 0);
      this.tvEventDetails.Name = "tvEventDetails";
      this.tvEventDetails.SelectedIndex = 0;
      this.tvEventDetails.Size = new System.Drawing.Size(490, 379);
      this.tvEventDetails.TabIndex = 0;
      // 
      // tpEventGeneral
      // 
      this.tpEventGeneral.Controls.Add(this.tbEventText);
      this.tpEventGeneral.Controls.Add(this.panel2);
      this.tpEventGeneral.Location = new System.Drawing.Point(4, 22);
      this.tpEventGeneral.Name = "tpEventGeneral";
      this.tpEventGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tpEventGeneral.Size = new System.Drawing.Size(482, 353);
      this.tpEventGeneral.TabIndex = 0;
      this.tpEventGeneral.Text = "General";
      this.tpEventGeneral.UseVisualStyleBackColor = true;
      // 
      // tbEventText
      // 
      this.tbEventText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbEventText.Location = new System.Drawing.Point(3, 3);
      this.tbEventText.Name = "tbEventText";
      this.tbEventText.ReadOnly = true;
      this.tbEventText.Size = new System.Drawing.Size(476, 210);
      this.tbEventText.TabIndex = 1;
      this.tbEventText.Text = "";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.tbEventLevel);
      this.panel2.Controls.Add(this.tbEventUser);
      this.panel2.Controls.Add(this.tbEventLogName);
      this.panel2.Controls.Add(this.tbEventComputer);
      this.panel2.Controls.Add(this.tbEventKeywords);
      this.panel2.Controls.Add(this.tbEventEventCatrgory);
      this.panel2.Controls.Add(this.tbEventLogged);
      this.panel2.Controls.Add(this.tbEventEventId);
      this.panel2.Controls.Add(this.tbEventSource);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.label10);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(3, 213);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(476, 137);
      this.panel2.TabIndex = 0;
      // 
      // tbEventLevel
      // 
      this.tbEventLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventLevel.Location = new System.Drawing.Point(68, 83);
      this.tbEventLevel.Name = "tbEventLevel";
      this.tbEventLevel.ReadOnly = true;
      this.tbEventLevel.Size = new System.Drawing.Size(169, 13);
      this.tbEventLevel.TabIndex = 17;
      // 
      // tbEventUser
      // 
      this.tbEventUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventUser.Location = new System.Drawing.Point(68, 109);
      this.tbEventUser.Name = "tbEventUser";
      this.tbEventUser.ReadOnly = true;
      this.tbEventUser.Size = new System.Drawing.Size(169, 13);
      this.tbEventUser.TabIndex = 16;
      // 
      // tbEventLogName
      // 
      this.tbEventLogName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventLogName.Location = new System.Drawing.Point(68, 5);
      this.tbEventLogName.Name = "tbEventLogName";
      this.tbEventLogName.ReadOnly = true;
      this.tbEventLogName.Size = new System.Drawing.Size(169, 13);
      this.tbEventLogName.TabIndex = 15;
      // 
      // tbEventComputer
      // 
      this.tbEventComputer.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventComputer.Location = new System.Drawing.Point(328, 83);
      this.tbEventComputer.Name = "tbEventComputer";
      this.tbEventComputer.ReadOnly = true;
      this.tbEventComputer.Size = new System.Drawing.Size(169, 13);
      this.tbEventComputer.TabIndex = 14;
      // 
      // tbEventKeywords
      // 
      this.tbEventKeywords.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventKeywords.Location = new System.Drawing.Point(328, 57);
      this.tbEventKeywords.Name = "tbEventKeywords";
      this.tbEventKeywords.ReadOnly = true;
      this.tbEventKeywords.Size = new System.Drawing.Size(169, 13);
      this.tbEventKeywords.TabIndex = 13;
      // 
      // tbEventEventCatrgory
      // 
      this.tbEventEventCatrgory.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventEventCatrgory.Location = new System.Drawing.Point(328, 31);
      this.tbEventEventCatrgory.Name = "tbEventEventCatrgory";
      this.tbEventEventCatrgory.ReadOnly = true;
      this.tbEventEventCatrgory.Size = new System.Drawing.Size(169, 13);
      this.tbEventEventCatrgory.TabIndex = 12;
      // 
      // tbEventLogged
      // 
      this.tbEventLogged.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventLogged.Location = new System.Drawing.Point(328, 5);
      this.tbEventLogged.Name = "tbEventLogged";
      this.tbEventLogged.ReadOnly = true;
      this.tbEventLogged.Size = new System.Drawing.Size(169, 13);
      this.tbEventLogged.TabIndex = 11;
      // 
      // tbEventEventId
      // 
      this.tbEventEventId.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventEventId.Location = new System.Drawing.Point(68, 57);
      this.tbEventEventId.Name = "tbEventEventId";
      this.tbEventEventId.ReadOnly = true;
      this.tbEventEventId.Size = new System.Drawing.Size(169, 13);
      this.tbEventEventId.TabIndex = 10;
      // 
      // tbEventSource
      // 
      this.tbEventSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbEventSource.Location = new System.Drawing.Point(68, 31);
      this.tbEventSource.Name = "tbEventSource";
      this.tbEventSource.ReadOnly = true;
      this.tbEventSource.Size = new System.Drawing.Size(169, 13);
      this.tbEventSource.TabIndex = 9;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(3, 109);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(32, 13);
      this.label11.TabIndex = 8;
      this.label11.Text = "User:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(243, 57);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(56, 13);
      this.label10.TabIndex = 7;
      this.label10.Text = "Keywords:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(243, 83);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(55, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Computer:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(243, 35);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(79, 13);
      this.label8.TabIndex = 5;
      this.label8.Text = "Task Category:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(243, 5);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(46, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "Logged:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(3, 83);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(36, 13);
      this.label6.TabIndex = 3;
      this.label6.Text = "Level:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 57);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(52, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Event ID:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 31);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(44, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Source:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 5);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Log Name:";
      // 
      // tpDetails
      // 
      this.tpDetails.Controls.Add(this.wbEventXML);
      this.tpDetails.Location = new System.Drawing.Point(4, 22);
      this.tpDetails.Name = "tpDetails";
      this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
      this.tpDetails.Size = new System.Drawing.Size(482, 353);
      this.tpDetails.TabIndex = 1;
      this.tpDetails.Text = "Details";
      this.tpDetails.UseVisualStyleBackColor = true;
      // 
      // wbEventXML
      // 
      this.wbEventXML.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wbEventXML.Location = new System.Drawing.Point(3, 3);
      this.wbEventXML.MinimumSize = new System.Drawing.Size(20, 20);
      this.wbEventXML.Name = "wbEventXML";
      this.wbEventXML.Size = new System.Drawing.Size(476, 347);
      this.wbEventXML.TabIndex = 0;
      // 
      // pEventControls
      // 
      this.pEventControls.AutoScroll = true;
      this.pEventControls.Controls.Add(this.tbMaxEvents);
      this.pEventControls.Controls.Add(this.label17);
      this.pEventControls.Controls.Add(this.label16);
      this.pEventControls.Controls.Add(this.label15);
      this.pEventControls.Controls.Add(this.label14);
      this.pEventControls.Controls.Add(this.btEventMakeXPathQuery);
      this.pEventControls.Controls.Add(this.cbEventSelectLog);
      this.pEventControls.Controls.Add(this.tbEventXPathQuery);
      this.pEventControls.Controls.Add(this.tbMaxSearchEvents);
      this.pEventControls.Controls.Add(this.cbEventSearchRegExp);
      this.pEventControls.Controls.Add(this.tbEventSearchExpression);
      this.pEventControls.Controls.Add(this.label12);
      this.pEventControls.Controls.Add(this.rbEventFilter);
      this.pEventControls.Controls.Add(this.btEventsRefresh);
      this.pEventControls.Controls.Add(this.rbSearch);
      this.pEventControls.Controls.Add(this.label1);
      this.pEventControls.Controls.Add(this.rbLastEvents);
      this.pEventControls.Controls.Add(this.label2);
      this.pEventControls.Controls.Add(this.btBrowseLogs);
      this.pEventControls.Dock = System.Windows.Forms.DockStyle.Left;
      this.pEventControls.Location = new System.Drawing.Point(3, 3);
      this.pEventControls.Name = "pEventControls";
      this.pEventControls.Size = new System.Drawing.Size(200, 379);
      this.pEventControls.TabIndex = 1;
      // 
      // tbMaxEvents
      // 
      this.tbMaxEvents.Location = new System.Drawing.Point(3, 336);
      this.tbMaxEvents.Name = "tbMaxEvents";
      this.tbMaxEvents.Size = new System.Drawing.Size(80, 20);
      this.tbMaxEvents.TabIndex = 1;
      this.tbMaxEvents.Text = "100";
      this.tbMaxEvents.TextChanged += new System.EventHandler(this.tbMaxEvents_TextChanged);
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.Location = new System.Drawing.Point(3, 307);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(54, 13);
      this.label17.TabIndex = 18;
      this.label17.Text = "Options:";
      // 
      // label16
      // 
      this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label16.Location = new System.Drawing.Point(3, 174);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(191, 2);
      this.label16.TabIndex = 17;
      // 
      // label15
      // 
      this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label15.Location = new System.Drawing.Point(3, 104);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(191, 2);
      this.label15.TabIndex = 16;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(3, 68);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(86, 13);
      this.label14.TabIndex = 15;
      this.label14.Text = "Search Mode:";
      // 
      // btEventMakeXPathQuery
      // 
      this.btEventMakeXPathQuery.Location = new System.Drawing.Point(3, 281);
      this.btEventMakeXPathQuery.Name = "btEventMakeXPathQuery";
      this.btEventMakeXPathQuery.Size = new System.Drawing.Size(191, 23);
      this.btEventMakeXPathQuery.TabIndex = 12;
      this.btEventMakeXPathQuery.Text = "Construct Query";
      this.btEventMakeXPathQuery.UseVisualStyleBackColor = true;
      this.btEventMakeXPathQuery.Click += new System.EventHandler(this.btEventMakeXPathQuery_Click);
      // 
      // cbEventSelectLog
      // 
      this.cbEventSelectLog.FormattingEnabled = true;
      this.cbEventSelectLog.Location = new System.Drawing.Point(3, 44);
      this.cbEventSelectLog.Name = "cbEventSelectLog";
      this.cbEventSelectLog.Size = new System.Drawing.Size(159, 21);
      this.cbEventSelectLog.TabIndex = 6;
      // 
      // tbEventXPathQuery
      // 
      this.tbEventXPathQuery.Location = new System.Drawing.Point(3, 202);
      this.tbEventXPathQuery.Multiline = true;
      this.tbEventXPathQuery.Name = "tbEventXPathQuery";
      this.tbEventXPathQuery.Size = new System.Drawing.Size(191, 73);
      this.tbEventXPathQuery.TabIndex = 11;
      this.tbEventXPathQuery.TextChanged += new System.EventHandler(this.tbEventXPathQuery_TextChanged);
      // 
      // tbMaxSearchEvents
      // 
      this.tbMaxSearchEvents.Location = new System.Drawing.Point(89, 336);
      this.tbMaxSearchEvents.Name = "tbMaxSearchEvents";
      this.tbMaxSearchEvents.Size = new System.Drawing.Size(80, 20);
      this.tbMaxSearchEvents.TabIndex = 13;
      this.tbMaxSearchEvents.Text = "1000";
      this.tbMaxSearchEvents.TextChanged += new System.EventHandler(this.tbMaxSearchEvents_TextChanged);
      // 
      // cbEventSearchRegExp
      // 
      this.cbEventSearchRegExp.AutoSize = true;
      this.cbEventSearchRegExp.Location = new System.Drawing.Point(3, 154);
      this.cbEventSearchRegExp.Name = "cbEventSearchRegExp";
      this.cbEventSearchRegExp.Size = new System.Drawing.Size(86, 17);
      this.cbEventSearchRegExp.TabIndex = 10;
      this.cbEventSearchRegExp.Text = "Use RegExp";
      this.cbEventSearchRegExp.UseVisualStyleBackColor = true;
      // 
      // tbEventSearchExpression
      // 
      this.tbEventSearchExpression.Location = new System.Drawing.Point(0, 132);
      this.tbEventSearchExpression.Name = "tbEventSearchExpression";
      this.tbEventSearchExpression.Size = new System.Drawing.Size(194, 20);
      this.tbEventSearchExpression.TabIndex = 9;
      this.tbEventSearchExpression.TextChanged += new System.EventHandler(this.tbEventSearchExpression_TextChanged);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(86, 320);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(65, 13);
      this.label12.TabIndex = 14;
      this.label12.Text = "Max search:";
      // 
      // rbEventFilter
      // 
      this.rbEventFilter.AutoSize = true;
      this.rbEventFilter.Location = new System.Drawing.Point(3, 179);
      this.rbEventFilter.Name = "rbEventFilter";
      this.rbEventFilter.Size = new System.Drawing.Size(128, 17);
      this.rbEventFilter.TabIndex = 4;
      this.rbEventFilter.Text = "Filtered (XPath Query)";
      this.rbEventFilter.UseVisualStyleBackColor = true;
      // 
      // btEventsRefresh
      // 
      this.btEventsRefresh.Location = new System.Drawing.Point(3, 3);
      this.btEventsRefresh.Name = "btEventsRefresh";
      this.btEventsRefresh.Size = new System.Drawing.Size(191, 23);
      this.btEventsRefresh.TabIndex = 0;
      this.btEventsRefresh.Text = "Load / Refresh";
      this.btEventsRefresh.UseVisualStyleBackColor = true;
      this.btEventsRefresh.Click += new System.EventHandler(this.btEventsRefresh_Click);
      // 
      // rbSearch
      // 
      this.rbSearch.AutoSize = true;
      this.rbSearch.Location = new System.Drawing.Point(3, 109);
      this.rbSearch.Name = "rbSearch";
      this.rbSearch.Size = new System.Drawing.Size(59, 17);
      this.rbSearch.TabIndex = 3;
      this.rbSearch.Text = "Search";
      this.rbSearch.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 320);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Max return:";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // rbLastEvents
      // 
      this.rbLastEvents.AutoSize = true;
      this.rbLastEvents.Checked = true;
      this.rbLastEvents.Location = new System.Drawing.Point(3, 84);
      this.rbLastEvents.Name = "rbLastEvents";
      this.rbLastEvents.Size = new System.Drawing.Size(80, 17);
      this.rbLastEvents.TabIndex = 2;
      this.rbLastEvents.TabStop = true;
      this.rbLastEvents.Text = "Last events";
      this.rbLastEvents.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(57, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Select log:";
      // 
      // btBrowseLogs
      // 
      this.btBrowseLogs.Location = new System.Drawing.Point(168, 44);
      this.btBrowseLogs.Name = "btBrowseLogs";
      this.btBrowseLogs.Size = new System.Drawing.Size(26, 23);
      this.btBrowseLogs.TabIndex = 7;
      this.btBrowseLogs.Text = "...";
      this.btBrowseLogs.UseVisualStyleBackColor = true;
      this.btBrowseLogs.Click += new System.EventHandler(this.btBrowseLogs_Click);
      // 
      // tpRegistry
      // 
      this.tpRegistry.Controls.Add(this.lvRegItems);
      this.tpRegistry.Controls.Add(this.pRegistryControls);
      this.tpRegistry.Location = new System.Drawing.Point(4, 22);
      this.tpRegistry.Name = "tpRegistry";
      this.tpRegistry.Padding = new System.Windows.Forms.Padding(3);
      this.tpRegistry.Size = new System.Drawing.Size(1103, 385);
      this.tpRegistry.TabIndex = 2;
      this.tpRegistry.Text = "Registry";
      this.tpRegistry.UseVisualStyleBackColor = true;
      // 
      // lvRegItems
      // 
      this.lvRegItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRegName,
            this.chRegType,
            this.chRegData});
      this.lvRegItems.ContextMenuStrip = this.cmRegEditMenu;
      this.lvRegItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvRegItems.FullRowSelect = true;
      this.lvRegItems.HideSelection = false;
      this.lvRegItems.Location = new System.Drawing.Point(3, 50);
      this.lvRegItems.MultiSelect = false;
      this.lvRegItems.Name = "lvRegItems";
      this.lvRegItems.Size = new System.Drawing.Size(1097, 332);
      this.lvRegItems.SmallImageList = this.ilRegIcons;
      this.lvRegItems.TabIndex = 1;
      this.lvRegItems.UseCompatibleStateImageBehavior = false;
      this.lvRegItems.View = System.Windows.Forms.View.Details;
      this.lvRegItems.DoubleClick += new System.EventHandler(this.lvRegItems_DoubleClick);
      // 
      // chRegName
      // 
      this.chRegName.Text = "Name";
      this.chRegName.Width = 165;
      // 
      // chRegType
      // 
      this.chRegType.Text = "Type";
      this.chRegType.Width = 93;
      // 
      // chRegData
      // 
      this.chRegData.Text = "Data";
      this.chRegData.Width = 650;
      // 
      // cmRegEditMenu
      // 
      this.cmRegEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripSeparator2,
            this.newToolStripMenuItem});
      this.cmRegEditMenu.Name = "contextMenuStrip1";
      this.cmRegEditMenu.Size = new System.Drawing.Size(118, 104);
      this.cmRegEditMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmRegEditMenu_Opening);
      // 
      // modifyToolStripMenuItem
      // 
      this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
      this.modifyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.modifyToolStripMenuItem.Text = "Modify";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // renameToolStripMenuItem
      // 
      this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
      this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.renameToolStripMenuItem.Text = "Rename";
      this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyToolStripMenuItem,
            this.toolStripSeparator3,
            this.stringToolStripMenuItem,
            this.binaryToolStripMenuItem,
            this.dWORDToolStripMenuItem,
            this.qWORDToolStripMenuItem,
            this.multiStringValueToolStripMenuItem,
            this.expandableStringValueToolStripMenuItem});
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.newToolStripMenuItem.Text = "New";
      // 
      // keyToolStripMenuItem
      // 
      this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
      this.keyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.keyToolStripMenuItem.Text = "Key";
      this.keyToolStripMenuItem.Click += new System.EventHandler(this.keyToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
      // 
      // stringToolStripMenuItem
      // 
      this.stringToolStripMenuItem.Name = "stringToolStripMenuItem";
      this.stringToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.stringToolStripMenuItem.Text = "String Value";
      this.stringToolStripMenuItem.Click += new System.EventHandler(this.stringToolStripMenuItem_Click);
      // 
      // binaryToolStripMenuItem
      // 
      this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
      this.binaryToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.binaryToolStripMenuItem.Text = "Binary Value";
      // 
      // dWORDToolStripMenuItem
      // 
      this.dWORDToolStripMenuItem.Name = "dWORDToolStripMenuItem";
      this.dWORDToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.dWORDToolStripMenuItem.Text = "DWORD Value";
      // 
      // qWORDToolStripMenuItem
      // 
      this.qWORDToolStripMenuItem.Name = "qWORDToolStripMenuItem";
      this.qWORDToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.qWORDToolStripMenuItem.Text = "QWORD Value";
      // 
      // multiStringValueToolStripMenuItem
      // 
      this.multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
      this.multiStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.multiStringValueToolStripMenuItem.Text = "Multi-String Value";
      // 
      // expandableStringValueToolStripMenuItem
      // 
      this.expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
      this.expandableStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
      this.expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
      // 
      // ilRegIcons
      // 
      this.ilRegIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilRegIcons.ImageStream")));
      this.ilRegIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.ilRegIcons.Images.SetKeyName(0, "RegKey.gif");
      this.ilRegIcons.Images.SetKeyName(1, "RegStrValue.gif");
      this.ilRegIcons.Images.SetKeyName(2, "RegBinValue.gif");
      // 
      // pRegistryControls
      // 
      this.pRegistryControls.AutoScroll = true;
      this.pRegistryControls.Controls.Add(this.btRegGo);
      this.pRegistryControls.Controls.Add(this.tbRegPath);
      this.pRegistryControls.Controls.Add(this.label18);
      this.pRegistryControls.Controls.Add(this.cbRegRootKey);
      this.pRegistryControls.Controls.Add(this.label13);
      this.pRegistryControls.Dock = System.Windows.Forms.DockStyle.Top;
      this.pRegistryControls.Location = new System.Drawing.Point(3, 3);
      this.pRegistryControls.Name = "pRegistryControls";
      this.pRegistryControls.Size = new System.Drawing.Size(1097, 47);
      this.pRegistryControls.TabIndex = 0;
      this.pRegistryControls.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // btRegGo
      // 
      this.btRegGo.Location = new System.Drawing.Point(718, 14);
      this.btRegGo.Name = "btRegGo";
      this.btRegGo.Size = new System.Drawing.Size(75, 23);
      this.btRegGo.TabIndex = 4;
      this.btRegGo.Text = "Go";
      this.btRegGo.UseVisualStyleBackColor = true;
      this.btRegGo.Click += new System.EventHandler(this.btRegGo_Click);
      // 
      // tbRegPath
      // 
      this.tbRegPath.Location = new System.Drawing.Point(204, 16);
      this.tbRegPath.Name = "tbRegPath";
      this.tbRegPath.Size = new System.Drawing.Size(508, 20);
      this.tbRegPath.TabIndex = 3;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(201, 0);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(32, 13);
      this.label18.TabIndex = 2;
      this.label18.Text = "Path:";
      this.label18.Click += new System.EventHandler(this.label18_Click);
      // 
      // cbRegRootKey
      // 
      this.cbRegRootKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRegRootKey.Items.AddRange(new object[] {
            "HKEY_CLASSES_ROOT",
            "HKEY_LOCAL_MACHINE",
            "HKEY_USERS",
            "HKEY_CURRENT_CONFIG"});
      this.cbRegRootKey.Location = new System.Drawing.Point(6, 16);
      this.cbRegRootKey.Name = "cbRegRootKey";
      this.cbRegRootKey.Size = new System.Drawing.Size(192, 21);
      this.cbRegRootKey.TabIndex = 1;
      this.cbRegRootKey.SelectionChangeCommitted += new System.EventHandler(this.cbRegRootKey_SelectionChangeCommitted);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(3, 0);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(53, 13);
      this.label13.TabIndex = 0;
      this.label13.Text = "Root key:";
      // 
      // tpPerformance
      // 
      this.tpPerformance.Location = new System.Drawing.Point(4, 22);
      this.tpPerformance.Name = "tpPerformance";
      this.tpPerformance.Padding = new System.Windows.Forms.Padding(3);
      this.tpPerformance.Size = new System.Drawing.Size(1103, 385);
      this.tpPerformance.TabIndex = 3;
      this.tpPerformance.Text = "Performance";
      this.tpPerformance.UseVisualStyleBackColor = true;
      // 
      // tpSystemInfo
      // 
      this.tpSystemInfo.Location = new System.Drawing.Point(4, 22);
      this.tpSystemInfo.Name = "tpSystemInfo";
      this.tpSystemInfo.Padding = new System.Windows.Forms.Padding(3);
      this.tpSystemInfo.Size = new System.Drawing.Size(1103, 385);
      this.tpSystemInfo.TabIndex = 4;
      this.tpSystemInfo.Text = "System Information";
      this.tpSystemInfo.UseVisualStyleBackColor = true;
      // 
      // tpStorage
      // 
      this.tpStorage.Location = new System.Drawing.Point(4, 22);
      this.tpStorage.Name = "tpStorage";
      this.tpStorage.Padding = new System.Windows.Forms.Padding(3);
      this.tpStorage.Size = new System.Drawing.Size(1103, 385);
      this.tpStorage.TabIndex = 5;
      this.tpStorage.Text = "Storage";
      this.tpStorage.UseVisualStyleBackColor = true;
      // 
      // tpPtocesses
      // 
      this.tpPtocesses.Location = new System.Drawing.Point(4, 22);
      this.tpPtocesses.Name = "tpPtocesses";
      this.tpPtocesses.Padding = new System.Windows.Forms.Padding(3);
      this.tpPtocesses.Size = new System.Drawing.Size(1103, 385);
      this.tpPtocesses.TabIndex = 6;
      this.tpPtocesses.Text = "Processes";
      this.tpPtocesses.UseVisualStyleBackColor = true;
      // 
      // tpShares
      // 
      this.tpShares.Location = new System.Drawing.Point(4, 22);
      this.tpShares.Name = "tpShares";
      this.tpShares.Padding = new System.Windows.Forms.Padding(3);
      this.tpShares.Size = new System.Drawing.Size(1103, 385);
      this.tpShares.TabIndex = 7;
      this.tpShares.Text = "Shared Folders";
      this.tpShares.UseVisualStyleBackColor = true;
      // 
      // tpLocalUsers
      // 
      this.tpLocalUsers.Location = new System.Drawing.Point(4, 22);
      this.tpLocalUsers.Name = "tpLocalUsers";
      this.tpLocalUsers.Padding = new System.Windows.Forms.Padding(3);
      this.tpLocalUsers.Size = new System.Drawing.Size(1103, 385);
      this.tpLocalUsers.TabIndex = 8;
      this.tpLocalUsers.Text = "Local Users and Groups";
      this.tpLocalUsers.UseVisualStyleBackColor = true;
      // 
      // tbComputerCertificates
      // 
      this.tbComputerCertificates.Location = new System.Drawing.Point(4, 22);
      this.tbComputerCertificates.Name = "tbComputerCertificates";
      this.tbComputerCertificates.Padding = new System.Windows.Forms.Padding(3);
      this.tbComputerCertificates.Size = new System.Drawing.Size(1103, 385);
      this.tbComputerCertificates.TabIndex = 9;
      this.tbComputerCertificates.Text = "Computer Certificates";
      this.tbComputerCertificates.UseVisualStyleBackColor = true;
      // 
      // tpFirewall
      // 
      this.tpFirewall.Location = new System.Drawing.Point(4, 22);
      this.tpFirewall.Name = "tpFirewall";
      this.tpFirewall.Padding = new System.Windows.Forms.Padding(3);
      this.tpFirewall.Size = new System.Drawing.Size(1103, 385);
      this.tpFirewall.TabIndex = 10;
      this.tpFirewall.Text = "Firewall";
      this.tpFirewall.UseVisualStyleBackColor = true;
      // 
      // lCurrentTasks
      // 
      this.lCurrentTasks.AutoSize = true;
      this.lCurrentTasks.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lCurrentTasks.Location = new System.Drawing.Point(0, 398);
      this.lCurrentTasks.Name = "lCurrentTasks";
      this.lCurrentTasks.Size = new System.Drawing.Size(0, 13);
      this.lCurrentTasks.TabIndex = 1;
      // 
      // TasksTabView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lCurrentTasks);
      this.Controls.Add(this.tcCategories);
      this.Name = "TasksTabView";
      this.Size = new System.Drawing.Size(1111, 411);
      this.tcCategories.ResumeLayout(false);
      this.tpServices.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
      this.pServiceControls.ResumeLayout(false);
      this.tpEvents.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvEventsMain)).EndInit();
      this.tvEventDetails.ResumeLayout(false);
      this.tpEventGeneral.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tpDetails.ResumeLayout(false);
      this.pEventControls.ResumeLayout(false);
      this.pEventControls.PerformLayout();
      this.tpRegistry.ResumeLayout(false);
      this.cmRegEditMenu.ResumeLayout(false);
      this.pRegistryControls.ResumeLayout(false);
      this.pRegistryControls.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tcCategories;
    private System.Windows.Forms.TabPage tpServices;
    private System.Windows.Forms.TabPage tpEvents;
    private System.Windows.Forms.TabPage tpRegistry;
    private System.Windows.Forms.DataGridView dgvServices;
    private System.Windows.Forms.Panel pServiceControls;
    private System.Windows.Forms.Button btServicesRefresh;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceDisplayName;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceStart;
    private System.Windows.Forms.DataGridViewCheckBoxColumn cServiceIsTriggered;
    private System.Windows.Forms.DataGridViewCheckBoxColumn cServiceIsDelayed;
    private System.Windows.Forms.DataGridViewTextBoxColumn cServiceObjectName;
    private System.Windows.Forms.Panel pEventControls;
    private System.Windows.Forms.Button btEventsRefresh;
    private System.Windows.Forms.TabPage tpPerformance;
    private System.Windows.Forms.TabPage tpSystemInfo;
    private System.Windows.Forms.TabPage tpStorage;
    private System.Windows.Forms.TabPage tpPtocesses;
    private System.Windows.Forms.TabPage tpShares;
    private System.Windows.Forms.TabPage tpLocalUsers;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView dgvEventsMain;
    private System.Windows.Forms.TabControl tvEventDetails;
    private System.Windows.Forms.TabPage tpEventGeneral;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox tbEventLevel;
    private System.Windows.Forms.TextBox tbEventUser;
    private System.Windows.Forms.TextBox tbEventLogName;
    private System.Windows.Forms.TextBox tbEventComputer;
    private System.Windows.Forms.TextBox tbEventKeywords;
    private System.Windows.Forms.TextBox tbEventEventCatrgory;
    private System.Windows.Forms.TextBox tbEventLogged;
    private System.Windows.Forms.TextBox tbEventEventId;
    private System.Windows.Forms.TextBox tbEventSource;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TabPage tpDetails;
    private System.Windows.Forms.WebBrowser wbEventXML;
    private System.Windows.Forms.Button btEventMakeXPathQuery;
    private System.Windows.Forms.TextBox tbEventXPathQuery;
    private System.Windows.Forms.CheckBox cbEventSearchRegExp;
    private System.Windows.Forms.TextBox tbEventSearchExpression;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btBrowseLogs;
    private System.Windows.Forms.ComboBox cbEventSelectLog;
    private System.Windows.Forms.RadioButton rbEventFilter;
    private System.Windows.Forms.RadioButton rbSearch;
    private System.Windows.Forms.RadioButton rbLastEvents;
    private System.Windows.Forms.TextBox tbMaxEvents;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridViewTextBoxColumn cLevel;
    private System.Windows.Forms.DataGridViewTextBoxColumn cLogged;
    private System.Windows.Forms.DataGridViewTextBoxColumn cSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn cEventId;
    private System.Windows.Forms.DataGridViewTextBoxColumn cTaskCategory;
    private System.Windows.Forms.RichTextBox tbEventText;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox tbMaxSearchEvents;
    private System.Windows.Forms.Label lCurrentTasks;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Panel pRegistryControls;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.ComboBox cbRegRootKey;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.ListView lvRegItems;
    private System.Windows.Forms.Button btRegGo;
    private System.Windows.Forms.TextBox tbRegPath;
    private System.Windows.Forms.ColumnHeader chRegName;
    private System.Windows.Forms.ColumnHeader chRegType;
    private System.Windows.Forms.ColumnHeader chRegData;
    private System.Windows.Forms.ImageList ilRegIcons;
    private System.Windows.Forms.ContextMenuStrip cmRegEditMenu;
    private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem stringToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dWORDToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem qWORDToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem;
    private System.Windows.Forms.TabPage tbComputerCertificates;
    private System.Windows.Forms.TabPage tpFirewall;
  }
}
