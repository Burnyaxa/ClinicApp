import { Component, OnDestroy, OnInit } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { Patient } from '../../_models/patient';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-patient',
  templateUrl: './list-patient.component.html',
  providers: [PatientService]
})
export class ListPatientComponent implements OnInit {

  patient: Patient = new Patient();
  patients: Patient[];
  tableMode: boolean = true;

  constructor(private patientService: PatientService, private router: Router) { }

  ngOnInit() {
    this.loadPatients();
  }

  loadPatients() {
    this.patientService.getPatients()
      .subscribe((data: Patient[]) => this.patients = data);
  }

  save() {
    if (this.patient.id == null) {
      this.patientService.createPatient(this.patient.lastName, this.patient.firstName,
        this.patient.patronymic, this.patient.birthDate, this.patient.phoneNumber)
        .subscribe((data: Patient) => this.patients.push(data));
    } else {
      this.patientService.updatePatient(this.patient.id, this.patient.lastName, this.patient.firstName,
        this.patient.patronymic, this.patient.birthDate, this.patient.phoneNumber)
        .subscribe(data => this.loadPatients());
    }
    this.cancel();
  }
  editPatient(d: Patient) {
    this.patient = d;
  }
  cancel() {
    this.patient = new Patient();
    this.tableMode = true;
  }
  delete(patientId: number) {
    this.patientService.deletePatient(patientId)
      .subscribe(data => this.loadPatients());
  }
  add() {
    this.router.navigateByUrl('create/patient');
  }
}
