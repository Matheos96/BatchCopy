namespace BatchCopy
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			destinationPath.TextChanged += Browse_TextChanged;
			sourcePath.TextChanged += Browse_TextChanged;
			BatchCopy.OnProgressChanged += progress =>
			{
				if (InvokeRequired) Invoke(UpdateProgressBar, progress);
				else UpdateProgressBar(progress);
			};
		}

		// Update progress bar with new value
		private void UpdateProgressBar(int progress) => progressBar.Value = progress;

		// Enable Copy button if we have two paths that are not empty
		private void Browse_TextChanged(object? sender, EventArgs e) 
			=> copyBtn.Enabled = !string.IsNullOrWhiteSpace(destinationPath.Text) && !string.IsNullOrWhiteSpace(sourcePath.Text);
			

		private void BrowseSourceClick(object sender, EventArgs e) => BrowseTextBoxClick(sourcePath);
		//{
		//	using var dialog = new FolderBrowserDialog();
		//	if (!string.IsNullOrEmpty(destinationPath.Text)) dialog.SelectedPath = sourcePath.Text;
		//	if (dialog.ShowDialog() == DialogResult.OK) sourcePath.Text = dialog.SelectedPath;
		//}

		private void BrowseDestinationClick(object sender, EventArgs e) => BrowseTextBoxClick(destinationPath);
		//{
		//	using var dialog = new FolderBrowserDialog();
		//	if (!string.IsNullOrEmpty(destinationPath.Text)) dialog.SelectedPath = destinationPath.Text;
		//	if (dialog.ShowDialog() == DialogResult.OK) destinationPath.Text = dialog.SelectedPath;
		//}

		private static void BrowseTextBoxClick(TextBox textbox)
		{
			using var dialog = new FolderBrowserDialog();
			if (!string.IsNullOrEmpty(textbox.Text)) dialog.SelectedPath = textbox.Text;
			if (dialog.ShowDialog() == DialogResult.OK) textbox.Text = dialog.SelectedPath;
		}

		private void CopyBtnClick(object sender, EventArgs e)
		{
			if (destinationPath.Text == sourcePath.Text)
			{
				MessageBox.Show(this, "Source and destination must be different!");
				return;
			}

			// Do not block UI thread when copying
			Task.Run(DoCopy);
		}

		private void DoCopy()
		{
			var success = BatchCopy.TryCopy(fileNames.Text, sourcePath.Text, destinationPath.Text, overwriteCheck.Checked, out var resultMessage);
			var message = success
				? $"Done!\n{resultMessage}"
				: $"Something went wrong.\n{resultMessage}";

			// Ensure we show messagebox from UI Thread
			if (InvokeRequired) Invoke(ShowResultMessage, message);
			else ShowResultMessage(message);
		}

		private void ShowResultMessage(string message) => MessageBox.Show(this, message);
	}
}
