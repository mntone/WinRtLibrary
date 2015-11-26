namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class StatusBarProgressIndicatorViewModel : NotificationObject
	{
		public bool IsApiEnabled => ManagedWinRtLibrary.UI.Xaml.Interactions.StatusBarProgressIndicatorBehavior.IsApiEnabled;
		public bool IsApiDisabled => !this.IsApiEnabled;

		public bool IsEnabled
		{
			get { return this._IsEnabled; }
			set { this.SetValue(ref this._IsEnabled, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _IsEnabled = true;

		public bool? IsIndeterminateNullable
		{
			get { return this._IsIndeterminateNullable; }
			set
			{
				if (this.SetValue(ref this._IsIndeterminateNullable, value))
				{
					this.RaisePropertyChange(nameof(this.IsIndeterminate));
				}
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool? _IsIndeterminateNullable = true;

		public bool IsIndeterminate => this.IsIndeterminateNullable ?? true;

		public string Text
		{
			get { return this._Text; }
			set { this.SetValue(ref this._Text, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private string _Text;

		public double Value
		{
			get { return this._Value; }
			set { this.SetValue(ref this._Value, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private double _Value = 0.3;

		public double MinValue
		{
			get { return this._MinValue; }
			set { this.SetValue(ref this._MinValue, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private double _MinValue = 0.0;

		public double MaxValue
		{
			get { return this._MaxValue; }
			set { this.SetValue(ref this._MaxValue, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private double _MaxValue = 1.0;
	}
}