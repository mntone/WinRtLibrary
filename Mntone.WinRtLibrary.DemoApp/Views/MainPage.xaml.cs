using Mntone.WinRtLibrary.DemoApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Mntone.WinRtLibrary.DemoApp.Views
{
	public sealed partial class MainPage : Page
	{
		public MainPageViewModel MainPageViewModel { get; } = new MainPageViewModel();

		public MainPage()
		{
			this.InitializeComponent();
		}
	}
}