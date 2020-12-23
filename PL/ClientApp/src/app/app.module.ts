import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CreateDoctorComponent } from './create/create-doctor/create-doctor.component';
import { ListDoctorComponent } from './list/list-doctor/list-doctor.component';
import { CreatePatientComponent } from './create/create-patient/create-patient.component';
import { ListPatientComponent } from './list/list-patient/list-patient.component';
import { CreateDoctorScheduleComponent } from './create/create-doctorSchedule/create-doctorSchedule.component';
import { ListDoctorScheduleComponent } from './list/list-doctorSchedules/list-doctorSchedule.component';
import { CreateVisitComponent } from './create/create-visit/create-visit.component';
import { ListVisitComponent } from './list/list-visit/list-visit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CreateDoctorComponent,
    ListDoctorComponent,
    CreatePatientComponent,
    ListPatientComponent,
    CreateDoctorScheduleComponent,
    ListDoctorScheduleComponent,
    CreateVisitComponent,
    ListVisitComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'doctors', component: ListDoctorComponent },
      { path: 'create/doctor', component: CreateDoctorComponent },
      { path: 'patients', component: ListPatientComponent },
      { path: 'create/patient', component: CreatePatientComponent },
      { path: 'doctorSchedules', component: ListDoctorScheduleComponent },
      { path: 'create/doctorSchedule', component: CreateDoctorScheduleComponent },
      { path: 'visits', component: ListVisitComponent },
      { path: 'create/visit', component: CreateVisitComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
