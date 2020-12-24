import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Days, DoctorSchedule } from '../_models/doctorSchedule';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TimeSpan } from '../_models/timespan';

@Injectable({
  providedIn: 'root'
})
export class DoctorScheduleService {
  private backendUrl = `${environment.url}/doctorSchedules`

  constructor(private http: HttpClient) { }

  getDoctorSchedules(): Observable<DoctorSchedule[]> {
    return this.http.get<DoctorSchedule[]>(this.backendUrl);
  }

  getDoctorSchedule(id: number): Observable<DoctorSchedule> {
    return this.http.get<DoctorSchedule>(`${this.backendUrl}/${id}`);
  }

  createDoctorSchedule(doctorId: number, day: number, startTime: string, endTime: string): Observable<DoctorSchedule> {
    return this.http.post<DoctorSchedule>(this.backendUrl, { doctorId, day, startTime, endTime });
  }

  updateDoctorSchedule(doctorScheduleId: number, doctorId: number, day: number, startTime: string, endTime: string): Observable<any> {
    return this.http.put<any>(`${this.backendUrl}/${doctorScheduleId}`, { doctorId, day, startTime, endTime });
  }

  deleteDoctorSchedule(doctorScheduleId: number): Observable<any> {
    return this.http.delete<any>(`${this.backendUrl}/${doctorScheduleId}`);
  }

  getDoctorSchedulesByDoctorId(doctorId: number): Observable<DoctorSchedule[]> {
    return this.http.get<DoctorSchedule[]>(`${this.backendUrl}/doctor/${doctorId}`);
  }

  searchDoctorSchedules(url: string): Observable<DoctorSchedule[]> {
    return this.http.get<any>(`${environment.url}${url}`)
  }
}
