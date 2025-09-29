import { JobPostWhereInput } from "./JobPostWhereInput";
import { JobPostOrderByInput } from "./JobPostOrderByInput";

export type JobPostFindManyArgs = {
  where?: JobPostWhereInput;
  orderBy?: Array<JobPostOrderByInput>;
  skip?: number;
  take?: number;
};
