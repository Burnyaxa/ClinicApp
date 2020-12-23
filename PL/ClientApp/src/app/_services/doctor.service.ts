import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doctor } from '../_models/doctor';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private backendUrl = `${environment.url}/doctors`

  constructor(private http: HttpClient) { }

  getDoctors(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(this.backendUrl);
  }

  getDoctor(id: number): Observable<Doctor> {
    return this.http.get<Doctor>(`${this.backendUrl}/${id}`);
  }

  createDoctor(lastName: string, firstName: string, patronymic: string, specialty: string, phoneNumber: string, address: string, cabinet: number): Observable<Doctor> {
    return this.http.post<Doctor>(this.backendUrl, { lastName, firstName, patronymic, specialty, address, phoneNumber, cabinet });
  }

  updateDoctor(doctorId: number, lastName: string, firstName: string, patronymic: string, specialty: string, phoneNumber: string, address: string, cabinet: number): Observable<any> {
    return this.http.put<any>(`${this.backendUrl}/${doctorId}`, { lastName, firstName, patronymic, specialty, address, phoneNumber, cabinet });
  }

  deleteDoctor(doctorId: number): Observable<any> {
    return this.http.delete<any>(`${this.backendUrl}/${doctorId}`);
  }

  searchDoctors(url: string): Observable<Doctor[]> {
    return this.http.get<any>(`${environment.url}${url}`)
  }
}
