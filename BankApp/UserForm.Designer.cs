// UserForm.Designer.cs (updated layout: no AccountNo inputs; shows account details)
namespace BankClient
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tab = new System.Windows.Forms.TabControl();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.grpMyAccount = new System.Windows.Forms.GroupBox();
            this.lblOpenedAtValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrencyValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAccClassValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAccNoValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.tabCash = new System.Windows.Forms.TabPage();
            this.grpDeposit = new System.Windows.Forms.GroupBox();
            this.txtDepNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.txtDepAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpWithdraw = new System.Windows.Forms.GroupBox();
            this.txtWdrNote = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.txtWdrAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpTransfer = new System.Windows.Forms.GroupBox();
            this.txtTrNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTrAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTrTo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabStatement = new System.Windows.Forms.TabPage();
            this.btnLoadStatement = new System.Windows.Forms.Button();
            this.gridStatement = new System.Windows.Forms.DataGridView();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.grpMyAccount.SuspendLayout();
            this.tabCash.SuspendLayout();
            this.grpDeposit.SuspendLayout();
            this.grpWithdraw.SuspendLayout();
            this.grpTransfer.SuspendLayout();
            this.tabStatement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabAccount);
            this.tab.Controls.Add(this.tabCash);
            this.tab.Controls.Add(this.tabStatement);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(860, 560);
            this.tab.TabIndex = 0;
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.btnLogout);
            this.tabAccount.Controls.Add(this.grpMyAccount);
            this.tabAccount.Controls.Add(this.lblAccountInfo);
            this.tabAccount.Location = new System.Drawing.Point(4, 25);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(852, 531);
            this.tabAccount.TabIndex = 0;
            this.tabAccount.Text = "Tài khoản của tôi";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // grpMyAccount
            // 
            this.grpMyAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMyAccount.Controls.Add(this.lblOpenedAtValue);
            this.grpMyAccount.Controls.Add(this.label7);
            this.grpMyAccount.Controls.Add(this.lblStatusValue);
            this.grpMyAccount.Controls.Add(this.label6);
            this.grpMyAccount.Controls.Add(this.lblBalanceValue);
            this.grpMyAccount.Controls.Add(this.label5);
            this.grpMyAccount.Controls.Add(this.lblCurrencyValue);
            this.grpMyAccount.Controls.Add(this.label4);
            this.grpMyAccount.Controls.Add(this.lblAccClassValue);
            this.grpMyAccount.Controls.Add(this.label3);
            this.grpMyAccount.Controls.Add(this.lblAccNoValue);
            this.grpMyAccount.Controls.Add(this.label2);
            this.grpMyAccount.Location = new System.Drawing.Point(28, 56);
            this.grpMyAccount.Name = "grpMyAccount";
            this.grpMyAccount.Size = new System.Drawing.Size(796, 170);
            this.grpMyAccount.TabIndex = 4;
            this.grpMyAccount.TabStop = false;
            this.grpMyAccount.Text = "Thông tin tài khoản";
            // 
            // lblOpenedAtValue
            // 
            this.lblOpenedAtValue.AutoSize = true;
            this.lblOpenedAtValue.Location = new System.Drawing.Point(520, 98);
            this.lblOpenedAtValue.Name = "lblOpenedAtValue";
            this.lblOpenedAtValue.Size = new System.Drawing.Size(11, 16);
            this.lblOpenedAtValue.TabIndex = 0;
            this.lblOpenedAtValue.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mở vào ";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(520, 66);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(11, 16);
            this.lblStatusValue.TabIndex = 2;
            this.lblStatusValue.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Trạng thái";
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.AutoSize = true;
            this.lblBalanceValue.Location = new System.Drawing.Point(520, 34);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.Size = new System.Drawing.Size(11, 16);
            this.lblBalanceValue.TabIndex = 4;
            this.lblBalanceValue.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số dư";
            // 
            // lblCurrencyValue
            // 
            this.lblCurrencyValue.AutoSize = true;
            this.lblCurrencyValue.Location = new System.Drawing.Point(120, 98);
            this.lblCurrencyValue.Name = "lblCurrencyValue";
            this.lblCurrencyValue.Size = new System.Drawing.Size(11, 16);
            this.lblCurrencyValue.TabIndex = 6;
            this.lblCurrencyValue.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Currency";
            // 
            // lblAccClassValue
            // 
            this.lblAccClassValue.AutoSize = true;
            this.lblAccClassValue.Location = new System.Drawing.Point(120, 66);
            this.lblAccClassValue.Name = "lblAccClassValue";
            this.lblAccClassValue.Size = new System.Drawing.Size(11, 16);
            this.lblAccClassValue.TabIndex = 8;
            this.lblAccClassValue.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Loại tài khoản";
            // 
            // lblAccNoValue
            // 
            this.lblAccNoValue.AutoSize = true;
            this.lblAccNoValue.Location = new System.Drawing.Point(120, 34);
            this.lblAccNoValue.Name = "lblAccNoValue";
            this.lblAccNoValue.Size = new System.Drawing.Size(11, 16);
            this.lblAccNoValue.TabIndex = 10;
            this.lblAccNoValue.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Số tài khoản";
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.Location = new System.Drawing.Point(28, 24);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(293, 16);
            this.lblAccountInfo.TabIndex = 3;
            this.lblAccountInfo.Text = "Thông tin tài khoản sẽ hiển thị sau khi đăng nhập";
            // 
            // tabCash
            // 
            this.tabCash.Controls.Add(this.grpDeposit);
            this.tabCash.Controls.Add(this.grpWithdraw);
            this.tabCash.Controls.Add(this.grpTransfer);
            this.tabCash.Location = new System.Drawing.Point(4, 25);
            this.tabCash.Name = "tabCash";
            this.tabCash.Padding = new System.Windows.Forms.Padding(3);
            this.tabCash.Size = new System.Drawing.Size(852, 531);
            this.tabCash.TabIndex = 1;
            this.tabCash.Text = "Giao dịch";
            this.tabCash.UseVisualStyleBackColor = true;
            // 
            // grpDeposit
            // 
            this.grpDeposit.Controls.Add(this.txtDepNote);
            this.grpDeposit.Controls.Add(this.label8);
            this.grpDeposit.Controls.Add(this.btnDeposit);
            this.grpDeposit.Controls.Add(this.txtDepAmount);
            this.grpDeposit.Controls.Add(this.label9);
            this.grpDeposit.Location = new System.Drawing.Point(25, 20);
            this.grpDeposit.Name = "grpDeposit";
            this.grpDeposit.Size = new System.Drawing.Size(380, 160);
            this.grpDeposit.TabIndex = 0;
            this.grpDeposit.TabStop = false;
            this.grpDeposit.Text = "Nạp tiền (vào tài khoản của tôi)";
            // 
            // txtDepNote
            // 
            this.txtDepNote.Location = new System.Drawing.Point(120, 70);
            this.txtDepNote.Name = "txtDepNote";
            this.txtDepNote.Size = new System.Drawing.Size(230, 22);
            this.txtDepNote.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ghi chú";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(120, 104);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(120, 28);
            this.btnDeposit.TabIndex = 3;
            this.btnDeposit.Text = "Nạp tiền";
            this.btnDeposit.UseVisualStyleBackColor = true;
            // 
            // txtDepAmount
            // 
            this.txtDepAmount.Location = new System.Drawing.Point(120, 38);
            this.txtDepAmount.Name = "txtDepAmount";
            this.txtDepAmount.Size = new System.Drawing.Size(120, 22);
            this.txtDepAmount.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Số tiền";
            // 
            // grpWithdraw
            // 
            this.grpWithdraw.Controls.Add(this.txtWdrNote);
            this.grpWithdraw.Controls.Add(this.label10);
            this.grpWithdraw.Controls.Add(this.btnWithdraw);
            this.grpWithdraw.Controls.Add(this.txtWdrAmount);
            this.grpWithdraw.Controls.Add(this.label11);
            this.grpWithdraw.Location = new System.Drawing.Point(25, 200);
            this.grpWithdraw.Name = "grpWithdraw";
            this.grpWithdraw.Size = new System.Drawing.Size(380, 160);
            this.grpWithdraw.TabIndex = 1;
            this.grpWithdraw.TabStop = false;
            this.grpWithdraw.Text = "Rút tiền (từ tài khoản của tôi)";
            // 
            // txtWdrNote
            // 
            this.txtWdrNote.Location = new System.Drawing.Point(120, 70);
            this.txtWdrNote.Name = "txtWdrNote";
            this.txtWdrNote.Size = new System.Drawing.Size(230, 22);
            this.txtWdrNote.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ghi chú";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(120, 104);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(120, 28);
            this.btnWithdraw.TabIndex = 3;
            this.btnWithdraw.Text = "Rút tiền";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // txtWdrAmount
            // 
            this.txtWdrAmount.Location = new System.Drawing.Point(120, 38);
            this.txtWdrAmount.Name = "txtWdrAmount";
            this.txtWdrAmount.Size = new System.Drawing.Size(120, 22);
            this.txtWdrAmount.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số tiền";
            // 
            // grpTransfer
            // 
            this.grpTransfer.Controls.Add(this.txtTrNote);
            this.grpTransfer.Controls.Add(this.label15);
            this.grpTransfer.Controls.Add(this.btnTransfer);
            this.grpTransfer.Controls.Add(this.txtTrAmount);
            this.grpTransfer.Controls.Add(this.label14);
            this.grpTransfer.Controls.Add(this.txtTrTo);
            this.grpTransfer.Controls.Add(this.label13);
            this.grpTransfer.Location = new System.Drawing.Point(430, 20);
            this.grpTransfer.Name = "grpTransfer";
            this.grpTransfer.Size = new System.Drawing.Size(380, 210);
            this.grpTransfer.TabIndex = 2;
            this.grpTransfer.TabStop = false;
            this.grpTransfer.Text = "Chuyển khoản (từ tài khoản của tôi)";
            // 
            // txtTrNote
            // 
            this.txtTrNote.Location = new System.Drawing.Point(120, 110);
            this.txtTrNote.Name = "txtTrNote";
            this.txtTrNote.Size = new System.Drawing.Size(230, 22);
            this.txtTrNote.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "Ghi chú";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(120, 145);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 28);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "Chuyển tiền";
            this.btnTransfer.UseVisualStyleBackColor = true;
            // 
            // txtTrAmount
            // 
            this.txtTrAmount.Location = new System.Drawing.Point(120, 78);
            this.txtTrAmount.Name = "txtTrAmount";
            this.txtTrAmount.Size = new System.Drawing.Size(120, 22);
            this.txtTrAmount.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "Số tiền chuyển";
            // 
            // txtTrTo
            // 
            this.txtTrTo.Location = new System.Drawing.Point(120, 46);
            this.txtTrTo.Name = "txtTrTo";
            this.txtTrTo.Size = new System.Drawing.Size(190, 22);
            this.txtTrTo.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Tài khoản hưởng";
            // 
            // tabStatement
            // 
            this.tabStatement.Controls.Add(this.btnLoadStatement);
            this.tabStatement.Controls.Add(this.gridStatement);
            this.tabStatement.Controls.Add(this.dtTo);
            this.tabStatement.Controls.Add(this.label17);
            this.tabStatement.Controls.Add(this.dtFrom);
            this.tabStatement.Controls.Add(this.label16);
            this.tabStatement.Location = new System.Drawing.Point(4, 25);
            this.tabStatement.Name = "tabStatement";
            this.tabStatement.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatement.Size = new System.Drawing.Size(852, 531);
            this.tabStatement.TabIndex = 2;
            this.tabStatement.Text = "Sao kê";
            this.tabStatement.UseVisualStyleBackColor = true;
            // 
            // btnLoadStatement
            // 
            this.btnLoadStatement.Location = new System.Drawing.Point(710, 25);
            this.btnLoadStatement.Name = "btnLoadStatement";
            this.btnLoadStatement.Size = new System.Drawing.Size(120, 28);
            this.btnLoadStatement.TabIndex = 5;
            this.btnLoadStatement.Text = "Tải sao kê";
            this.btnLoadStatement.UseVisualStyleBackColor = true;
            // 
            // gridStatement
            // 
            this.gridStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatement.Location = new System.Drawing.Point(23, 70);
            this.gridStatement.Name = "gridStatement";
            this.gridStatement.RowHeadersWidth = 51;
            this.gridStatement.RowTemplate.Height = 24;
            this.gridStatement.Size = new System.Drawing.Size(807, 435);
            this.gridStatement.TabIndex = 6;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(420, 28);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 22);
            this.dtTo.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(390, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 16);
            this.label17.TabIndex = 9;
            this.label17.Text = "Tới";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(140, 28);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(110, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 16);
            this.label16.TabIndex = 7;
            this.label16.Text = "Từ";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(339, 242);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(128, 31);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.tab);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Client - Customer";
            this.tab.ResumeLayout(false);
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            this.grpMyAccount.ResumeLayout(false);
            this.grpMyAccount.PerformLayout();
            this.tabCash.ResumeLayout(false);
            this.grpDeposit.ResumeLayout(false);
            this.grpDeposit.PerformLayout();
            this.grpWithdraw.ResumeLayout(false);
            this.grpWithdraw.PerformLayout();
            this.grpTransfer.ResumeLayout(false);
            this.grpTransfer.PerformLayout();
            this.tabStatement.ResumeLayout(false);
            this.tabStatement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.TabPage tabCash;
        private System.Windows.Forms.TabPage tabStatement;

        private System.Windows.Forms.Label lblAccountInfo;

        private System.Windows.Forms.GroupBox grpMyAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAccNoValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAccClassValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrencyValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBalanceValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOpenedAtValue;

        private System.Windows.Forms.GroupBox grpDeposit;
        private System.Windows.Forms.TextBox txtDepAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.TextBox txtDepNote;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.GroupBox grpWithdraw;
        private System.Windows.Forms.TextBox txtWdrAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.TextBox txtWdrNote;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.GroupBox grpTransfer;
        private System.Windows.Forms.TextBox txtTrTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTrAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtTrNote;
        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnLoadStatement;
        private System.Windows.Forms.DataGridView gridStatement;
        private System.Windows.Forms.Button btnLogout;
    }
}



