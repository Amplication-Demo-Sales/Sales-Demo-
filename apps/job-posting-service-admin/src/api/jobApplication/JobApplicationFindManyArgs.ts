import { JobApplicationWhereInput } from "./JobApplicationWhereInput";
import { JobApplicationOrderByInput } from "./JobApplicationOrderByInput";

export type JobApplicationFindManyArgs = {
  where?: JobApplicationWhereInput;
  orderBy?: Array<JobApplicationOrderByInput>;
  skip?: number;
  take?: number;
};
