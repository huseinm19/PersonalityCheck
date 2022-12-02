import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { QuestionService } from '../../services/question.service';
import {Router} from "@angular/router"

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {

  public name: string = "";
  public questionList: any[] = [];
  public currentQuestion: number = 0;
  public points: number = 0;
  public resultText:string = "";
  progress: string = "0";
  isQuizCompleted : boolean = false;
  user: User = new User();
  constructor(private questionService: QuestionService,
              private router: Router) { }

  ngOnInit(): void {
    this.name = localStorage.getItem("name")!;
    this.getAllQuestions();
  }
  async getAllQuestions() {
    await this.questionService.getQuestionJson()
      .subscribe(res => {
        this.questionList = res.data;
      })
  }
  async saveResult() {
    this.user.FullName = localStorage.getItem("name")!;
    this.user.ResultPercentage = (this.points/4 * 100) + "%";
    if ((this.points/4 * 100) > 50)
      this.resultText = "You are more of an introvert";
    else
      this.resultText = "You are more of an extrovert";
    await this.questionService.saveResult(this.user)
      .subscribe(res => {
        console.log(res);
      })
  }
  nextQuestion() {
    this.currentQuestion++;
  }
  previousQuestion() {
    this.currentQuestion--;
  }
  answer(currentQno: number, option: any) {
    if(currentQno === this.questionList.length){
      this.saveResult();
      this.isQuizCompleted = true;
    }
      this.points += option.value;
      setTimeout(() => {
        this.currentQuestion++;
        this.getProgressPercent();
      }, 1000);
  }
  resetQuiz(fromResult = false) {
    this.getAllQuestions();
    this.points = 0;
    this.currentQuestion = 0;
    this.progress = "0";
    if (fromResult)
      this.router.navigate(['/welcome'])
  }
  getProgressPercent() {
    this.progress = ((this.currentQuestion / this.questionList.length) * 100).toString();
    return this.progress;
  }
}
