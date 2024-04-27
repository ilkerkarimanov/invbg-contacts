import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, catchError, concatMap, mergeMap, switchMap, tap } from 'rxjs/operators';
import * as ContactsActions from './contacts.actions';
import { of } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { ContactService } from './contacts.service';
import { Store } from '@ngrx/store';

@Injectable()
export class ContactsEffects {

getContacts$ = createEffect(() => {
return this.actions$.pipe(
    ofType(ContactsActions.getContacts),
    mergeMap((action) => {
        return this.contactsService.getContacts().pipe(
            map((result) => {
                return ContactsActions.getContactsSuccess({ contacts: result });
              }),
              catchError((errorRes: HttpErrorResponse) => {                  
                return of(ContactsActions.getContactsFail(
                  { errorMessage: 'Error during loading contacts.' }
                ));
              })
        );
        //var data = this.contactsService.getContacts();
        //return ContactsActions.getContactsSuccess({contacts : data});
    }));
});

addContacts$ = createEffect(() => {
return this.actions$.pipe(
    ofType(ContactsActions.addContact),
    mergeMap((action) => {
        return this.contactsService.addContact(action.contact).pipe(
            map((result) => {
                this.store.dispatch(ContactsActions.getContacts());
                return ContactsActions.addContactSuccess();
              }),
              catchError((errorRes: HttpErrorResponse) => {                  
                return of(ContactsActions.addContactFail(
                  { errorMessage: 'Error during adding contact.' }
                ));
              })
        );
        //this.contactsService.addContact(action.contact);
        //this.store.dispatch(ContactsActions.getContacts());
        //return ContactsActions.addContactSuccess();
    })
);
});

editContacts$ = createEffect(() => {
return this.actions$.pipe(
    ofType(ContactsActions.editContact),
    mergeMap((action) => {
        return this.contactsService.editContact(action.contact).pipe(
            map((result) => {
                this.store.dispatch(ContactsActions.getContacts());
                return ContactsActions.editContactSuccess();
              }),
              catchError((errorRes: HttpErrorResponse) => {                  
                return of(ContactsActions.editContactFail(
                  { errorMessage: 'Error during editing contact.' }
                ));
              })
        );
        //this.contactsService.editContact(action.contact);
        //this.store.dispatch(ContactsActions.getContacts());
        //return ContactsActions.editContactSuccess();
    })
);
});

deleteContacts$ = createEffect(() => {
return this.actions$.pipe(
    ofType(ContactsActions.deleteContact),
    mergeMap((action) => {
        return this.contactsService.deleteContact(action.contactId).pipe(
            map((result) => {
                this.store.dispatch(ContactsActions.getContacts());
                return ContactsActions.deleteContactSuccess();
              }),
              catchError((errorRes: HttpErrorResponse) => {
                return of(ContactsActions.deleteContactFail(
                  { errorMessage: 'Error during deleting contact.' }
                ));
              })
        );
        //this.contactsService.deleteContact(action.contactId);
        //this.store.dispatch(ContactsActions.getContacts());
        //return ContactsActions.addContactSuccess();
    })
);
});

  constructor(
    private actions$: Actions,
    private contactsService: ContactService,
    private store: Store,
  ){}

}
