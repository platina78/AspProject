var editor;

require.config({ paths: { 'vs': 'https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.16.2/min/vs' } });
require(['vs/editor/editor.main'], function () {
    editor = monaco.editor.create(document.getElementById('monaco'), {
        theme: 'vs',
        fontFamily: 'Nanum Gothic Coding',
        automaticLayout: true,
        accessibilitySupport: "on",
        language: 'html',
        value: [
            '<!DOCTYPE html>',
            '<html lang="en">',
            '<head>',
            '    <meta charset="UTF-8">',
            '    <meta name="viewport" content="width=device-width, initial-scale=1.0">',
            '    <title>Document</title>',
            '</head>',
            '<body>',
            '    여기에 코드를 작성해보세요!',
            '</body>',
            '</html>'
        ].join('\n')
    });
    

});
/*
var compile_btn = document.querySelector('compile_btn');

compile_btn.addEventListener('click', function (e) {
    e.preventDefault();

    var idoc = document.getElementById('design').contentWindow.document;
    idoc.open();
    idoc.write(editor.getValue());
    idoc.close();
});
*/

function update() {
    var idoc = document.getElementById('design').contentWindow.document;
    idoc.open();
    idoc.write(editor.getValue());
    idoc.close();
}
let isCtrl = false;

document.addEventListener("keyup", e => { //키가 떼지면?
    if (e.keyCode == 17) {
        isCtrl = false;
        console.log('show ctrl keyup!');
    }
});
document.addEventListener("keydown", e => { //키가 눌리는 중
    if (e.keyCode == 17) {
        isCtrl = true;
        console.log('show ctrl keydown');
    }
    if (isCtrl == true && e.keyCode == 83 ) {
        console.log('saving!');
        e.preventDefault();
        update();
    }  
});
