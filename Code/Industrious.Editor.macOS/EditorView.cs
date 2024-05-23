using WebKit;

namespace Industrious.Editor;

/// <summary>
///  A macOS implementation of the editor view.
/// </summary>
/// <remarks>
///  Eventually this should move into the shared editor assembly, but I have to work out
///  how to make that support multiple platforms.
/// </remarks>
public class EditorView : NSView
{
	private readonly WKWebView _webView;
	private readonly EditorCore _editorCore;


	public EditorView (CGRect frame)
		: base (frame)
	{
		// will probably want to tweak this soon enough
		var configuration = new WKWebViewConfiguration ();

		_webView = new WKWebView (CGRect.Empty, configuration);
		var adapter = new EditorWebKitAdapter (_webView);
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
