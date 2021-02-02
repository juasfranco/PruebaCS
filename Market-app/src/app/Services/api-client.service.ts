import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../Models/response';
import { Client } from 'src/app/Models/client';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  url: string = 'https://localhost:44372/api/Client';
  constructor(
    private _http: HttpClient
  ) { }

  getClient(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
  addClient(client: Client): Observable<Response> {
    return this._http.post<Response>(this.url, client, httpOption);
  }
  editClient(client: Client): Observable<Response> {
    return this._http.put<Response>(this.url, client, httpOption);
  }
  deleteClient(id: number): Observable<Response> {
    return this._http.delete<Response>(`${this.url}/${id}`);
  }
}
