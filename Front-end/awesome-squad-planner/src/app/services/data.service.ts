import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TeamMember } from '../models/team-member.model';
import { TEAM_MEMBERS } from '../mock-data/team-members';
import { environment } from 'src/environment';

@Injectable({
  providedIn: 'root'
})

export class DataService {

  baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }
  getTeamMembers(): Observable<TeamMember[]> {
    return of(TEAM_MEMBERS);
  }

  getCapacity(): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/capacity`);
  }

  getVelocity(): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/velocity`);
  }

  getHolidays(country: string, startDate: string): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/holidays`, {
      country,
      startDate
    });
  }

  getIssues(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Issues`);
  }

  getCurrentSprint(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Sprint/Current`);
  }
}
