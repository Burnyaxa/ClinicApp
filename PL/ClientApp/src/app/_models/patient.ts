import { Appointment } from "./appointment";

export class Patient {
  id: number;
  lastName: string;
  firstName: string;
  patronymic: string;
  birthDate: Date;
  phoneNumber: string;

  appointments: Appointment[];
}
