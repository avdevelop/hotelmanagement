function redirect(time, to) {
    window.setTimeout(function() {
            window.location.href = to;
        }, time);
    }
