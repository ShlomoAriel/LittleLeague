var MatchCtrl = function ($scope, authService, $stateParams, PlayerService, MatchesService, AttendanceService) {
    $scope.matchId = $stateParams.Id;
    $scope.match = MatchesService.match;
    $scope.seasonId = MatchesService.match.SeasonId;
    $scope.users = [];
    $scope.matchPlayers = PlayerService.matchPlayers;
    $scope.attendancePlayers = AttendanceService.attendancePlayers;
    $scope.getCurrentUserTeamId = function () {
        authService.getTeamId().then(function (response) {
            if (response.data == '') {  //flags admin
                // $scope.teamId = $stateParams.Id
            }
            else {
                $scope.teamId = response.data;
            }
        });
    }
    $scope.getMatchPlayers = function () {
        PlayerService.get
    };
    $scope.getCurrentUserTeamId();
    MatchesService.getMatch($scope.matchId);
    PlayerService.getMatchPlayers($scope.matchId).then(function () {
        AttendanceService.getMatchAttendance($scope.matchId).then(function (response) {
            angular.forEach($scope.matchPlayers, function (playerKey, playerValue) {
                playerKey.PlayerId = playerKey.Id;
                playerKey.Id = 0;
                playerKey.MatchId = $scope.matchId;
                playerKey.SeasonId = $scope.match.SeasonId;
                angular.forEach(response.data, function (key, value) {
                    if (key.PlayerId == playerKey.PlayerId) {
                        playerKey.Id = key.Id;
                        $scope.users.push(playerKey);
                    }
                });
            });
        });

    });

    $scope.test = function () {
        AttendanceService.updateMatchAttendance($scope.users).then(function () {
            alert('pkak');
        });
    }
}