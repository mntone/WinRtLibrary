using Microsoft.Xaml.Interactivity;
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	[TypeConstraint(typeof(PivotItem))]
	public sealed class HidablePivotItemBehavior : Behavior<PivotItem>
	{
		private Pivot _parent = null;
		private int _index = -1;

		public bool IsVisible
		{
			get { return (bool)base.GetValue(IsVisibleProperty); }
			set { base.SetValue(IsVisibleProperty, value); }
		}
		public static readonly DependencyProperty IsVisibleProperty
			= DependencyProperty.Register(
				nameof(IsVisible),
				typeof(bool),
				typeof(HidablePivotItemBehavior),
				PropertyMetadata.Create(true, OnIsVisiblePropertyChanged));

		protected override void OnAttached()
		{
			this.AssociatedObject.LayoutUpdated += this.OnLayoutUpdated;
		}

		protected override void OnDetaching()
		{
#if !WINDOWS_UWP
			this._index = -1;
			this._parent = null;
#endif
		}

		private void OnLayoutUpdated(object sender, object e)
		{
			this.AssociatedObject.LayoutUpdated -= this.OnLayoutUpdated;
			this.ApplyVisible(this.IsVisible);
		}

		private void ApplyVisible(bool flag)
		{
			if (this._parent == null)
			{
				var parentPivot = (Pivot)this.AssociatedObject.Parent;
				if (parentPivot == null) return;

				this._parent = parentPivot;
			}

			var items = this._parent.Items;
			var target = this.AssociatedObject;
			if (flag)
			{
				if (!items.Contains(target))
				{
					if (this._index < 0 || this._index >= items.Count)
					{
						items.Add(target);
					}
					else
					{
						items.Insert(this._index, target);
					}
					this._index = -1;
				}
			}
			else
			{
				if (items.Contains(target))
				{
					this._index = items.IndexOf(target);
					items.Remove(target);
				}
			}
		}

		private static void OnIsVisiblePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (HidablePivotItemBehavior)d;
			var flag = (bool)e.NewValue;
			that.ApplyVisible(flag);
		}
	}
}
