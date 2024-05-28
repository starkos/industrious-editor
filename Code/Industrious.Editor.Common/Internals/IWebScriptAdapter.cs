using System.Collections;

namespace Industrious.Editor.Internals;

public interface IWebScriptAdapter
{
	event EventHandler<IDictionary> OnJavaScriptMessage;
}
