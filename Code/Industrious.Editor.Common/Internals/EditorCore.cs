using System.Collections;
using System.Reflection;

namespace Industrious.Editor.Internals;

public class EditorCore : IEditor
{
	private readonly IWebViewAdapter _webView;
	private readonly IWebScriptAdapter _webScript;


	public EditorCore (IWebViewAdapter webView, IWebScriptAdapter webScript)
	{
		_webView = webView;
		_webScript = webScript;

		webScript.OnJavaScriptMessage += OnJavaScriptMessage;

		Document = Document.Empty;

		var assembly = Assembly.GetExecutingAssembly ();
		using var stream = assembly.GetManifestResourceStream ("Industrious.Editor.Lexical.dist.index.html");
		using var streamReader = new StreamReader (stream!);

		var html = streamReader.ReadToEnd ();
		webView.LoadHtmlString (html);
	}


	public Document Document { get; private set; }


	public void Save ()
	{
		Console.WriteLine ("[EditorCore.Save]");
	}


	private void OnJavaScriptMessage (Object? sender, IDictionary arg)
	{
		Document = new Document (arg);
	}
}
