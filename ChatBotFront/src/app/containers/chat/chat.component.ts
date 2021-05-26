import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageDto } from 'src/app/Shared/Models/MessageDto';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  userName = '';
  message = '';
  messageList: {userName: string, messageBody: string}[] = [];
  body: {userName: string, messageBody: string}

  constructor(private http: HttpClient) { }

  userNameUpdate(name: string): void {
    this.userName = name;
  }
  callBotApi():void {
    this.http.post('https://localhost:44387/api/MsgFromUser', this.body).subscribe((response: any) =>{
      let messageDto = new MessageDto(response);
      this.messageList = messageDto.historyDto;
      console.log(messageDto);
    }, error => {
      console.log(error);
    });
  }

  sendMessage(): void{
    
    this.body = {userName: this.userName, messageBody: this.message};
    console.log(this.body);
    this.callBotApi();
    this.message = "";
  }
}
