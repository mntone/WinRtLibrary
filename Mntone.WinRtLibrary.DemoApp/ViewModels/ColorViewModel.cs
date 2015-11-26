using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Mntone.WinRtLibrary.DemoApp.ViewModels
{
	public sealed class ColorViewModel : NotificationObject
	{
		public ColorViewModel()
		{
			this.Update();
		}

		public ColorViewModel(byte red, byte green, byte blue)
		{
			this._Red = red;
			this._Green = green;
			this._Blue = blue;
			this.Update();
		}

		public void Update() => this.Value = Color.FromArgb(0xff, this._Red, this._Green, this._Blue);

		public int Red
		{
			get { return this._Red; }
			set
			{
				if (this.SetValue(ref this._Red, (byte)value))
				{
					this.Update();
				}
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private byte _Red = 0;

		public int Green
		{
			get { return this._Green; }
			set
			{
				if (this.SetValue(ref this._Green, (byte)value))
				{
					this.Update();
				}
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private byte _Green = 0;

		public int Blue
		{
			get { return this._Blue; }
			set
			{
				if (this.SetValue(ref this._Blue, (byte)value))
				{
					this.Update();
				}
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private byte _Blue = 0;

		public Color? Value
		{
			get { return this._Value; }
			set
			{
				if (this.SetValue(ref this._Value, value))
				{ this.RaisePropertyChange(nameof(this.Brush)); }
			}
		}
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Color? _Value = null;

		public Brush Brush => this.Value.HasValue ? new SolidColorBrush(this.Value.Value) : null;
	}
}