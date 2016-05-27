﻿function SignInController($scope) {
  // This flag we use to show or hide the button in our HTML.
  $scope.signedIn = false;

  // Here we do the authentication processing and error handling.
  // Note that authResult is a JSON object.
  $scope.processAuth = function (authResult) {
    // Do a check if authentication has been successful.
    if (authResult['access_token']) {
      // Successful sign in.
      $scope.signedIn = true;

      //     ...
      // Do some work [1].
      //     ...
    } else if (authResult['error']) {
      // Error while signing in.
      $scope.signedIn = false;

      // Report error.
    }
  };

  // When callback is received, we need to process authentication.
  $scope.signInCallback = function (authResult) {
    $scope.$apply(function () {
      $scope.processAuth(authResult);
    });
  };

  // Render the sign in button.
  $scope.renderSignInButton = function () {
    gapi.signin.render('signInButton',
        {
          'callback': $scope.signInCallback, // Function handling the callback.
          'clientid': '114195099775-lshhs1ugjfv3lh5f78ls46oeukg0jj9k.apps.googleusercontent.com', // CLIENT_ID from developer console which has been explained earlier.
          'requestvisibleactions': 'http://schemas.google.com/AddActivity', // Visible actions, scope and cookie policy wont be described now,
          // as their explanation is available in Google+ API Documentation.
          'scope': 'https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email',
          'cookiepolicy': 'single_host_origin'
        }
    );
  }

  // Start function in this example only renders the sign in button.
  $scope.start = function () {
    $scope.renderSignInButton();
  };

  // Call start function on load.
  $scope.start();



  // Process user info.
  // userInfo is a JSON object.
  $scope.processUserInfo = function (userInfo) {
    console.log(userInfo);
    // You can check user info for domain.
    if (userInfo['domain'] == 'askiitians.com') {
      alert('askiitians');
    }

    //// Or use his email address to send e-mails to his primary e-mail address.
    //sendEMail(userInfo['emails'][0]['value']);
  }

  // When callback is received, process user info.
  $scope.userInfoCallback = function (userInfo) {
    $scope.$apply(function () {
      $scope.processUserInfo(userInfo);
    });
  };

  // Request user info.
  $scope.getUserInfo = function () {
    gapi.client.request(
        {
          'path': '/plus/v1/people/me',
          'method': 'GET',
          'callback': $scope.userInfoCallback
        }
    );
  };
}