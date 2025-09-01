namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            client = new TabPage();
            buttonSendMessage = new Button();
            panelMessage1 = new Panel();
            comboBoxRank = new ComboBox();
            labelRank = new Label();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            textBoxUnitNo = new TextBox();
            labelUnitNo = new Label();
            textBoxFirstName = new TextBox();
            labelFirstName = new Label();
            textBoxMsg1RefNo = new TextBox();
            labelUnitRefNum1 = new Label();
            labelMessageID1 = new Label();
            panelMessage2 = new Panel();
            textBoxAltitude = new TextBox();
            checkBoxLocValid = new CheckBox();
            labelAltitude = new Label();
            textBoxLongitude = new TextBox();
            labelLongitude = new Label();
            textBoxLatitude = new TextBox();
            labelLatitude = new Label();
            labelLocValid = new Label();
            textBoxMsg2RefNo = new TextBox();
            labelUnitRefNum2 = new Label();
            labelMessageID2 = new Label();
            comboMessageType = new ComboBox();
            listBoxLog = new ListBox();
            buttonConnect = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            serverPage = new TabPage();
            label4 = new Label();
            buttonStartServer = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            serverIPaddress = new Label();
            buttonStopServer = new Button();
            tabControl1.SuspendLayout();
            client.SuspendLayout();
            panelMessage1.SuspendLayout();
            panelMessage2.SuspendLayout();
            serverPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(client);
            tabControl1.Controls.Add(serverPage);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(768, 506);
            tabControl1.TabIndex = 0;
            // 
            // client
            // 
            client.BackColor = Color.Transparent;
            client.Controls.Add(buttonSendMessage);
            client.Controls.Add(panelMessage1);
            client.Controls.Add(panelMessage2);
            client.Controls.Add(comboMessageType);
            client.Controls.Add(listBoxLog);
            client.Controls.Add(buttonConnect);
            client.Controls.Add(textBox2);
            client.Controls.Add(label2);
            client.Controls.Add(textBox1);
            client.Controls.Add(label1);
            client.Location = new Point(4, 24);
            client.Name = "client";
            client.Padding = new Padding(3);
            client.Size = new Size(760, 478);
            client.TabIndex = 0;
            client.Text = "Client";
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.Location = new Point(621, 342);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(97, 23);
            buttonSendMessage.TabIndex = 9;
            buttonSendMessage.Text = "Send Message";
            buttonSendMessage.UseVisualStyleBackColor = true;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // panelMessage1
            // 
            panelMessage1.Controls.Add(comboBoxRank);
            panelMessage1.Controls.Add(labelRank);
            panelMessage1.Controls.Add(textBoxLastName);
            panelMessage1.Controls.Add(labelLastName);
            panelMessage1.Controls.Add(textBoxUnitNo);
            panelMessage1.Controls.Add(labelUnitNo);
            panelMessage1.Controls.Add(textBoxFirstName);
            panelMessage1.Controls.Add(labelFirstName);
            panelMessage1.Controls.Add(textBoxMsg1RefNo);
            panelMessage1.Controls.Add(labelUnitRefNum1);
            panelMessage1.Controls.Add(labelMessageID1);
            panelMessage1.Location = new Point(266, 56);
            panelMessage1.Name = "panelMessage1";
            panelMessage1.Size = new Size(323, 272);
            panelMessage1.TabIndex = 7;
            // 
            // comboBoxRank
            // 
            comboBoxRank.FormattingEnabled = true;
            comboBoxRank.Location = new Point(129, 164);
            comboBoxRank.Name = "comboBoxRank";
            comboBoxRank.Size = new Size(121, 23);
            comboBoxRank.TabIndex = 10;
            // 
            // labelRank
            // 
            labelRank.AutoSize = true;
            labelRank.Location = new Point(27, 164);
            labelRank.Name = "labelRank";
            labelRank.Size = new Size(33, 15);
            labelRank.TabIndex = 9;
            labelRank.Text = "Rank";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(129, 135);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(100, 23);
            textBoxLastName.TabIndex = 8;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(27, 135);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(63, 15);
            labelLastName.TabIndex = 7;
            labelLastName.Text = "Last Name";
            // 
            // textBoxUnitNo
            // 
            textBoxUnitNo.Location = new Point(129, 106);
            textBoxUnitNo.Name = "textBoxUnitNo";
            textBoxUnitNo.Size = new Size(100, 23);
            textBoxUnitNo.TabIndex = 6;
            // 
            // labelUnitNo
            // 
            labelUnitNo.AutoSize = true;
            labelUnitNo.Location = new Point(27, 106);
            labelUnitNo.Name = "labelUnitNo";
            labelUnitNo.Size = new Size(48, 15);
            labelUnitNo.TabIndex = 5;
            labelUnitNo.Text = "Unit No";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(129, 73);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(100, 23);
            textBoxFirstName.TabIndex = 4;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(27, 73);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(64, 15);
            labelFirstName.TabIndex = 3;
            labelFirstName.Text = "First Name";
            // 
            // textBoxMsg1RefNo
            // 
            textBoxMsg1RefNo.Location = new Point(129, 41);
            textBoxMsg1RefNo.Name = "textBoxMsg1RefNo";
            textBoxMsg1RefNo.Size = new Size(100, 23);
            textBoxMsg1RefNo.TabIndex = 2;
            // 
            // labelUnitRefNum1
            // 
            labelUnitRefNum1.AutoSize = true;
            labelUnitRefNum1.Location = new Point(27, 44);
            labelUnitRefNum1.Name = "labelUnitRefNum1";
            labelUnitRefNum1.Size = new Size(96, 15);
            labelUnitRefNum1.TabIndex = 1;
            labelUnitRefNum1.Text = "Unit Ref Number";
            // 
            // labelMessageID1
            // 
            labelMessageID1.AutoSize = true;
            labelMessageID1.Location = new Point(27, 17);
            labelMessageID1.Name = "labelMessageID1";
            labelMessageID1.Size = new Size(79, 15);
            labelMessageID1.TabIndex = 0;
            labelMessageID1.Text = "Message ID: 1";
            // 
            // panelMessage2
            // 
            panelMessage2.Controls.Add(textBoxAltitude);
            panelMessage2.Controls.Add(checkBoxLocValid);
            panelMessage2.Controls.Add(labelAltitude);
            panelMessage2.Controls.Add(textBoxLongitude);
            panelMessage2.Controls.Add(labelLongitude);
            panelMessage2.Controls.Add(textBoxLatitude);
            panelMessage2.Controls.Add(labelLatitude);
            panelMessage2.Controls.Add(labelLocValid);
            panelMessage2.Controls.Add(textBoxMsg2RefNo);
            panelMessage2.Controls.Add(labelUnitRefNum2);
            panelMessage2.Controls.Add(labelMessageID2);
            panelMessage2.Location = new Point(266, 56);
            panelMessage2.Name = "panelMessage2";
            panelMessage2.Size = new Size(323, 272);
            panelMessage2.TabIndex = 8;
            // 
            // textBoxAltitude
            // 
            textBoxAltitude.Location = new Point(122, 164);
            textBoxAltitude.Name = "textBoxAltitude";
            textBoxAltitude.Size = new Size(100, 23);
            textBoxAltitude.TabIndex = 23;
            // 
            // checkBoxLocValid
            // 
            checkBoxLocValid.AutoSize = true;
            checkBoxLocValid.Location = new Point(131, 74);
            checkBoxLocValid.Name = "checkBoxLocValid";
            checkBoxLocValid.Size = new Size(15, 14);
            checkBoxLocValid.TabIndex = 22;
            checkBoxLocValid.UseVisualStyleBackColor = true;
            // 
            // labelAltitude
            // 
            labelAltitude.AutoSize = true;
            labelAltitude.Location = new Point(20, 164);
            labelAltitude.Name = "labelAltitude";
            labelAltitude.Size = new Size(49, 15);
            labelAltitude.TabIndex = 20;
            labelAltitude.Text = "Altitude";
            // 
            // textBoxLongitude
            // 
            textBoxLongitude.Location = new Point(122, 135);
            textBoxLongitude.Name = "textBoxLongitude";
            textBoxLongitude.Size = new Size(100, 23);
            textBoxLongitude.TabIndex = 19;
            textBoxLongitude.TextChanged += textBox4_TextChanged;
            // 
            // labelLongitude
            // 
            labelLongitude.AutoSize = true;
            labelLongitude.Location = new Point(20, 135);
            labelLongitude.Name = "labelLongitude";
            labelLongitude.Size = new Size(61, 15);
            labelLongitude.TabIndex = 18;
            labelLongitude.Text = "Longitude";
            // 
            // textBoxLatitude
            // 
            textBoxLatitude.Location = new Point(122, 106);
            textBoxLatitude.Name = "textBoxLatitude";
            textBoxLatitude.Size = new Size(100, 23);
            textBoxLatitude.TabIndex = 17;
            // 
            // labelLatitude
            // 
            labelLatitude.AutoSize = true;
            labelLatitude.Location = new Point(20, 106);
            labelLatitude.Name = "labelLatitude";
            labelLatitude.Size = new Size(50, 15);
            labelLatitude.TabIndex = 16;
            labelLatitude.Text = "Latitude";
            // 
            // labelLocValid
            // 
            labelLocValid.AutoSize = true;
            labelLocValid.Location = new Point(20, 73);
            labelLocValid.Name = "labelLocValid";
            labelLocValid.Size = new Size(81, 15);
            labelLocValid.TabIndex = 14;
            labelLocValid.Text = "Location Valid";
            // 
            // textBoxMsg2RefNo
            // 
            textBoxMsg2RefNo.Location = new Point(122, 41);
            textBoxMsg2RefNo.Name = "textBoxMsg2RefNo";
            textBoxMsg2RefNo.Size = new Size(100, 23);
            textBoxMsg2RefNo.TabIndex = 13;
            // 
            // labelUnitRefNum2
            // 
            labelUnitRefNum2.AutoSize = true;
            labelUnitRefNum2.Location = new Point(20, 44);
            labelUnitRefNum2.Name = "labelUnitRefNum2";
            labelUnitRefNum2.Size = new Size(96, 15);
            labelUnitRefNum2.TabIndex = 12;
            labelUnitRefNum2.Text = "Unit Ref Number";
            // 
            // labelMessageID2
            // 
            labelMessageID2.AutoSize = true;
            labelMessageID2.Location = new Point(20, 17);
            labelMessageID2.Name = "labelMessageID2";
            labelMessageID2.Size = new Size(79, 15);
            labelMessageID2.TabIndex = 11;
            labelMessageID2.Text = "Message ID: 2";
            // 
            // comboMessageType
            // 
            comboMessageType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMessageType.FormattingEnabled = true;
            comboMessageType.Location = new Point(386, 24);
            comboMessageType.Name = "comboMessageType";
            comboMessageType.Size = new Size(121, 23);
            comboMessageType.TabIndex = 6;
            comboMessageType.SelectedIndexChanged += comboMessageType_SelectedIndexChanged;
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 15;
            listBoxLog.Location = new Point(39, 393);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(679, 79);
            listBoxLog.TabIndex = 5;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(39, 166);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(75, 23);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(39, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            textBox2.Text = "5500";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 90);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(39, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "127.0.0.1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 24);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Ip Address";
            // 
            // server
            // 
            serverPage.BackColor = Color.Transparent;
            serverPage.Controls.Add(buttonStopServer);
            serverPage.Controls.Add(label4);
            serverPage.Controls.Add(buttonStartServer);
            serverPage.Controls.Add(textBox3);
            serverPage.Controls.Add(label3);
            serverPage.Controls.Add(serverIPaddress);
            serverPage.Location = new Point(4, 24);
            serverPage.Name = "server";
            serverPage.Padding = new Padding(3);
            serverPage.Size = new Size(760, 478);
            serverPage.TabIndex = 1;
            serverPage.Text = "Server";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 57);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 10;
            label4.Text = "127.0.0.1";
            // 
            // buttonStartServer
            // 
            buttonStartServer.Location = new Point(38, 166);
            buttonStartServer.Name = "buttonStartServer";
            buttonStartServer.Size = new Size(75, 23);
            buttonStartServer.TabIndex = 9;
            buttonStartServer.Text = "Start Server";
            buttonStartServer.UseVisualStyleBackColor = true;
            buttonStartServer.Click += buttonStartServer_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(38, 117);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 8;
            textBox3.Text = "5500";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 90);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 7;
            label3.Text = "Port";
            // 
            // serverIPaddress
            // 
            serverIPaddress.AutoSize = true;
            serverIPaddress.Location = new Point(38, 24);
            serverIPaddress.Name = "serverIPaddress";
            serverIPaddress.Size = new Size(62, 15);
            serverIPaddress.TabIndex = 5;
            serverIPaddress.Text = "Ip Address";
            // 
            // buttonStopServer
            // 
            buttonStopServer.Location = new Point(119, 166);
            buttonStopServer.Name = "buttonStopServer";
            buttonStopServer.Size = new Size(75, 23);
            buttonStopServer.TabIndex = 11;
            buttonStopServer.Text = "Stop Server";
            buttonStopServer.UseVisualStyleBackColor = true;
            buttonStopServer.Click += buttonStopServer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            client.ResumeLayout(false);
            client.PerformLayout();
            panelMessage1.ResumeLayout(false);
            panelMessage1.PerformLayout();
            panelMessage2.ResumeLayout(false);
            panelMessage2.PerformLayout();
            serverPage.ResumeLayout(false);
            serverPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage client;
        private TabPage serverPage;
        private Label label1;
        private ListBox listBoxLog;
        private Button buttonConnect;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Button buttonStartServer;
        private TextBox textBox3;
        private Label label3;
        private Label serverIPaddress;
        private Label label4;
        private ComboBox comboMessageType;
        private Panel panelMessage1;
        private Button buttonSendMessage;
        private Panel panelMessage2;
        private Label labelMessageID1;
        private Label labelRank;
        private TextBox textBoxLastName;
        private Label labelLastName;
        private TextBox textBoxUnitNo;
        private Label labelUnitNo;
        private TextBox textBoxFirstName;
        private Label labelFirstName;
        private TextBox textBoxMsg1RefNo;
        private Label labelUnitRefNum1;
        private ComboBox comboBoxRank;
        private Label labelAltitude;
        private TextBox textBoxLongitude;
        private Label labelLongitude;
        private TextBox textBoxLatitude;
        private Label labelLatitude;
        private Label labelLocValid;
        private TextBox textBoxMsg2RefNo;
        private Label labelUnitRefNum2;
        private Label labelMessageID2;
        private CheckBox checkBoxLocValid;
        private TextBox textBoxAltitude;
        private Button buttonStopServer;
    }
}
