import { Injectable } from '@angular/core';
import { MasterDataUrl } from "../../../urls/master-data.url";
import { BaseService } from "../../../services/base.service";
import { Observable } from "rxjs";
import { MasterData } from '../../models/master-data.model';
@Injectable({
  providedIn: 'root'
})
export class MasterDataService {

  constructor(
    public baseService: BaseService
  ) { }

  getLanguages(): Observable<MasterData[]>{
    const url = MasterDataUrl.GET_LANGUAGES
    return this.baseService.getDataList(url)
  }
  removeLanguage(id) {
    const url = MasterDataUrl.REMOVE_LANGUAGE.replace('{id}', id);
    return this.baseService.delete(url);
  }
  addLanguage(formData){
    const url = MasterDataUrl.ADD_LANGUAGE
    return this.baseService.addData(url, formData);
  }
  getLanguage(id): Observable<MasterData>{
    const url = MasterDataUrl.GET_PUT_LANGUAGE.replace('{id}', id)
    return this.baseService.getData(url)
  }
  putLanguage(id, formData){
    const url = MasterDataUrl.GET_PUT_LANGUAGE.replace('{id}', id)
    return this.baseService.putData(url, formData)
  }

  getFrameworks(): Observable<MasterData[]>{
    const url = MasterDataUrl.GET_FRAMEWORKS
    return this.baseService.getDataList(url)
  }
  removeFramework(id) {
    const url = MasterDataUrl.REMOVE_FRAMEWORK.replace('{id}', id);
    return this.baseService.delete(url);
  }
  addFramework(formData){
    const url = MasterDataUrl.ADD_FRAMEWORK
    return this.baseService.addData(url, formData);
  }
  getFramework(id): Observable<MasterData>{
    const url = MasterDataUrl.GET_PUT_FRAMEWORK.replace('{id}', id);
    return this.baseService.getData(url)
  }
  putFramework(id, formData){
    const url = MasterDataUrl.GET_PUT_FRAMEWORK.replace('{id}', id)
    return this.baseService.putData(url, formData)
  }
}
