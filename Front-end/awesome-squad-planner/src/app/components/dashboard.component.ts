import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Issue } from '../models/issue.model';
import { Holiday } from '../models/holiday.model';
import { TeamMember } from '../models/team-member.model';
import { Sprint } from '../models/sprint.model';

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
  startDate: string =  new Date().toISOString();
  currentSprint: Sprint[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.loadCurrentSprint();
    this.loadCapacity();
    this.loadVelocity();
    this.loadIssues();
    this.loadTeamMembers();
  }

  loadCurrentSprint(): void {
    this.dataService.getCurrentSprint().subscribe(data => {
      this.currentSprint = data;
    });
  }

  loadTeamMembers(): void {
    this.dataService.getTeamMembers().subscribe(data => {
      this.teamMembers = data;
      for (const member of this.teamMembers) {
        this.loadHolidaysForMember(member);
      }
    });
  }

  loadHolidaysForMember(member: TeamMember): void {
    this.startDate = this.currentSprint[0]?.startDate ? this.currentSprint[0]?.startDate : new Date().toISOString();
    this.dataService.getHolidays(member.Location.Country, this.startDate).subscribe(holidays => {
      this.holidays[member.Id] = holidays;
    });
  }

  loadCapacity(): void {
    this.dataService.getCapacity().subscribe(data => {
      this.capacity = data;
    });
  }

  loadVelocity(): void {
    this.dataService.getVelocity().subscribe(data => {
      this.velocity = data;
    });
  }

  loadIssues(): void {
    this.dataService.getIssues().subscribe(data => {
      this.issues = data.issues;
    });
  }
}
