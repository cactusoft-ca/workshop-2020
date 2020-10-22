import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { interval, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class MoistureService {

  public constructor(private httpClient: HttpClient) { }

  public getMoisture(): Observable<number> {
    return interval(environment.moistureRefreshInterval).pipe(
      switchMap(() => this.httpClient.get<number>('moisture'))
    );
  }
}