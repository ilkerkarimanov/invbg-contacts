import { createFeatureSelector, createSelector } from '@ngrx/store';
import { State } from './contacts.reducer';

const contactsFeatureSelector = createFeatureSelector<State>('contacts');

export const selectContacts = createSelector(
    contactsFeatureSelector,
  (state: State) => state.contacts
);

export const selectDeleteOperation = createSelector(
  contactsFeatureSelector,
(state: State) => state.deleteOperation
);

export const selectAddOperation = createSelector(
  contactsFeatureSelector,
(state: State) => state.addOperation
);

export const selectEditOperation = createSelector(
  contactsFeatureSelector,
(state: State) => state.editOperation
);
