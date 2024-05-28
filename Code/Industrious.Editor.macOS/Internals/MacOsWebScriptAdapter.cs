using System.Collections;

using WebKit;

namespace Industrious.Editor.Internals;

/// <summary>
///  Receive and forward messages from a WebKit-hosted Javascript.
/// </summary>
internal class MacOsWebScriptAdapter : NSView, IWKScriptMessageHandler, IWebScriptAdapter
{
	public event EventHandler<IDictionary>? OnJavaScriptMessage;


	public void DidReceiveScriptMessage (WKUserContentController userContentController, WKScriptMessage message)
	{
		if (message.Body is IDictionary body)
			OnJavaScriptMessage?.Invoke (this, body);
	}
}
