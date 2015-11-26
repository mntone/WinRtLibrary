#include "pch.h"
#include "BooleanToVisibilityConverter.h"

using namespace Platform;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Interop;
using namespace Mntone::WinRtLibrary::UI::Xaml::Converters;

Object^ BooleanToVisibilityConverter::Convert(Object^ value, TypeName /*targetType*/, Object^ /*parameter*/, String^ /*language*/)
{
	auto flag = dynamic_cast<IBox<bool>^>(value);
	if (flag != nullptr)
	{
		return flag->Value ? Visibility::Visible : Visibility::Collapsed;
	}
	return DependencyProperty::UnsetValue;
}

Object^ BooleanToVisibilityConverter::ConvertBack(Object^ value, TypeName /*targetType*/, Object^ /*parameter*/, String^ /*language*/)
{
	auto visibility = dynamic_cast<IBox<Visibility>^>(value);
	if (visibility != nullptr)
	{
		return visibility->Value == Visibility::Visible ? true : false;
	}
	return nullptr;
}