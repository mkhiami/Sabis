import { HttpClient, HttpResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs"
import { map } from 'rxjs/operators';
import { Question } from '../models/Question';
import { Concept } from '../models/concept';
import { Subject } from '../models/subject';

@Injectable()
    export class BackendService {
    public questions: Question[] = [];
    public concepts: Concept[] = [];
    public subjects: Subject[] = [];
    public question: Question;
      constructor(private http: HttpClient) {}

    getQuestions(conceptId:any): Observable<boolean> {
        let url = "/api/sabis/questions";
        if(!isNaN(conceptId) && conceptId > 0) url += "?conceptid="+conceptId;
    return this.http.get(url)
      .pipe(
        map((data: any[]) => {
          this.questions = data;
          return true;
      }))};
     getQuestion(id): Observable<boolean> {
    return this.http.get("/api/sabis/question/"+id)
      .pipe(
        map((data: Question) => {
          this.question = data;
          return true;
      }))};
  getSubjects(): Observable<boolean> {
    return this.http.get("/api/sabis/subjects")
      .pipe(
        map((data: any[]) => {
          this.subjects = data;
          return true;
      }))};
      getConcepts(id): Observable<boolean> {
    return this.http.get("/api/sabis/concepts?subjectid="+id)
      .pipe(
        map((data: Concept[]) => {
          this.concepts = data;
          return true;
      }))};

 
    //I could have used a question parameter but opted for a proprty 
    saveQuestion(){
         return this.http.post("/api/sabis/question", this.question).subscribe(data => {console.log("question saved successfully ", data); }, error => { console.log("Error in save question", error); } );  
}

}
