using System;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class Behavior<T> : Behavior
		where T : DependencyObject
	{
		protected Behavior()
			: base(typeof(T))
		{ }

		public T TypedAssociatedObject => (T)this.AssociatedObject;
		public sealed override Type AssociatedType => base.AssociatedType;
	}
}
