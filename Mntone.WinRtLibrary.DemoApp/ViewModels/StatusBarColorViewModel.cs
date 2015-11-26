namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class StatusBarColorViewModel : NotificationObject
	{
		public bool IsApiEnabled => ManagedWinRtLibrary.UI.Xaml.Interactions.StatusBarColorBehavior.IsApiEnabled;
        public bool IsApiDisabled => !this.IsApiEnabled;

		public ColorViewModel ForegroundColor
		{
			get { return this._ForegroundColor; }
			set { this.SetValue(ref this._ForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ForegroundColor = new ColorViewModel(255, 255, 255);

		public ColorViewModel BackgroundColor
		{
			get { return this._BackgroundColor; }
			set { this.SetValue(ref this._BackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _BackgroundColor = new ColorViewModel();

		public double BackgroundOpacity
		{
			get { return this._BackgroundOpacity; }
			set { this.SetValue(ref this._BackgroundOpacity, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private double _BackgroundOpacity = 1.0;
	}
}