myapp.controller('Employees', function ($scope, employeeService) {
    $scope.EmployeeList = {};
    $scope.UpdateEmployee = function (employee) {
        if (employee !== null) {
            var buttonId = '#updateEmployee' + employee.id;
            var button = $(buttonId);
            button.prop("disabled", true);
            button.val('updating...');
            try {
                employeeService.patch(employee);
            } catch (exception) {
                console.log(exception);
            }
        }

        window.setTimeout(function () {
            button.prop("disabled", false);
            button.val('Update');
        }, 2000);
    };

    $scope.AddEmployee = function (employee) {
        if (employee !== null)
            try {
                var success1 = employeeService.post(employee).success(function (data, status, headers, config) {
                    $scope.GetEmployees();
                });
            } catch (exception) {
                console.log(exception);
            }
    };

    $scope.GetEmployees = function () {
        setTimeout(function () {
            var page = jQuery('#page');
            if (page !== undefined && page !== null && page.length > 0) {
                page.html(jQuery('#employeesList').html());
            }
            employeeService.getEmployees().success(function (data, status, headers, config) {
                data.push({
                    "firstName": "",
                    "lastName": "",
                    "email": "",
                    "phone": null,
                    "addressId": 0,
                    "addresses": []
                });
                $scope.EmployeeList = data;
            }).error(function (data, status, headers, config) {
                console.log(status);
            });
        }, 500);
    };

    $scope.GetEmployees();
});