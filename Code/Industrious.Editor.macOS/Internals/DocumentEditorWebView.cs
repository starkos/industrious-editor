using WebKit;

namespace Industrious.Editor.Internals;

internal class DocumentEditorWebView : IEditorWebView
{
	private readonly WKWebView _webView;


	public DocumentEditorWebView (WKWebView webView)
	{
		_webView = webView;
	}


	public void LoadHtmlString (String htmlString)
	{
		_webView.LoadHtmlString (htmlString, NSUrl.FromString ("file:///")!);
	}
}
