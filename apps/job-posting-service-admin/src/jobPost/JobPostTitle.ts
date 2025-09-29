import { JobPost as TJobPost } from "../api/jobPost/JobPost";

export const JOBPOST_TITLE_FIELD = "id";

export const JobPostTitle = (record: TJobPost): string => {
  return record.id?.toString() || String(record.id);
};
