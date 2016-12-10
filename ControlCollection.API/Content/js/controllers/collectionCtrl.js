angular.module("controlCollection").controller("collectionCtrl", function($scope,  collections, collectionAPI, contactAPI){

  

    //Lista todos os itens na tabela.
    $scope.collections = collections.data;
    

    $scope.types = [
				{nameType: "Livro"},
				{nameType: "CD"},
                {nameType: "DVD"},
			];
    
    $scope.optionStatus = [
				{optionName: "Disponível"}				
			];

    $scope.optionLoan = [
				{optionName: "Emprestado"}				
    ];

    $scope.optionVarious = [
            { optionName: "Emprestado" },
            { optionName: "Disponível" }
    ];

    ;

    $scope.resetFilter = function () {        
        $scope.fillop = undefined;
        $scope.filltip = undefined;
    }



    $scope.vObjectItem = function(item) { 

        $scope.item = angular.copy(item);
    }

    

    $scope.cleanItem = function(){
        $scope.item = null;
    }    

    $scope.insertItem = function (item) {
                
                collectionAPI.saveItem(item).success(function(data){
                $scope.collections.push(angular.copy(item));              
                
                });
                delete $scope.item;
    };  

    $scope.getByTerm = function (q) {  
         
                if(q !== undefined){
                    collectionAPI.getItemsByTerm(q).success(function(data){
                    $scope.collections = data;
                    });	
                }
                else
                {
                    $scope.collections;
                }   			
    };

        $scope.getByContact = function () {
                
                    contactAPI.getContacts().success(function(data){
                    $scope.contacts = data;
                    
                    });	
        };
        
        $scope.getContactId = function (q) {
 
            if (q !== undefined) {
                    contactAPI.getContactsByID(q).success(function (data) {
                        $scope.unique = data;
                        console.log($scope.unique);
                });
            }
            else {
                $scope.contacts;
            }
        };

    


    $scope.loanItem = function(loan){
        console.log(loan);
        collectionAPI.loanItem(loan).success(function(data){
            $scope.collections;
        });

    };

    $scope.removeRow = function (idx) {
        $scope.products.splice(idx, 1);
    };

    $scope.deleteItem = function(id){
        collectionAPI.deleteItem(id).success(function (data) {
            $scope.collections = data;
        });

    }

    $scope.orderCol = function (field) {
        $scope.order = field;
        $scope.directOrder = !$scope.directOrder;
    };

    $scope.desactOrder = function(){
        $scope.order = null;
        $scope.directOrder = null;
    };





    

});