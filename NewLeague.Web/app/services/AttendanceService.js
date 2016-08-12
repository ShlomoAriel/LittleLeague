app.service('AttendanceService', function ($http, Teams) {
    var _data = this;
    _data.attendancePlayers = [];

    _data.getMatchAttendance = function (matchId) {
        var promise = $http.get('http://beta.redlionleague.com///api/Match/GetMatchAttendance', {
            params: { matchId: matchId }
        }).success(function (data) {
            angular.copy(data, _data.attendancePlayers);
        });
        return promise;
    };
    _data.updateMatchAttendance = function (matches) {
        var promise =
            $http.post('http://beta.redlionleague.com///api/Match/UpdateAttendance', matches);
        return promise;
    };
});