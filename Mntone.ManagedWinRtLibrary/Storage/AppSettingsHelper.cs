using Windows.Storage;

namespace Mntone.ManagedWinRtLibrary.Storage
{
	public static class AppConfigHelper
	{
		public static bool HasLocalValue(string name)
		{
			var values = ApplicationData.Current.LocalSettings.Values;
			return values.ContainsKey(name);
		}

		public static T GetLocalValue<T>(string name, T defaultValue)
		{
			var values = ApplicationData.Current.LocalSettings.Values;
			try
			{
				if (values.ContainsKey(name)) return (T)values[name];
			}
			catch { }
			return defaultValue;
		}

		public static void SetLocalValue<T>(string name, T value)
		{
			var settings = ApplicationData.Current.LocalSettings;
			try
			{
				if (settings.Values.ContainsKey(name))
				{
					settings.Values[name] = value;
				}
				else
				{
					settings.Values.Add(name, value);
				}
			}
			catch { }
		}

		public static bool HasRoaminglValue(string name)
		{
			var values = ApplicationData.Current.RoamingSettings.Values;
			return values.ContainsKey(name);
		}

		public static T GetRoamingValue<T>(string name, T defaultValue)
		{
			var values = ApplicationData.Current.RoamingSettings.Values;
			try
			{
				if (values.ContainsKey(name)) return (T)values[name];
			}
			catch { }
			return defaultValue;
		}

		public static void SetRoamingValue<T>(string name, T value)
		{
			var settings = ApplicationData.Current.RoamingSettings;
			try
			{
				if (settings.Values.ContainsKey(name))
				{
					settings.Values[name] = value;
				}
				else
				{
					settings.Values.Add(name, value);
				}
			}
			catch { }
		}
	}
}