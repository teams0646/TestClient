namespace TestClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.testsListBox = new System.Windows.Forms.ListBox();
            this.loadTestsButton = new System.Windows.Forms.Button();
            this.startTestButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerDRadioButton = new System.Windows.Forms.RadioButton();
            this.answerCRadioButton = new System.Windows.Forms.RadioButton();
            this.answerBRadioButton = new System.Windows.Forms.RadioButton();
            this.answerARadioButton = new System.Windows.Forms.RadioButton();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.answerGroupBox = new System.Windows.Forms.GroupBox();
            this.questionGroupBox = new System.Windows.Forms.GroupBox();
            this.testsGroupBox = new System.Windows.Forms.GroupBox();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // testsListBox
            // 
            this.testsListBox.FormattingEnabled = true;
            this.testsListBox.Location = new System.Drawing.Point(12, 18);
            this.testsListBox.Name = "testsListBox";
            this.testsListBox.Size = new System.Drawing.Size(257, 420);
            this.testsListBox.TabIndex = 1;
            this.testsListBox.SelectedIndexChanged += new System.EventHandler(this.testsListBox_SelectedIndexChanged_1);
            // 
            // loadTestsButton
            // 
            this.loadTestsButton.Location = new System.Drawing.Point(386, 415);
            this.loadTestsButton.Name = "loadTestsButton";
            this.loadTestsButton.Size = new System.Drawing.Size(75, 23);
            this.loadTestsButton.TabIndex = 2;
            this.loadTestsButton.Text = "load test";
            this.loadTestsButton.UseVisualStyleBackColor = true;
            // 
            // startTestButton
            // 
            this.startTestButton.Location = new System.Drawing.Point(295, 415);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(75, 23);
            this.startTestButton.TabIndex = 3;
            this.startTestButton.Text = "start test";
            this.startTestButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(713, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(292, 62);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(73, 13);
            this.questionLabel.TabIndex = 5;
            this.questionLabel.Text = "questionLabel";
            // 
            // answerDRadioButton
            // 
            this.answerDRadioButton.AutoSize = true;
            this.answerDRadioButton.Location = new System.Drawing.Point(386, 131);
            this.answerDRadioButton.Name = "answerDRadioButton";
            this.answerDRadioButton.Size = new System.Drawing.Size(33, 17);
            this.answerDRadioButton.TabIndex = 6;
            this.answerDRadioButton.TabStop = true;
            this.answerDRadioButton.Text = "D";
            this.answerDRadioButton.UseVisualStyleBackColor = true;
            this.answerDRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // answerCRadioButton
            // 
            this.answerCRadioButton.AutoSize = true;
            this.answerCRadioButton.Location = new System.Drawing.Point(386, 108);
            this.answerCRadioButton.Name = "answerCRadioButton";
            this.answerCRadioButton.Size = new System.Drawing.Size(32, 17);
            this.answerCRadioButton.TabIndex = 7;
            this.answerCRadioButton.TabStop = true;
            this.answerCRadioButton.Text = "C";
            this.answerCRadioButton.UseVisualStyleBackColor = true;
            this.answerCRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // answerBRadioButton
            // 
            this.answerBRadioButton.AutoSize = true;
            this.answerBRadioButton.Location = new System.Drawing.Point(386, 85);
            this.answerBRadioButton.Name = "answerBRadioButton";
            this.answerBRadioButton.Size = new System.Drawing.Size(32, 17);
            this.answerBRadioButton.TabIndex = 8;
            this.answerBRadioButton.TabStop = true;
            this.answerBRadioButton.Text = "B";
            this.answerBRadioButton.UseVisualStyleBackColor = true;
            this.answerBRadioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // answerARadioButton
            // 
            this.answerARadioButton.AutoSize = true;
            this.answerARadioButton.Location = new System.Drawing.Point(386, 62);
            this.answerARadioButton.Name = "answerARadioButton";
            this.answerARadioButton.Size = new System.Drawing.Size(32, 17);
            this.answerARadioButton.TabIndex = 9;
            this.answerARadioButton.TabStop = true;
            this.answerARadioButton.Text = "A";
            this.answerARadioButton.UseVisualStyleBackColor = true;
            this.answerARadioButton.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Location = new System.Drawing.Point(290, 180);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(128, 23);
            this.nextQuestionButton.TabIndex = 10;
            this.nextQuestionButton.Text = "next question";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(459, 185);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(52, 13);
            this.feedbackLabel.TabIndex = 11;
            this.feedbackLabel.Text = "feedback";
            this.feedbackLabel.Click += new System.EventHandler(this.feedbackLabel_Click);
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Location = new System.Drawing.Point(541, 12);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(200, 100);
            this.answerGroupBox.TabIndex = 12;
            this.answerGroupBox.TabStop = false;
            this.answerGroupBox.Text = "Answer";
            this.answerGroupBox.Enter += new System.EventHandler(this.answerGroupBox_Enter);
            // 
            // questionGroupBox
            // 
            this.questionGroupBox.Location = new System.Drawing.Point(541, 252);
            this.questionGroupBox.Name = "questionGroupBox";
            this.questionGroupBox.Size = new System.Drawing.Size(200, 100);
            this.questionGroupBox.TabIndex = 13;
            this.questionGroupBox.TabStop = false;
            this.questionGroupBox.Text = "Answer";
            // 
            // testsGroupBox
            // 
            this.testsGroupBox.Location = new System.Drawing.Point(541, 131);
            this.testsGroupBox.Name = "testsGroupBox";
            this.testsGroupBox.Size = new System.Drawing.Size(200, 100);
            this.testsGroupBox.TabIndex = 13;
            this.testsGroupBox.TabStop = false;
            this.testsGroupBox.Text = "Answer";
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.passwordTextBox);
            this.loginGroupBox.Controls.Add(this.usernameTextBox);
            this.loginGroupBox.Location = new System.Drawing.Point(311, 252);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(200, 100);
            this.loginGroupBox.TabIndex = 14;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Login";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(37, 19);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(37, 45);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginGroupBox);
            this.Controls.Add(this.questionGroupBox);
            this.Controls.Add(this.testsGroupBox);
            this.Controls.Add(this.answerGroupBox);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.answerARadioButton);
            this.Controls.Add(this.answerBRadioButton);
            this.Controls.Add(this.answerCRadioButton);
            this.Controls.Add(this.answerDRadioButton);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.loadTestsButton);
            this.Controls.Add(this.testsListBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox testsListBox;
        private System.Windows.Forms.Button loadTestsButton;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.RadioButton answerDRadioButton;
        private System.Windows.Forms.RadioButton answerCRadioButton;
        private System.Windows.Forms.RadioButton answerBRadioButton;
        private System.Windows.Forms.RadioButton answerARadioButton;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.GroupBox questionGroupBox;
        private System.Windows.Forms.GroupBox testsGroupBox;
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
    }
}

