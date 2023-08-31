import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ErrorModalService } from 'src/app/Services/error-modal.service';

@Component({
  selector: 'app-error-modal',
  templateUrl: './error-modal.component.html',
  styleUrls: ['./error-modal.component.scss'],
})
export class ErrorModalComponent implements OnInit {
  public errors: Array<String> = [];
  public showErrorModal: boolean = false;

  constructor(private _errorModalService: ErrorModalService) {}

  ngOnInit(): void {
    this._errorModalService.errors$.subscribe(
      (x)=>{
        this.errors = x;

        if(this.errors.length==0){
          this.showErrorModal = false;
        } else{
          this.showErrorModal = true;
        }
      }
    )
  }

  public closeDialog(){
    this.showErrorModal = false;
  }
}
