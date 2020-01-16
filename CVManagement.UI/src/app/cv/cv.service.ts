import { Injectable } from '@angular/core';
import { BaseService } from '../../services/base.service';
import { CvUrl } from "../../urls/cv.url";
@Injectable({
  providedIn: 'root'
})
export class CvService {

  constructor(
    public baseService: BaseService
  ) { }
  getCandidates(){
    const url = CvUrl.GET_CANDIDATES
    return this.baseService.getDataList(url)
  }
  removeCandidate(id) {
    const url = CvUrl.REMOVE_CANDIDATE.replace('{id}', id);
    return this.baseService.delete(url);
}
}
