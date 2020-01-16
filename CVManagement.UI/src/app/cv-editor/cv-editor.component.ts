import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { HttpClient } from '@angular/common/http';
import { CvEditorService } from "./cv-editor.service";
import { Candidate } from "../models/candidate.model";
import { NgForm, FormControl, FormBuilder, FormGroup, Validators, ReactiveFormsModule, AbstractControl, FormGroupDirective } from '@angular/forms';
import { DialogService } from "../../services/dialog.service";
import {ErrorStateMatcher} from '@angular/material/core';
import {Router} from "@angular/router"
import { Status } from '../models/status.model';
import { MasterDataService } from "../master-data/master-data-template/master-data.service";
import { MasterData } from '../models/master-data.model';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-cv-editor',
  templateUrl: './cv-editor.component.html',
  styleUrls: ['./cv-editor.component.css']
})
export class CvEditorComponent implements OnInit {
  matcher = new MyErrorStateMatcher();
  ad : any = { price : 0 };
  candidateModel = new Candidate;
  public title : any;
  public isFullInfo = false;
  public isEdit = false;
  languagesModel = new Array<MasterData>();
  frameworksModel = new Array<MasterData>();
  statusListModel = new Array<Status>();
  statusList = new FormControl();
  public addCandidateForm: FormGroup;

  fileData: File = null;
  cvData : File = null;
  previewUrl:any = null;
  fileUploadProgress: string = null;
  uploadedFilePath: string = null;
  cvUrl: any

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<CvEditorComponent>,
    private http : HttpClient,
    private cvEditorService : CvEditorService,
    public dialogService: DialogService,
    public masterDataService : MasterDataService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {}

  ngOnInit() {
    this.initData()
    if(this.data.id && this.data.isFullInfo){
      this.getCandidate(this.data.id);
      this.title = "Full Information"
      this.isFullInfo = true
      this.createForm()
      this.addCandidateForm.disable()
    }
    else if(this.data.id && this.data.isEdit){
      this.getCandidate(this.data.id);
      this.title = "Edit Candidate"
      this.isEdit = true
      this.createForm()
    }
  }

  initData(){
    this.createForm()
    this.title = "Add New Candidate"
    this.getLanguages()
    this.getFrameworks()
    this.getStatusList()
  }

  createForm(){
    this.addCandidateForm = this.formBuilder.group({
      firstName: ['',[Validators.required]],
      lastName: ['',[Validators.required]],
      dob: ['',[Validators.required]],
      university: '',
      email : ['', [
        Validators.required,
        Validators.email,
      ]],
      phoneNumber: '',
      linkedIn: '',
      facebook: '',
      languageIds: ['',[Validators.required]],
      frameworkIds: ['',[Validators.required]],
      statusId: ['',[Validators.required]],
      note: '',
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit() {
    if(this.data.id && this.data.isEdit){
      this.editCandidate(this.addCandidateForm)
    }
    else{
      this.addCandidate(this.addCandidateForm)
    }
  }

  addCandidate(addCandidateForm){
    const formData = new FormData();
    if (this.fileData) {
      formData.append('image', this.fileData);
    }
    if (this.cvData){
      formData.append('cv', this.cvData);
    }
    formData.append('data', JSON.stringify(this.addCandidateForm.value))
    this.cvEditorService.addCandidate(formData)
    .subscribe((result) => {
      this.dialogRef.close();
    })
  }

  editCandidate(addCandidateForm){
    const formData = new FormData();
    if (this.fileData) {
      formData.append('image', this.fileData);
    }
    if (this.cvData){
      formData.append('cv', this.cvData);
    }
    formData.append('data', JSON.stringify(this.addCandidateForm.value))
    console.log(formData.get("data"))
    this.cvEditorService.editCandidate(this.data.id, formData)
    .subscribe((result) => {
      this.dialogRef.close();
    })
  }
  getCandidate(id) {
    this.cvEditorService.getCandidate(id).subscribe(
        (result) => {
            if (result) {
                this.candidateModel = result;
                const dateOfBirth = (new Date(this.candidateModel.dob));
                this.addCandidateForm.get('firstName').setValue(this.candidateModel.firstName);
                this.addCandidateForm.get('lastName').setValue(this.candidateModel.lastName);
                this.addCandidateForm.get('dob').setValue(dateOfBirth);
                this.addCandidateForm.get('university').setValue(this.candidateModel.university);
                this.addCandidateForm.get('email').setValue(this.candidateModel.email);
                this.addCandidateForm.get('phoneNumber').setValue(this.candidateModel.phoneNumber);
                this.addCandidateForm.get('linkedIn').setValue(this.candidateModel.linkedIn);
                this.addCandidateForm.get('facebook').setValue(this.candidateModel.facebook);
                this.addCandidateForm.get('languageIds').setValue(this.candidateModel.languageIds);
                this.addCandidateForm.get('frameworkIds').setValue(this.candidateModel.frameworkIds);
                this.addCandidateForm.get('statusId').setValue(this.candidateModel.statusId);
                this.addCandidateForm.get('note').setValue(this.candidateModel.note);
                this.previewUrl = this.candidateModel.avatarUrl;
                this.cvUrl = this.candidateModel.cvUrl;
            }
        }
    );
  }
  getLanguages(){
    this.masterDataService.getLanguages().subscribe(
      (result) => {
        if (result) {
          this.languagesModel = result;
        }
      }
    )
  }
  getFrameworks(){
    this.masterDataService.getFrameworks().subscribe(
      (result) => {
        if (result) {
          this.frameworksModel = result;
        }
      }
    )
  }
  getStatusList(){
    this.cvEditorService.getStatusList().subscribe(
      (result) => {
        if (result){
          this.statusListModel = result;
        }
      }
    )
  }

  onLanguageChange(event){
    this.addCandidateForm.value.languageId = event.value;
  }
  onFrameworkChange(event){
    this.addCandidateForm.value.frameworkId = event.value;
  }


  fileProgress(fileInput: any) {
    this.fileData = <File>fileInput.target.files[0];
    this.preview();
  }
  cvProgress(cvInput: any) {
    this.cvData = <File>cvInput.target.files[0];
  }
  preview() {
    // Show preview
    var mimeType = this.fileData.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(this.fileData);
    reader.onload = (_event) => {
      this.previewUrl = reader.result;
    }
  }

}
