angular.module("controlCollection").controller("contactCtrl", function($scope,  contacts, contactAPI ){

    //Lista todos os contatos na tabela.
    $scope.contacts = contacts.data;

    $scope.vObject = function(contact) {    
        $scope.contact = angular.copy(contact);
    }

    $scope.clean = function(contact){
        $scope.contact = null;
    }

    $scope.insertContact = function (contact) {
                contactAPI.saveContacts(contact).success(function(data){
                $scope.contacts.push(angular.copy(contact));                        
                delete $scope.contact;		
        });				
    };  

    $scope.getByTerm = function (q) {  
         
                if(q !== undefined){
                    contactAPI.getContactsByTerm(q).success(function(data){
                    $scope.contacts = data;
                    });	
                }
                else
                {
                    $scope.contacts;
                }   			
    };

    $scope.deleteContact = function (id) {
        contactAPI.deleteContacts(id).success(function(data){
            $scope.contacts;
        });

    }

    $scope.orderCol = function (field) {
        $scope.order = field;
        $scope.directOrder = !$scope.directOrder;
    };

    $scope.desactOrder = function(){
        $scope.order = null;
        $scope.directOrder = null;
    }

});