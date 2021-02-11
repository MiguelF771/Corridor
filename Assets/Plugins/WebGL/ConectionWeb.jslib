mergeInto(LibraryManager.library, {

   SendJsonWeb:function (text) {
      var json = Pointer_stringify(text);
      reciveUnityJson(json);
   },
});