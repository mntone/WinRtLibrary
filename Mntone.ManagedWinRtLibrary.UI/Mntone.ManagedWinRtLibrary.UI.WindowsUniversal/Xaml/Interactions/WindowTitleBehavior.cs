using Microsoft.Xaml.Interactivity;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#if !WINDOWS_UWP
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
#endif

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


#if !WINDOWS_UWP
		private bool _isEnabled = false;
#endif

		protected override void OnAttached()
		{
#if WINDOWS_UWP
			this.Apply();
#else
			this._isEnabled = true;
			this.Apply();
			this.AssociatedObject.Loaded += this.OnLoaded;
			this.AssociatedObject.Unloaded += this.OnUnloaded;
#endif
		}

		protected override void OnDetaching()
		{
#if WINDOWS_UWP
			this.Unapply();
#else
			this.AssociatedObject.Loaded -= this.OnLoaded;
			this.AssociatedObject.Unloaded -= this.OnUnloaded;
			this.Unapply();
			this._isEnabled = false;
#endif
		}

#if !WINDOWS_UWP
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (!this._isEnabled)
			{
				this._isEnabled = true;
				this.Apply();
			}
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			if (this._isEnabled)
			{
				this.Unapply();
				this._isEnabled = false;
			}
		}
#endif

		private void Apply() => ApplicationView.Title = this.Title;
		private void Unapply() => ApplicationView.Title = string.Empty;

		private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (WindowTitleBehavior)d;
#if !WINDOWS_UWP
			if (that._isEnabled)
#endif
				ApplicationView.Title = (string)e.NewValue;
		}

		private static ApplicationView ApplicationView => ApplicationView.GetForCurrentView();
	}
}
