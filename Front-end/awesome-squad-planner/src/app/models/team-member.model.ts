export interface TeamMember {
  Id: string;
  Name: string;
  Location: Location;
}

interface Location {
  Id: string;
  Country: string;
  Region: string;
}
