import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IInputData } from 'src/model/InputData';



@Injectable()
export class CalculatorService {

    private baseUrl = 'http://localhost:5000/';

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }

    constructor(private http: HttpClient) { }


    add(data: IInputData): Observable<any> {
        return this.http.post(this.baseUrl+"add", data, this.httpOptions);
    }

    subtract(data: any): Observable<any> {
        return this.http.post(this.baseUrl+"subtract", JSON.stringify(data),this.httpOptions);
    }

    multiply(data: any): Observable<any> {
        return this.http.post(this.baseUrl+"multiply", JSON.stringify(data),this.httpOptions);
    }

    divide(data: any): Observable<any> {
        return this.http.post(this.baseUrl+"divide", JSON.stringify(data),this.httpOptions);
    }


}
