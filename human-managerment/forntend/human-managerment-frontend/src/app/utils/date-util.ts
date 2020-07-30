export class DateUtil {

    public static doStringToDateConverting(dateStr: string): string {
        const date = new Date(dateStr);
        return date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
    }

    public static doStringToTimeConverting(dateStr: string): string {
        if (dateStr == null || dateStr == '')
            return null;
        const date = new Date(dateStr);
        return date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
    }

    public static getTime(dateStr: string, format: string): Date {
        let date = new Date();
        if (format === 'hh:mm:ss') {
            let dateEle = dateStr.split(":");
            dateEle.forEach((ele, index) => {
                index == 0 ? date.setHours(parseInt(ele)) : index == 1 ? date.setMinutes(parseInt(ele)) : index == 2 ? date.setSeconds(parseInt(ele)) : 0;
            });
        }
        return date;
    }
}
