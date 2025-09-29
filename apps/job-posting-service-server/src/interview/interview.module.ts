import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { InterviewModuleBase } from "./base/interview.module.base";
import { InterviewService } from "./interview.service";
import { InterviewController } from "./interview.controller";
import { InterviewResolver } from "./interview.resolver";

@Module({
  imports: [InterviewModuleBase, forwardRef(() => AuthModule)],
  controllers: [InterviewController],
  providers: [InterviewService, InterviewResolver],
  exports: [InterviewService],
})
export class InterviewModule {}
