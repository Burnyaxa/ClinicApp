import { Component, OnDestroy, OnInit } from '@angular/core';
import { VisitService } from '../../_services/visit.service';
import { Visit } from '../../_models/visit';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-visit',
  templateUrl: './list-visit.component.html',
  providers: [VisitService]
})
export class ListVisitComponent implements OnInit {

  visit: Visit = new Visit();
  visits: Visit[];
  tableMode: boolean = true;

  constructor(private visitService: VisitService, private router: Router) { }

  ngOnInit() {
    this.loadVisits();
  }

  loadVisits() {
    this.visitService.getVisits()
      .subscribe((data: Visit[]) => this.visits = data);
  }

  save() {
    if (this.visit.id == null) {
      this.visitService.createVisit(this.visit.doctorId, this.visit.patientId, this.visit.date,
        this.visit.diagnosis, this.visit.note)
        .subscribe((data: Visit) => this.visits.push(data));
    } else {
      this.visitService.updateVisit(this.visit.id, this.visit.doctorId, this.visit.patientId,
        this.visit.date, this.visit.diagnosis, this.visit.note)
        .subscribe(data => this.loadVisits());
    }
    this.cancel();
  }
  editVisit(d: Visit) {
    this.visit = d;
  }
  cancel() {
    this.visit = new Visit();
    this.tableMode = true;
  }
  delete(visitId: number) {
    this.visitService.deleteVisit(visitId)
      .subscribe(data => this.loadVisits());
  }
  add() {
    this.router.navigateByUrl('create/visit');
  }
}
