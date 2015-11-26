#include "pch.h"
#include "DisplaySizeHelper.h"

#include <sysinfoapi.h>

using namespace Mntone::WinRtLibrary::UI::ViewManagement;

DisplaySizeHelper::DisplaySizeHelper()
{ }

float64 DisplaySizeHelper::GetDisplaySize()
{
	float64 displaySize;
	HRESULT result = GetIntegratedDisplaySize(&displaySize);
	if (FAILED(result)) throw ref new Platform::COMException(result);
	return displaySize;
}