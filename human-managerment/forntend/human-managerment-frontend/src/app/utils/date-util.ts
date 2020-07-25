export class DateUtil {

    public doStringToDateConverting(dateStr: string): string{
        const date = new Date(dateStr);
        return date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
    }
}
