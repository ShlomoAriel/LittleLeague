app.service('GoalService', function ($http,Goals,Assists) {
    var _data = this;
    _data.goals = [];
    _data.seasonGoals = [];
    _data.assists = [];
    _data.seasonAssists = [];

    _data.getGoals = function () {
        return Goals.query(function (data) {
            angular.copy(data, _data.goals);
        });
    };
    _data.getSeasonGoals = function (seasonId) {
        $http.get('http://localhost:55506///api/Match/GetGoalsBySeason', {
            params: { seasonId: seasonId }
        }).success(function (data) {
            angular.copy(data, _data.seasonGoals);
        });
    };
    _data.getAssists = function () {
        return Assists.query(function (data) {
            angular.copy(data, _data.assists);
        });
    };
    _data.getSeasonAssists = function (seasonId) {
        $http.get('http://localhost:55506///api/Match/GetAssistsBySeason', {
            params: { seasonId: seasonId }
        }).success(function (data) {
            angular.copy(data, _data.seasonAssists);
        });
    };
    _data.getGoals();
    _data.getAssists();
});