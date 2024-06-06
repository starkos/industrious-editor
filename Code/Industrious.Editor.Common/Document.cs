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


	public void Write (Stream outputStream)
	{
		using var streamWriter = new StreamWriter (outputStream);
		streamWriter.Write (_jsonObject.ToString ());
	}


	public async Task WriteAsync (Stream outputStream)
	{
		await using var streamWriter = new StreamWriter (outputStream);
		await streamWriter.WriteAsync (_jsonObject.ToString ());
	}


	public override String ToString ()
	{
		return _jsonObject.ToString () ?? String.Empty;
	}
}
