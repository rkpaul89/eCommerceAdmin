angular.module("app").controller("productCategoriesView", function productCategories($scope, $http, $location, dialog,toast) {
    var vm = $scope;

    var getData = function () {
        $http.get("api/productCategories").then(function (res) {
            vm.gridOptions.data = res.data;
        });
    }
   
    vm.gridOptions = {
        enableSorting: true,
        paginationPageSizes: [10, 25, 50,75,100],
        paginationPageSize: 10,
        //enableFiltering:true
        columnDefs: [
            { name: 'categoryID', field: 'categoryID' },
            { name: 'categoryName', field: 'categoryName' },
            { name: 'Actions', display: 'Actions', cellTemplate: '<i class="fas fa-edit ml-2 mr-3" ng-click="grid.appScope.edit(row.entity)"></i><i class= "fas fa-trash" ng-click="grid.appScope.remove(row.entity)" ></i >' },
        ]
    };
    vm.edit = function (entity) {
        console.log(entity);
    }
    vm.remove = function (entity) {
        var f = dialog.confirm("Are you sure ?");
    }
    getData();
});

angular.module("app").controller("productCategoriesCreate", function ($scope,$http,$location,toast) {
    $scope.saveCategory = function () {
        $http.post("api/productCategories", JSON.stringify($scope.category)).then(function (res) {
            toast.added();
            $location.path("/product/categories");
        });
    }
});
