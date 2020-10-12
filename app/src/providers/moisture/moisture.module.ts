import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MoistureApiInterceptor } from './moisture-server.interceptor';
import { MoistureService } from './moisture.service';


@NgModule({
  imports: [],
  exports: [],
  declarations: [],
  providers: [
    MoistureService,
    {
      provide: 'MOISTURE_API_URL',
      useValue: environment.moistureApiUrl
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MoistureApiInterceptor,
      multi: true,
    },
    MoistureService
  ],
})
export class MoistureModule { }
