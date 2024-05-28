namespace Industrious.Editor.Internals;

/// <summary>
///  A platform-agnostic interface to the various web browser engines.
/// </summary>
public interface IWebViewAdapter
{
	void LoadHtmlString (String htmlString);
}
