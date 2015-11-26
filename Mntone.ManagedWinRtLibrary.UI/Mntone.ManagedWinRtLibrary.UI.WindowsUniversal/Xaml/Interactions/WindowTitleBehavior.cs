using Microsoft.Xaml.Interactivity;
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	public sealed class WindowTitleBehavior : Behavior<Page>
	{
		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public string Title
		{
			get { return (string)base.GetValue(TitleProperty); }
			set { base.SetValue(TitleProperty, value); }
		}
		public static readonly DependencyProperty TitleProperty
			= DependencyProperty.Register(nameof(Title), typeof(string), typeof(WindowTitleBehavior), PropertyMetadata.Create(string.Empty, OnTitleChanged));


		private bool _isEnabled = false;

		protected override void OnAttached()
		{
			this._isEnabled = true;
			this.Apply();
			this.TypedAssociatedObject.Loaded += this.OnLoaded;
			this.TypedAssociatedObject.Unloaded += this.OnUnloaded;
		}

		protected override void OnDetaching()
		{
			this.TypedAssociatedObject.Loaded -= this.OnLoaded;
			this.TypedAssociatedObject.Unloaded -= this.OnUnloaded;
			this.Unapply();
			this._isEnabled = false;
		}
		
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			this._isEnabled = true;
			this.Apply();
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			if (this._isEnabled)
			{
				this.Unapply();
				this._isEnabled = false;
			}
		}

		private void Apply() => ApplicationView.Title = this.Title;
		private void Unapply() => ApplicationView.Title = string.Empty;

		private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (WindowTitleBehavior)d;
			if (that._isEnabled) ApplicationView.Title = (string)e.NewValue;
		}

		private static ApplicationView ApplicationView => ApplicationView.GetForCurrentView();
	}
}
