   function myFunction() {
        var dots = document.getElementById("dots");
        var btnText = document.getElementById("myBtn");
        var ReadMore = document.getElementById("ReadMore");
        var ReadLess = document.getElementById("ReadLess");

        if (ReadMore.style.display === "none") {
            dots.style.display = "inline";
            ReadLess.style.display = "none";
            btnText.innerHTML = "Đọc Thêm";
            ReadMore.style.display = "inline";
        } else {
            dots.style.display = "none";
            ReadMore.style.display = "none";
            btnText.innerHTML = "Tóm Gọn";
            ReadLess.style.display = "inline";
        }
}

