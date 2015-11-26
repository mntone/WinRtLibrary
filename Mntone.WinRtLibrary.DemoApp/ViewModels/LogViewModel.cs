using System.Collections.ObjectModel;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class LogViewModel
	{
		public ObservableCollection<string> Log { get; } = new ObservableCollection<string>();

		public void Add(string text) => this.Log.Insert(0, text);
	}
}