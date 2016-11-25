var AngularModule = angular.module('App', []);


AngularModule.controller('AppController', function ($scope, $http, ApiCall) {

    $scope.requestDirsResult;
    $scope.requestFilesResult;
    $scope.makeRuquest = function(Path)
    {
        var getDirsResult = (ApiCall.getDirs(Path)).success(function (data) {
            $scope.requestDirsResult = data;
        });
        var getFilesResult = (ApiCall.getFiles(Path)).success(function (data) {
            $scope.requestFilesResult = data;
        });
    }

});