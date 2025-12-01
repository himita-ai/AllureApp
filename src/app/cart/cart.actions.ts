import { createAction, props } from '@ngrx/store';
import { CartItem } from '../cart/cart.model';

export const loadCart = createAction(
  '[Cart] Load Cart',
  props<{ userId: number }>()
);

export const loadCartSuccess = createAction(
  '[Cart] Load Cart Success',
  props<{ items: CartItem[] }>()
);

export const loadCartFailure = createAction(
  '[Cart] Load Cart Failure',
  props<{ error: any }>()
);

export const addToCart = createAction(
  '[Cart] Add To Cart',
  props<{ cartItem: CartItem }>()
);

export const addToCartSuccess = createAction(
  '[Cart] Add To Cart Success'
);

export const addToCartFailure = createAction(
  '[Cart] Add To Cart Failure',
  props<{ error: string }>()
);

export const updateQuantity = createAction(
  '[Cart] Update Quantity',
  props<{ cartItemId: number; change: number }>() // change = +1 or -1
);

export const updateQuantitySuccess = createAction('[Cart] Update Quantity Success');

export const updateQuantityFailure = createAction(
  '[Cart] Update Quantity Failure',
  props<{ error: string }>()
);

export const deleteItem = createAction(
  '[Cart] Delete Item',
  props<{ cartItemId: number }>()
);

export const deleteItemSuccess = createAction('[Cart] Delete Item Success');

export const deleteItemFailure = createAction(
  '[Cart] Delete Item Failure',
  props<{ error: string }>()
);


