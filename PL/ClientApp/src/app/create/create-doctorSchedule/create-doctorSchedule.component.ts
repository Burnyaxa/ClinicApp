import { Component, OnInit, OnDestroy } from '@angular/core';
import { DoctorScheduleService } from '../../_services/doctorSchedule.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Days, DoctorSchedule } from '../../_models/doctorSchedule';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-doctorSchedule',
  templateUrl: './create-doctorSchedule.component.html',
  styleUrls: ['./create-doctorSchedule.component.css']
})
export class CreateDoctorScheduleComponent implements OnInit, OnDestroy {
  private sub = new Subscription();
  doctorScheduleForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  doctorScheduleId: number;


  get f() { return this.doctorScheduleForm.controls; }


  constructor(
    private doctorScheduleService: DoctorScheduleService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.doctorScheduleForm = this.formBuilder.group({
      doctorId: ['', Validators.required],
      day: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
    });
  }

  OnSubmit() {
    this.submitted = true;

    if (this.doctorScheduleForm.invalid) { return }

    this.loading = true;
    this.doctorScheduleService.createDoctorSchedule(this.f.doctorId.value, Number(this.f.day.value),
      this.f.startTime.value, this.f.endTime.value)
      .subscribe(
        data => {
          this.router.navigateByUrl(`doctorSchedules`);
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
