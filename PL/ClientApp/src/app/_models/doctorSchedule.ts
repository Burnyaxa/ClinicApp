import { TimeSpan } from "./timespan";

export enum Days {
  Monday,
  Tuesday,
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday,
}

export class DoctorSchedule {
  id: number;
  doctorId: number;
  day: Days;
  startTime: string;
  endTime: string;
}
