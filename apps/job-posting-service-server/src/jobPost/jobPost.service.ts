import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { JobPostServiceBase } from "./base/jobPost.service.base";

@Injectable()
export class JobPostService extends JobPostServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
