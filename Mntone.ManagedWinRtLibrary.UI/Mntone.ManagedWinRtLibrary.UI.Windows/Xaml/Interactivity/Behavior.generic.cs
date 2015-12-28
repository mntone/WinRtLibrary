using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class Behavior<T> : Behavior
		where T : DependencyObject
	{
		protected internal override void AttachCheck(DependencyObject associatedObject)
		{
			if (!typeof(T).GetTypeInfo().IsAssignableFrom(associatedObject.GetType().GetTypeInfo()))
			{
				var actualType = associatedObject.GetType().FullName;
				var expectedType = typeof(T).FullName;
				var message = string.Format("AssociatedObject is of type {0} but should be of type {1}.", actualType, expectedType);
				throw new InvalidOperationException(message);
			}
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public new T AssociatedObject
		{
			get { return (T)base.AssociatedObject; }
		}
	}
}
