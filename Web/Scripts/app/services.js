myapp.service('employeeService', function ($http) {
    this.getEmployees = function () {
        return $http.get('/api/Employees');
    };

    this.get = function (id) {
        return $http.get('/api/Employees/' + id);
    };

    this.post = function (employee) {
        if (employee != null) {
            return $http.post('/api/Employees', employee);
        }
    };

    this.patch = function (employee) {
        if (employee != null) {
            return $http.patch('/api/Employees', employee);
        }
    }

    this.delete = function (employee) {
        if (employee != null) {
            return $http.delete('/api/Employees', employee);
        }
    }
});