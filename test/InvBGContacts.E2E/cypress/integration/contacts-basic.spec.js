/// <reference types="cypress" />

// Welcome to Cypress!
//
// This spec file contains a variety of sample tests
// for a todo list app that are designed to demonstrate
// the power of writing tests in Cypress.
//
// To learn more about how Cypress works and
// what makes it such an awesome testing tool,
// please read our getting started guide:
// https://on.cypress.io/introduction-to-cypress

describe('Contacts Test', () => {

    beforeEach(() => {

        cy.visit('http://localhost:4200')
    })

    it('displays contact title by default', () => {

        cy.get('#contactsTitle').should('have.text', 'Manage Contacts')

    })

    it('can add new contact', () => {

        cy.get('button').contains('New').click()

        cy.fixture('contact')
        .then((contact) => {

            cy.get('button[label=Save]').should('be.disabled')

            cy.get('input[id=firstName]').type(contact.firstName)
            cy.get('input[id=lastName]').type(contact.lastName)
            cy.get('p-calendar[id=dateOfBirth]')
                //.find('input').first()
                    .type(contact.dateOfBirth)
            cy.get('input[id=street]').type(contact.street)
            cy.get('input[id=zipCode]').type(contact.zipCode)
            cy.get('input[id=city]').type(contact.city)
            cy.get('input[id=phoneNumber]').type(contact.phoneNumber)
            cy.get('input[id=iban]').type(contact.iban)
        
            cy.get('button[label=Save]').should('not.be.disabled')

            cy.get('button[label=Save]').click()

            cy.wait(250)

            cy.get('p-table[id=contactList]')
                .find('table').first()
                    .find('tbody')
                    .find('tr').last()
                        .children('td').eq(1)
                        .should('have.text', contact.firstName)
        });

    })

    it('can delete contact', () => {

        cy.get('p-table[id=contactList]')
        .find('table').first().find('tbody')
            .find('tr').children('td').first().then((beforeId) => {

                cy.get('p-table[id=contactList]')
                .find('table').first()
                    .find('tbody')
                    .find('tr').first()
                    .find('button[class*="delete-contact"]').click()
                
                cy.get('p-confirmDialog[id=contactConfirm]')
                    .find('button[class*="p-confirm-dialog-accept"]').click()
                
                cy.wait(250)    

                cy.log(beforeId.text());
                
                cy.get('p-table[id=contactList]')
                .find('table').first().find('tbody')
                    .find('tr').children('td').first().then((afterId) => {

                        cy.wait(250)    

                        cy.log(afterId.text());

                        cy.expect(beforeId.text()).not.to.equal(afterId.text())
                    });
            });       
    })

})
