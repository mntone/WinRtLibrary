using System.ComponentModel;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public abstract class NotificationObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChange([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			this.RaisePropertyChange(new PropertyChangedEventArgs(propertyName));
		}
		protected void RaisePropertyChange(PropertyChangedEventArgs e) => this.PropertyChanged?.Invoke(this, e);

		protected bool SetValue<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value)) return false;

			storage = value;
			this.RaisePropertyChange(new PropertyChangedEventArgs(propertyName));
			return true;
		}

		protected bool SetValue<T>(ref T storage, T value, PropertyChangedEventArgs e)
		{
			if (object.Equals(storage, value)) return false;

			storage = value;
			this.RaisePropertyChange(e);
			return true;
		}
	}
}
