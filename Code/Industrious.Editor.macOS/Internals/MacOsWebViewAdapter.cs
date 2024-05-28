using WebKit;

namespace Industrious.Editor.Internals;

/// <summary>
///  Provide a generic interface around a system-specific web view for the core editor.
/// </summary>
internal class MacOsWebViewAdapter : IWebViewAdapter
{
	private readonly WKWebView _webView;


	public MacOsWebViewAdapter (WKWebView webView)
	{
		_webView = webView;
	}


	public void LoadHtmlString (String htmlString)
	{
		_webView.LoadHtmlString (htmlString, NSUrl.FromString ("file:///")!);
	}
}
