import { Appointment } from "./appointment";
import { DoctorSchedule } from "./doctorSchedule";
import { Visit } from "./visit";

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
  appointments: Appointment[];
  visits: Visit[];
}
