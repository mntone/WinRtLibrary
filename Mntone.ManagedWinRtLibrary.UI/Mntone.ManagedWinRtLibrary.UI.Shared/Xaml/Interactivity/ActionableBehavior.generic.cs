using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class ActionableBehavior<T> : Behavior<T>
		where T : DependencyObject
	{
		protected ActionableBehavior()
		{ }

		public static readonly DependencyProperty ActionsProperty =
			DependencyProperty.Register("Actions", typeof(ActionCollection), typeof(ActionableBehavior<T>), new PropertyMetadata(null));
	}
}