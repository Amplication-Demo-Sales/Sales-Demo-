import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { InterviewService } from "./interview.service";
import { InterviewControllerBase } from "./base/interview.controller.base";

@swagger.ApiTags("interviews")
@common.Controller("interviews")
export class InterviewController extends InterviewControllerBase {
  constructor(
    protected readonly service: InterviewService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
