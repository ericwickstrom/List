(function()  {
    var app = angular.module('listApp', []);
    app.controller('ListController', function($scope, $http, $log){
        $scope.list = [];

        var updateList = function () {
            $http.get('api/list').then(function (response) {
                $log.log(response);
                $scope.list = response.data;
            });
        };

        updateList();

        $scope.add = function(item){
            
            $http.post('api/list', { text: item, complete: false }).then(function (response) {
                updateList();
            });
            $scope.listItem = null;
        };
    
        $scope.remove = function (item) {
            $log.log("delete: " + item);
            $http.delete('api/list/' + item.id).then(function (response) {
                updateList();
            });
        };

        $scope.toggleComplete = function(item){
            var index = $scope.list.indexOf(item);
            $scope.list[index].complete = true;
            $scope.update($scope.list[index]);
        };

        $scope.update = function (item) {
            $http.put('api/list/' + item.id, item).then(function (resposne) {
                updateList();
            });
        };
    });
})();