using Mntone.WinRtLibrary.DemoApp.Views;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mntone.WinRtLibrary.DemoApp
{
	sealed partial class App : Application
	{
		public App()
		{
			this.InitializeComponent();
		}
		
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached) this.DebugSettings.EnableFrameRateCounter = true;
#endif

			var currentAppView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
			currentAppView.SetPreferredMinSize(new Windows.Foundation.Size(300, 200));

			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
			{
				rootFrame = new Frame();
				rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
				rootFrame.CacheSize = 1;

				Window.Current.Content = rootFrame;
			}
			if (rootFrame.Content == null)
			{
				if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
				{
					throw new Exception("Failed to create initial page");
				}
			}

			Window.Current.Activate();
		}
	}
}