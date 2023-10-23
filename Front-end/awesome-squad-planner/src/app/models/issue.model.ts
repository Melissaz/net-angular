export interface SearchResponse {
    total: number;
    issues: Issue[];
  }
  
  export interface Issue {
    id: string;
    key: string;
    fields: IssueFields;
  }
  
  interface IssueFields {
    issueType: IssueType;
    created: string;
    customField_10016: number;
    customField_10020: Sprint[];
    status: IssueStatus;
  }
  
  interface IssueType {
    id: string;
    description: string;
    iconUrl: string;
    name: string;
  }
  
  interface Sprint {
    id: string;
    name: string;
    startDate: string;
    endDate: string;
  }
  
  interface IssueStatus {
    name: string;
    iconUrl: string;
  }
  