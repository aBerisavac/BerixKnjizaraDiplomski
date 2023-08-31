import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path:"",
    loadChildren: ()=> import("./commercial/commercial.module").then(result=>result.CommercialModule)
  },
  {
    path:"admin",
    loadChildren: ()=> import("./admin/admin.module").then(result=>result.AdminModule)
  },
  {
    path:"user",
    loadChildren: ()=> import("./user-access/user-access.module").then(result=>result.UserAccessModule)
  },
  {
    path: "**",
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
