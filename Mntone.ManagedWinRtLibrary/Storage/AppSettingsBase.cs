using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Windows.Storage;

namespace Mntone.ManagedWinRtLibrary.Storage
{
	public abstract class AppSettingsBase<Impl> : INotifyPropertyChanged where Impl : class, new()
	{
		private bool _disposed = false;

		protected AppSettingsBase()
		{
			ApplicationData.Current.DataChanged += this.OnDataChanged; 
		}

		protected virtual void OnDataChanged(ApplicationData sender, object args)
		{ }

		private T GetValueProxy<T>(string name, T defaultValue)
		{
			var prop = this.GetType().GetRuntimeProperty(name);
			var attr = prop.GetCustomAttribute(typeof(LocalValueAttribute));
			return attr != null ? AppConfigHelper.GetLocalValue(name, defaultValue) : AppConfigHelper.GetRoamingValue(name, defaultValue);
		}

		private bool SetValueProxy<T>(string name, T value)
		{
			var prop = this.GetType().GetRuntimeProperty(name);
			var attr = prop.GetCustomAttribute(typeof(LocalValueAttribute));
			if (attr != null)
			{
				var hasData = AppConfigHelper.HasLocalValue(name);
				if (hasData && object.Equals(AppConfigHelper.GetLocalValue(name, value), value)) return false;
				AppConfigHelper.SetLocalValue(name, value);
			}
			else
			{
				var hasData = AppConfigHelper.HasRoaminglValue(name);
				if (hasData && object.Equals(AppConfigHelper.GetRoamingValue(name, value), value)) return false;
				AppConfigHelper.SetRoamingValue(name, value);
			}
			this.RaisePropertyChanged(name);
			return true;
		}

		protected T GetValue<T>([CallerMemberName] string name = null) => this.GetValueProxy(name, default(T));
		protected T GetValue<T>(T defaultValue, [CallerMemberName] string name = null) => this.GetValueProxy(name, defaultValue);

		protected void SetValue<T>(T value, [CallerMemberName] string name = null) => this.SetValueProxy(name, value);

		protected void RaisePropertyChanged([CallerMemberName] string name = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		public event PropertyChangedEventHandler PropertyChanged;

		public static Impl Instance { get { return _instance ?? (_instance = new Impl()); } }
		private static Impl _instance;
	}
}