import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Customer } from '../customer/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  customerApi=environment.api+"/Customer";
  constructor(private http:HttpClient) { }

  GetCustomers(page:number){
    let query=page? `?pageNumber=${page}`:"";
    return this.http.get<CustomerResponse>(this.customerApi+query);
  }
  GetCustomer(id:number){
    return this.http.get<Customer>(this.customerApi+`/${id}`);
  }
  DeleteCustomer(id:number){
   return  this.http.delete(this.customerApi+`/${id}`);
  }
  AddCustomer(customer:Customer){
    return this.http.post(this.customerApi,customer);
  }
  UpdateCustomer(customer:Customer){
    return this.http.put(this.customerApi+`/${customer.id}`,customer);

  }
}

interface CustomerResponse{
  data: Customer[];
  numbOfPages:number;
}
