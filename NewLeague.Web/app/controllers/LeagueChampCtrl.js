var LeagueChampCtrl = function ($scope, CommonServices, PlayerService) {
    $scope.seasons = CommonServices.seasons;
    $scope.season = $scope.seasons[CommonServices.currentSeasonOption];
    $scope.leagueChamp = PlayerService.leagueChamp;
    $scope.getLeagueChamp = function () {
        CommonServices.currentSeasonOption = $scope.seasons.indexOf($scope.season);
        PlayerService.getLeagueChamp($scope.season.Id);
    }

    $scope.$watchCollection('seasons', function (newValue, oldValue) {
        if (newValue.length) {
            $scope.season = $scope.seasons[CommonServices.currentSeasonOption];
            if (PlayerService.leagueChamp.length == 0) {
                PlayerService.getLeagueChamp($scope.season.Id);
            }
        }
    });
    if (PlayerService.previousSeasonId != CommonServices.currentSeasonOption) {
        PlayerService.previousSeasonId = CommonServices.currentSeasonOption;
        if ($scope.season != "undefined" && $scope.season != null && $scope.season.length > 0) {
            PlayerService.getLeagueChamp($scope.season.Id);
        }

    }
};
angular.module('routedTabs').controller('LeagueChampCtrl', LeagueChampCtrl);