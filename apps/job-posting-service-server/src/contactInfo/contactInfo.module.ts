import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ContactInfoModuleBase } from "./base/contactInfo.module.base";
import { ContactInfoService } from "./contactInfo.service";
import { ContactInfoController } from "./contactInfo.controller";
import { ContactInfoResolver } from "./contactInfo.resolver";

@Module({
  imports: [ContactInfoModuleBase, forwardRef(() => AuthModule)],
  controllers: [ContactInfoController],
  providers: [ContactInfoService, ContactInfoResolver],
  exports: [ContactInfoService],
})
export class ContactInfoModule {}
