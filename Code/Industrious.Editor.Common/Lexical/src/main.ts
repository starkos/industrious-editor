import './styles.css';

import {registerDragonSupport} from '@lexical/dragon';
import {createEmptyHistoryState, registerHistory} from '@lexical/history';
import {HeadingNode, QuoteNode, registerRichText} from '@lexical/rich-text';
import {mergeRegister} from '@lexical/utils';
import {createEditor} from 'lexical';

// This can be moved out to index.html?
// Do I need the wrapper?

document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
<div class="editor-wrapper">
  <div id="lexical-editor" contenteditable></div>
</div>`;

const editorRef = document.getElementById('lexical-editor');

const initialConfig = {
  namespace: 'Industrious.Editor',
  nodes: [HeadingNode, QuoteNode],
  onError: (error: Error) => {
    throw error;
  },
  theme: {
  },
};

const editor = createEditor(initialConfig);
editor.setRootElement(editorRef);

mergeRegister(
  registerRichText(editor),
  registerDragonSupport(editor),
  registerHistory(editor, createEmptyHistoryState(), 300),
);

// Listen for changes - will eventually want to surface this to host

//editor.registerUpdateListener(({editorState}) => {
//  stateRef!.value = JSON.stringify(editorState.toJSON(), undefined, 2);
//});
