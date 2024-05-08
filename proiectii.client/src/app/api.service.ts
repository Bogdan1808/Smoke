import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:4000/api'; // Replace this with your .NET backend URL
  constructor(private http: HttpClient) { }
  getData() {
    return this.http.get(`${this.apiUrl}/data`);
  }
}
