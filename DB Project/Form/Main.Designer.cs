namespace DB_Project
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginPanel_OK = new System.Windows.Forms.Button();
            this.LoginPanel_Password = new System.Windows.Forms.TextBox();
            this.LoginPanel_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FunctionPanel = new System.Windows.Forms.Panel();
            this.FunctionPanel_Hide = new System.Windows.Forms.Button();
            this.FunctionPanel_Stop = new System.Windows.Forms.Button();
            this.FunctionPanel_Record = new System.Windows.Forms.Button();
            this.QueryPanel = new System.Windows.Forms.Panel();
            this.DataList = new System.Windows.Forms.DataGridView();
            this.TableList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.FunctionPanel.SuspendLayout();
            this.QueryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginPanel.Controls.Add(this.LoginPanel_OK);
            this.LoginPanel.Controls.Add(this.LoginPanel_Password);
            this.LoginPanel.Controls.Add(this.LoginPanel_ID);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Location = new System.Drawing.Point(408, 27);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(176, 52);
            this.LoginPanel.TabIndex = 0;
            // 
            // LoginPanel_OK
            // 
            this.LoginPanel_OK.Location = new System.Drawing.Point(141, 26);
            this.LoginPanel_OK.Name = "LoginPanel_OK";
            this.LoginPanel_OK.Size = new System.Drawing.Size(32, 23);
            this.LoginPanel_OK.TabIndex = 2;
            this.LoginPanel_OK.Text = "OK";
            this.LoginPanel_OK.UseVisualStyleBackColor = true;
            this.LoginPanel_OK.Click += new System.EventHandler(this.LoginRequest);
            // 
            // LoginPanel_Password
            // 
            this.LoginPanel_Password.Location = new System.Drawing.Point(78, 28);
            this.LoginPanel_Password.MaxLength = 10;
            this.LoginPanel_Password.Name = "LoginPanel_Password";
            this.LoginPanel_Password.PasswordChar = '*';
            this.LoginPanel_Password.Size = new System.Drawing.Size(61, 21);
            this.LoginPanel_Password.TabIndex = 1;
            this.LoginPanel_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginKeyProcess);
            // 
            // LoginPanel_ID
            // 
            this.LoginPanel_ID.Location = new System.Drawing.Point(78, 3);
            this.LoginPanel_ID.MaxLength = 10;
            this.LoginPanel_ID.Name = "LoginPanel_ID";
            this.LoginPanel_ID.Size = new System.Drawing.Size(61, 21);
            this.LoginPanel_ID.TabIndex = 0;
            this.LoginPanel_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginKeyProcess);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.편집EToolStripMenuItem,
            this.설정ToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // 편집EToolStripMenuItem
            // 
            this.편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            this.편집EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.편집EToolStripMenuItem.Text = "편집(E)";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.설정ToolStripMenuItem.Text = "설정(O)";
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보ToolStripMenuItem});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.정보ToolStripMenuItem.Text = "정보";
            // 
            // FunctionPanel
            // 
            this.FunctionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FunctionPanel.Controls.Add(this.FunctionPanel_Hide);
            this.FunctionPanel.Controls.Add(this.FunctionPanel_Stop);
            this.FunctionPanel.Controls.Add(this.FunctionPanel_Record);
            this.FunctionPanel.Location = new System.Drawing.Point(314, 27);
            this.FunctionPanel.Name = "FunctionPanel";
            this.FunctionPanel.Size = new System.Drawing.Size(88, 30);
            this.FunctionPanel.TabIndex = 2;
            // 
            // FunctionPanel_Hide
            // 
            this.FunctionPanel_Hide.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FunctionPanel_Hide.Location = new System.Drawing.Point(59, 3);
            this.FunctionPanel_Hide.Name = "FunctionPanel_Hide";
            this.FunctionPanel_Hide.Size = new System.Drawing.Size(23, 23);
            this.FunctionPanel_Hide.TabIndex = 5;
            this.FunctionPanel_Hide.Text = "＿";
            this.FunctionPanel_Hide.UseVisualStyleBackColor = true;
            this.FunctionPanel_Hide.Click += new System.EventHandler(this.ProcessBackGround);
            // 
            // FunctionPanel_Stop
            // 
            this.FunctionPanel_Stop.Location = new System.Drawing.Point(31, 3);
            this.FunctionPanel_Stop.Name = "FunctionPanel_Stop";
            this.FunctionPanel_Stop.Size = new System.Drawing.Size(23, 23);
            this.FunctionPanel_Stop.TabIndex = 4;
            this.FunctionPanel_Stop.Text = "■";
            this.FunctionPanel_Stop.UseVisualStyleBackColor = true;
            this.FunctionPanel_Stop.Click += new System.EventHandler(this.RecordingPause);
            // 
            // FunctionPanel_Record
            // 
            this.FunctionPanel_Record.Location = new System.Drawing.Point(3, 3);
            this.FunctionPanel_Record.Name = "FunctionPanel_Record";
            this.FunctionPanel_Record.Size = new System.Drawing.Size(23, 23);
            this.FunctionPanel_Record.TabIndex = 3;
            this.FunctionPanel_Record.Text = "▶";
            this.FunctionPanel_Record.UseVisualStyleBackColor = true;
            this.FunctionPanel_Record.Click += new System.EventHandler(this.RecordingStart);
            // 
            // QueryPanel
            // 
            this.QueryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueryPanel.Controls.Add(this.DataList);
            this.QueryPanel.Location = new System.Drawing.Point(0, 85);
            this.QueryPanel.Name = "QueryPanel";
            this.QueryPanel.Size = new System.Drawing.Size(582, 275);
            this.QueryPanel.TabIndex = 3;
            // 
            // DataList
            // 
            this.DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataList.Location = new System.Drawing.Point(0, 0);
            this.DataList.Name = "DataList";
            this.DataList.RowTemplate.Height = 23;
            this.DataList.Size = new System.Drawing.Size(580, 273);
            this.DataList.TabIndex = 0;
            // 
            // TableList
            // 
            this.TableList.FormattingEnabled = true;
            this.TableList.Location = new System.Drawing.Point(314, 60);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(88, 20);
            this.TableList.TabIndex = 4;
            this.TableList.SelectedIndexChanged += new System.EventHandler(this.TableChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "w";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.QueryPanel);
            this.Controls.Add(this.FunctionPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "DB Project #131018 kim-jihwan";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FunctionPanel.ResumeLayout(false);
            this.QueryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.TextBox LoginPanel_Password;
        private System.Windows.Forms.TextBox LoginPanel_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginPanel_OK;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.Panel FunctionPanel;
        private System.Windows.Forms.Button FunctionPanel_Stop;
        private System.Windows.Forms.Button FunctionPanel_Record;
        private System.Windows.Forms.Button FunctionPanel_Hide;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.Panel QueryPanel;
        private System.Windows.Forms.DataGridView DataList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TableList;
        private System.Windows.Forms.Label label4;
    }
}

