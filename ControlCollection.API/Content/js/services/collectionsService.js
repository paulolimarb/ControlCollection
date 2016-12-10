angular.module("controlCollection").factory("collectionAPI", function($http, config){
    
    var _getItems = function(){
        return $http.get(config.baseUrl + "/api/items");
    };

    var _getItemsByTerm = function(q){
        
        return $http.get(config.baseUrl + "/api/items/" + q);
    };

    var _saveItem = function (item) {
        return $http.post(config.baseUrl + "/api/items", item);
    };

    var _updateItem = function(item){
        return $http.put(config.baseUrl + "/api/items", item);
    };

    var _loanItem = function(item){
        return $http.put(config.baseUrl + "/api/items/loan", item);
    };

    var _deleteItem = function(id){
        return $http.delete(config.baseUrl + "/api/items/" + id);
    };

    return{
        getItems : _getItems,
        getItemsByTerm : _getItemsByTerm,
        saveItem : _saveItem,
        updateItem : _updateItem,
        loanItem :_loanItem,
        deleteItem : _deleteItem
    };

});