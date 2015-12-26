using Microsoft.Xaml.Interactivity;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#if !WINDOWS_UWP
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
#endif

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	[TypeConstraint(typeof(Page))]
	public sealed class StatusBarColorBehavior : Behavior<Page>
	{
		[System.ThreadStatic]
		private static StatusBarColorBehavior _owner = null;

#if WINDOWS_UWP
		public static bool IsApiEnabled { get; }

		static StatusBarColorBehavior()
		{
			IsApiEnabled = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
		}
#endif

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ForegroundColor
		{
			get { return (Color?)base.GetValue(ForegroundColorProperty); }
			set { base.SetValue(ForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ForegroundColorProperty
			= DependencyProperty.Register(nameof(ForegroundColor), typeof(object), typeof(StatusBarColorBehavior), PropertyMetadata.Create((object)null, OnForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? BackgroundColor
		{
			get { return (Color?)base.GetValue(BackgroundColorProperty); }
			set { base.SetValue(BackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty BackgroundColorProperty
			= DependencyProperty.Register(nameof(BackgroundColor), typeof(object), typeof(StatusBarColorBehavior), PropertyMetadata.Create((object)null, OnBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public double BackgroundOpacity
		{
			get { return (double)base.GetValue(BackgroundOpacityProperty); }
			set { base.SetValue(BackgroundOpacityProperty, value); }
		}
		public static readonly DependencyProperty BackgroundOpacityProperty
			= DependencyProperty.Register(nameof(BackgroundOpacity), typeof(double), typeof(StatusBarColorBehavior), PropertyMetadata.Create(1.0, OnBackgroundOpacityChanged));


#if !WINDOWS_UWP
		private bool _isEnabled = false;
#endif

		protected override void OnAttached()
		{
#if WINDOWS_UWP
			if (IsApiEnabled) this.Apply();
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
			if (IsApiEnabled) this.Unapply();
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

		private void Apply()
		{
			var statusBar = StatusBar;
			statusBar.ForegroundColor = this.ForegroundColor;
			statusBar.BackgroundColor = this.BackgroundColor;
			statusBar.BackgroundOpacity = this.BackgroundOpacity;
			_owner = this;
		}

		private void Unapply()
		{
			if (_owner != this) return;

			var statusBar = StatusBar;
			statusBar.ForegroundColor = null;
			statusBar.BackgroundColor = null;
			statusBar.BackgroundOpacity = 1.0;
		}

		private static void OnForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarColorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled)
#else
			if (that._isEnabled)
#endif
			{
				StatusBar.ForegroundColor = (Color?)e.NewValue;
			}
		}

		private static void OnBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarColorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled)
#else
			if (that._isEnabled)
#endif
			{
				StatusBar.BackgroundColor = (Color?)e.NewValue;
			}
		}

		private static void OnBackgroundOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarColorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled)
#else
			if (that._isEnabled)
#endif
			{
				StatusBar.BackgroundOpacity = (double)e.NewValue;
			}
		}

		private static StatusBar StatusBar => StatusBar.GetForCurrentView();
	}
}