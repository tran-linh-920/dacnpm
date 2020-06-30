import {WorkingTimeDetail} from './working-time-detail';

export interface WorkingTime {
    id: number;
    name: string;
    bio: string;
    workingTimeDetails: WorkingTimeDetail[];
}
