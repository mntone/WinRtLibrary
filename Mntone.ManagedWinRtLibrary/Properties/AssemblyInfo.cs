using Mntone.ManagedWinRtLibrary.Internal;
using System.Reflection;
using System.Runtime.CompilerServices;
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

[assembly: InternalsVisibleTo("Mntone.ManagedWinRtLibrary.UI")]

namespace Mntone.ManagedWinRtLibrary.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.ManagedWinRtLibrary";
		public const string QualifiedName = "Mntone WinRT Library (Managed)";
		public const string Description = "This is my useful Windows Runtime library";
		public const string Version = "0.8.1.2";
		public const string Author = "mntone";
	}
}