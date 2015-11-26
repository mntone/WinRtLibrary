namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class MainPageViewModel
	{
		public KeyTriggerViewModel KeyTrigger { get; }
		public StatusBarColorViewModel StatusBarColor { get; } = new StatusBarColorViewModel();
		public StatusBarProgressIndicatorViewModel StatusBarProgressIndicator { get; } = new StatusBarProgressIndicatorViewModel();
		public TitleBarColorViewModel TitleBarColor { get; } = new TitleBarColorViewModel();
		public WindowTitleViewModel WindowTitle { get; } = new WindowTitleViewModel();
		public HidablePivotItemViewModel HidablePivotItem { get; } = new HidablePivotItemViewModel();

		public DisplaySizeViewModel DisplaySize { get; } = new DisplaySizeViewModel();

		public LogViewModel Log { get; } = new LogViewModel();

		public MainPageViewModel()
		{
			this.KeyTrigger = new KeyTriggerViewModel(this);
		}
	}
}