namespace Industrious.Editor;

public class EditorCore
{
	public EditorCore (IEditorHost host)
	{
		const String content = "<html><head></head><body><p>Editor is installed.</p></body></html>";
		host.LoadHtmlString (content);
	}
}
