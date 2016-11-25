AngularModule.service('ApiCall', ['$http', function ($http) {
    var result;

    this.getDirs = function (Path) {
        dirsFullPath = 'api/FileSystem/GetDirectories?path=' + Path;
        result = $http.get(dirsFullPath).success(function (data, status) {
            result = data;
        }).error(function () {
            alert('Error');
        });
        return result;
    };
    this.getFiles = function (Path) {
        filesFullPath = 'api/FileSystem/GetFilesWeights?path=' + Path;
        result = $http.get(filesFullPath).success(function (data) {
            result = data;
        }).error(function () {
            alert('Error');
        });
        return result;
    };
}]);