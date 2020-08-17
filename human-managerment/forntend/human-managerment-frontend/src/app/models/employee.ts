import {Department} from './department';
import { Job } from './job';
import { Degree } from './degree';

export interface Employee {
    // Emp_ID: number;
    // F_Name: string;
    // L_Name: string;
    // image: string;
    // IDCard: string;
    // Hire_Date: Date;
    // email: string;
    // address: string;
    // salary: number;
    // commission: number;
    // Manager_ID: number;
    // Department_ID: Department;
    // isActive: boolean;

    id: number;
    firstname: string;
    lastname: string;
    birthDay: Date;
    gender: boolean;
    email: string;
    phoneNumber: string;
    hireDay: Date;
    jobLevel: number;
    imageName: string;
    job: Job;
    degrees?: [Degree];

}