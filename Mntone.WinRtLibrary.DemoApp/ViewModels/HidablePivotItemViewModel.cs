using System.Windows.Input;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class HidablePivotItemViewModel : NotificationObject
	{
		public bool? IsVisibleNullable
		{
			get { return this._IsVisibleNullable; }
			set
			{
				if (this.SetValue(ref this._IsVisibleNullable, value))
				{
					this.RaisePropertyChange(nameof(this.IsVisible));
				}
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool? _IsVisibleNullable = true;

		public bool IsVisible => this.IsVisibleNullable ?? true;

		public ICommand HideCommand
		{
			get { return this._HideCommand ?? (this._HideCommand = new RelayCommand(() => this.IsVisibleNullable = false)); }
		}
		private ICommand _HideCommand = null;
	}
}