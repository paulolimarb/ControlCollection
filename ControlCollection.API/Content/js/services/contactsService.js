angular.module("controlCollection").factory("contactAPI", function($http, config){
    
    var _getContacts = function(){
        return $http.get(config.baseUrl + "/api/contacts");
    };

    var _getContactsByTerm = function(q){
        
        return $http.get(config.baseUrl + "/api/contacts/" + q);
    };

    var _getContactsByID = function (q) {

        return $http.get(config.baseUrl + "/api/contacts/unique/" + q);
    };

    var _saveContacts = function (contact) {
        return $http.post(config.baseUrl + "/api/contacts", contact);
    };

    var _updateContacts = function(contact){
        return $http.put(config.baseUrl + "/api/contacts", contact);
    };


    var _deleteContacts = function(id){
        return $http.delete(config.baseUrl + "/api/contacts/" + id);
    };

    return{
        getContacts : _getContacts,
        getContactsByTerm: _getContactsByTerm,
        getContactsByID : _getContactsByID,
        saveContacts : _saveContacts,
        updateContacts : _updateContacts,
        deleteContacts : _deleteContacts
    };

});