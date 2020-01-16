import { Injectable } from '@angular/core';
@Injectable()
export class MasterDataUrl {
  public static get GET_LANGUAGES(): string {return '/api/masterdata/language/all'}
  public static get REMOVE_LANGUAGE(): string{ return '/api/masterdata/language/{id}/delete'}
  public static get ADD_LANGUAGE(): string { return '/api/masterdata/language'}
  public static get GET_PUT_LANGUAGE(): string{ return '/api/masterdata/language/{id}'}

  public static get GET_FRAMEWORKS(): string {return '/api/masterdata/framework/all'; }
  public static get REMOVE_FRAMEWORK(): string{ return '/api/masterdata/framework/{id}/delete'}
  public static get ADD_FRAMEWORK(): string { return '/api/masterdata/framework'}
  public static get GET_PUT_FRAMEWORK(): string{ return '/api/masterdata/framework/{id}'}

  public static get GET_STATUS_LIST(): string {return '/api/masterdata/status/all'}
}
