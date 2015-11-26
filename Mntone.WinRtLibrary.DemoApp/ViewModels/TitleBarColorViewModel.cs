namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class TitleBarColorViewModel : NotificationObject
	{
		public ColorViewModel ForegroundColor
		{
			get { return this._ForegroundColor; }
			set { this.SetValue(ref this._ForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ForegroundColor = new ColorViewModel();

		public ColorViewModel BackgroundColor
		{
			get { return this._BackgroundColor; }
			set { this.SetValue(ref this._BackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _BackgroundColor = new ColorViewModel(255, 255, 255);

		public ColorViewModel InactiveForegroundColor
		{
			get { return this._InactiveForegroundColor; }
			set { this.SetValue(ref this._InactiveForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _InactiveForegroundColor = new ColorViewModel(0x33, 0x33, 0x33);

		public ColorViewModel InactiveBackgroundColor
		{
			get { return this._InactiveBackgroundColor; }
			set { this.SetValue(ref this._InactiveBackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _InactiveBackgroundColor = new ColorViewModel(255, 255, 255);

		public ColorViewModel ButtonForegroundColor
		{
			get { return this._ButtonForegroundColor; }
			set { this.SetValue(ref this._ButtonForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonForegroundColor = new ColorViewModel();

		public ColorViewModel ButtonBackgroundColor
		{
			get { return this._ButtonBackgroundColor; }
			set { this.SetValue(ref this._ButtonBackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonBackgroundColor = new ColorViewModel(255, 255, 255);

		public ColorViewModel ButtonHoverForegroundColor
		{
			get { return this._ButtonHoverForegroundColor; }
			set { this.SetValue(ref this._ButtonHoverForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonHoverForegroundColor = new ColorViewModel();

		public ColorViewModel ButtonHoverBackgroundColor
		{
			get { return this._ButtonHoverBackgroundColor; }
			set { this.SetValue(ref this._ButtonHoverBackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonHoverBackgroundColor = new ColorViewModel(0xdd, 0xdd, 0xdd);

		public ColorViewModel ButtonPressedForegroundColor
		{
			get { return this._ButtonPressedForegroundColor; }
			set { this.SetValue(ref this._ButtonPressedForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonPressedForegroundColor = new ColorViewModel();

		public ColorViewModel ButtonPressedBackgroundColor
		{
			get { return this._ButtonPressedBackgroundColor; }
			set { this.SetValue(ref this._ButtonPressedBackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonPressedBackgroundColor = new ColorViewModel(0xbb, 0xbb, 0xbb);

		public ColorViewModel ButtonInactiveForegroundColor
		{
			get { return this._ButtonInactiveForegroundColor; }
			set { this.SetValue(ref this._ButtonInactiveForegroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonInactiveForegroundColor = new ColorViewModel(0x99, 0x99, 0x99);

		public ColorViewModel ButtonInactiveBackgroundColor
		{
			get { return this._ButtonInactiveBackgroundColor; }
			set { this.SetValue(ref this._ButtonInactiveBackgroundColor, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ColorViewModel _ButtonInactiveBackgroundColor = new ColorViewModel(255, 255, 255);


	}
}