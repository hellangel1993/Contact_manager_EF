namespace Contact_manager_EF
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageState = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddressbook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenuHorx = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenuCascading = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManage,
            this.mnuAddressbook,
            this.mnuMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuManage
            // 
            this.mnuManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManageCountry,
            this.mnuManageUser,
            this.mnuManageState,
            this.mnuManageExit});
            this.mnuManage.Name = "mnuManage";
            this.mnuManage.Size = new System.Drawing.Size(62, 20);
            this.mnuManage.Text = "&Manage";
            // 
            // mnuManageCountry
            // 
            this.mnuManageCountry.Name = "mnuManageCountry";
            this.mnuManageCountry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuManageCountry.Size = new System.Drawing.Size(180, 22);
            this.mnuManageCountry.Text = "&Country";
            this.mnuManageCountry.Click += new System.EventHandler(this.mnuManageCountry_Click);
            // 
            // mnuManageUser
            // 
            this.mnuManageUser.Name = "mnuManageUser";
            this.mnuManageUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mnuManageUser.Size = new System.Drawing.Size(180, 22);
            this.mnuManageUser.Text = "&User";
            this.mnuManageUser.Click += new System.EventHandler(this.mnuManageUser_Click);
            // 
            // mnuManageState
            // 
            this.mnuManageState.Name = "mnuManageState";
            this.mnuManageState.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuManageState.Size = new System.Drawing.Size(180, 22);
            this.mnuManageState.Text = "&State";
            this.mnuManageState.Click += new System.EventHandler(this.mnuManageState_Click);
            // 
            // mnuManageExit
            // 
            this.mnuManageExit.Name = "mnuManageExit";
            this.mnuManageExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuManageExit.Size = new System.Drawing.Size(180, 22);
            this.mnuManageExit.Text = "&Exit";
            this.mnuManageExit.Click += new System.EventHandler(this.mnuManageExit_Click);
            // 
            // mnuAddressbook
            // 
            this.mnuAddressbook.Name = "mnuAddressbook";
            this.mnuAddressbook.Size = new System.Drawing.Size(91, 20);
            this.mnuAddressbook.Text = "&Address Book";
            this.mnuAddressbook.Click += new System.EventHandler(this.mnuAddressbook_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMenuHorx,
            this.mnuVertex,
            this.mnuMenuCascading});
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(50, 20);
            this.mnuMenu.Text = "&Menu";
            // 
            // mnuMenuHorx
            // 
            this.mnuMenuHorx.Name = "mnuMenuHorx";
            this.mnuMenuHorx.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuMenuHorx.Size = new System.Drawing.Size(180, 22);
            this.mnuMenuHorx.Text = "&Title Horx";
            this.mnuMenuHorx.Click += new System.EventHandler(this.mnuMenuHorx_Click);
            // 
            // mnuVertex
            // 
            this.mnuVertex.Name = "mnuVertex";
            this.mnuVertex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuVertex.Size = new System.Drawing.Size(180, 22);
            this.mnuVertex.Text = "&Title Vertex";
            this.mnuVertex.Click += new System.EventHandler(this.mnuVertex_Click);
            // 
            // mnuMenuCascading
            // 
            this.mnuMenuCascading.Name = "mnuMenuCascading";
            this.mnuMenuCascading.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuMenuCascading.Size = new System.Drawing.Size(180, 22);
            this.mnuMenuCascading.Text = "&Cascading";
            this.mnuMenuCascading.Click += new System.EventHandler(this.mnuMenuCascading_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIParent";
            this.Text = "MDIParent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuManage;
        private System.Windows.Forms.ToolStripMenuItem mnuManageCountry;
        private System.Windows.Forms.ToolStripMenuItem mnuManageUser;
        private System.Windows.Forms.ToolStripMenuItem mnuManageState;
        private System.Windows.Forms.ToolStripMenuItem mnuManageExit;
        private System.Windows.Forms.ToolStripMenuItem mnuAddressbook;
        private System.Windows.Forms.ToolStripMenuItem mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMenuHorx;
        private System.Windows.Forms.ToolStripMenuItem mnuVertex;
        private System.Windows.Forms.ToolStripMenuItem mnuMenuCascading;
    }
}