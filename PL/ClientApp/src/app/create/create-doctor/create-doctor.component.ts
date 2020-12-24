import { Component, OnInit, OnDestroy } from '@angular/core';
import { DoctorService } from '../../_services/doctor.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Doctor } from '../../_models/doctor';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-doctor',
  templateUrl: './create-doctor.component.html',
  styleUrls: ['./create-doctor.component.css']
})
export class CreateDoctorComponent implements OnInit, OnDestroy {
  private sub = new Subscription();
  doctorForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  doctorId: number;


  get f() { return this.doctorForm.controls; }


  constructor(
    private doctorService: DoctorService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.doctorForm = this.formBuilder.group({
      lastName: ['', Validators.required],
      firstName: ['', Validators.required],
      patronymic: [''],
      specialty: ['', Validators.required],
      address: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      cabinet: ['', Validators.required]
    });
  }

  OnSubmit() {
    this.submitted = true;

    if (this.doctorForm.invalid) { return }

    this.loading = true;
    this.doctorService.createDoctor(this.f.lastName.value, this.f.firstName.value,
      this.f.patronymic.value, this.f.specialty.value,
      this.f.phoneNumber.value, this.f.address.value, this.f.cabinet.value)
      .subscribe(
        data => {
          this.router.navigateByUrl(`doctors`);
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
