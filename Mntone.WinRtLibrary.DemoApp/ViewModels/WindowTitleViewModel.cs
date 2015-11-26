namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class WindowTitleViewModel : NotificationObject
	{
		public string Title
		{
			get { return this._Title; }
			set { this.SetValue(ref this._Title, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Title = "Sample text";
	}
}