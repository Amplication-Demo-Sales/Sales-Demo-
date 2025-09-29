import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ApplicantModuleBase } from "./base/applicant.module.base";
import { ApplicantService } from "./applicant.service";
import { ApplicantController } from "./applicant.controller";
import { ApplicantResolver } from "./applicant.resolver";

@Module({
  imports: [ApplicantModuleBase, forwardRef(() => AuthModule)],
  controllers: [ApplicantController],
  providers: [ApplicantService, ApplicantResolver],
  exports: [ApplicantService],
})
export class ApplicantModule {}
