namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public abstract class EnumViewModel<TEnum>
	{
		public TEnum Value { get; }
		public string Label => this.Value.ToString();

		public EnumViewModel(TEnum value)
		{
			this.Value = value;
		}
	}
}