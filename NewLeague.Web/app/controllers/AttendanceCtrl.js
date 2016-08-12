var AttendanceCtrl = function ($scope, authService, PlayerService, TeamService, CommonServices) {
    $scope.teams = TeamService.seasonTeams;
    $scope.teamSeasonPlayers = PlayerService.teamSeasonPlayers;
    $scope.getCurrentUserTeamId = function () {
        authService.getTeamId().then(function (response) {
            if (response.data == '') {  //flags admin
            }
            else {
                $scope.teamId = response.data;
            }
        });
    }
    $scope.getTeamSeasonPlayers = function () {
        PlayerService.getTeamSeasonPlayers($scope.season.Id, $scope.team.Id).then(function () {
            $scope.users = [$scope.matchPlayers[1]];
        });
    };
    $scope.getCurrentUserTeamId();
    
    
    $scope.test = function () {
        var pkak = $scope.users;
    }




    $scope.seasons = CommonServices.seasons;
    $scope.season = $scope.seasons[CommonServices.currentSeasonOption];//?
    $scope.$watchCollection('seasons', function (newValue, oldValue) {
        if (newValue.length) {
            $scope.season = $scope.seasons[CommonServices.currentSeasonOption];
            TeamService.getSeasonTeams($scope.season.Id).then(function () {
                $scope.team = $scope.teams[0];
                $scope.getTeamSeasonPlayers();
            });
        }
    });
    $scope.test = function () {
        var pkak = $scope.users;
    }
    
}