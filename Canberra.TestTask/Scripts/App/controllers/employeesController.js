(function () {
    'use strict';

    angular.module("app").controller("employeesController", [
        '$scope',
        '$http',
        function ($scope, $http) {

            $scope.genderLookup = ['Not specified', 'Male', 'Female'];
            $scope.sortOrder = "FullName";

            $scope.query = {
                sorting: {
                    property: 'FullName',
                    direction: 0
                },
                pagination: {
                    page: 1,
                    itemsPerPage: 18
                }
            };

            $scope.refresh = function () {
                $http.post('/api/employee/query', $scope.query)
                    .then(function(r) {
                        $scope.employees = r.data;
                    });
            };

            $scope.changeSortOrder = function (sortDirection) {
                if ($scope.sortOrder == sortDirection) {
                    $scope.query.sorting.property = sortDirection;
                    $scope.query.sorting.direction = $scope.query.sorting.direction == 0 ? 1 : 0;
                } else {
                    $scope.sortOrder = sortDirection;
                    $scope.query.sorting.property = sortDirection;
                    $scope.query.sorting.direction = 0;
                }
            }

            $scope.$watch('query',
                function () {
                    $scope.refresh();
                },
                true);

            $scope.refresh();
        }]);
})();