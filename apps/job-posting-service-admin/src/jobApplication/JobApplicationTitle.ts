import { JobApplication as TJobApplication } from "../api/jobApplication/JobApplication";

export const JOBAPPLICATION_TITLE_FIELD = "id";

export const JobApplicationTitle = (record: TJobApplication): string => {
  return record.id?.toString() || String(record.id);
};
