import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map, firstValueFrom } from 'rxjs';
import { selectCartItems } from 'src/app/cart/cart.selectors';
import { CartItem } from 'src/app/cart/cart.model';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/services/api.service';

declare var Razorpay: any; // Razorpay global object

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  cartItems$!: Observable<CartItem[]>;
  totalAmount$!: Observable<number>;

  constructor(private store: Store, private http: HttpClient, private api:ApiService ) {}

  ngOnInit(): void {
    this.cartItems$ = this.store.select(selectCartItems);

    this.totalAmount$ = this.cartItems$.pipe(
      map(items =>
        items.reduce((sum, item) => sum + item.UnitPrice * item.Quantity, 0)
      )
    );
  }

  async pay() {
    try {
      const amount = await firstValueFrom(this.totalAmount$);

      if (amount <= 0) {
        alert("Cart is empty or invalid amount!");
        return;
      }

      // Use PaymentService instead of HttpClient directly
      const orderResponse = await firstValueFrom(this.api.createOrder(amount));

      if (!orderResponse?.orderId) {
        alert("Failed to create order");
        return;
      }

      const options = {
        key: orderResponse.razorpayKey,
        amount: orderResponse.grandTotal,
        currency: orderResponse.currency,
        name: "Allure App",
        description: "Order Payment",
        order_id: orderResponse.orderId,
        handler: async (response: any) => {
          const verifyResponse = await firstValueFrom(this.api.verifyPayment({
            rzp_OrderId: response.razorpay_order_id,
            rzp_PaymentId: response.razorpay_payment_id,
            rzp_Signature: response.razorpay_signature,
            userId: 1 // replace with actual logged-in user
          }));

          if (verifyResponse?.message) {
            alert("Payment Successful!");
          } else {
            alert("Payment verification failed!");
          }
        },
        prefill: {
          name: "Jonny",
          email: "johny@ex.com",
          contact: "9999999999"
        },
        theme: { color: "#528FF0" }
      };

      const rzp = new Razorpay(options);
      rzp.open();

    } catch (error: any) {
      console.error(error);
      alert(error.message || "Payment failed!");
    }
}
}
