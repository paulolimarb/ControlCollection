angular.module("controlCollection").config(function ($routeProvider){

    $routeProvider.when("/listcollections",{
        templateUrl: "view/listcollections.html",
        controller : "collectionCtrl",
        resolve : {
            collections : function(collectionAPI){
                return collectionAPI.getItems();
            }
        }

    });



    $routeProvider.when("/listcontacts",{
        templateUrl: "view/listcontacts.html",
        controller : "contactCtrl",
        resolve : {
            contacts : function(contactAPI){
                return contactAPI.getContacts();
            }


        }

    });


});