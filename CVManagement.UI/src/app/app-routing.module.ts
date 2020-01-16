import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import {CvComponent} from './cv/cv.component';
import { MasterDataTemplateComponent } from "./master-data/master-data-template/master-data-template.component";

const routes: Routes = [
  {path: '', component: CvComponent, pathMatch: 'full'},
  {path: 'masterdata/languages', component: MasterDataTemplateComponent, pathMatch: 'full'},
  {path: 'masterdata/frameworks', component: MasterDataTemplateComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
