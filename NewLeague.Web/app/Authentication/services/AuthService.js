﻿'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = 'http://beta.redlionleague.com//';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };
    var _getTeamId = function () {
        return $http.get(serviceBase + 'api/account/GetCurrentUserTeamId');
    };
    var _getUsers = function () {
        return $http.get(serviceBase + 'api/account/GetUsers');
    };
    var _deleteUser = function (userName) {
        return $http.delete(serviceBase + 'api/account/DeleteUser?email=' + userName);
    };
    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };
    

    var _login = function (loginData) {
        _logOut();

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    var _addTeamManager = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/AddTeamManager', registration).then(function (response) {
            return response;
        });

    };
    var _isAdmin = function () {
        return $http.post(serviceBase + 'api/account/IsAdmin');
    }
    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.getTeamId = _getTeamId;
    authServiceFactory.deleteUser = _deleteUser;
    authServiceFactory.getUsers = _getUsers;
    authServiceFactory.addTeamManager = _addTeamManager;
    authServiceFactory.isAdmin = _isAdmin;

    return authServiceFactory;
}]);