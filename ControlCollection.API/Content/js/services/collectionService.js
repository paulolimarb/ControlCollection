angular.module('collection').service('collectionService', collectionService)

function collectionService($http, config){

    this.getItems = function () {        
        return $http.get(config.baseUrl + "/api/items");
    }

    this.getItemsByTerm = function(q){
        return $http.get(config.baseUrl + "/api/items/" + q);
    }
            
    this.saveItem = function (item) {
        return $http.post(config.baseUrl + "/api/items", item);
    };

    this.updateItem = function(item){
        return $http.put(config.baseUrl + "/api/items", item);
    };

    this.removeItem = function(id){
        return $http.delete(config.baseUrl + "/api/items/" + id);
    };

}