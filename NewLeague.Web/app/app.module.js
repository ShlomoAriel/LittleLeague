﻿var app = angular.module("routedTabs", ["checklist-model", "ngResource", "LocalStorageModule", "ui.router", "ui.bootstrap", "ngSanitize", "ui.bootstrap.datetimepicker", "angular.filter", "ui.select"]);
app.config(["$httpProvider", function () {
}
]);

app.factory("Teams", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Team/:id", { id: "@id" }, {
        update: { url: "http://beta.redlionleague.com///api/Team/PutTeam", method: "PUT" },
        'get': { url: "http://beta.redlionleague.com///api/Team/GetTeam", method: "GET", isArray: false },
        delete: { url: "http://beta.redlionleague.com///api/Team/DeleteTeam", method: "DELETE" }
    });
});

app.factory("Players", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Player/:id", { id: "@id" }, {
        update: { method: "PUT" },
        'get': { url: "http://beta.redlionleague.com///api/Player/GetPlayer", method: "GET", isArray: false },
        delete: { url: "http://beta.redlionleague.com///api/Player/DeletePlayer", method: "DELETE" }
    });
});

app.factory("Weeks", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Weeks/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Weeks/DeleteWeek", method: "DELETE" }
    });
});
app.factory("Seasons", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Seasons/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Seasons/DeleteSeason", method: "DELETE" }
    });
});
app.factory("Goals", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Goal/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Goal/DeleteGoal", method: "DELETE" }
    });
});

app.factory("CleanSheets", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/CleanSheets/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/CleanSheets/DeleteCleanSheet", method: "DELETE" }
    });
});
app.factory("Outstandings", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Outstandings/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Outstandings/DeleteOutstanding", method: "DELETE" }
    });
});


app.factory("Assists", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Assist/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Assists/DeleteAssist", method: "DELETE" }
    });
});
app.factory("Attendance", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Attendance/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Attendance/DeleteAttendance", method: "DELETE" }
    });
});
app.factory("Assists", function ($resource) {
    return $resource("http://domain.redlionleague.com//api/Assist/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://domain.redlionleague.com//api/Goal/DeleteAssist", method: "DELETE" }
    });
});
app.factory("Matches", function ($resource) {
    return $resource("http://beta.redlionleague.com///api/Match/:id", { id: "@id" }, {
        update: { method: "PUT" },
        delete: { url: "http://beta.redlionleague.com///api/Match/DeleteMatch", method: "DELETE" }
    });
});

app.filter("playingPlayers", function () {
    return function (players, match) {
        var out = [];

        if (match) {
            for (var x = 0; x < players.length; x++) {
                if (players[x].TeamId === match.HomeId || players[x].TeamId === match.AwayId)
                    out.push(players[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return players;
        }
        return out;
    };
});
app.filter("homePlayers", function () {
    return function (players, match) {
        var out = [];

        if (match && players) {

            for (var x = 0; x < players.length; x++) {
                if (players[x].TeamId === match.HomeId)
                    out.push(players[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return players;
        }
        return out;
    };
});
app.filter("awayPlayers", function () {
    return function (players, match) {
        var out = [];

        if (match && players) {
            for (var x = 0; x < players.length; x++) {
                if (players[x].TeamId === match.AwayId)
                    out.push(players[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return players;
        }
        return out;
    };
});
app.filter("matchPlayers", function () {
    return function (players, match) {
        var out = [];

        if (match && players) {
            for (var x = 0; x < players.length; x++) {
                if (players[x].TeamId === match.AwayId || players[x].TeamId === match.HomeId)
                    out.push(players[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return players;
        }
        return out;
    };
});
app.filter("awayScorers", function () {
    return function (goals, match) {
        var out = [];

        if (match && goals) {
            for (var x = 0; x < goals.length; x++) {
                if (goals[x].MatchId === match.Id&&goals[x].Player.TeamId === match.AwayId)
                    out.push(goals[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return goals;
        }
        return out;
    };
});
app.filter("awayAssist", function () {
    return function (assists, match) {
        var out = [];

        if (match && assists) {
            for (var x = 0; x < assists.length; x++) {
                if (assists[x].Player.TeamId === match.AwayId && assists[x].MatchId === match.Id)
                    out.push(assists[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return assists;
        }
        return out;
    };
});
app.filter("homeAssist", function () {
    return function (assists, match) {
        var out = [];

        if (match && assists) {
            for (var x = 0; x < assists.length; x++) {
                if (assists[x].MatchId === match.Id&&assists[x].Player.TeamId === match.HomeId)
                    out.push(assists[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return assists;
        }
        return out;
    };
});
app.filter("homeScorers", function () {
    return function (goals, match) {
        var out = [];

        if (match && goals) {
            for (var x = 0; x < goals.length; x++) {
                if (goals[x].Player.TeamId === match.HomeId && goals[x].MatchId === match.Id)
                    out.push(goals[x]);
            }
            return out;
        }
        else if (match == null || match.length === 0) {
            return goals;
        }
        return out;
    };
});
app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/main/table");

    $stateProvider
        .state("main", { abstract: true, url: "/main", controller: "MainCtrl", templateUrl: "templates/main.html" })
        .state("main.table", { url: "/table", controller: HomeCtrl, templateUrl: "templates/table.html" })
        .state("main.league-champ", { url: "/league-champ", controller: LeagueChampCtrl, templateUrl: "templates/league-champ.html" })
        .state("main.terms", { url: "/terms", templateUrl: "templates/terms.html" })
        .state("main.terms.rules", { url: "/rules", templateUrl: "templates/terms/rules.html" })
        .state("main.terms.schedule", { url: "/schedule", templateUrl: "templates/terms/schedule.html" })
        .state("main.terms.player-conduct", { url: "/player-conduct", templateUrl: "templates/terms/player-conduct.html" })
        .state("main.terms.structure", { url: "/structure", templateUrl: "templates/terms/structure.html" })
        .state("main.fixtures", { url: "/fixtures", controller: FixtureCtrl, templateUrl: "templates/fixtures.html" })
        .state("main.news", { url: "/news", controller: FixtureCtrl, templateUrl: "templates/news.html" })
        .state("main.scorers", { url: "/scorers", controller: PlayerCtrl, templateUrl: "templates/scorers.html" })
        .state("main.statistics", { url: "/statistics", controller: HomeCtrl, templateUrl: "templates/statistics.html" })
        .state("main.player", { url: "/player/:Id", controller: PlayerPageCtrl, templateUrl: "templates/player.html" })
        .state("main.team", { url: "/team/:Id", controller: TeamPageCtrl, templateUrl: "templates/team.html" })
        .state("main.match", { url: "/match/:Id", controller: MatchCtrl, templateUrl: "templates/match.html" })
        .state("main.attendance", { url: "/attendance", controller: AttendanceCtrl, templateUrl: "templates/attendance.html" })
        .state("main.teamManagment", { url: "/teamManagment/:Id", controller: TeamManagementCtrl, templateUrl: "templates/teamManagment.html" })
        .state("main.registration", { url: "/registration", controller: PlayerCtrl, templateUrl: "templates/registration.html" })
        .state("main.signup", { url: "/signup", controller: "SignupController", templateUrl: "templates/signup.html" })
        .state("main.login", { url: "/login", controller: "LoginController", templateUrl: "templates/login.html" })
        .state("main.edit", { url: "/edit", controller: EditCtrl, templateUrl: "templates/edit/main-edit.html" })
        .state("main.edit.weekScore", { url: "/weekScore", controller: EditScoreCtrl, templateUrl: "templates/edit/editScore.html" })
        .state("main.edit.weekTeams", { url: "/WeekTeams", controller: EditWeekCtrl, templateUrl: "templates/edit/editWeekTeams.html" })
        .state("main.edit.players", { url: "/players", controller: PlayerCtrl, templateUrl: "templates/edit/players.html" })
        .state("main.edit.seasons", { url: "/seasons", controller: SeasonCtrl, templateUrl: "templates/edit/seasons.html" })
        .state("main.edit.teams", { url: "/teams", controller: TeamCtrl, templateUrl: "templates/edit/teams.html" });

});
app.filter("slice", function () {
    return function (arr, start, end) {
        if (arr) {
            return arr.slice(start, end);
        }
    };
});
