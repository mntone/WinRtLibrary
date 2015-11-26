using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class Action : DependencyObject, IAction
	{
		public abstract object Execute(object sender, object parameter);
	}
}