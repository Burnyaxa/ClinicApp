import { Appointment } from "./appointment";
import { Visit } from "./visit";

export class Patient {
  id: number;
  lastName: string;
  firstName: string;
  patronymic: string;
  birthDate: Date;
  phoneNumber: string;

  appointments: Appointment[];
  visits: Visit[];
}
