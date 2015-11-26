using Microsoft.Xaml.Interactivity;
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	[TypeConstraint(typeof(Page))]
	public sealed class TitleBarColorBehavior : Behavior<Page>
	{
		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ForegroundColor
		{
			get { return (Color?)base.GetValue(ForegroundColorProperty); }
			set { base.SetValue(ForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ForegroundColorProperty
			= DependencyProperty.Register(nameof(ForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? BackgroundColor
		{
			get { return (Color?)base.GetValue(BackgroundColorProperty); }
			set { base.SetValue(BackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty BackgroundColorProperty
			= DependencyProperty.Register(nameof(BackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? InactiveForegroundColor
		{
			get { return (Color?)base.GetValue(InactiveForegroundColorProperty); }
			set { base.SetValue(InactiveForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty InactiveForegroundColorProperty
			= DependencyProperty.Register(nameof(InactiveForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnInactiveForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? InactiveBackgroundColor
		{
			get { return (Color?)base.GetValue(InactiveBackgroundColorProperty); }
			set { base.SetValue(InactiveBackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty InactiveBackgroundColorProperty
			= DependencyProperty.Register(nameof(InactiveBackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnInactiveBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonForegroundColor
		{
			get { return (Color?)base.GetValue(ButtonForegroundColorProperty); }
			set { base.SetValue(ButtonForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonForegroundColorProperty
			= DependencyProperty.Register(nameof(ButtonForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonBackgroundColor
		{
			get { return (Color?)base.GetValue(ButtonBackgroundColorProperty); }
			set { base.SetValue(ButtonBackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonBackgroundColorProperty
			= DependencyProperty.Register(nameof(ButtonBackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonHoverForegroundColor
		{
			get { return (Color?)base.GetValue(ButtonHoverForegroundColorProperty); }
			set { base.SetValue(ButtonHoverForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonHoverForegroundColorProperty
			= DependencyProperty.Register(nameof(ButtonHoverForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonHoverForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonHoverBackgroundColor
		{
			get { return (Color?)base.GetValue(ButtonHoverBackgroundColorProperty); }
			set { base.SetValue(ButtonHoverBackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonHoverBackgroundColorProperty
			= DependencyProperty.Register(nameof(ButtonHoverBackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonHoverBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonPressedForegroundColor
		{
			get { return (Color?)base.GetValue(ButtonPressedForegroundColorProperty); }
			set { base.SetValue(ButtonPressedForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonPressedForegroundColorProperty
			= DependencyProperty.Register(nameof(ButtonPressedForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonPressedForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonPressedBackgroundColor
		{
			get { return (Color?)base.GetValue(ButtonPressedBackgroundColorProperty); }
			set { base.SetValue(ButtonPressedBackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonPressedBackgroundColorProperty
			= DependencyProperty.Register(nameof(ButtonPressedBackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonPressedBackgroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonInactiveForegroundColor
		{
			get { return (Color?)base.GetValue(ButtonInactiveForegroundColorProperty); }
			set { base.SetValue(ButtonInactiveForegroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonInactiveForegroundColorProperty
			= DependencyProperty.Register(nameof(ButtonInactiveForegroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonInactiveForegroundColorChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public Color? ButtonInactiveBackgroundColor
		{
			get { return (Color?)base.GetValue(ButtonInactiveBackgroundColorProperty); }
			set { base.SetValue(ButtonInactiveBackgroundColorProperty, value); }
		}
		public static readonly DependencyProperty ButtonInactiveBackgroundColorProperty
			= DependencyProperty.Register(nameof(ButtonInactiveBackgroundColor), typeof(object), typeof(TitleBarColorBehavior), PropertyMetadata.Create((object)null, OnButtonInactiveBackgroundColorChanged));


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

		private void Apply()
		{
			var titleBar = TitleBar;
			titleBar.ForegroundColor = this.ForegroundColor;
			titleBar.BackgroundColor = this.BackgroundColor;
			titleBar.InactiveForegroundColor = this.InactiveForegroundColor;
			titleBar.InactiveBackgroundColor = this.InactiveBackgroundColor;
			titleBar.ButtonForegroundColor = this.ButtonForegroundColor;
			titleBar.ButtonBackgroundColor = this.ButtonBackgroundColor;
			titleBar.ButtonHoverForegroundColor = this.ButtonHoverForegroundColor;
			titleBar.ButtonHoverBackgroundColor = this.ButtonHoverBackgroundColor;
			titleBar.ButtonPressedForegroundColor = this.ButtonPressedForegroundColor;
			titleBar.ButtonPressedBackgroundColor = this.ButtonPressedBackgroundColor;
			titleBar.ButtonInactiveForegroundColor = this.ButtonInactiveForegroundColor;
			titleBar.ButtonInactiveBackgroundColor = this.ButtonInactiveBackgroundColor;
		}

		private void Unapply()
		{
			var titleBar = TitleBar;
			titleBar.ForegroundColor = null;
			titleBar.BackgroundColor = null;
			titleBar.InactiveForegroundColor = null;
			titleBar.InactiveBackgroundColor = null;
			titleBar.ButtonForegroundColor = null;
			titleBar.ButtonBackgroundColor = null;
			titleBar.ButtonHoverForegroundColor = null;
			titleBar.ButtonHoverBackgroundColor = null;
			titleBar.ButtonPressedForegroundColor = null;
			titleBar.ButtonPressedBackgroundColor = null;
			titleBar.ButtonInactiveForegroundColor = null;
			titleBar.ButtonInactiveBackgroundColor = null;
		}

		private static void OnForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ForegroundColor = (Color?)e.NewValue;
		}

		private static void OnBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.BackgroundColor = (Color?)e.NewValue;
		}

		private static void OnInactiveForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.InactiveForegroundColor = (Color?)e.NewValue;
		}

		private static void OnInactiveBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.InactiveBackgroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonForegroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonBackgroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonHoverForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonHoverForegroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonHoverBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonHoverBackgroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonPressedForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonPressedForegroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonPressedBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonPressedBackgroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonInactiveForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonInactiveForegroundColor = (Color?)e.NewValue;
		}

		private static void OnButtonInactiveBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (TitleBarColorBehavior)d;
			if (that._isEnabled) TitleBar.ButtonInactiveBackgroundColor = (Color?)e.NewValue;
		}

		private static ApplicationViewTitleBar TitleBar => ApplicationView.GetForCurrentView().TitleBar;
	}
}