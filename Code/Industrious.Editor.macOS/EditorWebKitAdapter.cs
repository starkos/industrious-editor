using System.Diagnostics.CodeAnalysis;

using Foundation;

using WebKit;

namespace Industrious.Editor;

[SuppressMessage ("Interoperability", "CA1416:Validate platform compatibility")]
public class EditorWebKitAdapter : IEditorWebView
{
	private readonly WKWebView _webView;


	public EditorWebKitAdapter (WKWebView webView)
	{
		_webView = webView;
	}


	public void LoadHtmlString (String htmlString)
	{
		_webView.LoadHtmlString (htmlString, NSUrl.FromString ("file:///")!);
	}
}
