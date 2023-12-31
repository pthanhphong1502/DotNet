tinymce.init({
    selector: "textarea#basic-example",
    height: 600,
    branding: false,
    menubar: true,
    table_toolbar: 'tableprops tabledelete | tableinsertrowbefore tableinsertrowafter tabledeleterow | tableinsertcolbefore tableinsertcolafter tabledeletecol',
    plugins:
        " table print preview paste importcss searchreplace autolink autosave save directionality code visualblocks visualchars fullscreen codesample charmap hr nonbreaking toc insertdatetime advlist lists wordcount imagetools textpattern noneditable help charmap  emoticons",
    toolbar: "undo redo | charmap emoticons | bold italic"
});