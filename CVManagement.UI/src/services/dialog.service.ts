import {Component, Injectable, ViewContainerRef, TemplateRef } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig } from '@angular/material/dialog';
import { Observable } from 'node_modules/rxjs';
import { DialogComponent } from '../app/dialog/dialog.component';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(private dialog: MatDialog) {
  }

  public openSuccessDialog(data) {
    data['type'] = 1; // success
    const dialogRef = this.openDialog(data);
    return dialogRef.afterClosed();
  }

  public openErrorDialog(data) {
    data['type'] = 2; // 2:error
    const dialogRef = this.openDialog(data);
    return dialogRef.afterClosed();
  }

  public openConfirmationDialog(data): Observable<any> {
    data['type'] = 3; // confirm
    data['yesOption'] = false;
    const dialogConfig = this.getDialogConfig();
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(DialogComponent, dialogConfig);
    return dialogRef.afterClosed();
  }

  public getDialogConfig(){
    let config = new MatDialogConfig();
    config.disableClose = true;
    config.width = '600px';
    return config;
  }

  public openComponentDialog(componentOrTemplateRef, data?: Object, config?: MatDialogConfig): Observable<any> {
    let dialogConfig =  Object.assign({}, this.getDialogConfig(), config);
    if (data) {
      dialogConfig.data = data;
    }
    let dialogRef = this.dialog.open(componentOrTemplateRef, dialogConfig);
    return dialogRef.afterClosed();
  }

  openDialog(data) {
    let dialogConfig = this.getDialogConfig();
    dialogConfig.data = data;
    let dialogRef = this.dialog.open(DialogComponent, dialogConfig);
    return dialogRef;
  }
}

