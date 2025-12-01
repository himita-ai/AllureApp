import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ApiService } from '../services/api.service';
import * as CartActions from './cart.actions';
import { catchError, map,switchMap, mergeMap, of } from 'rxjs';


@Injectable()
export class CartEffects {
  constructor(private actions$: Actions, private apiService: ApiService) {}

  loadCart$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CartActions.loadCart),
      mergeMap(({ userId }) =>
        this.apiService.getCart(userId).pipe(
          map((response: any) => {
            if (response.Success && response.Result) {
              return CartActions.loadCartSuccess({ items: response.Result });
            } else {
              return CartActions.loadCartFailure({ error: response.Status });
            }
          }),
          catchError((error) =>
            of(CartActions.loadCartFailure({ error: error.message }))
          )
        )
      )
    )
  );
  
addToCart$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CartActions.addToCart),
      mergeMap(action =>
        this.apiService.addToCart(action.cartItem).pipe(
          switchMap(() => [
            CartActions.addToCartSuccess(),
            // 🔄 Reload cart after adding
            CartActions.loadCart({ userId: action.cartItem.UserId }),
          ]),
          catchError(error =>
            of(CartActions.addToCartFailure({ error: error.message }))
          )
        )
      )
    )
  );

   
  updateQuantity$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CartActions.updateQuantity),
      mergeMap(action =>
        this.apiService.updateQuantity(action.cartItemId, action.change).pipe(
          switchMap(() => [
            CartActions.updateQuantitySuccess(),
            CartActions.loadCart({ userId: 4 }) // your current logged-in user
          ]),
          catchError(error => of(CartActions.updateQuantityFailure({ error: error.message })))
        )
      )
    )
  );
 
  deleteItem$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CartActions.deleteItem),
      mergeMap(action =>
        this.apiService.deleteItem(action.cartItemId).pipe(
          switchMap(() => [
            CartActions.deleteItemSuccess(),
            CartActions.loadCart({ userId: 4 })
          ]),
          catchError(error => of(CartActions.deleteItemFailure({ error: error.message })))
        )
      )
    )
  );
}
