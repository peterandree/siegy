//'use strict'

eventsApp.controller('EventController',
    function EventController($scope) {

        $scope.snippet = '<span style="color: red;">hello there</span>';
        $scope.boolValue = false;
        $scope.mystyle = { color:'hotpink'};
        $scope.myclass = 'blue';


        $scope.event = {
            name: 'Angular Boot Camp',
            date: '1/1/2017',
            time: '10:30 am',
            location: {
                address: 'Google Headwquarters',
                city: 'Mountain View',
                province: 'CA'
            },
            imageUrl: '/img/angularjs-logo.png',
            sessions: [
                {
                    name: 'Directives Masterclass',
                    creatorName: 'Bob',
                    duration: '1 hr',
                    level: 'Noob',
                    abstract: 'something about something',
                    upVoteCount: 3,
                },
                {
                    name: 'Scopes for things',
                    creatorName: 'Bill',
                    duration: '2 hrs',
                    level: 'Advanced',
                    abstract: 'something about something else',
                    upVoteCount: 2,
                },
                {
                    name: 'Well Behaved Controllers',
                    creatorName: 'Jenny',
                    duration: '3 hrs',
                    level: 'Pro',
                    abstract: 'something about something different',
                    upVoteCount: 35,
                }
            ]
        }

        $scope.upVoteSession = function (session) {
            session.upVoteCount++;
        };

        $scope.downVoteSession = function (session) {
            session.upVoteCount--;
        };
    }
);