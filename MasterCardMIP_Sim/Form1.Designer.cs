namespace MasterCardMIP_Sim
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_MIP_START = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.button_Send_good_END = new System.Windows.Forms.Button();
            this.button_Send_bad_END = new System.Windows.Forms.Button();
            this.button_MIP_STOP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_MIP_START
            // 
            this.button_MIP_START.Location = new System.Drawing.Point(176, 18);
            this.button_MIP_START.Name = "button_MIP_START";
            this.button_MIP_START.Size = new System.Drawing.Size(154, 28);
            this.button_MIP_START.TabIndex = 0;
            this.button_MIP_START.Text = "MIP Server START";
            this.button_MIP_START.UseVisualStyleBackColor = true;
            this.button_MIP_START.Click += new System.EventHandler(this.button_MIP_START_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(79, 15);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(91, 22);
            this.TextBox1.TabIndex = 73;
            this.TextBox1.Text = "10.13.102.241";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(14, 160);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 12);
            this.Label3.TabIndex = 71;
            this.Label3.Text = "訊息視窗";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 12);
            this.Label2.TabIndex = 70;
            this.Label2.Text = "Server Port";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(23, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 12);
            this.Label1.TabIndex = 69;
            this.Label1.Text = "Server IP";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(79, 43);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(91, 22);
            this.TextBox2.TabIndex = 68;
            this.TextBox2.Text = "6246";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(514, 22);
            this.textBox3.TabIndex = 74;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(532, 71);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(127, 22);
            this.button_Send.TabIndex = 75;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBoxInformation
            // 
            this.textBoxInformation.Location = new System.Drawing.Point(7, 198);
            this.textBoxInformation.Multiline = true;
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInformation.Size = new System.Drawing.Size(665, 143);
            this.textBoxInformation.TabIndex = 76;
            // 
            // button_Send_good_END
            // 
            this.button_Send_good_END.Location = new System.Drawing.Point(12, 114);
            this.button_Send_good_END.Name = "button_Send_good_END";
            this.button_Send_good_END.Size = new System.Drawing.Size(152, 26);
            this.button_Send_good_END.TabIndex = 77;
            this.button_Send_good_END.Text = "Send good END =>9980100";
            this.button_Send_good_END.UseVisualStyleBackColor = true;
            this.button_Send_good_END.Click += new System.EventHandler(this.button_Send_good_END_Click);
            // 
            // button_Send_bad_END
            // 
            this.button_Send_bad_END.Location = new System.Drawing.Point(178, 114);
            this.button_Send_bad_END.Name = "button_Send_bad_END";
            this.button_Send_bad_END.Size = new System.Drawing.Size(152, 26);
            this.button_Send_bad_END.TabIndex = 78;
            this.button_Send_bad_END.Text = "Send bad END =>9980101";
            this.button_Send_bad_END.UseVisualStyleBackColor = true;
            this.button_Send_bad_END.Click += new System.EventHandler(this.button_Send_bad_END_Click);
            // 
            // button_MIP_STOP
            // 
            this.button_MIP_STOP.Location = new System.Drawing.Point(353, 18);
            this.button_MIP_STOP.Name = "button_MIP_STOP";
            this.button_MIP_STOP.Size = new System.Drawing.Size(154, 28);
            this.button_MIP_STOP.TabIndex = 85;
            this.button_MIP_STOP.Text = "MIP Server STOP";
            this.button_MIP_STOP.UseVisualStyleBackColor = true;
            this.button_MIP_STOP.Click += new System.EventHandler(this.button_MIP_STOP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 363);
            this.Controls.Add(this.button_MIP_STOP);
            this.Controls.Add(this.button_Send_bad_END);
            this.Controls.Add(this.button_Send_good_END);
            this.Controls.Add(this.textBoxInformation);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.button_MIP_START);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " MasterCard MIP Server Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBoxInformation;
        private System.Windows.Forms.Button button_Send_good_END;
        private System.Windows.Forms.Button button_Send_bad_END;
        public System.Windows.Forms.Button button_MIP_STOP;
        private System.Windows.Forms.Button button_MIP_START;
    }
}

