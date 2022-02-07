import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
const baseUrl = 'https://localhost:44373/api/CustomerRegistration';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private headers: HttpHeaders;
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getAll(): Observable<Customer[]>
  {
    return this.http.get<Customer[]>(`${baseUrl}/GetCustomers`, {headers: this.headers});
  }
  get(id: any): Observable<Customer> {
    return this.http.get(`${baseUrl}/GetCustomers/${id}`);
  }
  create(data: any): Observable<any> {
    return this.http.post(`${baseUrl}/PostCustomer`, data);
  }
  update(id: any, data: any): Observable<any> {
    return this.http.post(`${baseUrl}/PutCustomer`, data);
  }
  delete(id: any): Observable<any> {
    return this.http.post(`${baseUrl}/DeleteCustomer/${id}`,'');
  }
  deleteAll(): Observable<any> {
    return this.http.delete(baseUrl);
  }
  findByTitle(customerName: any): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${baseUrl}/GetCustomersByName/${customerName}`);
  }
  

}
