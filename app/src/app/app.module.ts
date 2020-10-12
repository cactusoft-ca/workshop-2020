import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AngularFittextModule } from 'angular-fittext';
import { MoistureModule } from 'src/providers/moisture/moisture.module';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MoistureModule,
    AngularFittextModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
