import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { AppState } from './app-state';
import * as fromContacts from './demo/contacts.reducer';
import { environment } from '../environments/environment';

export const appReducer: ActionReducerMap<AppState> = {
  contacts: fromContacts.contactsReducer,
};

export const metaReducers: MetaReducer<AppState>[] = !environment.production ? [] : [];
