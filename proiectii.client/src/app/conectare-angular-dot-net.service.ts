import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ConectareAngularDotNetService{
  constructor(private http: HttpClient) {}

  getDataFromEndpoint(): Observable<any> {
    return this.http.get('http://localhost:5000/api/my-endpoint'); // Adjust the endpoint URL as needed
  }
}
