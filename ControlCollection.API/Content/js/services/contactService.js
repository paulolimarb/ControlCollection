angular.module('contact').service('contactService', contactService)

function contactService ($http, config) {

    this.getContacts = function () {           
        return $http.get(config.baseUrl + "/api/contacts");
    }

    this.getContactsByTerm = function (q) {
        return $http.get(config.baseUrl + "/api/contacts/" + q);
    }

    this.getContactById = function (q) {
        return $http.get(config.baseUrl + "/api/contacts/unique/" + q);
    }

    this.saveContact = function (contact) {
        return $http.post(config.baseUrl + "/api/contacts", contact);
    };

    this.updateContact = function (contact) {
        return $http.put(config.baseUrl + "/api/contacts", contact);
    };

    this.removeContact = function (id) {
        return $http.delete(config.baseUrl + "/api/contacts/" + id);
    };

};

