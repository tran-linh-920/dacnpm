import { Candidate } from './candidate';

export interface Schedule {
    id: number;
    interviewDate: Date;
    canId: number;
    canName: string;
    candidate: Candidate;
}