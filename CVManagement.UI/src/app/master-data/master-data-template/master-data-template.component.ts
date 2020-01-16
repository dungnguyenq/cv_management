import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { NgForm, FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule, AbstractControl, FormGroupDirective } from '@angular/forms';
import { DialogService } from "../../../services/dialog.service";
import { AppMessages } from "../../../shared/messages";
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { MasterDataService } from "./master-data.service";
import { AppRoutingModule } from "../../app-routing.module";
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';
import { MasterDataDialogComponent } from '../master-data-dialog/master-data-dialog.component';
import { DialogModel } from "../../models/dialog-model.model";

@Component({
  selector: 'app-master-data-template',
  templateUrl: './master-data-template.component.html',
  styleUrls: ['./master-data-template.component.css']
})
export class MasterDataTemplateComponent implements OnInit {

  displayedColumns: string[] = ['name', 'description', 'action'];
  dataSource = new MatTableDataSource([]);
  currentPage: any;
  addButton: any;
  languagesPage = 'languages'
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  public dialogData = new DialogModel();

  constructor(
    private masterDataService: MasterDataService,
    public dialogService: DialogService,
    private dialog: MatDialog,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.initData()
    if( this.currentPage === this.languagesPage){
      this.addButton = 'Add Language'
      this.getLanguages();
    }
    else{
      this.addButton = 'Add Framework'
      this.getFrameworks();
    }

  }

  initData(){
    this.dialogData.height = '300px'
    this.dialogData.width = '500px'
    this.route.url.subscribe(url => this.currentPage = url[1].path);
  }

  onRemove(id){
    this.dialogService.openConfirmationDialog({ message: AppMessages.dialog.confirmMessage1 }).subscribe(
      (result) => {
          if (result) {
            if(this.currentPage === this.languagesPage){
                      this.masterDataService.removeLanguage(id).subscribe(
                        result => {
                          this.ngOnInit()
                        }
                      )
                    }
                    else{
                      this.masterDataService.removeFramework(id).subscribe(
                        result => {
                          this.ngOnInit()
                        }
                      )
                    }
                  }
                });
  }

  onEdit(id): void{
    if(this.currentPage === this.languagesPage){
      this.openDialog(id, true, true)
    }
    else{
      this.openDialog(id, false, true)
    }
  }

  onAddLanguage(): void {
    if(this.currentPage === this.languagesPage){
      this.openDialog(null, true, false)
    }
    else{
      this.openDialog(null, false, false)
    }
  }

  getLanguages(){
    this.masterDataService.getLanguages().subscribe(
      (result) => {
        if (result) {
          this.dataSource = new MatTableDataSource(result);
        }
      }
    )
  }

  getFrameworks(){
    this.masterDataService.getFrameworks().subscribe(
      (result) => {
        if (result) {
          this.dataSource = new MatTableDataSource(result);
        }
      }
    )
  }

  openDialog(id, isLanguages, isEdit): void{
    const dialogRef = this.dialog.open(MasterDataDialogComponent, {height: this.dialogData.height, width: this.dialogData.width, data: {id: id, isLanguages: isLanguages, isEdit: isEdit}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.ngOnInit()
    });
  }
}
