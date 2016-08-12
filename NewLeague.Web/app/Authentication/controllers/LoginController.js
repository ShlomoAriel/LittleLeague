'use strict';
app.controller('LoginController', ['$scope', '$location', 'authService', 'CommonServices', function ($scope, $location, authService, CommonServices) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        CommonServices.state.loading = true;
        authService.login($scope.loginData).then(function (response) {
        },
         function (err) {
             $scope.message = err.error_description;
         }).finally(function () {
             CommonServices.state.loading = false;
         });
    };

}]);