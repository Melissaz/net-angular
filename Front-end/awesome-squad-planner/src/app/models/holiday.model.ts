export interface Holiday {
  id: string;
  summary: string;
  description: string;
  start: DateObject;
  end: DateObject;
}

interface DateObject {
  date: string;
}
