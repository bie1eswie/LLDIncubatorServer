export function correctHeight() {
    var pageWrapper = jQuery('#page-wrapper');
    var navbarHeight = jQuery('nav.navbar-default').height();
    var wrapperHeight = pageWrapper.height();
    if (navbarHeight > wrapperHeight) {
        pageWrapper.css("min-height", navbarHeight + "px");
    }
    if (navbarHeight <= wrapperHeight) {
        if (navbarHeight < jQuery(window).height()) {
            pageWrapper.css("min-height", jQuery(window).height() + "px");
        }
        else {
            pageWrapper.css("min-height", navbarHeight + "px");
        }
    }
    if (jQuery('body').hasClass('fixed-nav')) {
        if (navbarHeight > wrapperHeight) {
            pageWrapper.css("min-height", navbarHeight + "px");
        }
        else {
            pageWrapper.css("min-height", jQuery(window).height() - 60 + "px");
        }
    }
}
export function detectBody() {
    if (jQuery(document).width() < 769) {
        jQuery('body').addClass('body-small');
    }
    else {
        jQuery('body').removeClass('body-small');
    }
}
export function smoothlyMenu() {
    if (!jQuery('body').hasClass('mini-navbar') || jQuery('body').hasClass('body-small')) {
        jQuery('#side-menu').hide();
        setTimeout(function () {
            jQuery('#side-menu').fadeIn(400);
        }, 200);
    }
    else if (jQuery('body').hasClass('fixed-sidebar')) {
        jQuery('#side-menu').hide();
        setTimeout(function () {
            jQuery('#side-menu').fadeIn(400);
        }, 100);
    }
    else {
        jQuery('#side-menu').removeAttr('style');
    }
}
//# sourceMappingURL=app.helpers.js.map