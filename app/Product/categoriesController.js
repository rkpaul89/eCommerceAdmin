angular.module("app").controller("productCategories", function productCategories($scope, $http, $location, msgAlert,toast) {
    var vm = $scope;

    var getData = function () {
        $http.get("api/productCategories").then(function (res) {
            vm.gridOptions.data = res.data;
        });
    }
    vm.saveCategory = function () {
        $http.post("api/productCategories", JSON.stringify(vm.category)).then(function (res) {
            //msgAlert.added();
            toast.added();
            $location.path("/product/categories");
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