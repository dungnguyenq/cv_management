import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpClientModule,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppMessages } from "../shared/messages";
import { BaseUrl } from "../urls/base.url";

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor(
    private httpClientModule: HttpClientModule,
    private http: HttpClient
    ) { }
    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    private log(message: string) {
      return(message);
    }

    delete (url: string){
      const reqUrl = BaseUrl.API_ENDPOINT + url
      return this.http.delete(reqUrl, this.httpOptions).pipe(
        tap(_ => this.log(`deleted`)),
      );
    }
    getData(url: string): Observable<any>{
      const reqUrl = BaseUrl.API_ENDPOINT + url
      return this.http.get(reqUrl).pipe(
        tap(_ => this.log(`fetched`)),
      );
    }
    getDataList(url: string): Observable<any>{
      const reqUrl = BaseUrl.API_ENDPOINT + url
      return this.http.get(reqUrl).pipe(
        tap(_=> this.log(`fetched all`))
      )
    }
    addData(url: string, formData: FormData){
      const reqUrl = BaseUrl.API_ENDPOINT + url
      return this.http.post(reqUrl, formData).pipe(
        tap((newObject: any) => this.log("added")),
      )
    }
    putData(url: string, formData: FormData){
      const reqUrl = BaseUrl.API_ENDPOINT + url
      return this.http.put(reqUrl, formData).pipe(
        tap(_ => this.log(`updated`))
      )
    }
    // addHero (hero: Hero): Observable<Hero> {
    //   return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions).pipe(
    //     tap((newHero: Hero) => this.log(`added hero w/ id=${newHero.id}`)),
    //     catchError(this.handleError<Hero>('addHero'))
    //   );
    // }
}
