import { TimeSpan } from "./timespan";

enum Days {
  Monday,
  Tuesday,
  Thirsday,
  Wednesday,
  Friday,
  Saturday,
  Sunday,
}

export class DoctorSchedule {
  id: number;
  doctorId: number;
  day: Days;
  startTime: TimeSpan;
  endTime: TimeSpan;
}
