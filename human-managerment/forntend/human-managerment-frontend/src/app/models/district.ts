import { Province } from './province';
import { Ward } from './ward';

export interface District {
    id: number;
    name: string;
    province_Id: number;
    province: Province;
    wards: Ward[];
}