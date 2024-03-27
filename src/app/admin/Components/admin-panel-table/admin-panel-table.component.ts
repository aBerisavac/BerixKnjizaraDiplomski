import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { capitalizeFirstLetter } from 'common';

@Component({
  selector: 'app-admin-panel-table',
  templateUrl: './admin-panel-table.component.html',
  styleUrls: ['./admin-panel-table.component.scss']
})
export class AdminPanelTableComponent implements OnInit {
  @Input() jsonObjectArrayToDisplay: Array<object> = [];
  @Input() editable: boolean = true;
  @Input() deletable: boolean = true;
  @Input() clickable: boolean = true;
  @Output() editItem = new EventEmitter<any>();
  @Output() deleteItem = new EventEmitter<any>();
  @Output() rowClick = new EventEmitter<any>();

  public columns: Array<string> =[]
  public columnsCapitalised: Array<string> =[]
  public itemValues: Array<any> = [];

  ngOnInit(): void {
      if(this.jsonObjectArrayToDisplay.length>0){
        for(let entry of Object.entries(this.jsonObjectArrayToDisplay[0])){
          let columnName = capitalizeFirstLetter(entry[0].toLowerCase())
          this.columnsCapitalised.push(columnName)
          this.columns.push(entry[0])
        }
      }
  }

  setValuesOfObject(object: object){
    let values: Array<any> = [];
    for(let entry of Object.entries(object)){
      values.push(entry[1])
    }

    this.itemValues = values;
  }

}
