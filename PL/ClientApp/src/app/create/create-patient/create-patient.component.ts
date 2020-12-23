import { Component, OnInit, OnDestroy } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Patient } from '../../_models/patient';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.css']
})
export class CreatePatientComponent implements OnInit, OnDestroy {
  private sub = new Subscription();
  patientForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  patientId: number;


  get f() { return this.patientForm.controls; }


  constructor(
    private patientService: PatientService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.patientForm = this.formBuilder.group({
      lastName: ['', Validators.required],
      firstName: ['', Validators.required],
      patronymic: [''],
      birthDate: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    });
  }

  OnSubmit() {
    this.submitted = true;

    if (this.patientForm.invalid) { return }

    this.loading = true;
    this.patientService.createPatient(this.f.lastName.value, this.f.firstName.value,
      this.f.patronymic.value, this.f.birthDate.value,
      this.f.phoneNumber.value)
      .subscribe(
        data => {
          this.router.navigateByUrl(`patients`);
        },
        error => {
          this.error = error;
          this.loading = false;
        }
      );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
