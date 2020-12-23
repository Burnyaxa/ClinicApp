import { Component, OnDestroy, OnInit } from '@angular/core';
import { DoctorService } from '../../_services/doctor.service';
import { Doctor } from '../../_models/doctor';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-doctor',
  templateUrl: './list-doctor.component.html',
  providers: [DoctorService]
})
export class ListDoctorComponent implements OnInit {

  doctor: Doctor = new Doctor();   
  doctors: Doctor[];               
  tableMode: boolean = true; 

  constructor(private doctorService: DoctorService, private router: Router) { }

  ngOnInit() {
    this.loadDoctors();   
  }

  loadDoctors() {
    this.doctorService.getDoctors()
      .subscribe((data: Doctor[]) => this.doctors = data);
  }

  save() {
    if (this.doctor.id == null) {
      this.doctorService.createDoctor(this.doctor.lastName, this.doctor.firstName,
        this.doctor.patronymic, this.doctor.specialty, this.doctor.phoneNumber, this.doctor.address,
      this.doctor.cabinet)
        .subscribe((data: Doctor) => this.doctors.push(data));
    } else {
      this.doctorService.updateDoctor(this.doctor.id, this.doctor.lastName, this.doctor.firstName,
        this.doctor.patronymic, this.doctor.specialty, this.doctor.phoneNumber, this.doctor.address,
        this.doctor.cabinet)
        .subscribe(data => this.loadDoctors());
    }
    this.cancel();
  }
  editDoctor(d: Doctor) {
    this.doctor = d;
  }
  cancel() {
    this.doctor = new Doctor();
    this.tableMode = true;
  }
  delete(doctorId: number) {
    this.doctorService.deleteDoctor(doctorId)
      .subscribe(data => this.loadDoctors());
  }
  add() {
    this.router.navigateByUrl('create/doctor');
  }
}
