var app = angular.module('Homeapp', []);

app.controller('HomeController', function ($scope, $http) {

    $http.get('/Home/getrecord').then(function (d) {

        $scope.regdata = d.data;

    }, function (error) {

        alert('failed');

    });

});