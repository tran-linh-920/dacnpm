import { Employee } from './employee';

export interface SalaryHistory {
    id: number,
    countedDate: Date,
    workDay: number,
    salaryCoefficient: number,
    taxMoney: number,
    rewardMoney: number,
    publishMoney: number,
    insurranceMoney: number,
    grossSalary: number,
    netSalary: number,
    isActive: boolean,
    employee: Employee
}
