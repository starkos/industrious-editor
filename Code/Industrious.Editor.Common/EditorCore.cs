using System.Reflection;

namespace Industrious.Editor;

public class EditorCore : IEditor
{
	public EditorCore (IEditorWebView adapter)
	{
		var assembly = Assembly.GetExecutingAssembly ();
		using var stream = assembly.GetManifestResourceStream ("Industrious.Editor.Common.Lexical.dist.index.html");
		using var streamReader = new StreamReader (stream!);

		var html = streamReader.ReadToEnd ();
		adapter.LoadHtmlString (html);
	}
}
