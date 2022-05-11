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


//ADMİN İNDEX SAYFASI JS İŞLEMLERİ

 //yollanılan 2. parametreye göre çalışacak olan metotlar...
 //değişen tek kısımları 2. parametrelerdir. Yani koda tek satır kod ile eklenecektir.

    function Goster(id, tiklanan) {
            var acc = document.getElementById("alt_" + tiklanan + "_" + id);
    if (acc.style.display == "none")
    acc.style.display = "block";
    else
    acc.style.display = "none";
        }
    function accordionSil(id, silinecek) {

            //ajax işlemleri eklenecek
            var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Admin/" + silinecek + "Sil?id=" + id, true);
    xhr.send();
    var obj = document.getElementById(silinecek + "_" + id);
    obj.remove();
    if (silinecek != "urun") {
                var alt = document.getElementById("alt_" + silinecek + "_" + id);
    alt.remove();
            }
        }
    //KATEGORİ EKLE
    $('.form').submit(function (e) {

        e.preventDefault();
    var formData = $(this).serialize();
    var kategoriAdi = $("#katAdi").val();
    //alert(kategoriAdi);
    $.ajax({
        type: 'POST',
    url: '/Admin/KategoriEkle',
    data: formData,
    success: function (data) {
        console.log("data", data);
    var div = document.createElement("div");
    div.id = "kategori_" + data;
    div.className = "kategoriAccordion";
    div.addEventListener("click", function () {
        Goster(data, "kategori");
                    });
    var h = document.createElement("h3");
    h.innerText = kategoriAdi;
    h.style.backgroundColor = "brown";
    h.className = "kat";
    var btn = document.createElement("button");
    btn.innerText = "X";
    btn.addEventListener("click", function () {
        accordionSil(data, 'kategori');
                    });
    h.appendChild(btn);
    div.appendChild(h);
    var d = document.getElementById("panelAdmin");
    d.appendChild(div);
                },
    error: function (error) {
        console.log("error", error);
                }
            });
        });

    //ALT KATEGORİ EKLE
    $('.altForm').submit(function (e) {
        e.preventDefault();
    var formData = $(this).serialize();
    var id = $(this).attr("id");
    $.ajax({
        type: 'POST',
    url: '/Admin/altKategoriEkle',
    data: formData,
    success: function (data) {
        console.log("data", data);
    var div = document.createElement("div");
    div.style.backgroundColor = "beige";
    div.addEventListener("click",function () {
        Goster(data, 'altKategori');
                    });
    div.id = "altKategori_" + data;
    div.className = "li kategori_" + id;
    div.innerText = $('#txtAlt_' + id).val();
    var btn = document.createElement("button");
    btn.addEventListener("click", function () {
        accordionSil(data, 'altKategori');
                    });
    btn.id = "btn_" + data;
    btn.innerText = "X";
    div.appendChild(btn);
    var d = document.getElementById("alt_kategori_" + id);
    d.appendChild(div);


                },
    error: function (error) {
        console.log("error", error);
                }
            });
        });


    //ÜRÜN EKLEME//NASIL TEKE İNDİRİLLİR?

    $('.urunForm').submit(function (e) {

        e.preventDefault();
    var formData = $(this).serialize();
    $.ajax({
        type: 'POST',
    url: '/Admin/urunEkle',
    data: formData,
    success: function (data) {

        console.log("data", data);

                },
    error: function (error) {
        console.log("error", error);
                }
            });
        });

        //function ekleListeye(id) {
        //    var txt = document.getElementById("txt");
        //    var d = document.getElementById("#alt_altKategori_" + id)
        //    var div = document.createElement("div");
        //    div.className = "urunAdmin";
        //    div.innerText = txt.value;
        //    var buton = document.createElement("button");
        //    buton.value = "X";
        //    div.appendChild(buton);
        //    d.appendChild(div);
        //}

        //function ara() {
        //    var txt = document.getElementById("ara");
        //    var divler = document.querySelectorAll("#panelAdmin div");


        //}
        //Arama Motoru
        $(document).ready(function () {
            $("#ara").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#panelAdmin div").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });



//Sayfa Açıldığında

function load() {
    
    sayfalama();
    renkDegis();
}


function renkDegis() {
    var cins = document.getElementById("cins");
    var h = document.getElementsByTagName("h3");
    if (cins.innerText == "Erkek" || cins.innerText == "Erkek Çocuk") {
        for (var i = 0; i < h.length; i++) {


            h[i].style.backgroundColor = "dodgerblue";
        }
    }
    else {
        for (var i = 0; i < h.length; i++) {


            h[i].style.backgroundColor = "hotpink";
        }
    }
}



//SAYFALAMA İŞLEMLERİ




//PAGE-INDEX

function goster() {
    var urunler = document.getElementsByClassName("urun");
    for (var i = 0; i < urunler.length; i++) {
        urunler[i].addEventListener("mouseover", function () {
            var ucret = document.getElementById("ucret_" + this.id);
            var bilgi = document.getElementById("bilgi_" + this.id);
            ucret.style.display = "block";
            bilgi.style.opacity = 1;
            this.addEventListener("mouseleave", function () {
                ucret.style.display = "none";
                bilgi.style.opacity = 0.5;
            });
        });
    }
}

//ÜYE GÜNCELLEME İŞLEMİ

$('#uyelikGuncelle').submit(function (e) {
    alert("başla");
    e.preventDefault();
    var formData = $(this).serialize();
    var id = $(this).attr("id");
    $.ajax({
        type: 'POST',
        url: '/Kullanici/BilgileriGuncelle',
        data: formData,
        success: function (data) {
            return 1;
        },
        error: function (error) {
            console.log("error", error);
        }
    });
});