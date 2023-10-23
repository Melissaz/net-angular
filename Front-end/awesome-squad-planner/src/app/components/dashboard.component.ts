import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Issue } from '../models/issue.model';
import { Holiday } from '../models/holiday.model';
import { TeamMember } from '../models/team-member.model';
import { Sprint } from '../models/sprint.model';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  capacity: number = 0;
  velocity: number = 0;
  issues: Issue[] = [];
  holidays: { [key: string]: Holiday[] } = {};
  teamMembers: TeamMember[] = [];
  startDate: string = new Date().toISOString();
  currentSprint: Sprint[] = [];

  constructor(private dataService: DataService) {}

  async ngOnInit(): Promise<void> {
    await this.loadData();
  }

  private async loadData(): Promise<void> {
    try {
      const [currentSprint, capacity, velocity, issues, teamMembers] = await Promise.all([
        this.dataService.getCurrentSprint(),
        this.dataService.getCapacity(),
        this.dataService.getVelocity(),
        this.dataService.getIssues(),
        this.dataService.getTeamMembers()
      ]);

      this.currentSprint = currentSprint;
      this.capacity = capacity;
      this.velocity = velocity;
      this.issues = issues;
      this.teamMembers = teamMembers;

      const holidaysPromises = this.teamMembers.map(async member => {
        this.holidays[member.Id] = await this.loadHolidaysForMember(member);
      });
      await Promise.all(holidaysPromises);
    } catch (error) {
      console.error('Error loading data:', error);
    }
  }

  private async loadHolidaysForMember(member: TeamMember): Promise<Holiday[]> {
    try {
      const startDate = this.currentSprint[0]?.startDate || new Date().toISOString();
      const holidays = await this.dataService.getHolidays(member.Location.Country, startDate);
      return holidays;
    } catch (error) {
      console.error('Error loading holidays for member:', member.Id, error);
      return [];
    }
  }
}
