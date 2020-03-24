(function () {
    'use strict';

    var app=angular.module('app', [
        // Angular modules 
        'ngRoute',
        'ui.grid',
        'ui.grid.pagination'
        // Custom modules 

        // 3rd Party Modules

    ]);
    app.config(function ($routeProvider, $httpProvider) {
        $routeProvider
            .when("/products/categories", { templateUrl: "app/Products/categories.html", Controller: "productCategories" })
            .when("/products/addCategory", { templateUrl:"app/Products/addCategory.html" })
            .otherwise({ redirectTo: 'dashboard', templateUrl:"app/dashboard.html" });
    }); 
    //Run block is used to initialize certain values for further use, register global events and anything that needs to run at the beginning 
    //of the application. 
    //Run block is executed only once in the lifetime of an AngularJS application
    //app.run(['$route', '$rootScope', '$location', function ($route, $rootScope, $location) {
    //    var original = $location.path;
    //    $location.path = function (path, reload) {
    //        if (reload === false) {
    //            var lastRoute = $route.current;
    //            var un = $rootScope.$on('$locationChangeSuccess', function () {
    //                $route.current = lastRoute;
    //                un();
    //            });
    //        }
    //        return original.apply($location, [path]);
    //    };
    //}])
})();