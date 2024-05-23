using Industrious.Editor.Internals;

using WebKit;

namespace Industrious.Editor;

/// <summary>
///  AppKit implementation of the document editor view.
/// </summary>
public class DocumentEditorView : NSView
{
	private readonly WKWebView _webView;
	private readonly EditorCore _editorCore;


	public DocumentEditorView (CGRect frame)
		: base (frame)
	{
		var scriptMessageHandler = new EditorScriptMessageHandler ();

		var userController = new WKUserContentController ();
		userController.AddScriptMessageHandler (scriptMessageHandler, "host");

		// will probably want to tweak this soon enough
		var configuration = new WKWebViewConfiguration () {
			UserContentController = userController
		};

		_webView = new WKWebView (CGRect.Empty, configuration);

		var adapter = new DocumentEditorWebView (_webView);
		_editorCore = new EditorCore (adapter);
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
