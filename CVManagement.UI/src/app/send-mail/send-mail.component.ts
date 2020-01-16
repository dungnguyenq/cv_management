import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { MyErrorStateMatcher } from '../cv-editor/cv-editor.component';
import { BaseUrl } from 'src/urls/base.url';
import { CvEditorService } from "../cv-editor/cv-editor.service";

@Component({
  selector: 'app-send-mail',
  templateUrl: './send-mail.component.html',
  styleUrls: ['./send-mail.component.css']
})
export class SendMailComponent implements OnInit {

  public sendMailForm: FormGroup;

  matcher = new MyErrorStateMatcher();
  constructor(
    private formBuilder: FormBuilder,
    public cvService : CvEditorService,
    public dialogRef: MatDialogRef<SendMailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit() {
    this.createForm()
  }

  onSubmit(){
    const formData = new FormData();
    formData.append('data', JSON.stringify(this.sendMailForm.value));
    console.log(this.sendMailForm.value)
    console.log(formData.get("data"))
    this.cvService.sendMail(formData).subscribe(
      (result)=>{
        this.dialogRef.close();
      }
    )
  }

  createForm(){
    this.sendMailForm = this.formBuilder.group({
      emailTo: [{value: this.data.email, disabled: false},[Validators.required,Validators.email]],
      emailCc: ['', [Validators.email]],
      subject: ['',[Validators.required]],
      body: ['',[Validators.required]]
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
