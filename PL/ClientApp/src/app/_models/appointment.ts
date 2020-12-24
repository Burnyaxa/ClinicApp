export const AppointmentStatus: string[] = [
  "Awaiting",
  "Completed",
  "Cancelled",
  "Delayed"];

export class Appointment {
  id: number;
  doctorId: number;
  patientId: number;
  date: Date;
  status: number;
}
