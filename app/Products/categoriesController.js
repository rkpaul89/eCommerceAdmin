angular.module("app").controller("productCategories", function productCategories($scope,$http) {
    var vm = $scope;
    
    var getData = function () {
        $http.get("api/productCategories").then(function (res) {
            vm.gridOptions.data = res.data;
        });
    }
    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort:null
    };
    //vm.data = [{ 'categoryID': 1, 'categoryName': 'rk' }];
    vm.gridOptions = {
        enableSorting: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        enableFiltering:true
        //columnDefs: [
        //    { name: 'categoryID', field: 'categoryID' },
        //    { name: 'categoryName', field: 'categoryName' },
        //]
    };
    //var getPage = function () {
    //    var url;
    //    switch (paginationOptions.sort) {
    //        case uiGridConstants.ASC:
    //            url = '/data/100_ASC.json';
    //            break;
    //        case uiGridConstants.DESC:
    //            url = '/data/100_DESC.json';
    //            break;
    //        default:
    //            url = '/data/100.json';
    //            break;
    //    }
    getData();
});