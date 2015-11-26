using System;
using System.Windows.Input;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute = null;
		private readonly Func<bool> _canExecute = null;

		public RelayCommand(Action execute) : this(execute, null) { }
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null) throw new ArgumentNullException(nameof(execute));
			this._execute = execute;
			this._canExecute = canExecute;
		}

		public bool CanExecute(object parameter) => this._canExecute == null ? true : this._canExecute();
		public void Execute(object parameter) => this._execute();

		public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		public event EventHandler CanExecuteChanged;
	}
}