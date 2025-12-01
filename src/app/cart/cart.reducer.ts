import { createReducer, on } from '@ngrx/store';
import * as CartActions from './cart.actions';
import { CartItem } from '../cart/cart.model';

export interface CartState {
  items: CartItem[];
  loading: boolean;
  error: any;
  totalAmount: number;
}

export const initialState: CartState = {
  items: [],
  loading: false,
  error: null,
  totalAmount: 0
};

export const cartReducer = createReducer(
  initialState,

  on(CartActions.loadCart, (state) => ({
    ...state,
    loading: true,
  })),

  on(CartActions.loadCartSuccess, (state, { items }) => ({
    ...state,
    loading: false,
    items,
  })),

  on(CartActions.loadCartFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  })),
   on(CartActions.addToCartSuccess, state => ({ ...state })),
     on(CartActions.updateQuantitySuccess, state => ({ ...state })),
       on(CartActions.deleteItemSuccess, state => ({ ...state })),
);
