import { Contact } from './contact';
import { createReducer, on, Action } from '@ngrx/store';
import * as ContactsActions from './contacts.actions';

export interface State {
    readonly contacts: Contact[];
    readonly deleteOperation: string;
    readonly addOperation: string;
    readonly editOperation: string;
}

export const initialState: State = {
    contacts: null,
    deleteOperation: 'idle',
    addOperation: 'idle',
    editOperation: 'idle'
}

const _contactReducer = createReducer(
    initialState,

    on(
        ContactsActions.getContacts,
      (state, action) => ({
        ...state,
        contacts: null
      })
    ),
  
    on(
        ContactsActions.getContactsSuccess,
      (state, action) => ({
        ...state,
        contacts: action.contacts,
      })
    ),
  
    on(
        ContactsActions.getContactsFail,
      (state, action) => ({
        ...state,
        contacts: null,
      })
    ),

    on(
      ContactsActions.deleteContact,
      (state, action) => ({
        ...state,
        deleteOperation: 'idle',
      }),  
    ),

    on(
      ContactsActions.deleteContactSuccess,
      (state, action) => ({
        ...state,
        deleteOperation: 'success',
      }),  
    ),

    on(
      ContactsActions.deleteContactFail,
      (state, action) => ({
        ...state,
        deleteOperation: 'fail',
      }),  
    ),
    
    on(
      ContactsActions.addContact,
      (state, action) => ({
        ...state,
        addOperation: 'idle',
      }),  
    ),

    on(
      ContactsActions.addContactSuccess,
      (state, action) => ({
        ...state,
        addOperation: 'success',
      }),  
    ),

    on(
      ContactsActions.addContactFail,
      (state, action) => ({
        ...state,
        addOperation: 'fail',
      }),  
    ),  


    on(
      ContactsActions.editContact,
      (state, action) => ({
        ...state,
        editOperation: 'idle',
      }),  
    ),

    on(
      ContactsActions.editContactSuccess,
      (state, action) => ({
        ...state,
        editOperation: 'success',
      }),  
    ),

    on(
      ContactsActions.editContactFail,
      (state, action) => ({
        ...state,
        editOperation: 'fail',
      }),  
    ),  
);

export function contactsReducer(state: State, action: Action) {
    return _contactReducer(state, action);
  }