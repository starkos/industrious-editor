using System.Reflection;

namespace Industrious.Editor;

/// <summary>
///  Common editor logic, shared between all platform adapters.
/// </summary>
public class EditorCore
{
	public EditorCore (IEditorHost host)
	{
		var assembly = Assembly.GetExecutingAssembly ();
		using var stream = assembly.GetManifestResourceStream ("Industrious.Editor.Resources.Editor.html");
		using var streamReader = new StreamReader (stream!);

		var html = streamReader.ReadToEnd ();
		host.LoadHtmlString (html);
	}
}
