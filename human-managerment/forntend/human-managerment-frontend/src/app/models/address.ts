import { Ward } from './ward';
export interface Address {
    id: number;
    name: string;
    ward_Id: number;
    ward: Ward;
}