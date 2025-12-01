import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as CartActions from 'src/app/cart/cart.actions';
import { selectCartItems, selectCartLoading } from 'src/app/cart/cart.selectors';
import { CartItem } from 'src/app/cart/cart.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  cartItems$!: Observable<CartItem[]>;
  loading$!: Observable<boolean>;
  userId = 4; // replace this with your actual logged-in user's ID


  constructor(private store: Store, private router:Router) {}

  ngOnInit(): void {
    this.store.dispatch(CartActions.loadCart({ userId: this.userId }));
    this.cartItems$ = this.store.select(selectCartItems);
    this.loading$ = this.store.select(selectCartLoading);
  }
  
   increaseQuantity(id: number) {
    this.store.dispatch(CartActions.updateQuantity({ cartItemId: id, change: +1 }));
  }

  decreaseQuantity(id: number) {
    this.store.dispatch(CartActions.updateQuantity({ cartItemId: id, change: -1 }));
  }
   deleteItem(id: number) {
    this.store.dispatch(CartActions.deleteItem({ cartItemId: id }));
  }
  goToCheckout() {
  this.router.navigate(['/admin/checkout']);
}
}
