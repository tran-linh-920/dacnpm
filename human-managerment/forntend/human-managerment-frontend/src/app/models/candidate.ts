import { Note } from './note';

export interface Candidate {
    id: number;
    firstname: string;
    lastname: string;
    birthDay: string;
    gender: boolean;
    email: string;
    phoneNumber: string;
    imageName: string;
    ethnic: string;
    hometown: string;
    IDCard: string;
    degree: string;
    career: string;
    experience: string;
    literacy: string;
    skill: string;
    hobby: string;
    position: string;
    status: number;
    note: Note;



}