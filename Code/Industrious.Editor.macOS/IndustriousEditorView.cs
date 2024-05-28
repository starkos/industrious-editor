using Industrious.Editor.Internals;

using WebKit;

namespace Industrious.Editor;

/// <summary>
///  AppKit implementation of the document editor view.
/// </summary>
public class IndustriousEditorView : NSView
{
	private readonly WKWebView _webView;
	private readonly EditorCore _editorCore;


	public IndustriousEditorView (CGRect frame)
		: base (frame)
	{
		// Create a generic adapter to receive messages from the JavaScript editor logic
		var webScriptAdapter = new MacOsWebScriptAdapter ();

		// Create a generic web view adapter to host the editor logic
		var userController = new WKUserContentController ();
		userController.AddScriptMessageHandler (webScriptAdapter, "host");

		_webView = new WKWebView (CGRect.Empty, new WKWebViewConfiguration () {
			UserContentController = userController
		});

		var webViewAdapter = new MacOsWebViewAdapter (_webView);

		// Create a new editor core around the system adapters
		_editorCore = new EditorCore (webViewAdapter, webScriptAdapter);
	}


	public IEditor Editor => _editorCore;


	// Always fill the available space with the web view
	public override void SetFrameSize (CGSize newSize)
	{
		base.SetFrameSize (newSize);
		_webView.SetFrameSize (newSize);
	}


	// This is weird but not yet sure how else to do it. I want to add `_webView` as a subview, so it's
	// not exposed to the client but is still part of the view hierarchy. I can't call `AddSubview()`
	// from the constructor because it's virtual. This is my best guess until I know better.
	public override void ViewWillMoveToSuperview (NSView? newSuperview)
	{
		// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
		if (_webView.Superview is null)
			AddSubview (_webView);
	}
}
