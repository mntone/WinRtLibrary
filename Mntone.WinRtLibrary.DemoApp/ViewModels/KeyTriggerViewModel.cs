using Mntone.ManagedWinRtLibrary.UI.Xaml.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.System;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class VirtualKeyViewModel : EnumViewModel<VirtualKey> { public VirtualKeyViewModel(VirtualKey value) : base(value) { } }
	public sealed class KeyPressedStateViewModel : EnumViewModel<KeyPressedState> { public KeyPressedStateViewModel(KeyPressedState value) : base(value) { } }

	public sealed class KeyTriggerViewModel : NotificationObject
	{
		public MainPageViewModel Parent { get; }

		public KeyTriggerViewModel(MainPageViewModel parent)
		{
			this.Parent = parent;
			this.VirtualKeys = Enum.GetValues(typeof(VirtualKey)).Cast<VirtualKey>().Select(e => new VirtualKeyViewModel(e)).ToList();
			this.PressedStates = Enum.GetValues(typeof(KeyPressedState)).Cast<KeyPressedState>().Select(e => new KeyPressedStateViewModel(e)).ToList();
		}

		public List<VirtualKeyViewModel> VirtualKeys { get; }
		public List<KeyPressedStateViewModel> PressedStates { get; }

		public VirtualKey Key
		{
			get { return this._Key; }
			set { this.SetValue(ref this._Key, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private VirtualKey _Key = VirtualKey.Escape;

		public VirtualKeyViewModel KeyVM
		{
			get { return this.VirtualKeys.Find(vm => vm.Value == this.Key); }
			set { this.Key = value.Value; }
		}

		public KeyPressedState ShiftKeyState
		{
			get { return this._ShiftKeyState; }
			set { this.SetValue(ref this._ShiftKeyState, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private KeyPressedState _ShiftKeyState = KeyPressedState.None;

		public KeyPressedStateViewModel ShiftKeyStateVM
		{
			get { return this.PressedStates.Find(vm => vm.Value == this.ShiftKeyState); }
			set { this.ShiftKeyState = value.Value; }
		}

		public KeyPressedState ControlKeyState
		{
			get { return this._ControlKeyState; }
			set { this.SetValue(ref this._ControlKeyState, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private KeyPressedState _ControlKeyState = KeyPressedState.None;

		public KeyPressedStateViewModel ControlKeyStateVM
		{
			get { return this.PressedStates.Find(vm => vm.Value == this.ControlKeyState); }
			set { this.ControlKeyState = value.Value; }
		}

		public KeyPressedState MenuKeyState
		{
			get { return this._MenuKeyState; }
			set { this.SetValue(ref this._MenuKeyState, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private KeyPressedState _MenuKeyState = KeyPressedState.None;

		public KeyPressedStateViewModel MenuKeyStateVM
		{
			get { return this.PressedStates.Find(vm => vm.Value == this.MenuKeyState); }
			set { this.MenuKeyState = value.Value; }
		}

		public KeyPressedState WindowsKeyState
		{
			get { return this._WindowsKeyState; }
			set { this.SetValue(ref this._WindowsKeyState, value); }
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private KeyPressedState _WindowsKeyState = KeyPressedState.All;

		public KeyPressedStateViewModel WindowsKeyStateVM
		{
			get { return this.PressedStates.Find(vm => vm.Value == this.WindowsKeyState); }
			set { this.WindowsKeyState = value.Value; }
		}

		public ICommand LogCommand
		{
			get { return this._LogCommand ?? (this._LogCommand = new RelayCommand(() => this.Parent.Log.Add($"{this.Key} is pressed."))); }
		}
		private ICommand _LogCommand = null;
	}
}