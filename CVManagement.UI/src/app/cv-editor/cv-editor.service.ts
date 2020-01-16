import { Injectable } from '@angular/core';
import { BaseService } from "../../services/base.service";
import { CvUrl } from "../../urls/cv.url";
import { Observable } from 'rxjs';
import { Candidate } from '../models/candidate.model';
import { Status } from "../models/status.model";

@Injectable({
  providedIn: 'root'
})
export class CvEditorService {

  constructor(
    public baseService : BaseService
    ) { }
    getCandidate(id): Observable<Candidate>{
      const url = CvUrl.GET_PUT_CANDIDATE.replace('{id}', id)
      return this.baseService.getData(url)
    }
    addCandidate(formData: FormData){
      const url = CvUrl.ADD_CANDIDATE
      return this.baseService.addData(url, formData)
    }
    editCandidate(id: string, formData: FormData){
      const url = CvUrl.GET_PUT_CANDIDATE.replace('{id}', id)
      return this.baseService.putData(url, formData)
    }
    getStatusList(): Observable<Status[]>{
      const url = CvUrl.GET_STATUS_LIST
      return this.baseService.getDataList(url)
    }
    sendMail(formData: FormData){
      const url = CvUrl.SEND_MAIL
      return this.baseService.addData(url, formData)
    }
}
