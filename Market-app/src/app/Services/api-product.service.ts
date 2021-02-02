import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Models/product';
import { Response } from '../Models/response';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiProductService {
  url: string = 'https://localhost:44372/api/Product';
  constructor(
    private _http: HttpClient
  ) { }

  getProduct(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
  addProduct(product: Product): Observable<Response> {
    return this._http.post<Response>(this.url, product, httpOption);
  }
  editProduct(product: Product): Observable<Response> {
    return this._http.put<Response>(this.url, product, httpOption);
  }
  deleteProduct(id: number): Observable<Response> {
    return this._http.delete<Response>(`${this.url}/${id}`);
  }
}
