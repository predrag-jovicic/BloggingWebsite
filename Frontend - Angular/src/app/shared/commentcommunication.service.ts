import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentcommunicationService {

  constructor() { }

  replyCommentSelected = new EventEmitter<any>();
  postChanged = new EventEmitter<any>();

  raiseEvent(id){
    this.replyCommentSelected.emit(id);
  }

  raisePostChanged(id){
    this.postChanged.emit(id);
  }
}
