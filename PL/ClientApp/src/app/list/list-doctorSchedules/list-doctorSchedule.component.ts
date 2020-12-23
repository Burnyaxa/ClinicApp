import { Component, OnDestroy, OnInit } from '@angular/core';
import { DoctorScheduleService } from '../../_services/doctorSchedule.service';
import { DoctorSchedule } from '../../_models/doctorSchedule';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-doctorSchedule',
  templateUrl: './list-doctorSchedule.component.html',
  providers: [DoctorScheduleService]
})
export class ListDoctorScheduleComponent implements OnInit {

  doctorSchedule: DoctorSchedule = new DoctorSchedule();
  doctorSchedules: DoctorSchedule[];
  tableMode: boolean = true;

  constructor(private doctorScheduleService: DoctorScheduleService, private router: Router) { }

  ngOnInit() {
    this.loadDoctorSchedules();
  }

  loadDoctorSchedules() {
    this.doctorScheduleService.getDoctorSchedules()
      .subscribe((data: DoctorSchedule[]) => this.doctorSchedules = data);
  }

  save() {
    if (this.doctorSchedule.id == null) {
      this.doctorScheduleService.createDoctorSchedule(this.doctorSchedule.doctorId, this.doctorSchedule.day,
        this.doctorSchedule.startTime, this.doctorSchedule.endTime)
        .subscribe((data: DoctorSchedule) => this.doctorSchedules.push(data));
    } else {
      this.doctorScheduleService.updateDoctorSchedule(this.doctorSchedule.id, this.doctorSchedule.doctorId, this.doctorSchedule.day,
        this.doctorSchedule.startTime, this.doctorSchedule.endTime)
        .subscribe(data => this.loadDoctorSchedules());
    }
    this.cancel();
  }
  editDoctorSchedule(d: DoctorSchedule) {
    this.doctorSchedule = d;
  }
  cancel() {
    this.doctorSchedule = new DoctorSchedule();
    this.tableMode = true;
  }
  delete(doctorScheduleId: number) {
    this.doctorScheduleService.deleteDoctorSchedule(doctorScheduleId)
      .subscribe(data => this.loadDoctorSchedules());
  }
  add() {
    this.router.navigateByUrl('create/doctorSchedule');
  }
}
