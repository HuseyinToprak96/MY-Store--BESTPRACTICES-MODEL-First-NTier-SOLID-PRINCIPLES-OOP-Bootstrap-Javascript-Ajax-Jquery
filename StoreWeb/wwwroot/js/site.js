$(document).ready(function () {
    $('.yetki').click("change", function () {
        //alert($(this).attr("id"));attribute ile atamış olduğumuz id değerinde n kişinin id sini çektik
        // alert($("input:checked").length);//seçili olanları bulur. Kaç tane olduğunu
        //alert($(this).prop("checked"));--True mu False mu kontrol etme...
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Admin/UyeYetkilendirme?yetki=" + $(this).prop("checked") + "&id=" + $(this).attr("id"), true);
        xhr.send();
    });
});
