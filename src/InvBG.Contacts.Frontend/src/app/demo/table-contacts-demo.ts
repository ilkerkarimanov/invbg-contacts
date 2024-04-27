import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Contact } from './contact';
import { FormBuilder, Validators, FormControl } from '@angular/forms';
import { select, Store } from '@ngrx/store';
import * as ContactsActions from "./contacts.actions";
import * as ContactsSelectors from "./contacts.selectors";
import { Subscription } from 'rxjs';

@Component({
    selector: 'table-contacts-demo',
    templateUrl: 'table-contacts-demo.html',
    styleUrls: ['table-contacts-demo.scss'],
    providers: [MessageService, ConfirmationService]
})
export class TableContactsDemo implements OnInit{
    contactDialog: boolean = false;
    contacts!: any;
    contact!: Contact;

    private subscription = new Subscription();

    minDate:Date | undefined = new Date(1900, 4, 1);
    maxDate:Date | undefined = new Date(Date.now());
    contactForm;

    constructor(
        private fb : FormBuilder,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private store: Store,) {
            this.initForm();
            this.store.dispatch(ContactsActions.getContacts());
        }

    ngOnInit() {
        this.contacts = this.store.select(ContactsSelectors.selectContacts);
        this.initNotifications();
    }

    initNotifications(){
        this.subscription.add(this.store.pipe(select(ContactsSelectors.selectDeleteOperation)).subscribe(op => {
            if(op === 'success') this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Contact Deleted', life: 3000 });
            if(op === 'fail') this.messageService.add({ severity: 'error', summary: 'Successful', detail: 'Contact Deletion Failed', life: 3000 });                

          }));

          this.subscription.add(this.store.pipe(select(ContactsSelectors.selectAddOperation)).subscribe(op => {
            if(op === 'success') this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Contact Created', life: 3000 });
            if(op === 'fail') this.messageService.add({ severity: 'error', summary: 'Successful', detail: 'Contact Creation Failed', life: 3000 });                
          }));

          this.subscription.add(this.store.pipe(select(ContactsSelectors.selectEditOperation)).subscribe(op => {
            if(op === 'success') this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Contact Edited', life: 3000 });
            if(op === 'fail') this.messageService.add({ severity: 'error', summary: 'Successful', detail: 'Contact Modification Failed', life: 3000 });                
          }));
    }

    create() {
        this.contact = {};
        this.initForm();
        this.contactDialog = true;
    }

    edit(contact: Contact) {
        this.contact = { ...contact };
        this.initForm();
        this.contactDialog = true;
    }

    delete(contact: Contact) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + contact.firstName + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.store.dispatch(ContactsActions.deleteContact({ contactId : contact.id }));
                this.contact = {};
            }
        });
    }

    hideDialog() {
        this.contactDialog = false;
    }

    save() {
        let data = {...this.contactForm.value};

        if (data.id) {
            this.store.dispatch(ContactsActions.editContact({contact: data}));
        } else {
            this.store.dispatch(ContactsActions.addContact({contact: data}));
        }
        this.contactDialog = false;
        this.contact = {};
    }

    initForm(){
        this.contactForm = this.fb.group({
            id: [this.contact?.id ?? null],
            firstName: [this.contact?.firstName ?? '', [Validators.required, this.whitespaceValidator, Validators.minLength(1), Validators.maxLength(20)]],
            lastName: [this.contact?.lastName ?? '', [Validators.required, this.whitespaceValidator, Validators.minLength(1), Validators.maxLength(20)]],
            dateOfBirth: [this.contact?.dateOfBirth ? new Date(this.contact.dateOfBirth) : '', Validators.required],
            street: [this.contact?.street ?? '', [Validators.required, this.whitespaceValidator,  Validators.minLength(1), Validators.maxLength(100)]],
            zipCode: [this.contact?.zipCode ?? '', [Validators.required, this.whitespaceValidator,  Validators.minLength(1), Validators.maxLength(5)]],
            city: [this.contact?.city ?? '', [Validators.required, this.whitespaceValidator,  Validators.minLength(1), Validators.maxLength(20)]],
            phoneNumber: [this.contact?.phoneNumber ?? '', [Validators.required, this.whitespaceValidator,  Validators.minLength(13), Validators.maxLength(13)]],
            iban: [this.contact?.iban ?? '', [Validators.required, this.whitespaceValidator,  Validators.minLength(20), Validators.maxLength(20)]]
          });
    }

    public whitespaceValidator(control: FormControl) {
        return (control.value || '').trim().length? null : { 'whitespace': true };
    }
}