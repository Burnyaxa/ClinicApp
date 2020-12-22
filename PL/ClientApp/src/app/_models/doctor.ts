import { DoctorSchedule } from "./doctorSchedule";

export class Doctor {
  id: number;
  lastName: string;
  firstName: string;
  patronymic: string;
  specialty: string;
  address: string;
  phoneNumber: string;
  cabinet: number;

  schedules: DoctorSchedule[];
}
