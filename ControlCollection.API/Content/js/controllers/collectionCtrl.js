angular.module('collection', []).config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/collections', {
            templateUrl: 'views/listcollections.html',
            controller: 'collectionsCtrl',
            controllerAs: 'collections'
        });


}]).controller('collectionsCtrl', ['$filter','collectionService', 'contactService', collectionCtrl])

function collectionCtrl($filter,collectionService, contactService) {
    var vm = this;

    vm.types = [
				{nameType: "Livro"},
				{nameType: "CD"},
                {nameType: "DVD"},
			];
    
    vm.optionStatus = [
				{optionName: "Disponível"}				
			];

    vm.optionLoan = [
				{optionName: "Emprestado"}				
    ];

    vm.optionVarious = [
            { optionName: "Emprestado" },
            { optionName: "Disponível" }
    ];


    vm.clean = clean;
    function clean() {
        vm.item = null;
    }

    //Lista todos os itens.
    collectionService
        .getItems()
        .then(function (response) {            
            vm.items = response.data;

        })

    //Busca os itens por termo
    vm.searchByTerm = searchByTerm;
    function searchByTerm(q) {
        collectionService.getItemsByTerm(q)
        .then(function (response) {
            vm.items = response.data;
        });
     }

    //Adciona um novo item.
    vm.add = add;
    function add(item) {        
        collectionService.saveItem(item)
        .then(function (response) {
            item = response.data
            vm.items.push(angular.copy(item));
            delete vm.item;
        });
    }

    //Copia os dados da lista para um objeto.
    vm.vObject = vObject;
    function vObject(item) {        
        vm.item = angular.copy(item);
    }

    //Salva os dados editados pelo usuario.
    vm.edit = edit;
    function edit(item) {
        collectionService.updateItem(item)
        .then(function (response) {
            var items = vm.items.map(function (el, i) {
                if (el.id === item.id) {
                    item = response.data;                    

                    return item;
                }
                return el;
            });
            vm.items = items;
        });
    }

    //Remove o item da lista.
    vm.remove = remove;
    function remove(item) {
        collectionService.removeItem(item.id)
        .then(function () {

            var itemz = $filter('filter')(vm.items, { id: item.id })[0];
            if (itemz) {
                vm.items.splice(vm.items.indexOf(itemz), 1);
            }
        });

    }

    //Lista todos os contatos cadastrados para ser emprestado.
    vm.getContacts = getContacts;
    function getContacts() {
        contactService.getContacts()
        .then(function (response) {
            vm.contacts = response.data;
        })
    }
    //Exibe o contato para qual o item foi emprestado.
    vm.getContactById = getContactById;
    function getContactById(q) {        
        contactService.getContactById(q)
        .then(function (response) {
            vm.contact = response.data;
        });

    }

    vm.reverse = true;
    vm.orderField = orderField
    function orderField(field) {        
        vm.predicate = field;
        vm.reverse = !vm.reverse;
    }

    vm.resetFilter = resetFilter;
    function resetFilter() {
            vm.fillop = undefined;
            vm.filltip = undefined;
    }

}
