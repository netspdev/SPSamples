var myapp = angular.module('myapp', ["ngResource"]);

myapp.factory('myHttpInterceptor', function ($q, $http) {
    return function (promise) {
        return promise.then(function response() {
            return response;
        }, function response() {
            return $q.reject(response);
        });
    };

});

myapp.config(function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    $httpProvider.interceptors.push(function ($q) {
        return {
            // optional method
            'request': function (config) {
                return config || $q.when(config);
            },

            // optional method
            'requestError': function (rejection) {
                return $q.reject(rejection);
            },

            // optional method
            'response': function (response) {
                return response || $q.when(response);
            },

            // optional method
            'responseError': function (rejection) {
                return $q.reject(rejection);
            }
        }
    });
});



angular.element(document).ready(function () {
    var initInjector = angular.injector(["ng"]);
    var $http = initInjector.get("$http");
    $http.defaults.useXDomain = true;
    $http.defaults.headers.common = 'Content-Type: application/json';
    delete $http.defaults.headers.common['X-Requested-With'];
    //$http.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    $http.defaults.headers.common["Origin"] = '*';
   // $http.get('http://l3.quill.com/api/PNI/TestHeader').
   //success(function (data, status, headers, config) {
   //    data = data.replace(new RegExp('href="/', 'g'), 'href="http://l3.quill.com/');
   //    data = data.replace(new RegExp('src="/', 'g'), 'src="http://l3.quill.com/');
   //    jQuery('#QuillPlaceHolder').html(data);
   //    // this callback will be called asynchronously
   //    // when the response is available
   //}).
   //error(function (data, status, headers, config) {
   //    console.log(status);
   //    // called asynchronously if an error occurs
   //    // or server returns response with an error status.
   //});
    //var request = $http({
    //    url: "http://l3.quill.com/api/PNI/TestHeader"
    //});
    //request.then(handleSuccess, handleError);
    //function handleError(response) {

    //    // The API response from the server should be returned in a
    //    // nomralized format. However, if the request was not handled by the
    //    // server (or what not handles properly - ex. server error), then we
    //    // may have to normalize it on our end, as best we can.
    //    if (
    //        !angular.isObject(response.data) ||
    //        !response.data.message
    //        ) {

    //        return ($q.reject("An unknown error occurred."));

    //    }

    //    // Otherwise, use expected error message.
    //    return ($q.reject(response.data.message));

    //}


    //// I transform the successful response, unwrapping the application data
    //// from the API response payload.
    //function handleSuccess(response) {
    //    alert('success');
    //    $('QuillPlaceHolder').html(response);

    //}

});
