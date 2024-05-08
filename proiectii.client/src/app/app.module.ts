// app.module.ts
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { DataComponent } from './app.component';
import { ApiService } from './api.service'; // Import the ApiService

@NgModule({
  declarations: [
    DataComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [ApiService], // Add the ApiService to the providers array
  bootstrap: [DataComponent]
})
export class AppModule { }