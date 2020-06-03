namespace Cognitive_TEXT_API
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.APIKey = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SourceFile = new System.Windows.Forms.TextBox();
            this.OutputFile = new System.Windows.Forms.TextBox();
            this.Process = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Results = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenSourceFile = new System.Windows.Forms.Button();
            this.SelectOutputFolder = new System.Windows.Forms.Button();
            this.Paste = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextAPIBaseURL = new System.Windows.Forms.TextBox();
            this.TextAPIVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSplit = new System.Windows.Forms.CheckBox();
            this.CloseApp = new System.Windows.Forms.Button();
            this.PctComplete = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbReplaceTab = new System.Windows.Forms.CheckBox();
            this.cbTAB = new System.Windows.Forms.ComboBox();
            this.cbTrim = new System.Windows.Forms.CheckBox();
            this.cbHashtag = new System.Windows.Forms.CheckBox();
            this.cbURL = new System.Windows.Forms.CheckBox();
            this.cb1500 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLanguage = new System.Windows.Forms.CheckBox();
            this.rbEntity = new System.Windows.Forms.CheckBox();
            this.rbKeyPhrases = new System.Windows.Forms.CheckBox();
            this.rbSentiment = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // APIKey
            // 
            this.APIKey.Location = new System.Drawing.Point(146, 70);
            this.APIKey.Margin = new System.Windows.Forms.Padding(2);
            this.APIKey.Name = "APIKey";
            this.APIKey.Size = new System.Drawing.Size(500, 20);
            this.APIKey.TabIndex = 0;
            this.APIKey.Text = "<YourTextAnalyticsAPIKeyHere>";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "*.txt";
            this.openFileDialog1.Filter = "txt Files|*.txt|All Files|*.*";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Title = "Select Source File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // SourceFile
            // 
            this.SourceFile.Location = new System.Drawing.Point(146, 100);
            this.SourceFile.Margin = new System.Windows.Forms.Padding(2);
            this.SourceFile.Name = "SourceFile";
            this.SourceFile.Size = new System.Drawing.Size(500, 20);
            this.SourceFile.TabIndex = 1;
            this.SourceFile.Text = "C:\\";
            this.SourceFile.TextChanged += new System.EventHandler(this.SourceFile_TextChanged);
            // 
            // OutputFile
            // 
            this.OutputFile.Location = new System.Drawing.Point(146, 131);
            this.OutputFile.Margin = new System.Windows.Forms.Padding(2);
            this.OutputFile.Name = "OutputFile";
            this.OutputFile.Size = new System.Drawing.Size(500, 20);
            this.OutputFile.TabIndex = 2;
            this.OutputFile.Text = "c:\\";
            // 
            // Process
            // 
            this.Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Process.Location = new System.Drawing.Point(650, 328);
            this.Process.Margin = new System.Windows.Forms.Padding(2);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(56, 30);
            this.Process.TabIndex = 3;
            this.Process.Text = "Start";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ProgressBar.Location = new System.Drawing.Point(9, 328);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(637, 29);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // Results
            // 
            this.Results.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.Location = new System.Drawing.Point(9, 363);
            this.Results.Margin = new System.Windows.Forms.Padding(2);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results.Size = new System.Drawing.Size(698, 276);
            this.Results.TabIndex = 5;
            this.Results.WordWrap = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // OpenSourceFile
            // 
            this.OpenSourceFile.Location = new System.Drawing.Point(650, 99);
            this.OpenSourceFile.Margin = new System.Windows.Forms.Padding(2);
            this.OpenSourceFile.Name = "OpenSourceFile";
            this.OpenSourceFile.Size = new System.Drawing.Size(56, 19);
            this.OpenSourceFile.TabIndex = 6;
            this.OpenSourceFile.Text = "Select...";
            this.OpenSourceFile.UseVisualStyleBackColor = true;
            this.OpenSourceFile.Click += new System.EventHandler(this.OpenSourceFile_Click);
            // 
            // SelectOutputFolder
            // 
            this.SelectOutputFolder.Location = new System.Drawing.Point(650, 131);
            this.SelectOutputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.SelectOutputFolder.Name = "SelectOutputFolder";
            this.SelectOutputFolder.Size = new System.Drawing.Size(56, 19);
            this.SelectOutputFolder.TabIndex = 7;
            this.SelectOutputFolder.Text = "Select...";
            this.SelectOutputFolder.UseVisualStyleBackColor = true;
            this.SelectOutputFolder.Click += new System.EventHandler(this.SelectOutputFolder_Click);
            // 
            // Paste
            // 
            this.Paste.Location = new System.Drawing.Point(650, 70);
            this.Paste.Margin = new System.Windows.Forms.Padding(2);
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(56, 19);
            this.Paste.TabIndex = 8;
            this.Paste.Text = "Paste";
            this.Paste.UseVisualStyleBackColor = true;
            this.Paste.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 314);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // TextAPIBaseURL
            // 
            this.TextAPIBaseURL.Location = new System.Drawing.Point(146, 10);
            this.TextAPIBaseURL.Margin = new System.Windows.Forms.Padding(2);
            this.TextAPIBaseURL.Name = "TextAPIBaseURL";
            this.TextAPIBaseURL.Size = new System.Drawing.Size(500, 20);
            this.TextAPIBaseURL.TabIndex = 10;
            this.TextAPIBaseURL.Text = "https://<YourNameHere>.cognitiveservices.azure.com/";
            // 
            // TextAPIVersion
            // 
            this.TextAPIVersion.Location = new System.Drawing.Point(146, 32);
            this.TextAPIVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TextAPIVersion.Name = "TextAPIVersion";
            this.TextAPIVersion.Size = new System.Drawing.Size(500, 20);
            this.TextAPIVersion.TabIndex = 11;
            this.TextAPIVersion.Text = "text/analytics/v3.0/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(700, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Text Analytics Base URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Text Analytics Version URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Output Folder Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Source Text File";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Text Analytics API Key";
            // 
            // cbSplit
            // 
            this.cbSplit.Checked = true;
            this.cbSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSplit.Location = new System.Drawing.Point(290, 168);
            this.cbSplit.Name = "cbSplit";
            this.cbSplit.Size = new System.Drawing.Size(174, 24);
            this.cbSplit.TabIndex = 34;
            this.cbSplit.Text = "Split Document into Sentences";
            // 
            // CloseApp
            // 
            this.CloseApp.Location = new System.Drawing.Point(651, 644);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(56, 30);
            this.CloseApp.TabIndex = 21;
            this.CloseApp.Text = "Close";
            this.CloseApp.UseVisualStyleBackColor = true;
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // PctComplete
            // 
            this.PctComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PctComplete.Location = new System.Drawing.Point(310, 336);
            this.PctComplete.Name = "PctComplete";
            this.PctComplete.Size = new System.Drawing.Size(75, 13);
            this.PctComplete.TabIndex = 22;
            this.PctComplete.Text = "0%";
            this.PctComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PctComplete.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 153);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(700, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // cbReplaceTab
            // 
            this.cbReplaceTab.AutoSize = true;
            this.cbReplaceTab.Checked = true;
            this.cbReplaceTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReplaceTab.Enabled = false;
            this.cbReplaceTab.Location = new System.Drawing.Point(290, 198);
            this.cbReplaceTab.Name = "cbReplaceTab";
            this.cbReplaceTab.Size = new System.Drawing.Size(127, 17);
            this.cbReplaceTab.TabIndex = 24;
            this.cbReplaceTab.Text = "Replace <TAB> Char";
            this.cbReplaceTab.UseVisualStyleBackColor = true;
            this.cbReplaceTab.CheckedChanged += new System.EventHandler(this.cbReplaceTab_CheckedChanged);
            // 
            // cbTAB
            // 
            this.cbTAB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTAB.FormattingEnabled = true;
            this.cbTAB.Items.AddRange(new object[] {
            "(SPACE)",
            ", (COMMA)"});
            this.cbTAB.Location = new System.Drawing.Point(146, 196);
            this.cbTAB.Name = "cbTAB";
            this.cbTAB.Size = new System.Drawing.Size(139, 21);
            this.cbTAB.TabIndex = 27;
            // 
            // cbTrim
            // 
            this.cbTrim.AutoSize = true;
            this.cbTrim.Checked = true;
            this.cbTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTrim.Location = new System.Drawing.Point(290, 224);
            this.cbTrim.Name = "cbTrim";
            this.cbTrim.Size = new System.Drawing.Size(104, 17);
            this.cbTrim.TabIndex = 28;
            this.cbTrim.Text = "Trim Left + Right";
            this.cbTrim.UseVisualStyleBackColor = true;
            // 
            // cbHashtag
            // 
            this.cbHashtag.AutoSize = true;
            this.cbHashtag.Checked = true;
            this.cbHashtag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHashtag.Location = new System.Drawing.Point(290, 248);
            this.cbHashtag.Name = "cbHashtag";
            this.cbHashtag.Size = new System.Drawing.Size(114, 17);
            this.cbHashtag.TabIndex = 29;
            this.cbHashtag.Text = "Remove Hashtags";
            this.cbHashtag.UseVisualStyleBackColor = true;
            // 
            // cbURL
            // 
            this.cbURL.AutoSize = true;
            this.cbURL.Checked = true;
            this.cbURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbURL.Location = new System.Drawing.Point(290, 272);
            this.cbURL.Name = "cbURL";
            this.cbURL.Size = new System.Drawing.Size(98, 17);
            this.cbURL.TabIndex = 30;
            this.cbURL.Text = "Remove URL\'s";
            this.cbURL.UseVisualStyleBackColor = true;
            // 
            // cb1500
            // 
            this.cb1500.AutoSize = true;
            this.cb1500.Checked = true;
            this.cb1500.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb1500.Enabled = false;
            this.cb1500.Location = new System.Drawing.Point(290, 296);
            this.cb1500.Name = "cb1500";
            this.cb1500.Size = new System.Drawing.Size(132, 17);
            this.cb1500.TabIndex = 31;
            this.cb1500.Text = "Truncate to 5120 char";
            this.cb1500.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLanguage);
            this.groupBox1.Controls.Add(this.rbEntity);
            this.groupBox1.Controls.Add(this.rbKeyPhrases);
            this.groupBox1.Controls.Add(this.rbSentiment);
            this.groupBox1.Location = new System.Drawing.Point(470, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 138);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text API Operations";
            // 
            // rbLanguage
            // 
            this.rbLanguage.AutoSize = true;
            this.rbLanguage.Checked = true;
            this.rbLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbLanguage.Enabled = false;
            this.rbLanguage.Location = new System.Drawing.Point(10, 106);
            this.rbLanguage.Name = "rbLanguage";
            this.rbLanguage.Size = new System.Drawing.Size(99, 17);
            this.rbLanguage.TabIndex = 39;
            this.rbLanguage.Text = "Language \"en\"";
            this.rbLanguage.UseVisualStyleBackColor = true;
            // 
            // rbEntity
            // 
            this.rbEntity.AutoSize = true;
            this.rbEntity.Checked = true;
            this.rbEntity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbEntity.Location = new System.Drawing.Point(10, 80);
            this.rbEntity.Name = "rbEntity";
            this.rbEntity.Size = new System.Drawing.Size(89, 17);
            this.rbEntity.TabIndex = 38;
            this.rbEntity.Text = "Named Entity";
            this.rbEntity.UseVisualStyleBackColor = true;
            this.rbEntity.CheckedChanged += new System.EventHandler(this.rbTopics_CheckedChanged);
            // 
            // rbKeyPhrases
            // 
            this.rbKeyPhrases.AutoSize = true;
            this.rbKeyPhrases.Checked = true;
            this.rbKeyPhrases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbKeyPhrases.Location = new System.Drawing.Point(10, 53);
            this.rbKeyPhrases.Name = "rbKeyPhrases";
            this.rbKeyPhrases.Size = new System.Drawing.Size(85, 17);
            this.rbKeyPhrases.TabIndex = 37;
            this.rbKeyPhrases.Text = "Key Phrases";
            this.rbKeyPhrases.UseVisualStyleBackColor = true;
            // 
            // rbSentiment
            // 
            this.rbSentiment.AutoSize = true;
            this.rbSentiment.Checked = true;
            this.rbSentiment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbSentiment.Location = new System.Drawing.Point(10, 26);
            this.rbSentiment.Name = "rbSentiment";
            this.rbSentiment.Size = new System.Drawing.Size(73, 17);
            this.rbSentiment.TabIndex = 36;
            this.rbSentiment.Text = "Sentiment";
            this.rbSentiment.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 683);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb1500);
            this.Controls.Add(this.cbURL);
            this.Controls.Add(this.cbHashtag);
            this.Controls.Add(this.cbTrim);
            this.Controls.Add(this.cbTAB);
            this.Controls.Add(this.cbReplaceTab);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PctComplete);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.cbSplit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextAPIVersion);
            this.Controls.Add(this.TextAPIBaseURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Paste);
            this.Controls.Add(this.SelectOutputFolder);
            this.Controls.Add(this.OpenSourceFile);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.OutputFile);
            this.Controls.Add(this.SourceFile);
            this.Controls.Add(this.APIKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cognitive_TEXT_API";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox APIKey;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SourceFile;
        private System.Windows.Forms.TextBox OutputFile;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TextBox Results;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button OpenSourceFile;
        private System.Windows.Forms.Button SelectOutputFolder;
        private System.Windows.Forms.Button Paste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextAPIBaseURL;
        private System.Windows.Forms.TextBox TextAPIVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbSplit;
        private System.Windows.Forms.Button CloseApp;
        private System.Windows.Forms.Label PctComplete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbReplaceTab;
        private System.Windows.Forms.ComboBox cbTAB;
        private System.Windows.Forms.CheckBox cbTrim;
        private System.Windows.Forms.CheckBox cbHashtag;
        private System.Windows.Forms.CheckBox cbURL;
        private System.Windows.Forms.CheckBox cb1500;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox rbEntity;
        private System.Windows.Forms.CheckBox rbKeyPhrases;
        private System.Windows.Forms.CheckBox rbSentiment;
        private System.Windows.Forms.CheckBox rbLanguage;
    }
}

