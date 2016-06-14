function get_timer_391() {
    var a = $(this).find(".result-day").text() * 60 * 60 * 1000 * 24 +
        $(this).find(".result-hour").text() * 60 * 60 * 1000 +
          $(this).find(".result-minute").text() * 60 * 1000 +
           $(this).find(".result-second").text() * 1000;
    a = a - 1000;
    var timer_391 = a;
    if (timer_391 > 0) {
        var day_391 = parseInt(timer_391 / (60 * 60 * 1000 * 24));
        if (day_391 < 10) {
            day_391 = "0" + day_391;
        }
        day_391 = day_391.toString();
        var hour_391 = parseInt(timer_391 / (60 * 60 * 1000)) % 24;
        if (hour_391 < 10) {
            hour_391 = "0" + hour_391;
        }
        hour_391 = hour_391.toString();
        var min_391 = parseInt(timer_391 / (1000 * 60)) % 60;
        if (min_391 < 10) {
            min_391 = "0" + min_391;
        }
        min_391 = min_391.toString();
        var sec_391 = parseInt(timer_391 / 1000) % 60;
        if (sec_391 < 10) {
            sec_391 = "0" + sec_391;
        }
        sec_391 = sec_391.toString();
        timethis_391 = day_391 + " : " + hour_391 + " : " + min_391 + " : " + sec_391;
        $(this).find(".result-day").text(day_391);
        $(this).find(".result-hour").text(hour_391);
        $(this).find(".result-minute").text(min_391);
        $(this).find(".result-second").text(sec_391);
    } else {
        $(this).find(".result-day").text("00");
        $(this).find(".result-hour").text("00");
        $(this).find(".result-minute").text("00");
        $(this).find(".result-second").text("00");
    }
}
function getfrominputs_391() {
    $(".timerhello_391").each(get_timer_391);
    setTimeout(getfrominputs_391, 1000);
}
$(document).ready(function () { getfrominputs_391(); });