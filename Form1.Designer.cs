namespace BatchCopy
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
			fileNames = new TextBox();
			browseSource = new Button();
			browseDestination = new Button();
			sourcePath = new TextBox();
			destinationPath = new TextBox();
			copyBtn = new Button();
			label1 = new Label();
			overwriteCheck = new CheckBox();
			progressBar = new ProgressBar();
			SuspendLayout();
			// 
			// fileNames
			// 
			fileNames.Location = new Point(12, 27);
			fileNames.Multiline = true;
			fileNames.Name = "fileNames";
			fileNames.PlaceholderText = "Comma separated list of filenames without extensions - Leave empty for ALL files (folders are skipped)";
			fileNames.ScrollBars = ScrollBars.Both;
			fileNames.Size = new Size(776, 237);
			fileNames.TabIndex = 1;
			fileNames.TabStop = false;
			// 
			// browseSource
			// 
			browseSource.Location = new Point(555, 296);
			browseSource.Name = "browseSource";
			browseSource.Size = new Size(91, 23);
			browseSource.TabIndex = 1;
			browseSource.Text = "Browse";
			browseSource.UseVisualStyleBackColor = true;
			browseSource.Click += BrowseSourceClick;
			// 
			// browseDestination
			// 
			browseDestination.Location = new Point(555, 325);
			browseDestination.Name = "browseDestination";
			browseDestination.Size = new Size(91, 23);
			browseDestination.TabIndex = 2;
			browseDestination.Text = "Browse";
			browseDestination.UseVisualStyleBackColor = true;
			browseDestination.Click += BrowseDestinationClick;
			// 
			// sourcePath
			// 
			sourcePath.Location = new Point(253, 297);
			sourcePath.Name = "sourcePath";
			sourcePath.PlaceholderText = "source";
			sourcePath.Size = new Size(296, 23);
			sourcePath.TabIndex = 3;
			sourcePath.TabStop = false;
			// 
			// destinationPath
			// 
			destinationPath.Location = new Point(253, 326);
			destinationPath.Name = "destinationPath";
			destinationPath.PlaceholderText = "destination";
			destinationPath.Size = new Size(296, 23);
			destinationPath.TabIndex = 4;
			destinationPath.TabStop = false;
			// 
			// copyBtn
			// 
			copyBtn.Enabled = false;
			copyBtn.Location = new Point(355, 380);
			copyBtn.Name = "copyBtn";
			copyBtn.Size = new Size(91, 23);
			copyBtn.TabIndex = 5;
			copyBtn.Text = "Copy";
			copyBtn.UseVisualStyleBackColor = true;
			copyBtn.Click += CopyBtnClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(80, 15);
			label1.TabIndex = 0;
			label1.Text = "Included files:";
			// 
			// overwriteCheck
			// 
			overwriteCheck.AutoSize = true;
			overwriteCheck.Checked = true;
			overwriteCheck.CheckState = CheckState.Checked;
			overwriteCheck.Location = new Point(253, 355);
			overwriteCheck.Name = "overwriteCheck";
			overwriteCheck.Size = new Size(145, 19);
			overwriteCheck.TabIndex = 6;
			overwriteCheck.Text = "Overwrite existing files";
			overwriteCheck.UseVisualStyleBackColor = true;
			// 
			// progressBar
			// 
			progressBar.Location = new Point(12, 409);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(776, 23);
			progressBar.TabIndex = 7;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CausesValidation = false;
			ClientSize = new Size(800, 444);
			Controls.Add(progressBar);
			Controls.Add(overwriteCheck);
			Controls.Add(label1);
			Controls.Add(copyBtn);
			Controls.Add(destinationPath);
			Controls.Add(sourcePath);
			Controls.Add(browseDestination);
			Controls.Add(browseSource);
			Controls.Add(fileNames);
			MaximizeBox = false;
			Name = "Form1";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Batch Copy";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox fileNames;
		private Button browseSource;
		private Button browseDestination;
		private TextBox sourcePath;
		private TextBox destinationPath;
		private Button copyBtn;
		private Label label1;
		private CheckBox overwriteCheck;
		private ProgressBar progressBar;
	}
}
