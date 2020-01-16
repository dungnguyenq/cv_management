import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { Subscription } from 'node_modules/rxjs';

import { AppMessages } from '../../shared/messages';
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  public title: string = AppMessages.dialog.successTitle;
  public message: string = '';
  public primaryButtons = AppMessages.dialog.closeButton;
  public secondaryButtons = AppMessages.dialog.cancelButton;
  public titleType = [AppMessages.dialog.successTitle, AppMessages.dialog.errorTitle, AppMessages.dialog.successTitle]; //0: success, 1:error
  public yesOption = false;

  constructor(public dialogRef:MatDialogRef<DialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data:any) {

}

  ngOnInit() {
    let dialogType = this.data["type"] || null;
    this.generateDialog(dialogType);
  }

  generateDialog(type) {
    this.title = this.data["title"] || this.titleType[type-1];
    this.message = this.data["message"] || this.message;
    switch (type-1) {
      case (0): //0: success dialog
        this.primaryButtons = this.data["primaryButtons"] || AppMessages.dialog.closeButton;
        this.secondaryButtons = this.data["secondaryButtons"] || null;
        break;
      case (1): //error dialog
        this.primaryButtons = this.data["primaryButtons"] || AppMessages.dialog.closeButton;
        this.secondaryButtons = this.data["secondaryButtons"] || null;
        break;
      case (2):  //confirm dialog
        this.primaryButtons = this.data["primaryButtons"] || AppMessages.dialog.yesButton;
        this.secondaryButtons = this.data["secondaryButtons"] || AppMessages.dialog.cancelButton;
        break;
      default:
        break;
    }
  }

  onPrimaryButton(){
    this.yesOption = true;
    this.dialogRef.close(this.yesOption);
  }

  onSecondaryButton(){
    this.yesOption = false;
    this.dialogRef.close(this.yesOption);
  }

}
