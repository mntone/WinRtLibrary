using Mntone.WinRtLibrary.UI.ViewManagement;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class DisplaySizeViewModel
	{
		public double DisplaySize => DisplaySizeHelper.GetDisplaySize();
	}
}