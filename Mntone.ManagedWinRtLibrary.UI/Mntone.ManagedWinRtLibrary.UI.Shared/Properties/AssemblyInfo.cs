using Mntone.ManagedWinRtLibrary.UI.Internal;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(AssemblyInfo.QualifiedName)]
[assembly: AssemblyDescription(AssemblyInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.Author)]
[assembly: AssemblyProduct(AssemblyInfo.QualifiedName)]
[assembly: AssemblyCopyright("Copyright (C) 2015- " + AssemblyInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion(AssemblyInfo.Version)]
[assembly: AssemblyFileVersion(AssemblyInfo.Version)]
[assembly: ComVisible(false)]

namespace Mntone.ManagedWinRtLibrary.UI.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.ManagedWinRtLibrary.UI";
		public const string QualifiedName = "Mntone WinRT Library (Managed.UI)";
		public const string Description = ManagedWinRtLibrary.Internal.AssemblyInfo.Description;
		public const string Version = ManagedWinRtLibrary.Internal.AssemblyInfo.Version;
		public const string Author = ManagedWinRtLibrary.Internal.AssemblyInfo.Author;
	}
}