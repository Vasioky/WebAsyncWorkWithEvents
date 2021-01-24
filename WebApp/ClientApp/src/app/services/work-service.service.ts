import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Work } from './model/work';

@Injectable({
  providedIn: 'root'
})
export class WorkServiceService {
  private url = "http://localhost:5002/api/processor";
  constructor(private http: HttpClient) { }

  startWork(x: number, y: number): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }
    return this.http.post(this.url, { x, y }, httpOptions);
  }
}
