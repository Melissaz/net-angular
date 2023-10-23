import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, lastValueFrom, of } from 'rxjs';
import { TeamMember } from '../models/team-member.model';
import { TEAM_MEMBERS } from '../mock-data/team-members';
import { environment } from 'src/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getTeamMembers(): Promise<TeamMember[]> {
    return Promise.resolve(TEAM_MEMBERS);
  }

  async getCapacity(): Promise<number> {
    const result = await lastValueFrom(this.http.get<number>(`${this.baseUrl}/capacity`));
    if (result === undefined) {
      throw new Error('No capacity data received');
    }
    return result;
  }

  async getVelocity(): Promise<number> {
    const result = await lastValueFrom(this.http.get<number>(`${this.baseUrl}/velocity`));
    if (result === undefined) {
      throw new Error('No velocity data received');
    }
    return result;
  }

  async getHolidays(country: string, startDate: string): Promise<any> {
    const result = await lastValueFrom(
      this.http.post<any>(`${this.baseUrl}/holidays`, {
        country,
        startDate
      })
    );
    if (result === undefined) {
      throw new Error('No holidays data received');
    }
    return result;
  }

  async getIssues(): Promise<any> {
    const result = await lastValueFrom(this.http.get<any>(`${this.baseUrl}/Issues`));
    if (result === undefined) {
      throw new Error('No issues data received');
    }
    return result;
  }

  async getCurrentSprint(): Promise<any> {
    const result = await lastValueFrom(this.http.get<any>(`${this.baseUrl}/Sprint/Current`));
    if (result === undefined) {
      throw new Error('No current sprint data received');
    }
    return result;
  }
}
