var EditScoreCtrl = function ($scope, PlayerService, Assists, Goals, CleanSheets, Outstandings,MatchesService, GoalService, CommonServices, $http, $filter) {
    $scope.players = PlayerService.seasonPlayers;
    $scope.seasonId = MatchesService.seasonId;
    $scope.matches = MatchesService.seasonsMatches;
    $scope.weeks = MatchesService.weeks;
    $scope.seasons = CommonServices.seasons;
    $scope.$watchCollection('seasons', function (newValue, oldValue) {
        if (newValue.length) {
            $scope.season = $scope.seasons[0];
            $scope.getSeasonWeeks();
            PlayerService.getSeasonPlayers(CommonServices.currentSeasonId);
            GoalService.getSeasonGoals(CommonServices.currentSeasonId);
        }
    });
    $scope.$watchCollection('weeks', function (newValue, oldValue) {
        if (newValue.length) {
            $scope.week = $scope.weeks[0];
            $scope.getweek();
        }
    });
    $scope.goals = GoalService.goals;
    $scope.assists = GoalService.assists;
    $scope.getweek = function () {
        var weeks = [];
        angular.forEach($scope.matches, function (key, value) {
            if (key.WeekId == $scope.week.Id) {
                weeks.push(key);
            }
        });
        $scope.selectedweek = weeks;
    };
    $scope.setHomeCleanSheet = function () {
        var test = this.HomeCleanSheet.Id;
    }
    $scope.updateweek = function () {
        var matches = $scope.selectedweek;
        $http.post('http://beta.redlionleague.com///api/Match/UpdateWeek', matches)
        .success(function () {
            $scope.savedAlert();
        });;
    }
    $scope.fixture = {};
    $scope.addHomeScorer = function () {
        var match = this.fixture;
        var goal = {};
        goal.MatchId = match.Id;
        goal.PlayerId = this.homeScorer.Id;
        goal.SeasonId = match.SeasonId;
        Goals.save(goal, function (data) {
            if(data!=null)
                $scope.goals.push(data);
        });
    };
    $scope.addHomeCleanSheet = function (playerI) {
        var match = this.fixture;
        var cleanSheet = {};
        cleanSheet.MatchId = match.Id;
        cleanSheet.TeamId = match.HomeId;
        cleanSheet.PlayerId = this.fixture.HomeGoalkeeperId;
        cleanSheet.SeasonId = match.SeasonId;
        CleanSheets.save(cleanSheet, function (data) {
        });
    };
    $scope.addAwayCleanSheet = function (playerI) {
        var match = this.fixture;
        var cleanSheet = {};
        cleanSheet.MatchId = match.Id;
        cleanSheet.TeamId = match.AwayId;
        cleanSheet.PlayerId = this.fixture.AwayGoalkeeperId;
        cleanSheet.SeasonId = match.SeasonId;
        CleanSheets.save(cleanSheet, function (data) {
        });
    };
    $scope.addOutstanding = function () {
        var match = this.fixture;
        var outstanding = {};
        outstanding.MatchId = match.Id;
        outstanding.PlayerId = this.fixture.OutstandingId;
        outstanding.SeasonId = match.SeasonId;
        Outstandings.save(outstanding, function (data) {
        });
    };
    $scope.addHomeAssist = function () {
        var match = this.fixture;
        var assist = {};
        assist.MatchId = match.Id;
        assist.PlayerId = this.homeAssist.Id;
        assist.SeasonId = match.SeasonId;
        Assists.save(assist, function (data) {
            if (data != null)
                $scope.assists.push(data);
        });
    };
    $scope.addAwayAssist = function () {
        var match = this.fixture;
        var assist = {};
        assist.MatchId = match.Id;
        assist.PlayerId = this.awayAssist.Id;
        assist.SeasonId = match.SeasonId;
        Assists.save(assist, function (data) {
            if (data != null)
                $scope.assists.push(data);
        });
    };
    $scope.addAwayScorer = function () {
        var match = this.fixture;
        var goal = {};
        goal.MatchId = match.Id;
        goal.PlayerId = this.awayScorer.Id;
        goal.SeasonId = match.SeasonId;
        Goals.save(goal, function (data) {
            if (data != null)
                $scope.goals.push(data);
        });
    };
    $scope.savedAlert = function (e) {
        $('#saved').fadeIn('slow', function () {
            $('#saved').fadeOut('slow');
        });
    };
    $scope.getSeasonWeeks = function () {
        MatchesService.getSeasonMatches($scope.season.Id);
        MatchesService.getSeasonWeeks($scope.season.Id);
        MatchesService.getSeasonTeams($scope.season.Id);
        PlayerService.getSeasonPlayers($scope.season.Id);
        GoalService.getSeasonGoals($scope.season.Id);
    };
    $scope.deleteGoal = function () {
        var id = this.goal.Id;
        Goals.delete({ id: id }, function () {
            $("#goal_" + id).fadeOut(500);
        });
    };
    $scope.savedAlert = function (e) {
        $('#saved').fadeOut('slow');
        $('#saved').fadeIn('slow', function () {
        });
    };
};