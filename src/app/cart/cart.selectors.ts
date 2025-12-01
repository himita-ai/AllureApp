import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CartState } from './cart.reducer';

export const selectCartState = createFeatureSelector<CartState>('cart');

export const selectCartItems = createSelector(
  selectCartState,
  (state) => state.items
);

export const selectCartLoading = createSelector(
  selectCartState,
  (state) => state.loading
);
export const selectCartTotal = createSelector(
  selectCartState,
  (state) => state.totalAmount
);


export const selectCartCount = createSelector(
  selectCartItems,
  (items) => items.reduce((count, item) => count + item.Quantity, 0)
);
