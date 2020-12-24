import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { DoctorService } from '../../_services/doctor.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Doctor } from '../../_models/doctor';
import { Router, ActivatedRoute } from '@angular/router';
import { Appointment } from '../../_models/appointment';
import { FreeTime } from '../../_models/freeTime';
import { AppointmentService } from '../../_services/appointment.service';
import { FreeTimeService } from '../../_services/freeTime.service';
import { SpecialtyService } from '../../_services/specialty.service';
import { Specialty } from '../../_models/specialty';

@Component({
  selector: 'app-create-appointment',
  templateUrl: './create-appointment.component.html',
  styleUrls: ['./create-appointment.component.css'],
  providers: [AppointmentService, FreeTimeService, SpecialtyService, DoctorService]
})
export class CreateAppointmentComponent implements OnInit, OnDestroy {
  private sub = new Subscription();
  appointmentForm: FormGroup;
  specialties: Specialty;
  freeTime: string[];
  doctors: Doctor[];
  doctorId: number;
  loading = false;
  isHavingSpecialties = false;
  isHavingTime = false;
  isHavingDoctors = false;
  submitted = false;
  error = '';
  appointmentId: number;


  get f() { return this.appointmentForm.controls; }


  constructor(
    private appointmentService: AppointmentService,
    private specialtyService: SpecialtyService,
    private freeTimeService: FreeTimeService,
    private doctorService: DoctorService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.OnGetSpecialties();
    this.appointmentForm = this.formBuilder.group({
      patientId: ['', Validators.required],
      specialty: ['', Validators.required],
      doctorId: ['', Validators.required],
      date: ['', Validators.required],
      time: ['', Validators.required],
    });

  }

  OnGetSpecialties(): void {
    this.isHavingDoctors = false;
    this.isHavingTime = false;
    this.specialtyService.getAllSpecialties()
      .subscribe(
        data => {
          this.specialties = data;
          this.isHavingSpecialties = true;
        },
        error => {
          this.error = error;
          this.loading = false;
          this.isHavingSpecialties = false;
    });
  }

  OnDoctorSelected(value: string): void {
    this.doctorId = Number(value);
  }

  OnGetDoctors(value: string): void {
    this.isHavingTime = false;
    this.doctorService.getDoctorsBySpecialty(value)
      .subscribe(
        data => {
          this.doctors = data;
          this.isHavingDoctors = true;
        },
        error => {
          this.error = error;
          this.loading = false;
          this.isHavingDoctors = false;
        }
    );
  }

  OnGetFreeTime(value: string): void {
    this.isHavingTime = true;
    this.freeTimeService.getFreeTimeByDateAndDoctorId(this.doctorId, value)
      .subscribe(
        data => {
          this.freeTime = data.freeTime;
        },
        error => {
          this.error = error;
          this.loading = false;
          this.isHavingTime = false;
        });
  }

  OnSubmit() {
    this.submitted = true;

    if (this.appointmentForm.invalid) { return }

    this.loading = true;
    let time: string = this.f.time.value;
    let hours: number = Number(time.substring(0, time.indexOf(':')));
    let minutes: number = Number(time.substring(time.indexOf(':') + 1));
    let date: Date = new Date(this.f.date.value);
    date.setUTCHours(hours, minutes);
    this.appointmentService.createAppointment(Number(this.f.doctorId.value), this.f.patientId.value,
      date.toISOString())
      .subscribe(
        data => {
          this.router.navigateByUrl(`appointments`);
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
