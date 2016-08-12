var MainCtrl = function ($rootScope, $scope, CommonServices, $state, authService) {
   
    $scope.state = CommonServices.state;
    CommonServices.getSeasons();
    $scope.tabs = [
        { heading: "טבלה", route: "main.table", active: false },
        { heading: "לוח משחקים", route: "main.fixtures", active: false },
        { heading: "כובשים", route: "main.scorers", active: false },
        { heading: "סטטיסטיקות", route: "main.statistics", active: false },
        { heading: "אלוף הליגה", route: "main.league-champ", active: false }
    ];
    $scope.editTabs = [
        { heading: "עדכון תוצאות", route: "main.edit.weekScore", active: false },
        { heading: "עריכת מחזור", route: "main.edit.weekTeams", active: false },
        { heading: "שחקנים", route: "main.edit.players", active: false },
        { heading: "עונות", route: "main.edit.seasons", active: false },
        { heading: "קבוצות", route: "main.edit.teams", active: false }
    ];

    $scope.termTabs = [
        { heading: "מבנה הליגה", route: "main.terms.structure", active: false },
        { heading: "מועדי משחקים", route: "main.terms.schedule", active: false },
        { heading: "חוקים", route: "main.terms.rules", active: false },
        { heading: "התנהלות שחקנים", route: "main.terms.player-conduct", active: false }
    ];

    $scope.go = function (route, params,isAdminRequest) {
        //if (isAdminRequest == true || route.indexOf("edit") > -1)
        //{
        //    authService.isAdmin().then(function (response) {
        //        if (response.data != true) {
        //            $state.go(route, params);
        //        }
        //    }).catch(function (response) {
        //        $state.go('main.login');
        //    });
        //}
        //else {
           $state.go(route, params);
        //}
        
    };

    $scope.active = function (route) {
        return $state.is(route);
    };
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams, options) {
        if (toState.name.indexOf("edit") > -1) {
            CommonServices.state.loading = true;
            authService.isAdmin().then(function (response) {
                if (response.data != true) {
                    $state.go(toState, toParams);
                }
            }).catch(function (response) {
               $state.go('main.login');
            }).finally(function () {
                CommonServices.state.loading = false;
            });;
        }
        else {
            $state.go(route, params);
        }
    });
    $scope.$on("$stateChangeSuccess", function () {
        $scope.tabs.forEach(function (tab) {
            tab.active = $scope.active(tab.route);
        });
        $scope.termTabs.forEach(function (tab) {
            tab.active = $scope.active(tab.route);
        });
        $scope.editTabs.forEach(function (tab) {
            tab.active = $scope.active(tab.route);
        });
    });
    $scope.goTop = function () {
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }
};
angular.module("routedTabs").controller("MainCtrl", MainCtrl);

