import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { User } from '../models/User';
@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private http : HttpClient) { }
  url:string = "https://localhost:7011/api/"

  getQuestionJson(){
    return this.http.get<any>(this.url + "GetQuestionsAndAnswers" + '?email=huseinm10@hotmail.com');
  }

  saveResult(user: User){
    return this.http.post<any>(this.url + "SaveResult", user);
  }
}
