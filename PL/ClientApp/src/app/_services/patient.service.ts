import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../_models/patient';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private backendUrl = `${environment.url}/patients`

  constructor(private http: HttpClient) { }

  getPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.backendUrl);
  }

  getPatient(id: number): Observable<Patient> {
    return this.http.get<Patient>(`${this.backendUrl}/${id}`);
  }

  createPatient(lastName: string, firstName: string, patronymic: string, birthDate: Date, phoneNumber: string): Observable<Patient> {
    return this.http.post<Patient>(this.backendUrl, { lastName, firstName, patronymic, birthDate, phoneNumber});
  }

  updatePatient(patientId: number, lastName: string, firstName: string, patronymic: string, birthDate: Date, phoneNumber: string): Observable<any> {
    return this.http.put<any>(`${this.backendUrl}/${patientId}`, { lastName, firstName, patronymic, birthDate, phoneNumber});
  }

  deletePatient(patientId: number): Observable<any> {
    return this.http.delete<any>(`${this.backendUrl}/${patientId}`);
  }

  searchPatients(url: string): Observable<Patient[]> {
    return this.http.get<any>(`${environment.url}${url}`)
  }
}
