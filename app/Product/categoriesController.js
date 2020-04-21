angular.module("app").controller("productCategoriesView", function productCategories($scope, $http, $location, dialog,toast) {
    var vm = $scope;

    var getData = function () {
        $http.get("api/productCategories").then(function (res) {
            vm.gridOptions.data = res.data;
        });
    }();
   
    vm.gridOptions = {
        enableSorting: true,
        paginationPageSizes: [10, 25, 50,75,100],
        paginationPageSize: 10,
        //enableFiltering:true
        columnDefs: [
            { name: 'categoryID', field: 'categoryID' },
            { name: 'categoryName', field: 'categoryName' },
            { name: 'Actions', display: 'Actions', cellTemplate: '<i class="fas fa-edit ml-2 mr-3" ng-click="grid.appScope.edit(row.entity.categoryID)"></i><i class= "fas fa-trash" ng-click="grid.appScope.remove(row.entity.categoryID)" ></i >' },
        ]
    };

    vm.edit = function (id) {
        $location.path("/product/category/edit/" + id);
    }
    vm.remove = function (entity) {
        var f = dialog.confirm("Are you sure ?");
    }
    vm.createClk = function () {
        $location.path("/product/category/create");
    }
});

angular.module("app").controller("productCategoriesCreate", function ($scope, $http, $location, toast, $routeParams) {
    var act = $routeParams.action;
    var id = $routeParams.id;
    var vm = $scope;
    vm.saveCategory = function () {
        if (act == "create") {
            $http.post("api/productCategories", JSON.stringify($scope.category)).then(function (res) {
                toast.added();
                $location.path("/product/categories");
            });
        }
        else if (act == "edit") {
            //JSON.stringify(
            let f = { "id": vm.category.categoryID, "productCategory": vm.category };
            $http.put("api/productCategories/" + vm.category.categoryID, vm.category).then(function (res) {
                toast.updated();
                $location.path("/product/categories");
            });
        }
    }
    if (act == "edit") {
        var getData = function () {
            $http.get("api/productCategories/" + id).then(function (res) {
                let d = res.data;
                vm.category = {};
                vm.category = d;
            });
        }();
    }
});
