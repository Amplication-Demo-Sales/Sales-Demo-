import { Interview as TInterview } from "../api/interview/Interview";

export const INTERVIEW_TITLE_FIELD = "id";

export const InterviewTitle = (record: TInterview): string => {
  return record.id?.toString() || String(record.id);
};
