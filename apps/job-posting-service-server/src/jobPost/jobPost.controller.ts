import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { JobPostService } from "./jobPost.service";
import { JobPostControllerBase } from "./base/jobPost.controller.base";

@swagger.ApiTags("jobPosts")
@common.Controller("jobPosts")
export class JobPostController extends JobPostControllerBase {
  constructor(
    protected readonly service: JobPostService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
