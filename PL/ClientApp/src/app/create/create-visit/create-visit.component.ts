import { Component, OnInit, OnDestroy } from '@angular/core';
import { VisitService } from '../../_services/visit.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Visit } from '../../_models/visit';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-visit',
  templateUrl: './create-visit.component.html',
  styleUrls: ['./create-visit.component.css']
})
export class CreateVisitComponent implements OnInit, OnDestroy {
  private sub = new Subscription();
  visitForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  visitId: number;


  get f() { return this.visitForm.controls; }


  constructor(
    private visitService: VisitService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.visitForm = this.formBuilder.group({
      doctorId: ['', Validators.required],
      patientId: ['', Validators.required],
      date: ['', Validators.required],
      diagosis: [''],
      note: ['']
    });
  }

  OnSubmit() {
    this.submitted = true;

    if (this.visitForm.invalid) { return }

    this.loading = true;
    this.visitService.createVisit(this.f.doctorId.value, this.f.patientId.value,
      this.f.date.value, this.f.diagnosis.value,
      this.f.note.value)
      .subscribe(
        data => {
          this.router.navigateByUrl(`visits`);
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
