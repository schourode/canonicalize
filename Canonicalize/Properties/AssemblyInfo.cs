using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Canonicalize")]
[assembly: AssemblyProduct("Canonicalize")]
[assembly: AssemblyDescription("URL canonicalization with ASP.NET (MVC) routing")]
[assembly: AssemblyCopyright("Copyright 2011 Joern Schou-Rode")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("0.9.*")]

[assembly: ComVisible(false)]