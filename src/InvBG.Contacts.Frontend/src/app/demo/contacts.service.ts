import { Injectable } from '@angular/core';
import { Contact } from 'src/app/demo/contact';
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from 'src/environments/environment';

const urls = {
    contacts: `${environment.apiUrl}/api/contacts`
};

@Injectable()
export class ContactService {

    constructor(private http: HttpClient) {}

    getContacts() {
        return this.http.get<Contact[]>(urls.contacts);
    }

    deleteContact(contactId: number){
        const queryParams = new HttpParams({ 
            fromObject: { 'contactId': contactId } 
        });
      
        return this.http.delete(
            urls.contacts,
            {
                params: queryParams
            }
        );
    }

    editContact(contact: Contact){
        return this.http.put(
            urls.contacts,
            {
              ...contact
            }
          )
    }

    addContact(contact: Contact){
        return this.http.post(urls.contacts, {...contact});
    }

    /*
    data : Array<Contact> = [
        {
            id: 1,
            firstName: 'Robot',
            lastName: 'Robotkin',
            dateOfBirth: new Date(1989, 4, 18),
            street: 'Slivnitsa',
            zipCode: '1359',
            city: 'Sofia',
            phoneNumber: '+359888123456',
            iban: '11112222333344445555'
        }
    ];

    getContacts() {
        return [...this.data];
    }

    deleteContact(contactId: number){
        this.data = this.data.filter((val) => val.id !== contactId);
    }

    editContact(contact: Contact){
        let idx = this.findIndexById(contact.id, this.data);
        this.data[idx] = contact;
    }

    addContact(contact: Contact){
        let newContact = {...contact, id : this.createId()};
        this.data.push(newContact);
    }

    findIndexById(id: number, data: Contact[]): number {
        let index = -1;
        for (let i = 0; i < data.length; i++) {
            if (data[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): number {
        return this.data.length + 1;
    }
    */
};