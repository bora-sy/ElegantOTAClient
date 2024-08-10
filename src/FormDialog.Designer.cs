namespace ElegantOTAClient
{
    partial class FormDialog
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
            buttonUpdate = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            progressBar = new ProgressBar();
            labelProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonUpdate.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonUpdate.Location = new Point(12, 12);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(317, 62);
            buttonUpdate.TabIndex = 0;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.NotifyFilter = NotifyFilters.LastAccess;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 12);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(249, 62);
            progressBar.TabIndex = 1;
            progressBar.Visible = false;
            // 
            // labelProgress
            // 
            labelProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            labelProgress.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelProgress.Location = new Point(267, 12);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(62, 62);
            labelProgress.TabIndex = 2;
            labelProgress.Text = "%000";
            labelProgress.TextAlign = ContentAlignment.MiddleLeft;
            labelProgress.Visible = false;
            // 
            // FormDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 90);
            Controls.Add(labelProgress);
            Controls.Add(progressBar);
            Controls.Add(buttonUpdate);
            KeyPreview = true;
            Name = "FormDialog";
            Text = "FormDialog";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpdate;
        private FileSystemWatcher fileSystemWatcher1;
        private ProgressBar progressBar;
        private Label labelProgress;
    }
}