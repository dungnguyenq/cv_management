import { Injectable } from '@angular/core';
@Injectable()
export class CvUrl {
  public static get GET_CANDIDATES() : string {return '/api/candidate/all'}
  public static get REMOVE_CANDIDATE(): string { return '/api/candidate/{id}/delete'}
  public static get GET_PUT_CANDIDATE(): string {return '/api/candidate/{id}'}
  public static get ADD_CANDIDATE(): string {return '/api/candidate'}
  public static get SEND_MAIL(): string { return '/api/candidate/send-email'}

  public static get GET_LANGUAGES(): string {return '/api/masterdata/language/all'; }
  public static get GET_FRAMEWORKS(): string {return '/api/masterdata/framework/all'; }
  public static get GET_STATUS_LIST(): string {return '/api/masterdata/status/all'}
}

