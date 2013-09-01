var showTooltip = function (event) {
    $('div.tooltip').remove();
    $('<div class="tooltip">' + $(this).attr('tip') + '</div>')
     .appendTo('body');
    changeTooltipPosition(event);
};

var changeTooltipPosition = function (event) {
    var tooltipX = event.pageX - 8;
    var tooltipY = event.pageY + 8;
    $('div.tooltip').css({ top: tooltipY, left: tooltipX });
};

var hideTooltip = function () {
    $('div.tooltip').remove();
};

$(document).ready(function () {
    $(".hint").bind({
        mousemove: changeTooltipPosition,
        mouseenter: showTooltip,
        mouseleave: hideTooltip
    });
});