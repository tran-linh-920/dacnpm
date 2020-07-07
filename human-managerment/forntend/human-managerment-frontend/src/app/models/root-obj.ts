import { Paging } from './paging';

export interface RootObj<T> {
    statusCode: number;
    data: T;
    message: string;
    paging: Paging;
}
