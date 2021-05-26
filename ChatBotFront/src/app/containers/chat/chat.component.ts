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
    // Please double check your port where API is hosted usually it will be 5001 but if you build your project in VS as default it will be 44387
    let url: string = "https://localhost:5001/api/MsgFromUser"; 
    this.http.post(url, this.body).subscribe((response: any) =>{
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
