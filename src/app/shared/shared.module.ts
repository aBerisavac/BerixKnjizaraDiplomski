import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { NavigationComponent } from './navigation/navigation.component';
import { MatIconModule } from '@angular/material/icon';
import { PopupBottomRightComponent } from './popup-bottom-right/popup-bottom-right.component';
import { ErrorModalComponent } from './error-modal/error-modal.component';
import { OrderDetailsComponent } from './order-details/order-details.component';


@NgModule({
  declarations: [
    NavigationComponent,
    PopupBottomRightComponent,
    ErrorModalComponent,
    OrderDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    MatIconModule,
  ],
  exports: [
    NavigationComponent,
    PopupBottomRightComponent,
    ErrorModalComponent,
    OrderDetailsComponent
  ]
})
export class SharedModule { }
