import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppointmentStatus, Appointment } from '../_models/appointment';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { TimeSpan } from '../_models/timespan';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  private backendUrl = `${environment.url}/appointments`

  constructor(private http: HttpClient) { }

  getAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.backendUrl);
  }

  getAppointment(id: number): Observable<Appointment> {
    return this.http.get<Appointment>(`${this.backendUrl}/${id}`);
  }

  createAppointment(doctorId: number, patientId: number, date: string, status: number = 0): Observable<Appointment> {
    return this.http.post<Appointment>(this.backendUrl, { doctorId, patientId, date, status });
  }

  updateAppointment(appointmentId: number, doctorId: number, patientId: number, date: string, status: number = 0): Observable<any> {
    return this.http.put<any>(`${this.backendUrl}/${appointmentId}`, { doctorId, patientId, date, status });
  }

  deleteAppointment(appointmentId: number): Observable<any> {
    return this.http.delete<any>(`${this.backendUrl}/${appointmentId}`);
  }

  getAppointmentsByDoctorId(doctorId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.backendUrl}/doctor/${doctorId}`);
  }

  getAppointmentsByPatientId(patientId: number): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.backendUrl}/patient/${patientId}`);
  }

  searchAppointments(url: string): Observable<Appointment[]> {
    return this.http.get<any>(`${environment.url}${url}`)
  }
}
