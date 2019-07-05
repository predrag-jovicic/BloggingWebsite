import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentcommunicationService {

  constructor() { }

  replyCommentSelected = new EventEmitter<any>();

  raiseEvent(id){
    this.replyCommentSelected.emit(id);
  }
}
