import { WorkingTime } from './working-time';
import { TimeSlot } from './time-slot';

export interface WorkingTimeDetail {
    workingTimeId: number;
    workingTime: WorkingTime;
    timeSlotId:number;
    timeSlot: TimeSlot;
}
