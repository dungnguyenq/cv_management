import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CvComponent } from './cv/cv.component';
import { CvEditorComponent } from './cv-editor/cv-editor.component';
import { MatDialogModule} from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { MaterialModule } from "../app/cv-editor/material-module";
import { from } from 'rxjs';
import { DialogComponent } from './dialog/dialog.component';
import { MasterDataTemplateComponent } from './master-data/master-data-template/master-data-template.component';
import { MasterDataDialogComponent } from './master-data/master-data-dialog/master-data-dialog.component';
import { JwPaginationComponent } from 'jw-angular-pagination';
import { SendMailComponent } from './send-mail/send-mail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CvComponent,
    CvEditorComponent,
    DialogComponent,
    MasterDataTemplateComponent,
    MasterDataDialogComponent,
    JwPaginationComponent,
    SendMailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ApiAuthorizationModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  entryComponents: [DialogComponent, CvEditorComponent, MasterDataDialogComponent, SendMailComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
