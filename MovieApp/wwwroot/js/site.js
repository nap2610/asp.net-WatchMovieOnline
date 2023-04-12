'use strict';

const heroBanner = function () {

    let controlItemIndex = 0;

    const buttonControls = document.querySelectorAll("[slider-control]");
    for (const i of buttonControls) {
        i.setAttribute("slider-control", controlItemIndex)
        controlItemIndex++;
    }
    addHeroSlide();

}

const addHeroSlide = function () {
    const sliderItems = document.querySelectorAll("[slider-item]");
    const sliderControls = document.querySelectorAll("[slider-control]");

    let lastSliderItem = sliderItems[0];
    let lastSliderControl = sliderControls[0];

    lastSliderItem.classList.add("active");
    lastSliderControl.classList.add("active");

    const sliderStart = function () {
        lastSliderItem.classList.remove("active");
        lastSliderControl.classList.remove("active");

        sliderItems[Number(this.getAttribute("slider-control"))].classList.add("active");
        this.classList.add("active");

        lastSliderItem = sliderItems[Number(this.getAttribute("slider-control"))];
        lastSliderControl = this;
    }

    addEventOnElements(sliderControls, "click", sliderStart);

}


heroBanner();