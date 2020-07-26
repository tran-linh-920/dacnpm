import {District} from './district'
export interface Province {
    id: number;
    name: string;
    districts: District[];
}