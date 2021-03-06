#pragma once

namespace Mntone {
namespace WinRtLibrary {
namespace UI {
namespace Xaml {
namespace Converters {

[Windows::Foundation::Metadata::WebHostHidden]
public ref class BooleanToInvertedVisibilityConverter sealed
	: public ::Windows::UI::Xaml::Data::IValueConverter
{
public:
	virtual ::Platform::Object^ Convert(
		::Platform::Object^ value,
		::Windows::UI::Xaml::Interop::TypeName targetType,
		::Platform::Object^ parameter,
		::Platform::String^ language);

	virtual ::Platform::Object^ ConvertBack(
		::Platform::Object^ value,
		::Windows::UI::Xaml::Interop::TypeName targetType,
		::Platform::Object^ parameter,
		::Platform::String^ language);
};

}
}
}
}
}