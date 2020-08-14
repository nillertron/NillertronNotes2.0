function replaceSelectedText(Tag) {
    var txtarea = document.getElementById('TextArea');
    if (!txtarea)
        alert("Och");
    if (txtarea.selectionStart != undefined) {
        var startPos = txtarea.selectionStart;
        var endPos = txtarea.selectionEnd;
        selectedText = txtarea.value.substring(startPos, endPos);
        txtarea.value = txtarea.value.slice(0, startPos) + "/" + Tag + selectedText + Tag + "\\ " + txtarea.value.slice(endPos);
    }
}

function GetText() {
    var txt = document.getElementById('TextArea');
    return txt.value;
}

function InitText(text) {
    var txtarea = document.getElementById('TextArea');
    txtarea.value = text;
}