
import { JobLevel } from './job-level';
export interface Job {
    id: number;
    jobTitle: string;
    jobBio: string;
    jobLevel: JobLevel;
}
