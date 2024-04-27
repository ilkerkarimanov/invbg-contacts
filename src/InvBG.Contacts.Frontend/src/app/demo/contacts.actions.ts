import { createAction, props } from '@ngrx/store';
import { Contact } from 'src/app/demo/contact';

export const getContacts = createAction(
  '[Contacts] Get Contacts'
);

export const getContactsSuccess = createAction(
  '[Contacts] Get Contacts Success',
  props<{
    contacts: Array<Contact>
  }>()
);

export const getContactsFail = createAction(
  '[Contacts] Get Contacts Fail',
  props<{
    errorMessage: string;
  }>()
);


export const deleteContact = createAction(
    '[Contacts] Delete Contact',
    props<{
        contactId: number
    }>()
  );
  
  export const deleteContactSuccess = createAction(
    '[Contacts] Delete Contact Success'
  );
  
  export const deleteContactFail = createAction(
    '[Contacts] Delete Contact Fail',
    props<{
      errorMessage: string;
    }>()
  );

  export const addContact = createAction(
    '[Contacts] Add Contact',
    props<{
        contact: Contact
    }>()
  );
  
  export const addContactSuccess = createAction(
    '[Contacts] Add Contact Success'
  );
  
  export const addContactFail = createAction(
    '[Contacts] Add Contact Fail',
    props<{
      errorMessage: string;
    }>()
  );

  export const editContact = createAction(
    '[Contacts] Edit Contact',
    props<{
        contact: Contact
    }>()
  );
  
  export const editContactSuccess = createAction(
    '[Contacts] Edit Contact Success'
  );
  
  export const editContactFail = createAction(
    '[Contacts] Edit Contact Fail',
    props<{
      errorMessage: string;
    }>()
  );