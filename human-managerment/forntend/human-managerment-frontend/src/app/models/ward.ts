import { District } from './district';
import { Address } from './address';

export interface Ward {
    id: number;
    name: string;
    district_Id: number;
    district: District;
    addresses: Address[];
}