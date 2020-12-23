"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Appointment = exports.AppointmentStatus = void 0;
var AppointmentStatus;
(function (AppointmentStatus) {
    AppointmentStatus[AppointmentStatus["Awaiting"] = 0] = "Awaiting";
    AppointmentStatus[AppointmentStatus["Completed"] = 1] = "Completed";
    AppointmentStatus[AppointmentStatus["Cancelled"] = 2] = "Cancelled";
    AppointmentStatus[AppointmentStatus["Delayed"] = 3] = "Delayed";
})(AppointmentStatus = exports.AppointmentStatus || (exports.AppointmentStatus = {}));
var Appointment = /** @class */ (function () {
    function Appointment() {
    }
    return Appointment;
}());
exports.Appointment = Appointment;
//# sourceMappingURL=appointment.js.map