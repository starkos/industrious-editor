import './styles.css';

import {registerDragonSupport} from '@lexical/dragon';
import {createEmptyHistoryState, registerHistory} from '@lexical/history';
import {HeadingNode, QuoteNode, registerRichText} from '@lexical/rich-text';
import {mergeRegister} from '@lexical/utils';
import {createEditor} from 'lexical';

const editor = createEditor({
	namespace: 'Industrious.Editor',
	nodes: [HeadingNode, QuoteNode],
	onError: (error: Error) => {
		throw error;
	},
	theme: {
	},
});

const editorRef = document.getElementById('editor');
editor.setRootElement(editorRef);

mergeRegister(
  registerRichText(editor),
  registerDragonSupport(editor),
  registerHistory(editor, createEmptyHistoryState(), 300),
);

// Set the initial input focus
editorRef!.focus();


declare global {
	interface Window {
		webkit?: {
			messageHandlers: {
				[x: string]: {
					postMessage: (data: any) => void;
				};
			};
		};
	}
}

editor.registerUpdateListener(({editorState}) => {
	// I haven't dug into the Lexical code to verify, but this is likely a relatively expensive operation.
	// It might be nice to only do the work if there is actually a listener registered on the C# side?

	const json = editorState.toJSON();

	if (window.webkit != null)
		window.webkit.messageHandlers.host.postMessage(json);
});
