import { Candidate } from './candidate';

export interface Note {
    id: number;
    content: string;
    candidate: Candidate;
}