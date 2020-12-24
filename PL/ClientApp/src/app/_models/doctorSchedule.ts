import { TimeSpan } from "./timespan";

export const Days: string[] = [
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday",
  "Sunday"
];

export class DoctorSchedule {
  id: number;
  doctorId: number;
  day: number;
  startTime: string;
  endTime: string;
}
