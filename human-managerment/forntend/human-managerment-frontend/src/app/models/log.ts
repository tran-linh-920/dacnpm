export interface Log {
    id: number;
    message: string;
    level: string;
    address: string;
    ip: string;
    createdAt: Date;
    userID: number;
}