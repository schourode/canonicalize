using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Canonicalize")]
[assembly: AssemblyDescription("URL canonicalization with ASP.NET (MVC) routing")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("1.2.*")]

[assembly: ComVisible(false)]