using Microsoft.Xaml.Interactivity;
using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity
{
	public abstract class Behavior : DependencyObject, IBehavior
	{
		private readonly Type _associatedType;

		private DependencyObject _associatedObject;

		protected Behavior(Type associatedType)
			: base()
		{
			this._associatedType = associatedType;
		}

		public void Attach(DependencyObject dependencyObject)
		{
			if (this.AssociatedObject != dependencyObject)
			{
				if (this.AssociatedObject != null)
				{
					// TODO: message
					throw new InvalidOperationException();
				}

				if (dependencyObject == null) throw new ArgumentNullException(nameof(dependencyObject));
				if (!this.AssociatedType.GetTypeInfo().IsAssignableFrom(dependencyObject.GetType().GetTypeInfo()))
				{
					// TODO: message
					throw new InvalidOperationException();
				}

				this._associatedObject = dependencyObject;
				this.RaiseAssociatedObjectChanged();

				this.OnAttached();
			}
		}

		protected abstract void OnAttached();

		public void Detach()
		{
			this.OnDetaching();
			this._associatedObject = null;
			this.RaiseAssociatedObjectChanged();
		}

		protected abstract void OnDetaching();


		public EventHandler AssociatedObjectChanged;
		private void RaiseAssociatedObjectChanged() => this.AssociatedObjectChanged?.Invoke(this, EventArgs.Empty);

		public virtual DependencyObject AssociatedObject => this._associatedObject;
		public virtual Type AssociatedType => this._associatedType;
	}
}