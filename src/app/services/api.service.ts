import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { UserModel } from '../models/user-model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CartItem } from '../cart/cart.model';
import { map } from 'rxjs/operators';

interface CreateOrderRequest {
  amount: number;
}

interface CreateOrderResponse {
  orderId: string;
  currency: string;
  grandTotal: number;
  razorpayKey: string;
  receipt: string;
}

interface VerifyPaymentRequest {
  rzp_OrderId: string;
  rzp_PaymentId: string;
  rzp_Signature: string;
  userId: number;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }
  url=environment.api
  saveUser(obj:UserModel):Observable<any>{
    return this.http.post<any>(`${this.url}/User/InsertOrUpdateUser`,obj,{
     headers: { 'Content-Type': 'application/json' }
  });

  }
  verifyUser(username:any, password:any):Observable<any>{
    let param=new HttpParams();
    param=param.set('email', username)
    param=param.set('password', password)
    return this.http.get<any>(`${this.url}/User/VerifyUser`, {params: param});
  }
    getAllUser():Observable<any>{
    return this.http.get<any>(`${this.url}/User/GetAllUsers`);
  }
   getNavItems(): Observable<any>{
    return this.http.get<any>(`${this.url}/User/GetAdminNavItems`)
  }
    getAllRoles(): Observable<any>{
    return this.http.get<any>(`${this.url}/Role/GetAllRoles`)
  }
  saveRole(obj: any): Observable<any>{
      return this.http.post<any>(`${this.url}/Role/InsertOrUpdateRole`, obj)
  }
  assignRole(obj: any): Observable<any>{
      return this.http.post<any>(`${this.url}/User/AssignRoleToUser`, obj)
  }
  getProducts(): Observable<any>{
    return this.http.get<any>(`${this.url}/Product/GetAllProduct`)
  }
  getCategories(): Observable<any>{
    return this.http.get<any>(`${this.url}/Product/GetAllCategories`)
  }
   saveProduct(obj: any): Observable<any>{
      return this.http.post<any>(`${this.url}/Product/InsertOrUpdateProduct`, obj)
  }
  getFrontPage(): Observable<any>{
    return this.http.get<any>(`${this.url}/Product/GetFrontPageProducts`)
  }
  // saveImage(file:any,productId:any): Observable<any>{
  //   let params=new HttpParams();
  //   params=params.set('productId',productId);
  //   // const formData: FormData = new FormData();
  //   // formData.append('file', file);
  //   return this.http.post<any>(`${this.url}/Image/SaveImage`, file,{params:params});
  // }
saveImage(formData: FormData, productId: any): Observable<any> {
  let params = new HttpParams().set('productId', productId);
  return this.http.post<any>(`${this.url}/Image/SaveImage`, formData, { params: params });
}
  deleteProduct(productId:any): Observable<any>{
    let param=new HttpParams();
    param=param.set('productId',productId);
    return this.http.delete<any>(`${this.url}/Product/DeleteProduct`,{params:param});
  }
  getCart(userId: number): Observable<any> {
    return this.http.get(`${this.url}/Cart/GetCart?UserId=${userId}`);
  }
  addToCart(cartItem: any) {
  return this.http.post(`${this.url}/Cart/AddToCart`, cartItem);
}
updateQuantity(cartItemId: number, change: number) {
  const endpoint = change > 0
    ? `${this.url}/Cart/IncreaseQuantity?Id=${cartItemId}`
    : `${this.url}/Cart/DecreaseQuantity?Id=${cartItemId}`;
  return this.http.put(endpoint, {});
}
deleteItem(cartItemId: number) {
  return this.http.delete(`${this.url}/Cart/DeleteItem?Id=${cartItemId}`);
}
createOrder(amount: number): Observable<CreateOrderResponse> {
    const payload: CreateOrderRequest = { amount };
    return this.http.post<CreateOrderResponse>(`${this.url}/Payment/create-order`, payload);
  }

  verifyPayment(request: VerifyPaymentRequest): Observable<any> {
    return this.http.post<any>(`${this.url}/Payment/verify`, request);
  }


}



