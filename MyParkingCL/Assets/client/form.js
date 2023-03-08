$(document).on("click", ".open-AddBookDialog", function () {
    var myBookId = $(this).data('id');
    var myBookViTri = $(this).data('vitriodo');
    $("#bookId").val(myBookId);
    $("#bookIdViTri").val(myBookViTri);
});

