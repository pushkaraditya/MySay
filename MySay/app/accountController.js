(function () {
  var accountController = function ($scope) {
    $scope.title = "Register";

    $scope.signOut = function () {
      debugger;
      var auth2 = gapi.auth2.getAuthInstance();
      auth2.signOut().then(function () {
        console.log('User signed out.');
      });
    };
  };

  var votingApp = angular.module("votingApp");
  votingApp.controller("accountController", accountController);
}());