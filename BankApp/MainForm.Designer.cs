// MainForm.Designer.cs
namespace BankClient
{
    partial class MainForm
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
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpCreateLoginUser = new System.Windows.Forms.GroupBox();
            this.btnCreateLoginUser = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtLoginCustomerId = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.grpCreateCustomer = new System.Windows.Forms.GroupBox();
            this.txtCreatedCustomerId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCusEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpSearchCustomers = new System.Windows.Forms.GroupBox();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.btnSearchCustomers = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.grpGetAccount = new System.Windows.Forms.GroupBox();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.btnGetAccount = new System.Windows.Forms.Button();
            this.txtGetAccountNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpOpenAccount = new System.Windows.Forms.GroupBox();
            this.txtOpenedAccountNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnOpenAccount = new System.Windows.Forms.Button();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCustomerIdForAccount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.grpTransfer = new System.Windows.Forms.GroupBox();
            this.txtTrNote = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTrAmount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTrTo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTrFrom = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.grpWithdraw = new System.Windows.Forms.GroupBox();
            this.txtWdrNote = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.txtWdrAmount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtWdrAccount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.grpDeposit = new System.Windows.Forms.GroupBox();
            this.txtDepNote = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.txtDepAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDepAccount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabStatement = new System.Windows.Forms.TabPage();
            this.gridStatement = new System.Windows.Forms.DataGridView();
            this.btnLoadStatement = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStmAccount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            this.grpCreateLoginUser.SuspendLayout();
            this.grpCreateCustomer.SuspendLayout();
            this.grpSearchCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            this.tabAccounts.SuspendLayout();
            this.grpGetAccount.SuspendLayout();
            this.grpOpenAccount.SuspendLayout();
            this.tabTransactions.SuspendLayout();
            this.grpTransfer.SuspendLayout();
            this.grpWithdraw.SuspendLayout();
            this.grpDeposit.SuspendLayout();
            this.tabStatement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabCustomers);
            this.tab.Controls.Add(this.tabAccounts);
            this.tab.Controls.Add(this.tabTransactions);
            this.tab.Controls.Add(this.tabStatement);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1132, 648);
            this.tab.TabIndex = 0;
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.btnLogout);
            this.tabCustomers.Controls.Add(this.grpCreateLoginUser);
            this.tabCustomers.Controls.Add(this.grpCreateCustomer);
            this.tabCustomers.Controls.Add(this.grpSearchCustomers);
            this.tabCustomers.Location = new System.Drawing.Point(4, 25);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(1124, 619);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Customers";
            this.tabCustomers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(982, 586);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 30);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // grpCreateLoginUser
            // 
            this.grpCreateLoginUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCreateLoginUser.Controls.Add(this.btnCreateLoginUser);
            this.grpCreateLoginUser.Controls.Add(this.txtLoginPassword);
            this.grpCreateLoginUser.Controls.Add(this.label30);
            this.grpCreateLoginUser.Controls.Add(this.txtLoginEmail);
            this.grpCreateLoginUser.Controls.Add(this.label29);
            this.grpCreateLoginUser.Controls.Add(this.txtLoginCustomerId);
            this.grpCreateLoginUser.Controls.Add(this.label28);
            this.grpCreateLoginUser.Location = new System.Drawing.Point(20, 248);
            this.grpCreateLoginUser.Name = "grpCreateLoginUser";
            this.grpCreateLoginUser.Size = new System.Drawing.Size(1082, 100);
            this.grpCreateLoginUser.TabIndex = 2;
            this.grpCreateLoginUser.TabStop = false;
            this.grpCreateLoginUser.Text = "Tạo tài khoản cho Người dùng";
            // 
            // btnCreateLoginUser
            // 
            this.btnCreateLoginUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateLoginUser.Location = new System.Drawing.Point(982, 29);
            this.btnCreateLoginUser.Name = "btnCreateLoginUser";
            this.btnCreateLoginUser.Size = new System.Drawing.Size(100, 28);
            this.btnCreateLoginUser.TabIndex = 6;
            this.btnCreateLoginUser.Text = "Tạo";
            this.btnCreateLoginUser.UseVisualStyleBackColor = true;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(782, 32);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '●';
            this.txtLoginPassword.Size = new System.Drawing.Size(140, 22);
            this.txtLoginPassword.TabIndex = 5;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(690, 34);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 16);
            this.label30.TabIndex = 4;
            this.label30.Text = "Mật khẩu";
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.Location = new System.Drawing.Point(484, 31);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(200, 22);
            this.txtLoginEmail.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(417, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 16);
            this.label29.TabIndex = 2;
            this.label29.Text = "Email";
            // 
            // txtLoginCustomerId
            // 
            this.txtLoginCustomerId.Location = new System.Drawing.Point(131, 32);
            this.txtLoginCustomerId.Name = "txtLoginCustomerId";
            this.txtLoginCustomerId.Size = new System.Drawing.Size(279, 22);
            this.txtLoginCustomerId.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "ID Người dùng";
            // 
            // grpCreateCustomer
            // 
            this.grpCreateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCreateCustomer.Controls.Add(this.txtCreatedCustomerId);
            this.grpCreateCustomer.Controls.Add(this.label8);
            this.grpCreateCustomer.Controls.Add(this.btnCreateCustomer);
            this.grpCreateCustomer.Controls.Add(this.txtAddress);
            this.grpCreateCustomer.Controls.Add(this.label7);
            this.grpCreateCustomer.Controls.Add(this.txtPhone);
            this.grpCreateCustomer.Controls.Add(this.label6);
            this.grpCreateCustomer.Controls.Add(this.txtCusEmail);
            this.grpCreateCustomer.Controls.Add(this.label5);
            this.grpCreateCustomer.Controls.Add(this.txtFullName);
            this.grpCreateCustomer.Controls.Add(this.label4);
            this.grpCreateCustomer.Location = new System.Drawing.Point(20, 16);
            this.grpCreateCustomer.Name = "grpCreateCustomer";
            this.grpCreateCustomer.Size = new System.Drawing.Size(1082, 198);
            this.grpCreateCustomer.TabIndex = 0;
            this.grpCreateCustomer.TabStop = false;
            this.grpCreateCustomer.Text = "Tạo Người dùng";
            // 
            // txtCreatedCustomerId
            // 
            this.txtCreatedCustomerId.Location = new System.Drawing.Point(131, 164);
            this.txtCreatedCustomerId.Name = "txtCreatedCustomerId";
            this.txtCreatedCustomerId.ReadOnly = true;
            this.txtCreatedCustomerId.Size = new System.Drawing.Size(220, 22);
            this.txtCreatedCustomerId.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "ID Người dùng";
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCustomer.Location = new System.Drawing.Point(693, 158);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(138, 28);
            this.btnCreateCustomer.TabIndex = 8;
            this.btnCreateCustomer.Text = "Tạo ID Người dùng";
            this.btnCreateCustomer.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(131, 121);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(379, 22);
            this.txtAddress.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(671, 65);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(210, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số điện thoại";
            // 
            // txtCusEmail
            // 
            this.txtCusEmail.Location = new System.Drawing.Point(131, 81);
            this.txtCusEmail.Name = "txtCusEmail";
            this.txtCusEmail.Size = new System.Drawing.Size(379, 22);
            this.txtCusEmail.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(131, 37);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(379, 22);
            this.txtFullName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên đầy đủ";
            // 
            // grpSearchCustomers
            // 
            this.grpSearchCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchCustomers.Controls.Add(this.gridCustomers);
            this.grpSearchCustomers.Controls.Add(this.btnSearchCustomers);
            this.grpSearchCustomers.Controls.Add(this.txtSearch);
            this.grpSearchCustomers.Controls.Add(this.label3);
            this.grpSearchCustomers.Location = new System.Drawing.Point(20, 364);
            this.grpSearchCustomers.Name = "grpSearchCustomers";
            this.grpSearchCustomers.Size = new System.Drawing.Size(1082, 220);
            this.grpSearchCustomers.TabIndex = 3;
            this.grpSearchCustomers.TabStop = false;
            this.grpSearchCustomers.Text = "Search Customers";
            // 
            // gridCustomers
            // 
            this.gridCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.Location = new System.Drawing.Point(25, 68);
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.RowHeadersWidth = 51;
            this.gridCustomers.RowTemplate.Height = 24;
            this.gridCustomers.Size = new System.Drawing.Size(1032, 130);
            this.gridCustomers.TabIndex = 3;
            // 
            // btnSearchCustomers
            // 
            this.btnSearchCustomers.Location = new System.Drawing.Point(420, 30);
            this.btnSearchCustomers.Name = "btnSearchCustomers";
            this.btnSearchCustomers.Size = new System.Drawing.Size(90, 28);
            this.btnSearchCustomers.TabIndex = 2;
            this.btnSearchCustomers.Text = "Tìm";
            this.btnSearchCustomers.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(90, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Keyword";
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.grpGetAccount);
            this.tabAccounts.Controls.Add(this.grpOpenAccount);
            this.tabAccounts.Location = new System.Drawing.Point(4, 25);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccounts.Size = new System.Drawing.Size(1124, 619);
            this.tabAccounts.TabIndex = 2;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // grpGetAccount
            // 
            this.grpGetAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGetAccount.Controls.Add(this.lblAccountInfo);
            this.grpGetAccount.Controls.Add(this.btnGetAccount);
            this.grpGetAccount.Controls.Add(this.txtGetAccountNo);
            this.grpGetAccount.Controls.Add(this.label11);
            this.grpGetAccount.Location = new System.Drawing.Point(20, 176);
            this.grpGetAccount.Name = "grpGetAccount";
            this.grpGetAccount.Size = new System.Drawing.Size(950, 120);
            this.grpGetAccount.TabIndex = 1;
            this.grpGetAccount.TabStop = false;
            this.grpGetAccount.Text = "Lấy thông tin tài khoản";
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.Location = new System.Drawing.Point(22, 78);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(214, 16);
            this.lblAccountInfo.TabIndex = 3;
            this.lblAccountInfo.Text = "Số dư/Trạng thái sẽ hiển thị ở đây...";
            // 
            // btnGetAccount
            // 
            this.btnGetAccount.Location = new System.Drawing.Point(310, 40);
            this.btnGetAccount.Name = "btnGetAccount";
            this.btnGetAccount.Size = new System.Drawing.Size(110, 28);
            this.btnGetAccount.TabIndex = 2;
            this.btnGetAccount.Text = "Lấy thông tin";
            this.btnGetAccount.UseVisualStyleBackColor = true;
            // 
            // txtGetAccountNo
            // 
            this.txtGetAccountNo.Location = new System.Drawing.Point(110, 42);
            this.txtGetAccountNo.Name = "txtGetAccountNo";
            this.txtGetAccountNo.Size = new System.Drawing.Size(180, 22);
            this.txtGetAccountNo.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Số tài khoản";
            // 
            // grpOpenAccount
            // 
            this.grpOpenAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOpenAccount.Controls.Add(this.txtOpenedAccountNo);
            this.grpOpenAccount.Controls.Add(this.label15);
            this.grpOpenAccount.Controls.Add(this.btnOpenAccount);
            this.grpOpenAccount.Controls.Add(this.txtCurrency);
            this.grpOpenAccount.Controls.Add(this.label14);
            this.grpOpenAccount.Controls.Add(this.cboAccountType);
            this.grpOpenAccount.Controls.Add(this.label13);
            this.grpOpenAccount.Controls.Add(this.txtCustomerIdForAccount);
            this.grpOpenAccount.Controls.Add(this.label12);
            this.grpOpenAccount.Location = new System.Drawing.Point(20, 16);
            this.grpOpenAccount.Name = "grpOpenAccount";
            this.grpOpenAccount.Size = new System.Drawing.Size(950, 140);
            this.grpOpenAccount.TabIndex = 0;
            this.grpOpenAccount.TabStop = false;
            this.grpOpenAccount.Text = "Mở tài khoản ngân hàng";
            // 
            // txtOpenedAccountNo
            // 
            this.txtOpenedAccountNo.Location = new System.Drawing.Point(110, 96);
            this.txtOpenedAccountNo.Name = "txtOpenedAccountNo";
            this.txtOpenedAccountNo.ReadOnly = true;
            this.txtOpenedAccountNo.Size = new System.Drawing.Size(200, 22);
            this.txtOpenedAccountNo.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "Số tài khoản";
            // 
            // btnOpenAccount
            // 
            this.btnOpenAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenAccount.Location = new System.Drawing.Point(850, 40);
            this.btnOpenAccount.Name = "btnOpenAccount";
            this.btnOpenAccount.Size = new System.Drawing.Size(100, 28);
            this.btnOpenAccount.TabIndex = 6;
            this.btnOpenAccount.Text = "Mở";
            this.btnOpenAccount.UseVisualStyleBackColor = true;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(610, 42);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(80, 22);
            this.txtCurrency.TabIndex = 5;
            this.txtCurrency.Text = "VND";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(550, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Currency";
            // 
            // cboAccountType
            // 
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Location = new System.Drawing.Point(388, 42);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(150, 24);
            this.cboAccountType.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(290, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Tài khoản loại";
            // 
            // txtCustomerIdForAccount
            // 
            this.txtCustomerIdForAccount.Location = new System.Drawing.Point(110, 42);
            this.txtCustomerIdForAccount.Name = "txtCustomerIdForAccount";
            this.txtCustomerIdForAccount.Size = new System.Drawing.Size(160, 22);
            this.txtCustomerIdForAccount.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "ID Người dùng";
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.grpTransfer);
            this.tabTransactions.Controls.Add(this.grpWithdraw);
            this.tabTransactions.Controls.Add(this.grpDeposit);
            this.tabTransactions.Location = new System.Drawing.Point(4, 25);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransactions.Size = new System.Drawing.Size(1124, 619);
            this.tabTransactions.TabIndex = 3;
            this.tabTransactions.Text = "Transactions";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // grpTransfer
            // 
            this.grpTransfer.Controls.Add(this.txtTrNote);
            this.grpTransfer.Controls.Add(this.label26);
            this.grpTransfer.Controls.Add(this.btnTransfer);
            this.grpTransfer.Controls.Add(this.txtTrAmount);
            this.grpTransfer.Controls.Add(this.label25);
            this.grpTransfer.Controls.Add(this.txtTrTo);
            this.grpTransfer.Controls.Add(this.label24);
            this.grpTransfer.Controls.Add(this.txtTrFrom);
            this.grpTransfer.Controls.Add(this.label23);
            this.grpTransfer.Location = new System.Drawing.Point(500, 20);
            this.grpTransfer.Name = "grpTransfer";
            this.grpTransfer.Size = new System.Drawing.Size(470, 240);
            this.grpTransfer.TabIndex = 2;
            this.grpTransfer.TabStop = false;
            this.grpTransfer.Text = "Chuyển khoản";
            // 
            // txtTrNote
            // 
            this.txtTrNote.Location = new System.Drawing.Point(140, 130);
            this.txtTrNote.Name = "txtTrNote";
            this.txtTrNote.Size = new System.Drawing.Size(300, 22);
            this.txtTrNote.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(22, 133);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 16);
            this.label26.TabIndex = 8;
            this.label26.Text = "Ghi chú";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(140, 170);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 28);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Text = "Chuyển tiền";
            this.btnTransfer.UseVisualStyleBackColor = true;
            // 
            // txtTrAmount
            // 
            this.txtTrAmount.Location = new System.Drawing.Point(140, 100);
            this.txtTrAmount.Name = "txtTrAmount";
            this.txtTrAmount.Size = new System.Drawing.Size(140, 22);
            this.txtTrAmount.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(22, 103);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 16);
            this.label25.TabIndex = 5;
            this.label25.Text = "Số tiền chuyển";
            // 
            // txtTrTo
            // 
            this.txtTrTo.Location = new System.Drawing.Point(140, 70);
            this.txtTrTo.Name = "txtTrTo";
            this.txtTrTo.Size = new System.Drawing.Size(180, 22);
            this.txtTrTo.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(22, 73);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 16);
            this.label24.TabIndex = 3;
            this.label24.Text = "Tài khoản hưởng";
            // 
            // txtTrFrom
            // 
            this.txtTrFrom.Location = new System.Drawing.Point(140, 40);
            this.txtTrFrom.Name = "txtTrFrom";
            this.txtTrFrom.Size = new System.Drawing.Size(180, 22);
            this.txtTrFrom.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "Tài khoản chuyển";
            // 
            // grpWithdraw
            // 
            this.grpWithdraw.Controls.Add(this.txtWdrNote);
            this.grpWithdraw.Controls.Add(this.label22);
            this.grpWithdraw.Controls.Add(this.btnWithdraw);
            this.grpWithdraw.Controls.Add(this.txtWdrAmount);
            this.grpWithdraw.Controls.Add(this.label21);
            this.grpWithdraw.Controls.Add(this.txtWdrAccount);
            this.grpWithdraw.Controls.Add(this.label20);
            this.grpWithdraw.Location = new System.Drawing.Point(20, 210);
            this.grpWithdraw.Name = "grpWithdraw";
            this.grpWithdraw.Size = new System.Drawing.Size(450, 170);
            this.grpWithdraw.TabIndex = 1;
            this.grpWithdraw.TabStop = false;
            this.grpWithdraw.Text = "Rút tiền";
            // 
            // txtWdrNote
            // 
            this.txtWdrNote.Location = new System.Drawing.Point(110, 96);
            this.txtWdrNote.Name = "txtWdrNote";
            this.txtWdrNote.Size = new System.Drawing.Size(300, 22);
            this.txtWdrNote.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(22, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 16);
            this.label22.TabIndex = 6;
            this.label22.Text = "Ghi chú";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(110, 128);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(110, 28);
            this.btnWithdraw.TabIndex = 4;
            this.btnWithdraw.Text = "Rút tiền";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // txtWdrAmount
            // 
            this.txtWdrAmount.Location = new System.Drawing.Point(110, 66);
            this.txtWdrAmount.Name = "txtWdrAmount";
            this.txtWdrAmount.Size = new System.Drawing.Size(120, 22);
            this.txtWdrAmount.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(22, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 16);
            this.label21.TabIndex = 2;
            this.label21.Text = "Số tiền rút";
            // 
            // txtWdrAccount
            // 
            this.txtWdrAccount.Location = new System.Drawing.Point(110, 36);
            this.txtWdrAccount.Name = "txtWdrAccount";
            this.txtWdrAccount.Size = new System.Drawing.Size(180, 22);
            this.txtWdrAccount.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Số tài khoản";
            // 
            // grpDeposit
            // 
            this.grpDeposit.Controls.Add(this.txtDepNote);
            this.grpDeposit.Controls.Add(this.label18);
            this.grpDeposit.Controls.Add(this.btnDeposit);
            this.grpDeposit.Controls.Add(this.txtDepAmount);
            this.grpDeposit.Controls.Add(this.label17);
            this.grpDeposit.Controls.Add(this.txtDepAccount);
            this.grpDeposit.Controls.Add(this.label16);
            this.grpDeposit.Location = new System.Drawing.Point(20, 20);
            this.grpDeposit.Name = "grpDeposit";
            this.grpDeposit.Size = new System.Drawing.Size(450, 170);
            this.grpDeposit.TabIndex = 0;
            this.grpDeposit.TabStop = false;
            this.grpDeposit.Text = "Nạp tiền";
            // 
            // txtDepNote
            // 
            this.txtDepNote.Location = new System.Drawing.Point(110, 96);
            this.txtDepNote.Name = "txtDepNote";
            this.txtDepNote.Size = new System.Drawing.Size(300, 22);
            this.txtDepNote.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 16);
            this.label18.TabIndex = 6;
            this.label18.Text = "Ghi chú";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(110, 128);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(110, 28);
            this.btnDeposit.TabIndex = 4;
            this.btnDeposit.Text = "Nạp tiền";
            this.btnDeposit.UseVisualStyleBackColor = true;
            // 
            // txtDepAmount
            // 
            this.txtDepAmount.Location = new System.Drawing.Point(110, 66);
            this.txtDepAmount.Name = "txtDepAmount";
            this.txtDepAmount.Size = new System.Drawing.Size(120, 22);
            this.txtDepAmount.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "Số tiền nạp";
            // 
            // txtDepAccount
            // 
            this.txtDepAccount.Location = new System.Drawing.Point(110, 36);
            this.txtDepAccount.Name = "txtDepAccount";
            this.txtDepAccount.Size = new System.Drawing.Size(180, 22);
            this.txtDepAccount.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Số tài khoản";
            // 
            // tabStatement
            // 
            this.tabStatement.Controls.Add(this.gridStatement);
            this.tabStatement.Controls.Add(this.btnLoadStatement);
            this.tabStatement.Controls.Add(this.dtTo);
            this.tabStatement.Controls.Add(this.label19);
            this.tabStatement.Controls.Add(this.dtFrom);
            this.tabStatement.Controls.Add(this.label10);
            this.tabStatement.Controls.Add(this.txtStmAccount);
            this.tabStatement.Controls.Add(this.label9);
            this.tabStatement.Location = new System.Drawing.Point(4, 25);
            this.tabStatement.Name = "tabStatement";
            this.tabStatement.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatement.Size = new System.Drawing.Size(1124, 619);
            this.tabStatement.TabIndex = 4;
            this.tabStatement.Text = "Statement";
            this.tabStatement.UseVisualStyleBackColor = true;
            // 
            // gridStatement
            // 
            this.gridStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatement.Location = new System.Drawing.Point(25, 88);
            this.gridStatement.Name = "gridStatement";
            this.gridStatement.RowHeadersWidth = 51;
            this.gridStatement.RowTemplate.Height = 24;
            this.gridStatement.Size = new System.Drawing.Size(940, 500);
            this.gridStatement.TabIndex = 7;
            // 
            // btnLoadStatement
            // 
            this.btnLoadStatement.Location = new System.Drawing.Point(890, 28);
            this.btnLoadStatement.Name = "btnLoadStatement";
            this.btnLoadStatement.Size = new System.Drawing.Size(75, 28);
            this.btnLoadStatement.TabIndex = 6;
            this.btnLoadStatement.Text = "Tải";
            this.btnLoadStatement.UseVisualStyleBackColor = true;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(655, 31);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(220, 22);
            this.dtTo.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(625, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "Tới";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(392, 31);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(220, 22);
            this.dtFrom.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Từ";
            // 
            // txtStmAccount
            // 
            this.txtStmAccount.Location = new System.Drawing.Point(110, 31);
            this.txtStmAccount.Name = "txtStmAccount";
            this.txtStmAccount.Size = new System.Drawing.Size(230, 22);
            this.txtStmAccount.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Số tài khoản";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(640, 40);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(420, 42);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 42);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 648);
            this.Controls.Add(this.tab);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Admin - MainForm";
            this.tab.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            this.grpCreateLoginUser.ResumeLayout(false);
            this.grpCreateLoginUser.PerformLayout();
            this.grpCreateCustomer.ResumeLayout(false);
            this.grpCreateCustomer.PerformLayout();
            this.grpSearchCustomers.ResumeLayout(false);
            this.grpSearchCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            this.tabAccounts.ResumeLayout(false);
            this.grpGetAccount.ResumeLayout(false);
            this.grpGetAccount.PerformLayout();
            this.grpOpenAccount.ResumeLayout(false);
            this.grpOpenAccount.PerformLayout();
            this.tabTransactions.ResumeLayout(false);
            this.grpTransfer.ResumeLayout(false);
            this.grpTransfer.PerformLayout();
            this.grpWithdraw.ResumeLayout(false);
            this.grpWithdraw.PerformLayout();
            this.grpDeposit.ResumeLayout(false);
            this.grpDeposit.PerformLayout();
            this.tabStatement.ResumeLayout(false);
            this.tabStatement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.GroupBox grpCreateCustomer;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCusEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.TextBox txtCreatedCustomerId;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.GroupBox grpCreateLoginUser; // NEW
        private System.Windows.Forms.TextBox txtLoginCustomerId; // NEW
        private System.Windows.Forms.TextBox txtLoginEmail; // NEW
        private System.Windows.Forms.TextBox txtLoginPassword; // NEW
        private System.Windows.Forms.Button btnCreateLoginUser; // NEW
        private System.Windows.Forms.Label label28; // NEW
        private System.Windows.Forms.Label label29; // NEW
        private System.Windows.Forms.Label label30; // NEW

        private System.Windows.Forms.GroupBox grpSearchCustomers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchCustomers;
        private System.Windows.Forms.DataGridView gridCustomers;

        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.GroupBox grpOpenAccount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerIdForAccount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboAccountType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Button btnOpenAccount;
        private System.Windows.Forms.TextBox txtOpenedAccountNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox grpGetAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGetAccountNo;
        private System.Windows.Forms.Button btnGetAccount;
        private System.Windows.Forms.Label lblAccountInfo;

        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.GroupBox grpDeposit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDepAccount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDepAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.TextBox txtDepNote;
        private System.Windows.Forms.Label label18;

        private System.Windows.Forms.GroupBox grpWithdraw;
        private System.Windows.Forms.TextBox txtWdrNote;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.TextBox txtWdrAmount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtWdrAccount;
        private System.Windows.Forms.Label label20;

        private System.Windows.Forms.GroupBox grpTransfer;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTrFrom;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTrTo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTrAmount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtTrNote;
        private System.Windows.Forms.Label label26;

        private System.Windows.Forms.TabPage tabStatement;
        private System.Windows.Forms.TextBox txtStmAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnLoadStatement;
        private System.Windows.Forms.DataGridView gridStatement;
        private System.Windows.Forms.Button btnLogout;
    }
}




