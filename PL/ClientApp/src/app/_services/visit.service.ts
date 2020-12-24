import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Visit } from '../_models/visit';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TimeSpan } from '../_models/timespan';

@Injectable({
  providedIn: 'root'
})
export class VisitService {
  private backendUrl = `${environment.url}/visits`

  constructor(private http: HttpClient) { }

  getVisits(): Observable<Visit[]> {
    return this.http.get<Visit[]>(this.backendUrl);
  }

  getVisit(id: number): Observable<Visit> {
    return this.http.get<Visit>(`${this.backendUrl}/${id}`);
  }

  createVisit(doctorId: number, patientId: number, date: Date, diagnosis: string, note: string): Observable<Visit> {
    return this.http.post<Visit>(this.backendUrl, { patientId, doctorId, date, diagnosis, note });
  }

  updateVisit(visitId: number, doctorId: number, patientId: number, date: Date, diagnosis: string, note: string): Observable<any> {
    return this.http.put<any>(`${this.backendUrl}/${visitId}`, { patientId, doctorId, date, diagnosis, note });
  }

  deleteVisit(visitId: number): Observable<any> {
    return this.http.delete<any>(`${this.backendUrl}/${visitId}`);
  }

  getVisitsByDoctorId(doctorId: number): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.backendUrl}/doctor/${doctorId}`);
  }

  getVisitsByPatientId(patientId: number): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.backendUrl}/patient/${patientId}`);
  }

  searchVisits(url: string): Observable<Visit[]> {
    return this.http.get<any>(`${environment.url}${url}`)
  }
}
