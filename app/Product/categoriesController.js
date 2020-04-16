angular.module("app").controller("productCategoriesView", function productCategories($scope, $http, $location, msgAlert,toast) {
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
        enableFiltering:true
        //columnDefs: [
        //    { name: 'categoryID', field: 'categoryID' },
        //    { name: 'categoryName', field: 'categoryName' },
        //]
    };
    getData();
});

angular.module("app").controller("productCategoriesCreate", function ($scope,$http,$location,toast) {
    $scope.saveCategory = function () {
        $http.post("api/productCategories", JSON.stringify(vm.category)).then(function (res) {
            toast.added();
            $location.path("/product/categories");
        });
    }
});
