import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FreeTime } from '../_models/freeTime';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FreeTimeService {
  private backendUrl = `${environment.url}/freeTimes`

  constructor(private http: HttpClient) { }

  getFreeTimeByDateAndDoctorId(doctorId: number, date: Date): Observable<FreeTime> {
    return this.http.get<FreeTime>(`${this.backendUrl}?date=${date}&doctorId=${doctorId}`);
  }
}
