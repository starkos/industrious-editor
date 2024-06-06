using System.Collections;
using System.Reflection;

namespace Industrious.Editor.Internals;

public class EditorCore : IEditor
{
	private readonly IWebViewAdapter _webView;
	private readonly IWebScriptAdapter _webScript;


	public EditorCore (IWebViewAdapter webView, IWebScriptAdapter webScript)
	{
		Document = Document.Empty;

		_webView = webView;
		_webScript = webScript;

		// Listen for messages flowing out from the JavaScript bridge
		webScript.OnJavaScriptMessage += OnJavaScriptMessage;

		// Load the editor's web environment into the provided web view
		var assembly = Assembly.GetExecutingAssembly ();
		using var stream = assembly.GetManifestResourceStream ("Industrious.Editor.Lexical.dist.index.html");
		using var streamReader = new StreamReader (stream!);
		var html = streamReader.ReadToEnd ();
		webView.LoadHtmlString (html);
	}


	public Document Document { get; private set; }


	private void OnJavaScriptMessage (Object? sender, IDictionary arg)
	{
		// Assuming this will get more complex soon enough...
		Document = new Document (arg);
	}
}
