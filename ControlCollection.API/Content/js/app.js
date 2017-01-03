angular.module('controlCollection', ['ngRoute', 'ngAnimate', 'ngMessages', 'collection', 'contact']).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    //$locationProvider.html5Mode(true);
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/', {
            templateUrl: 'views/layoutInit.html',
        })
        .otherwise({
            redirectTo: '/'
        });
}]);