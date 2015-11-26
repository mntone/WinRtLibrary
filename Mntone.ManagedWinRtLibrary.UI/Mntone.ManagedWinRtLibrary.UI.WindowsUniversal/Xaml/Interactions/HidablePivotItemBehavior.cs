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
		{ }

		protected override void OnDetaching()
		{
			this._index = -1;
			this._parent = null;
		}

		private static void OnIsVisiblePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (HidablePivotItemBehavior)d;
			var flag = (bool)e.NewValue;

			if (that._parent == null)
			{
				var parentPivot = (Pivot)that.TypedAssociatedObject.Parent;
				if (parentPivot == null) return;

				that._parent = parentPivot;
			}

			var items = that._parent.Items;
			var target = that.TypedAssociatedObject;
			if (flag)
			{
				if (!items.Contains(target))
				{
					if (that._index < 0 || that._index >= items.Count)
					{
						items.Add(target);
					}
					else
					{
						items.Insert(that._index, target);
					}
					that._index = -1;
				}
			}
			else
			{
				if (items.Contains(target))
				{
					that._index = items.IndexOf(target);
					items.Remove(target);
				}
			}
		}
	}
}
