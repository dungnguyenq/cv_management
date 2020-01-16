import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
@Injectable()
export class BaseUrl {
  public static get API_ENDPOINT(): string { return environment.apiEndpoint; }
}
