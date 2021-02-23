mergeInto(LibraryManager.library, {

   SendJsonWeb:function (text) {
      var data = JSON.parse(Pointer_stringify(text));
      reciveUnityJson(data);
   },
});