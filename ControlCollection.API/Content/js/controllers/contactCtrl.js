angular.module('contact', []).config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/contacts', {
            templateUrl: 'views/listcontacts.html',
            controller: 'contactsCtrl',
            controllerAs: 'contacts'
        });

}]).controller('contactsCtrl', ['$filter','contactService', contactsCtrl])

function contactsCtrl($filter, contactService) {
    
    var vm = this;

    //Limpa o objeto contato.
    vm.clean = clean;
    function clean() {
        vm.contact = null;
    }

    //Lista todos os contatos.
    contactService
        .getContacts()
        .then(function (response) {            
            vm.contacts = response.data;            
        })

    //Busca os contatos por termo
    vm.searchByTerm = searchByTerm;
    function searchByTerm(q) {
        contactService.getContactsByTerm(q)
        .then(function (response) {
            vm.contacts = response.data;
        });
    }
        
    //Adciona um novo contato.
    vm.add = add;
    function add(contact) {        
        contactService.saveContact(contact)
        .then(function (response) {
            contact = response.data;
            vm.contacts.push(angular.copy(contact));            
            delete vm.contact;
        });
    }

    //Copia os dados de um contato da lista para um objeto.
    vm.vObject = vObject;
    function vObject(contact) {
        vm.contact = angular.copy(contact);
    }

    //Salva os dados editados pelo usuario.
    vm.edit = edit;
    function edit(contact) {        
        contactService.updateContact(contact)
        .then(function (response) {
            var contacts = vm.contacts.map(function (el, i) {
                if (el.id === contact.id) {
                    contact = response.data;                    
                    return contact;
                }
                return el;
            });
            vm.contacts = contacts;
        });

    }

    //Remove o contato da lista.
    vm.remove = remove;
    function remove(contact) {
        contactService.removeContact(contact.id)
        .then(function () {
            var contactz = $filter('filter')(vm.contacts, { id: contact.id })[0];

            if (contactz) {
                vm.contacts.splice(vm.contacts.indexOf(contactz), 1);
            }
        });
    }

    //Ordena as colunas do maior para o menor
    vm.reverse = true;
    vm.orderField = orderField
    function orderField(field) {        
        vm.predicate = field;
        vm.reverse = !vm.reverse;
    }
}