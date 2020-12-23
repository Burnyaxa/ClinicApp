import { Component, OnDestroy, OnInit } from '@angular/core';
import { AppointmentService } from '../../_services/appointment.service';
import { Appointment } from '../../_models/appointment';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-appointment',
  templateUrl: './list-appointment.component.html',
  providers: [AppointmentService]
})
export class ListAppointmentComponent implements OnInit {

  appointment: Appointment = new Appointment();
  appointments: Appointment[];
  tableMode: boolean = true;

  constructor(private appointmentService: AppointmentService, private router: Router) { }

  ngOnInit() {
    this.loadAppointments();
  }

  loadAppointments() {
    this.appointmentService.getAppointments()
      .subscribe((data: Appointment[]) => this.appointments = data);
  }

  save() {
    if (this.appointment.id == null) {
      this.appointmentService.createAppointment(this.appointment.doctorId, this.appointment.patientId, this.appointment.date,
        this.appointment.status)
        .subscribe((data: Appointment) => this.appointments.push(data));
    } else {
      this.appointmentService.updateAppointment(this.appointment.id, this.appointment.doctorId, this.appointment.patientId,
        this.appointment.date, this.appointment.status)
        .subscribe(data => this.loadAppointments());
    }
    this.cancel();
  }
  editAppointment(d: Appointment) {
    this.appointment = d;
  }
  cancel() {
    this.appointment = new Appointment();
    this.tableMode = true;
  }
  delete(appointmentId: number) {
    this.appointmentService.deleteAppointment(appointmentId)
      .subscribe(data => this.loadAppointments());
  }
  add() {
    this.router.navigateByUrl('create/appointment');
  }
}
