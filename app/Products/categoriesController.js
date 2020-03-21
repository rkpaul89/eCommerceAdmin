angular.module("app").controller("productCategories", function productCategories($scope,$http) {
    var vm = $scope;
    
    var getData = function () {
        $http.get("api/productCategories").then(function (res) {
            vm.gridOptions.data = res.data;
        });
    }
    //vm.data = [{ 'categoryID': 1, 'categoryName': 'rk' }];
    vm.gridOptions = {
        enableSorting: true,
        //columnDefs: [
        //    { name: 'categoryID', field: 'categoryID' },
        //    { name: 'categoryName', field: 'categoryName' },
        //]
    };
    getData();
});