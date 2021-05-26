export class MessageDto {
    username: string;
    messageBody: string;
    historyDto: {userName: string, messageBody: string}[]

    constructor(userResponse: any){
        this.username = userResponse.userName;
        this.messageBody = userResponse.messageBody;
        this.historyDto = userResponse.historyDto;
    }
}