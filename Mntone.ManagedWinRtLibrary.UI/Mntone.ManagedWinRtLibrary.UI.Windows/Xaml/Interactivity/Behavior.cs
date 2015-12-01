using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class Behavior : DependencyObject, IBehavior
	{
		private DependencyObject _associatedObject;

		protected Behavior() : base() { }

		public void Attach(DependencyObject associatedObject)
		{
			if (this.AssociatedObject != null) throw new InvalidOperationException();
			if (associatedObject == null) throw new ArgumentNullException(nameof(associatedObject));
			this.AttachCheck(associatedObject);

			this._associatedObject = associatedObject;
			this.OnAttached();
		}

		protected internal virtual void AttachCheck(DependencyObject associatedObject) { }

		protected abstract void OnAttached();

		public void Detach()
		{
			this.OnDetaching();
			this._associatedObject = null;
		}

		protected abstract void OnDetaching();


		public virtual DependencyObject AssociatedObject => this._associatedObject;
	}
}