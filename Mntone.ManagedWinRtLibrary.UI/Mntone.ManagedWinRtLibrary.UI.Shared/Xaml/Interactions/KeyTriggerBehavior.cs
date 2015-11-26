using Microsoft.Xaml.Interactivity;
using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactivity;
using System.Linq;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions
{
	[TypeConstraint(typeof(UIElement))]
	[ContentProperty(Name = "Actions")]
	public sealed class KeyTriggerBehavior : ActionableBehavior<UIElement>
	{
		public ActionCollection Actions
		{
			get
			{
				var actions = (ActionCollection)base.GetValue(ActionsProperty);
				if (actions == null)
				{
					actions = new ActionCollection();
					base.SetValue(ActionsProperty, actions);
				}
				return actions;
			}
		}

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public VirtualKey Key
		{
			get { return (VirtualKey)base.GetValue(KeyProperty); }
			set { base.SetValue(KeyProperty, value); }
		}
		public static readonly DependencyProperty KeyProperty
			= DependencyProperty.Register(nameof(Key), typeof(VirtualKey), typeof(KeyTriggerBehavior), PropertyMetadata.Create(VirtualKey.None));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public KeyPressedState ShiftKeyState
		{
			get { return (KeyPressedState)base.GetValue(ShiftKeyStateProperty); }
			set { base.SetValue(ShiftKeyStateProperty, value); }
		}
		public static readonly DependencyProperty ShiftKeyStateProperty
			= DependencyProperty.Register(nameof(ShiftKeyState), typeof(KeyPressedState), typeof(KeyTriggerBehavior), PropertyMetadata.Create(KeyPressedState.None));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public KeyPressedState ControlKeyState
		{
			get { return (KeyPressedState)base.GetValue(ControlKeyStateProperty); }
			set { base.SetValue(ControlKeyStateProperty, value); }
		}
		public static readonly DependencyProperty ControlKeyStateProperty
			= DependencyProperty.Register(nameof(ControlKeyState), typeof(KeyPressedState), typeof(KeyTriggerBehavior), PropertyMetadata.Create(KeyPressedState.None));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public KeyPressedState MenuKeyState
		{
			get { return (KeyPressedState)base.GetValue(MenuKeyStateProperty); }
			set { base.SetValue(MenuKeyStateProperty, value); }
		}
		public static readonly DependencyProperty MenuKeyStateProperty
			= DependencyProperty.Register(nameof(MenuKeyState), typeof(KeyPressedState), typeof(KeyTriggerBehavior), PropertyMetadata.Create(KeyPressedState.None));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public KeyPressedState WindowsKeyState
		{
			get { return (KeyPressedState)base.GetValue(WindowsKeyStateProperty); }
			set { base.SetValue(WindowsKeyStateProperty, value); }
		}
		public static readonly DependencyProperty WindowsKeyStateProperty
			= DependencyProperty.Register(nameof(WindowsKeyState), typeof(KeyPressedState), typeof(KeyTriggerBehavior), PropertyMetadata.Create(KeyPressedState.All));

		[CustomPropertyValueEditor(CustomPropertyValueEditor.PropertyBinding)]
		public bool ActiveOnFocus
		{
			get { return (bool)base.GetValue(ActiveOnFocusProperty); }
			set { base.SetValue(ActiveOnFocusProperty, value); }
		}
		public static readonly DependencyProperty ActiveOnFocusProperty
			= DependencyProperty.Register(nameof(ActiveOnFocus), typeof(bool), typeof(KeyTriggerBehavior), PropertyMetadata.Create(false, OnActionOnFocusChanged));


		private UIElement _targetObject = null;

		protected override void OnAttached() => this.Hook();
		protected override void OnDetaching() => this.Unhook();

		private void Hook()
		{
			if (this._targetObject != null) return;

			var target = this.ActiveOnFocus ? (UIElement)this.AssociatedObject : GetRoot(this.AssociatedObject);
			target.KeyDown += this.OnKeyDown;
			this._targetObject = target;
		}

		private void Unhook()
		{
			if (this._targetObject == null) return;

			this._targetObject.KeyDown -= this.OnKeyDown;
			this._targetObject = null;
		}

		private void OnKeyDown(object sender, KeyRoutedEventArgs e)
		{
			var coreWindow = Window.Current.CoreWindow;
			var passed = CheckModifiers(coreWindow) && this.Key == e.Key;
			if (passed)
			{
				e.Handled = Interaction.ExecuteActions(this, this.Actions, e).Select(r =>
				{
					var bRet = r as bool?;
					if (bRet.HasValue) return bRet.Value;
					return true;
				}).Any();
			}
		}

		private bool CheckModifiers(CoreWindow target)
		{
			return CheckModifier(target, VirtualKey.Shift, VirtualKey.LeftShift, VirtualKey.RightShift, this.ShiftKeyState)
				&& CheckModifier(target, VirtualKey.Control, VirtualKey.LeftControl, VirtualKey.RightControl, this.ControlKeyState)
				&& CheckModifier(target, VirtualKey.Menu, VirtualKey.LeftMenu, VirtualKey.RightMenu, this.MenuKeyState)
				&& CheckModifier(target, null, VirtualKey.LeftWindows, VirtualKey.RightWindows, this.WindowsKeyState);
		}

		private static bool CheckModifier(CoreWindow target, VirtualKey? key, VirtualKey leftKey, VirtualKey rightKey, KeyPressedState state)
		{
			if (state == KeyPressedState.All) return true;

			var downState = CoreVirtualKeyStates.Down;
			if (state == KeyPressedState.Pressed)
			{
				if (!key.HasValue)
				{
					var l = (target.GetKeyState(leftKey) & downState) == downState;
					var r = (target.GetKeyState(rightKey) & downState) == downState;
					return l || r;
				}

				var pressed = (target.GetKeyState(key.Value) & downState) == downState;
				return pressed;
			}

			var left = (target.GetKeyState(leftKey) & downState) == downState;
			var right = (target.GetKeyState(rightKey) & downState) == downState;

			if (left)
			{
				if (right) return state == KeyPressedState.Both;
				return state == KeyPressedState.LeftOnly;
			}
			if (right) return state == KeyPressedState.RightOnly;
			return state == KeyPressedState.None;
		}

		private static void OnActionOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var self = (KeyTriggerBehavior)d;
			self.Unhook();
			self.Hook();
		}

		private static UIElement GetRoot(DependencyObject current)
		{
			UIElement result = null;
			while (current != null)
			{
				result = current as UIElement;
				current = VisualTreeHelper.GetParent(current);
			}
			return result;
		}
	}
}