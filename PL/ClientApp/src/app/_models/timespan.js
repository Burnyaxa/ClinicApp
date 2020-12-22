"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TimeSpan = void 0;
var MILLIS_PER_SECOND = 1000;
var MILLIS_PER_MINUTE = MILLIS_PER_SECOND * 60; //     60,000
var MILLIS_PER_HOUR = MILLIS_PER_MINUTE * 60; //  3,600,000
var MILLIS_PER_DAY = MILLIS_PER_HOUR * 24; // 86,400,000
var TimeSpan = /** @class */ (function () {
    function TimeSpan(millis) {
        this._millis = millis;
    }
    TimeSpan.interval = function (value, scale) {
        if (Number.isNaN(value)) {
            throw new Error("value can't be NaN");
        }
        var tmp = value * scale;
        var millis = TimeSpan.round(tmp + (value >= 0 ? 0.5 : -0.5));
        return new TimeSpan(millis);
    };
    TimeSpan.round = function (n) {
        if (n < 0) {
            return Math.ceil(n);
        }
        else if (n > 0) {
            return Math.floor(n);
        }
        return 0;
    };
    TimeSpan.timeToMilliseconds = function (hour, minute, second) {
        var totalSeconds = (hour * 3600) + (minute * 60) + second;
        return totalSeconds * MILLIS_PER_SECOND;
    };
    Object.defineProperty(TimeSpan, "zero", {
        get: function () {
            return new TimeSpan(0);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan, "maxValue", {
        get: function () {
            return new TimeSpan(Number.MAX_SAFE_INTEGER);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan, "minValue", {
        get: function () {
            return new TimeSpan(Number.MIN_SAFE_INTEGER);
        },
        enumerable: false,
        configurable: true
    });
    TimeSpan.fromDays = function (value) {
        return TimeSpan.interval(value, MILLIS_PER_DAY);
    };
    TimeSpan.fromHours = function (value) {
        return TimeSpan.interval(value, MILLIS_PER_HOUR);
    };
    TimeSpan.fromMilliseconds = function (value) {
        return TimeSpan.interval(value, 1);
    };
    TimeSpan.fromMinutes = function (value) {
        return TimeSpan.interval(value, MILLIS_PER_MINUTE);
    };
    TimeSpan.fromSeconds = function (value) {
        return TimeSpan.interval(value, MILLIS_PER_SECOND);
    };
    TimeSpan.fromTime = function (daysOrHours, hoursOrMinutes, minutesOrSeconds, seconds, milliseconds) {
        if (milliseconds != undefined) {
            return this.fromTimeStartingFromDays(daysOrHours, hoursOrMinutes, minutesOrSeconds, seconds, milliseconds);
        }
        else {
            return this.fromTimeStartingFromHours(daysOrHours, hoursOrMinutes, minutesOrSeconds);
        }
    };
    TimeSpan.fromTimeStartingFromHours = function (hours, minutes, seconds) {
        var millis = TimeSpan.timeToMilliseconds(hours, minutes, seconds);
        return new TimeSpan(millis);
    };
    TimeSpan.fromTimeStartingFromDays = function (days, hours, minutes, seconds, milliseconds) {
        var totalMilliSeconds = (days * MILLIS_PER_DAY) +
            (hours * MILLIS_PER_HOUR) +
            (minutes * MILLIS_PER_MINUTE) +
            (seconds * MILLIS_PER_SECOND) +
            milliseconds;
        return new TimeSpan(totalMilliSeconds);
    };
    Object.defineProperty(TimeSpan.prototype, "days", {
        get: function () {
            return TimeSpan.round(this._millis / MILLIS_PER_DAY);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "hours", {
        get: function () {
            return TimeSpan.round((this._millis / MILLIS_PER_HOUR) % 24);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "minutes", {
        get: function () {
            return TimeSpan.round((this._millis / MILLIS_PER_MINUTE) % 60);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "seconds", {
        get: function () {
            return TimeSpan.round((this._millis / MILLIS_PER_SECOND) % 60);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "milliseconds", {
        get: function () {
            return TimeSpan.round(this._millis % 1000);
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "totalDays", {
        get: function () {
            return this._millis / MILLIS_PER_DAY;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "totalHours", {
        get: function () {
            return this._millis / MILLIS_PER_HOUR;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "totalMinutes", {
        get: function () {
            return this._millis / MILLIS_PER_MINUTE;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "totalSeconds", {
        get: function () {
            return this._millis / MILLIS_PER_SECOND;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(TimeSpan.prototype, "totalMilliseconds", {
        get: function () {
            return this._millis;
        },
        enumerable: false,
        configurable: true
    });
    TimeSpan.prototype.add = function (ts) {
        var result = this._millis + ts.totalMilliseconds;
        return new TimeSpan(result);
    };
    TimeSpan.prototype.subtract = function (ts) {
        var result = this._millis - ts.totalMilliseconds;
        return new TimeSpan(result);
    };
    return TimeSpan;
}());
exports.TimeSpan = TimeSpan;
//# sourceMappingURL=timespan.js.map