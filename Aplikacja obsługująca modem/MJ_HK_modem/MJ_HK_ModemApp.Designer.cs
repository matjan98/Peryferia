namespace MJ_HK_modem
{
    partial class MJ_HK_ModemApp
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
            this.Button_Zadzwon = new System.Windows.Forms.Button();
            this.TextBox_SecondModem = new System.Windows.Forms.TextBox();
            this.Button_Odbierz = new System.Windows.Forms.Button();
            this.Button_Rozlacz = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.TerminalOutput = new System.Windows.Forms.RichTextBox();
            this.labelTerminal = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.AvailablePortsLabel = new System.Windows.Forms.Label();
            this.AvailablePortsList = new System.Windows.Forms.ComboBox();
            this.SerialPortGroupBox = new System.Windows.Forms.GroupBox();
            this.SingleCommand = new System.Windows.Forms.GroupBox();
            this.Button_CommandSend = new System.Windows.Forms.Button();
            this.TextBox_CommandToSend = new System.Windows.Forms.TextBox();
            this.labelCommand = new System.Windows.Forms.Label();
            this.SerialPortGroupBox.SuspendLayout();
            this.SingleCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Zadzwon
            // 
            this.Button_Zadzwon.Enabled = false;
            this.Button_Zadzwon.Location = new System.Drawing.Point(12, 12);
            this.Button_Zadzwon.Name = "Button_Zadzwon";
            this.Button_Zadzwon.Size = new System.Drawing.Size(164, 39);
            this.Button_Zadzwon.TabIndex = 0;
            this.Button_Zadzwon.Text = "Zadzwoń do";
            this.Button_Zadzwon.UseVisualStyleBackColor = true;
            this.Button_Zadzwon.Click += new System.EventHandler(this.Button_Zadzwon_Click);
            // 
            // TextBox_SecondModem
            // 
            this.TextBox_SecondModem.Location = new System.Drawing.Point(182, 18);
            this.TextBox_SecondModem.Name = "TextBox_SecondModem";
            this.TextBox_SecondModem.Size = new System.Drawing.Size(221, 26);
            this.TextBox_SecondModem.TabIndex = 1;
            // 
            // Button_Odbierz
            // 
            this.Button_Odbierz.BackColor = System.Drawing.Color.Green;
            this.Button_Odbierz.Enabled = false;
            this.Button_Odbierz.Location = new System.Drawing.Point(12, 75);
            this.Button_Odbierz.Name = "Button_Odbierz";
            this.Button_Odbierz.Size = new System.Drawing.Size(391, 39);
            this.Button_Odbierz.TabIndex = 3;
            this.Button_Odbierz.Text = "Odbierz";
            this.Button_Odbierz.UseVisualStyleBackColor = false;
            this.Button_Odbierz.Click += new System.EventHandler(this.Button_Odbierz_Click);
            // 
            // Button_Rozlacz
            // 
            this.Button_Rozlacz.Enabled = false;
            this.Button_Rozlacz.Location = new System.Drawing.Point(12, 130);
            this.Button_Rozlacz.Name = "Button_Rozlacz";
            this.Button_Rozlacz.Size = new System.Drawing.Size(391, 39);
            this.Button_Rozlacz.TabIndex = 4;
            this.Button_Rozlacz.Text = "Rozłącz";
            this.Button_Rozlacz.UseVisualStyleBackColor = true;
            this.Button_Rozlacz.Click += new System.EventHandler(this.Button_Rozlacz_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Location = new System.Drawing.Point(21, 641);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(391, 39);
            this.Button_Exit.TabIndex = 5;
            this.Button_Exit.Text = "Wyjście";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // TerminalOutput
            // 
            this.TerminalOutput.Location = new System.Drawing.Point(430, 53);
            this.TerminalOutput.Name = "TerminalOutput";
            this.TerminalOutput.ReadOnly = true;
            this.TerminalOutput.Size = new System.Drawing.Size(922, 638);
            this.TerminalOutput.TabIndex = 6;
            this.TerminalOutput.Text = "";
            // 
            // labelTerminal
            // 
            this.labelTerminal.AutoSize = true;
            this.labelTerminal.Location = new System.Drawing.Point(430, 27);
            this.labelTerminal.Name = "labelTerminal";
            this.labelTerminal.Size = new System.Drawing.Size(123, 20);
            this.labelTerminal.TabIndex = 7;
            this.labelTerminal.Text = "Terminal output:";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(256, 71);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(112, 35);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(14, 71);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(112, 35);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(135, 71);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(112, 35);
            this.DisconnectButton.TabIndex = 2;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // AvailablePortsLabel
            // 
            this.AvailablePortsLabel.AutoSize = true;
            this.AvailablePortsLabel.Location = new System.Drawing.Point(9, 34);
            this.AvailablePortsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailablePortsLabel.Name = "AvailablePortsLabel";
            this.AvailablePortsLabel.Size = new System.Drawing.Size(156, 20);
            this.AvailablePortsLabel.TabIndex = 10;
            this.AvailablePortsLabel.Text = "Available COM ports:";
            // 
            // AvailablePortsList
            // 
            this.AvailablePortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvailablePortsList.FormattingEnabled = true;
            this.AvailablePortsList.Location = new System.Drawing.Point(177, 29);
            this.AvailablePortsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailablePortsList.Name = "AvailablePortsList";
            this.AvailablePortsList.Size = new System.Drawing.Size(190, 28);
            this.AvailablePortsList.TabIndex = 0;
            // 
            // SerialPortGroupBox
            // 
            this.SerialPortGroupBox.Controls.Add(this.RefreshButton);
            this.SerialPortGroupBox.Controls.Add(this.ConnectButton);
            this.SerialPortGroupBox.Controls.Add(this.DisconnectButton);
            this.SerialPortGroupBox.Controls.Add(this.AvailablePortsLabel);
            this.SerialPortGroupBox.Controls.Add(this.AvailablePortsList);
            this.SerialPortGroupBox.Location = new System.Drawing.Point(12, 299);
            this.SerialPortGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SerialPortGroupBox.Name = "SerialPortGroupBox";
            this.SerialPortGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SerialPortGroupBox.Size = new System.Drawing.Size(390, 120);
            this.SerialPortGroupBox.TabIndex = 15;
            this.SerialPortGroupBox.TabStop = false;
            this.SerialPortGroupBox.Text = "Serial port";
            // 
            // SingleCommand
            // 
            this.SingleCommand.Controls.Add(this.Button_CommandSend);
            this.SingleCommand.Controls.Add(this.TextBox_CommandToSend);
            this.SingleCommand.Controls.Add(this.labelCommand);
            this.SingleCommand.Location = new System.Drawing.Point(12, 443);
            this.SingleCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SingleCommand.Name = "SingleCommand";
            this.SingleCommand.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SingleCommand.Size = new System.Drawing.Size(390, 77);
            this.SingleCommand.TabIndex = 16;
            this.SingleCommand.TabStop = false;
            this.SingleCommand.Text = "Single commands";
            // 
            // Button_CommandSend
            // 
            this.Button_CommandSend.Enabled = false;
            this.Button_CommandSend.Location = new System.Drawing.Point(256, 28);
            this.Button_CommandSend.Name = "Button_CommandSend";
            this.Button_CommandSend.Size = new System.Drawing.Size(112, 29);
            this.Button_CommandSend.TabIndex = 17;
            this.Button_CommandSend.Text = "Wyślij";
            this.Button_CommandSend.UseVisualStyleBackColor = true;
            this.Button_CommandSend.Click += new System.EventHandler(this.Button_CommandSend_Click);
            // 
            // TextBox_CommandToSend
            // 
            this.TextBox_CommandToSend.Location = new System.Drawing.Point(97, 28);
            this.TextBox_CommandToSend.Name = "TextBox_CommandToSend";
            this.TextBox_CommandToSend.Size = new System.Drawing.Size(150, 26);
            this.TextBox_CommandToSend.TabIndex = 11;
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(9, 34);
            this.labelCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(81, 20);
            this.labelCommand.TabIndex = 10;
            this.labelCommand.Text = "Komenda:";
            // 
            // MJ_HK_ModemApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 703);
            this.Controls.Add(this.SingleCommand);
            this.Controls.Add(this.SerialPortGroupBox);
            this.Controls.Add(this.labelTerminal);
            this.Controls.Add(this.TerminalOutput);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Rozlacz);
            this.Controls.Add(this.Button_Odbierz);
            this.Controls.Add(this.TextBox_SecondModem);
            this.Controls.Add(this.Button_Zadzwon);
            this.Name = "MJ_HK_ModemApp";
            this.Text = "Form1";
            this.SerialPortGroupBox.ResumeLayout(false);
            this.SerialPortGroupBox.PerformLayout();
            this.SingleCommand.ResumeLayout(false);
            this.SingleCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Zadzwon;
        private System.Windows.Forms.TextBox TextBox_SecondModem;
        private System.Windows.Forms.Button Button_Odbierz;
        private System.Windows.Forms.Button Button_Rozlacz;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.RichTextBox TerminalOutput;
        private System.Windows.Forms.Label labelTerminal;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label AvailablePortsLabel;
        private System.Windows.Forms.ComboBox AvailablePortsList;
        private System.Windows.Forms.GroupBox SerialPortGroupBox;
        private System.Windows.Forms.GroupBox SingleCommand;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.Button Button_CommandSend;
        private System.Windows.Forms.TextBox TextBox_CommandToSend;
    }
}

