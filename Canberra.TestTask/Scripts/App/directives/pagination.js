
(function () {
    'use strict';

    angular.module("ui-grid", [])
        .controller('uiPaginationController',
        [
            '$scope',
            function ($scope) {
                var displayPages = angular.isNumber($scope.displayPages) ? $scope.displayPages : 6;

                var populateVisiblePages = function (pagination, total) {
                    if (!angular.isNumber(total)) {
                        return { totalPageCount: 0, visible: [] };
                    }

                    var current = pagination.page;
                    var pagesCount = Math.ceil(total / pagination.itemsPerPage);

                    var from = Math.max(1, current - displayPages / 2);
                    var to = Math.min(pagesCount, current + displayPages / 2);

                    var pages = [];

                    for (var i = from; i <= to; i++) {
                        pages.push(i);
                    }

                    return {
                        totalPageCount: pagesCount,
                        visible: pages
                    };
                };

                $scope.updatePages = function () {
                    var pages = populateVisiblePages($scope.pagination, $scope.totalCount);

                    $scope.totalPageCount = pages.totalPageCount;
                    $scope.pages = pages.visible;
                }

                $scope.$watch('pagination.page', $scope.updatePages);
                $scope.$watch('pagination.itemsPerPage', $scope.updatePages);
                $scope.$watch('totalCount', $scope.updatePages);
            }
        ])
        .directive("uiPagination",
        [
            function () {
                return {
                    transclude: true,
                    restrict: 'A',
                    controller: 'uiPaginationController',
                    scope: {
                        pagination: '=uiPagination',
                        totalCount: '='
                    },
                    link: function (scope, element, attrs, ctrl, transclude) {

                        transclude(scope, function (clone) {
                            element.append(clone);
                        });
                    }
                };
            }
        ]);
})();