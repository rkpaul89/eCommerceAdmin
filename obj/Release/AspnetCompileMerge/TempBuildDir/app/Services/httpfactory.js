(function () {
    'use strict';

    angular
        .module('app')
        .factory('factory', factory);

    factory.inject=['$http']

    function factory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData(endpoint, dt) {
            $http({
                method: "Get",
                url: endpoint,
                dataType: "json",
                data: dt,
                headers: {
                    "Content-Type": "application/json;charset=utf-8"
                }
            }).then(function (res) { return res; }, function (res) {
                return res;
            });
        }

        function postData(endpoint, dt) {
        }

        function putData(endpoint, dt) {
        }

        function deleteData(endpoint, dt) {
        }
    }
})();