#include "pch.h"
#include "BooleanToInvertedVisibilityConverter.h"

using namespace Platform;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Interop;
using namespace Mntone::WinRtLibrary::UI::Xaml::Converters;

Object^ BooleanToInvertedVisibilityConverter::Convert(Object^ value, TypeName /*targetType*/, Object^ /*parameter*/, String^ /*language*/)
{
	auto flag = dynamic_cast<IBox<bool>^>(value);
	if (flag != nullptr)
	{
		return flag->Value ? Visibility::Collapsed : Visibility::Visible;
	}
	return DependencyProperty::UnsetValue;
}

Object^ BooleanToInvertedVisibilityConverter::ConvertBack(Object^ value, TypeName /*targetType*/, Object^ /*parameter*/, String^ /*language*/)
{
	auto visibility = dynamic_cast<IBox<Visibility>^>(value);
	if (visibility != nullptr)
	{
		return visibility->Value == Visibility::Collapsed ? true : false;
	}
	return nullptr;
}