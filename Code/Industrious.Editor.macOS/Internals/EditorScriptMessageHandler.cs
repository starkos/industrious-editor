using WebKit;

namespace Industrious.Editor.Internals;

internal class EditorScriptMessageHandler : NSView, IWKScriptMessageHandler
{
	public void DidReceiveScriptMessage (WKUserContentController userContentController, WKScriptMessage message)
	{
		Console.Write ("Received a script message!");
	}
}
