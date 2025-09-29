import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { JobPostModuleBase } from "./base/jobPost.module.base";
import { JobPostService } from "./jobPost.service";
import { JobPostController } from "./jobPost.controller";
import { JobPostResolver } from "./jobPost.resolver";

@Module({
  imports: [JobPostModuleBase, forwardRef(() => AuthModule)],
  controllers: [JobPostController],
  providers: [JobPostService, JobPostResolver],
  exports: [JobPostService],
})
export class JobPostModule {}
