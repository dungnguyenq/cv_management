import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import {CvEditorComponent} from '../cv-editor/cv-editor.component';
import { DialogService } from "../../services/dialog.service";
import { AppMessages } from "../../shared/messages";
import { CvService } from "./cv.service";
import { CvEditorService } from "../cv-editor/cv-editor.service";
import { Candidate } from "../models/candidate.model";
import { DomSanitizer } from '@angular/platform-browser';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { SendMailComponent } from '../send-mail/send-mail.component';

@Component({
  selector: 'app-cv',
  templateUrl: './cv.component.html',
  styleUrls: ['./cv.component.css']
})
export class CvComponent implements OnInit {

  imageSource : any;
  cvs : Array<Candidate>;
  pageOfItems: Array<any>;
  public candidateModel : Candidate;

  displayedColumns: string[] = ['avatar', 'fullName','languages', 'frameworks', 'linkedIn', 'status', 'cv', 'note', 'actions'];
  dataSource: MatTableDataSource<Candidate>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  constructor(
    private http: HttpClient,
    private dialog: MatDialog,
    public dialogService: DialogService,
    private cvService: CvService,
    private cvEditorService : CvEditorService,
    private sanitizer: DomSanitizer,
    ) { };

  ngOnInit() {
    this.cvService.getCandidates().subscribe(
      (result) => {
        this.dataSource = new MatTableDataSource(result)
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    )
  }

  onChangePage(pageOfItems: Array<any>) {
    this.pageOfItems = pageOfItems;
  }

  onAddCandidate(): void {
    const dialogRef = this.dialog.open(CvEditorComponent, {height: '500px',width: '900px', data: {id: {}}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.ngOnInit()
    });
  }
  onRemoveCandidate(id){
    this.dialogService.openConfirmationDialog({ message: AppMessages.dialog.confirmMessage1 }).subscribe(
      (result) => {
          if (result) {
              this.cvService.removeCandidate(id).subscribe(
                (result)=>{
                  this.ngOnInit()
                }
              );
          }
      });
  }

  onFullInfoCandidate(id : any): void {
    const dialogRef = this.dialog.open(CvEditorComponent, {height: '500px',width: '900px', data: {id: id, isFullInfo : true}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.ngOnInit()
    });
  }

  onEditCandidate(id : any): void {
    const dialogRef = this.dialog.open(CvEditorComponent, {height: '500px',width: '900px', data: {id: id, isEdit : true}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.ngOnInit()
    });
  }

  onSendMail(email : string): void {
    const dialogRef = this.dialog.open(SendMailComponent, {height: '400px',width: '600px', data: {email: email}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.ngOnInit()
    });
  }

}
