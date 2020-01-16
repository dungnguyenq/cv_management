import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MasterDataService } from '../master-data-template/master-data.service';
import { MasterData } from 'src/app/models/master-data.model';

@Component({
  selector: 'app-master-data-dialog',
  templateUrl: './master-data-dialog.component.html',
  styleUrls: ['./master-data-dialog.component.css']
})
export class MasterDataDialogComponent implements OnInit {

  model = new MasterData;
  title: any

  constructor(
    public masterDataService : MasterDataService,
    public dialogRef: MatDialogRef<MasterDataDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit() {
    if(this.data.id){
      if (this.data.isLanguages){
        this.getLanguage(this.data.id)
        this.title = 'Edit Language'
      }
      else{
        this.getFramework(this.data.id)
        this.title = 'Edit Framework'
      }
    }
    else{
      if (this.data.isLanguages){
        this.title = 'Add New Language'
      }
      else{
        this.title = 'Add New Framework'
      }
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.data.isLanguages){
      if(this.data.isEdit){
        this.editLanguage()
      }
      else{
        this.addLanguage()
      }
    }
    else{
      if(this.data.isEdit){
        this.editFramework()
      }
      else{
        this.addFramework()
      }
    }
    this.dialogRef.close();
  }

  getLanguage(id){
    this.masterDataService.getLanguage(id).subscribe(
      (result) => {
        if(result){
          this.model = result
        }
      }
    )
  }

  getFramework(id){
    this.masterDataService.getFramework(this.data.id).subscribe(
      (result) =>{
        this.model = result
      }
    )
  }

  addLanguage(){
    const formData = new FormData();
    formData.append('name', this.model.name);
    formData.append('description', this.model.description);
    this.masterDataService.addLanguage(formData).subscribe(
      (result) =>{
      }
    )
  }
  addFramework(){
    const formData = new FormData();
    formData.append('name', this.model.name);
    formData.append('description', this.model.description);
    this.masterDataService.addFramework(formData).subscribe(
      (result) =>{
      }
    )
  }

  editLanguage(){
    const formData = new FormData();
    formData.append('name', this.model.name);
    formData.append('description', this.model.description);
    this.masterDataService.putLanguage(this.data.id, formData).subscribe(
      (result) => {
      }
    )
  }
  editFramework(){
    const formData = new FormData();
    formData.append('name', this.model.name);
    formData.append('description', this.model.description);
    this.masterDataService.putFramework(this.data.id, formData).subscribe(
      (result) => {
      }
    )
  }
}
