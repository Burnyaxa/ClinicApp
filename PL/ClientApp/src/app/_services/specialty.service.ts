import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Specialty } from '../_models/specialty';

@Injectable({
  providedIn: 'root'
})
export class SpecialtyService {
  private backendUrl = `${environment.url}/specialties`

  constructor(private http: HttpClient) { }

  getAllSpecialties(): Observable<Specialty> {
    return this.http.get<Specialty>(this.backendUrl);
  }
}
