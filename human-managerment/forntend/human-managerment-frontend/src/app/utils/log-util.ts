import { HttpRequest } from '@angular/common/http';
import { IpService } from '../services/ip.service';
import { LogService } from '../services/log.service';
import { Log } from '../models/log';

export class LogUtil {
    log: Log;
    constructor(private ipService: IpService, private logService: LogService) {
    }

createLog(request: any, userID: number) {
        if (request.method === 'GET' || request.url.includes('logs')) {
            return 'do nothing';
        } else {
            if (userID < 1) {
                userID = null;
            }
            const url = request.url;
            const message = this.createMessage(request.url, request.method, request.body);
            let address = '';
            const level = this.checkLevel( request.method);
            this.ipService.getIPAddress().subscribe(res => {
                address = res.ip;
                this.log = {id: 0, address: address, ip: '127.0.0.1', message: message, createdAt: new Date(),
                             level: level, userID: userID};
                this.logService.addLog(this.log).subscribe( res => {
                    console.log(res);
            });
            });
        }
    }

createMessage(url: string, method: string, data: any) {
        let res = '';
        if (data instanceof FormData) {
            var object = {};
            data.forEach((value, key) => {object[key] = value});
            data = object;
            console.log(data);
            
        }
        switch (method) {
            case 'POST':
                res = 'Thêm ';
                break;
            case 'PUT':
                res = 'Cập nhật ';
                break;
            case 'DELETE':
                res = 'Xóa ';
                break;
        }
        switch (true) {
            case url.includes('candidates'):
                console.log(data.Firstname);
                
                res += 'ứng viên ' + data.Firstname;
                break;
            case url.includes('addresses/province'):
                res += 'tỉnh ' + data.name;
                break;
            case url.includes('addresses/district'):
                res += 'thành phố ' + data.name;
                break;
            case url.includes('addresses/ward'):
                res += 'phường ' + data.name;
                break;
            case url.includes('degrees'):
                res += 'bằng cấp ' + data.imageName;
                break;
            case url.includes('schedules'):
                res = 'Lập lịch phỏng vấn ' + data.canName + ' lúc ' + data.interviewDate;
                break;
            case url.includes('notes'):
                res += 'ghi chú ' + data.candidate + ' của ' + data.candidate.firstname;
                break;
            case url.includes('salaries/counting'):
                res = 'Tính lương ngày' + data;
                break;
            case url.includes('salaries/increasing'):
                res = 'nâng/giảm lương ' + data;
                break;
            case url.includes('login'):
                res = 'đăng nhập dưới tên ' + data.username;
                break;
           default:
               break;
       }
       return res;

    }

checkLevel(method: string) {
        switch (method) {
            case 'POST':
                return 'Low';
            case 'PUT':
                return 'Medium';
            case 'DELETE':
                return 'High';
            default:
                break;
        }
    }

}