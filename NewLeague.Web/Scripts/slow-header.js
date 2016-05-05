﻿(function () {

    var parallax = document.querySelectorAll(".parallax"),
        speed = 0.5;

    window.onscroll = function () {
        [].slice.call(parallax).forEach(function (el, i) {

            var windowYOffset = window.pageYOffset + 50,
                elBackgrounPos = "50% " + (windowYOffset * speed) + "px";

            el.style.backgroundPosition = elBackgrounPos;

        });
    };

})();