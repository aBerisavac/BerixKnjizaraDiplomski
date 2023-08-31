import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule} from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CartPopupComponent } from './Components/cart-popup/cart-popup.component';
import { AdminModule } from './admin/admin.module';
import { SharedModule } from './shared/shared.module';
import { CommercialModule } from './commercial/commercial.module';
import { UserAccessModule } from './user-access/user-access.module';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    CartPopupComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    AdminModule,
    SharedModule,
    CommercialModule,
    UserAccessModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
