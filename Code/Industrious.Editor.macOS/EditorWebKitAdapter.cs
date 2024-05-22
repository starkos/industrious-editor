using WebKit;

namespace Industrious.Editor;

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
