import { Component, OnInit } from '@angular/core';
import { BackendService } from '../../services/backend.service';
import { Question } from '../../models/Question';
import { Subject } from '../../models/subject';
import { Concept } from '../../models/concept';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  constructor(private backendService: BackendService) { }
      public questions: Question[];
    public subjects: Subject[];
    public concept: Concept[];
    public subjectId = null;
        public conceptId = null;

    ngOnInit() {
      
        this.RefreshSubjects();
        this.RefreshConcepts();
        this.RefreshQuestions();
            
    
    } // end on init

    RefreshSubjects(){
       this.backendService.getSubjects()
      .subscribe(success => {
        if (success) {
          this.subjects = this.backendService.subjects;
        }
      });
    }

      RefreshConcepts(){
            this.backendService.getConcepts(this.subjectId)
      .subscribe(success => {
        if (success) {
          this.concept = this.backendService.concepts;
        }
      });
}
    RefreshQuestions(){
     this.backendService.getQuestions(this.conceptId)
      .subscribe(success => {
        if (success) {
          this.questions = this.backendService.questions;
        }
      });
    }

}
