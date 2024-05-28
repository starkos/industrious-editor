using System.Collections;

namespace Industrious.Editor;

public class Document
{
	public static readonly Document Empty = new Document (new Hashtable ());

	private readonly IDictionary _jsonObject;


	public Document (IDictionary jsonObject)
	{
		_jsonObject = jsonObject;
	}
}
