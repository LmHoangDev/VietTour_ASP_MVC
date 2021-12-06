
            window.addEventListener('DOMContentLoaded', (event) => {
                var index = 1;
                changeImage = function () {
                    var imgs = ["../Content/HomeTestLayout/Images/slide-viettour-1.jpg", "../Content/HomeTestLayout/Images/slide-viettour.jpg", "../Content/HomeTestLayout/Images/slide-viettour-2.jpg"];
                    document.getElementById("slide-img").src = imgs[index];
                    index++;
                    if (index == 3) {
                        index = 0;
                    }
                }
                setInterval(changeImage, 3000);
            });