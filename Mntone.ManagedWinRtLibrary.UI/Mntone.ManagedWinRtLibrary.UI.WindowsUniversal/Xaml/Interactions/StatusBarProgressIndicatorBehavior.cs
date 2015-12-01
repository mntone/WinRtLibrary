using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#if !WINDOWS_UWP
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
#endif

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	[TypeConstraint(typeof(Page))]
	public sealed class StatusBarProgressIndicatorBehavior : Behavior<Page>
	{
#if WINDOWS_UWP
		public static bool IsApiEnabled { get; }

		static StatusBarProgressIndicatorBehavior()
		{
			IsApiEnabled = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
		}
#endif

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public bool IsEnabled
		{
			get { return (bool)this.GetValue(IsEnabledProperty); }
			set { this.SetValue(IsEnabledProperty, value); }
		}
		public static readonly DependencyProperty IsEnabledProperty
			= DependencyProperty.Register(nameof(IsEnabled), typeof(bool), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(true, OnIsEnabledChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public bool IsIndeterminate
		{
			get { return (bool)this.GetValue(IsIndeterminateProperty); }
			set { this.SetValue(IsIndeterminateProperty, value); }
		}
		public static readonly DependencyProperty IsIndeterminateProperty
			= DependencyProperty.Register(nameof(IsIndeterminate), typeof(bool), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(false, OnValueChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public string Text
		{
			get { return (string)this.GetValue(TextProperty); }
			set { this.SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty TextProperty
			= DependencyProperty.Register(nameof(Text), typeof(string), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(string.Empty, OnTextChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public double MinValue
		{
			get { return (double)this.GetValue(MinValueProperty); }
			set { this.SetValue(MinValueProperty, value); }
		}
		public static readonly DependencyProperty MinValueProperty
			= DependencyProperty.Register(nameof(MinValue), typeof(double), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(0.0, OnValueChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public double MaxValue
		{
			get { return (double)this.GetValue(MaxValueProperty); }
			set { this.SetValue(MaxValueProperty, value); }
		}
		public static readonly DependencyProperty MaxValueProperty
			= DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(1.0, OnValueChanged));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public double Value
		{
			get { return (double)this.GetValue(ValueProperty); }
			set { this.SetValue(ValueProperty, value); }
		}
		public static readonly DependencyProperty ValueProperty
			= DependencyProperty.Register(nameof(Value), typeof(double), typeof(StatusBarProgressIndicatorBehavior), PropertyMetadata.Create(0.0, OnValueChanged));


#if !WINDOWS_UWP
		private bool _isEnabled = false;
#endif
		private bool _isVisible = false;

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

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Safety", "UWP001:Platform-specific", Justification = "Safety")]
		private async void Apply()
		{
			if (this._isVisible || !this.IsEnabled) return;
			this._isVisible = true;

			var progressIndicator = ProgressIndicator;
			progressIndicator.Text = this.Text;
			if (!this.IsIndeterminate)
			{
				progressIndicator.ProgressValue = (this.Value - this.MinValue) / (this.MaxValue - this.MinValue);
			}
			await progressIndicator.ShowAsync();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Safety", "UWP001:Platform-specific", Justification = "Safety")]
		private async void Unapply()
		{
			if (!this._isVisible) return;

			var progressIndicator = ProgressIndicator;
			progressIndicator.Text = this.Text;
			progressIndicator.ProgressValue = null;
			await progressIndicator.HideAsync();

			this._isVisible = false;
		}

		private void UpdateProgress()
		{
			if (!this.IsIndeterminate)
			{
				ProgressIndicator.ProgressValue = (this.Value - this.MinValue) / (this.MaxValue - this.MinValue);
			}
			else
			{
				ProgressIndicator.ProgressValue = null;
			}
		}

		private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarProgressIndicatorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled)
#else
			if (that._isEnabled)
#endif
			{
				if ((bool)e.NewValue) that.Apply();
				else that.Unapply();
			}
		}

		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarProgressIndicatorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled && that._isVisible)
#else
			if (that._isEnabled && that._isVisible)
#endif
			{
				ProgressIndicator.Text = (string)e.NewValue;
			}
		}

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var that = (StatusBarProgressIndicatorBehavior)d;
#if WINDOWS_UWP
			if (IsApiEnabled && that._isVisible)
#else
			if (that._isEnabled && that._isVisible)
#endif
			{
				that.UpdateProgress();
			}
		}

		private static StatusBarProgressIndicator ProgressIndicator => StatusBar.GetForCurrentView().ProgressIndicator;
	}
}