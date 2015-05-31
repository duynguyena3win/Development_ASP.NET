var app = angular.module('AppProjects', []);
var currentUser = null;
var RFS_Project = 'http://localhost:53373/api/Project';
var RFS_Time = 'http://localhost:53373/api/Time';
var currentIdProject = 1;
app.controller('ProjectsController', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
    $scope.projects = [];
    $scope.selectProject = {};
    $scope.addProject = {};
    $scope.LoadAllProject = function (username)
    {
        currentUser = username;
        $scope.projects = [];
        var url = RFS_Project + '?username=' + username;
        $http.get(url).success(function (data) {
            $scope.projects = data;
        });
    }

    $scope.insertProject = function (username, student) {
        student.username = username;
        
        $http({
            method: 'POST',
            url: RFS_Project,
            data: student
        }).success(function (data) {
            $scope.showModal('insert-student', false);
            $scope.LoadAllProject(username);
            
        });
    }

    $scope.saveProject = function (ISProject)
    {
        $http({
            method: 'PUT',
            url: RFS_Project,
            data: ISProject
        }).success(function (data) {
            $scope.showModal('insert-student', false);
            $scope.LoadAllProject(username);

        });
    }

    $scope.deleteProject = function (username, idProject)
    {
        var url = RFS_Project + '/' + idProject;
        if (idProject != null) {
            $http({
                method: 'DELETE',
                url: url,
                data: idProject
            }).success(function () {
                $scope.LoadAllProject(username);
            });
        }
    }

    $scope.LoadProject = function(id)
    {
        currentIdProject = id;
        $scope.selectProject = {};
        var url = RFS_Project + '/' + id;
        $http.get(url).success(function (data) {
            $scope.selectProject = data;
        });
        $scope.GetTimes(id);
    }

    $scope.editProject = function(ISproject)
    {
        alert(ISproject.name);
        alert(ISproject.totalJob);
        alert(ISproject.description);
    }
    // Save Time
    
    $scope.mytime = {};
    $scope.mytime.begin = null;
    $scope.mytime.end = null;
    $scope.mytime.pid = null;
    $scope.addTime = function (idProject)
    {
        if ($scope.mytime.begin === null) {
            $scope.mytime.pid = idProject;
            $scope.mytime.begin = $filter('date')(Date.now(), 'yyyy-MM-dd HH:mm:ss', 'UTC');
            var ele = document.getElementById("button_" + idProject);
            ele.innerHTML = "Pause";
        }
        else {
            if ($scope.mytime.pid === idProject) {
                $scope.mytime.end = $filter('date')(Date.now(), 'yyyy-MM-dd HH:mm:ss', 'UTC');
                $http({
                    method: 'POST',
                    url: RFS_Time,
                    data: $scope.mytime
                }).success(function () {
                    var ele = document.getElementById("button_" + idProject);
                    ele.innerHTML = "Start";
                    $scope.mytime.begin = null;
                });
            }
            else
                alert("Project have been ran! You only run one project!")
        }
    }
    
    $scope.allTimes = [];

    $scope.GetTimes = function (idProject) {
        if (idProject != null) {
            var url = RFS_Time + '?idProject=' + idProject;
            $http.get(url).success(function (data) {
                $scope.allTimes = data;
            });
        }
    }

    $scope.RemoveTime = function (idTime)
    {
        var url = RFS_Time + '?idTime=' + idTime;
        if(idTime != null)
        {
            $http({
                method: 'DELETE',
                url: url,
                data: idTime
            }).success(function () {
                $scope.GetTimes($scope.selectProject.pid);
            });
        }
    }

    $scope.editTime = function(IStime)
    {
        $http({
            method: 'PUT',
            url: RFS_Time,
            data: IStime
        }).success(function (data) {
            $scope.GetTimes(IStime.pid);
        });
    }

    $scope.showModal = function (id, value) {
        alert(id + value);
        if (value === true) {
            $('#' + id).modal('show');
        } else {
            $('#' + id).modal('hide');
        }
    }

    $scope.chartType = { typeName: 'BarChart', typeValue: 'BarChart' };
    
    $scope.HelloWorld = 'Hello';
}]);

app.controller('TimesController', ['$scope', '$http', '$filter', function ($scope, $http, $filter) {
    $scope.allTimes = [];
    alert("Gll");
    var hell = angular.module('ProjectsController').HelloWorld;
    alert(hell);
    $scope.GetTimes = function(idProject)
    {
        if (idProject != null) {
            $scope.projects = [];
            var url = RFS_Time + '?idProject=' + idProject;
            $http.get(url).success(function (data) {
                $scope.allTimes = data;
            });
        }
    }
}]);