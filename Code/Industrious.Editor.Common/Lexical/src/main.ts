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
	if (window.webkit != null)
		window.webkit.messageHandlers.host.postMessage(editorState);
});
