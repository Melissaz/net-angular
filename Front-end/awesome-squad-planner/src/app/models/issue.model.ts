export interface Issue {
  id: string;
  key: string;
  fields: IssueFields;
}

interface IssueFields {
  issuetype: IssueType;
  created: string;
  customfield_10020: Sprint[];
  status: IssueStatus;
}

interface IssueType {
  id: string;
  description: string;
  iconUrl: string;
  name: string;
}

interface Sprint {
  name: string;
  startDate: string;
  endDate: string;
}

interface IssueStatus {
  name: string;
  iconUrl: string;
}
