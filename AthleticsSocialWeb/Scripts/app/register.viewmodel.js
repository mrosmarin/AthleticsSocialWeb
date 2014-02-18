function RegisterViewModel(app, dataModel) {
    var self = this;
    
    //TODO put in a global place for validation
    self.patterns = {
        email: /^([\d\w-\.]+@([\d\w-]+\.)+[\w]{2,4})?$/,
        phone: /^\d[\d -]*\d$/,
        postcode: /^([a-zA-Z]{1,2}[0-9][0-9]?[a-zA-Z\s]?\s*[0-9][a-zA-Z]{2,2})|(GIR 0AA)$/,
        policy: /^(?=.{9,})(?=[a-z]*)(?=.*[A-Z])(?=.*[0-9])(?=.*\p{Punct}).*$/
    };


    // Data
    self.userName = ko.observable("").extend({
        required: true, pattern: {
            message: 'Must be a valid Email Address',
            params: self.patterns.email
        }
    });
    
    self.password = ko.observable("").extend({ required: true });
    self.confirmPassword = ko.observable("").extend({ required: true, equal: self.password });

    // Other UI state
    self.registering = ko.observable(false);
    self.errors = ko.observableArray();
    self.validationErrors = ko.validation.group([self.userName, self.password, self.confirmPassword]);

    // Operations
    self.register = function () {
        self.errors.removeAll();
        if (self.validationErrors().length > 0) {
            self.validationErrors.showAllMessages();
            return;
        }
        self.registering(true);

        dataModel.register({
            userName: self.userName(),
            password: self.password(),
            confirmPassword: self.confirmPassword()
        }).done(function (data) {
            dataModel.login({
                grant_type: "password",
                username: self.userName(),
                password: self.password()
            }).done(function (data) {
                self.registering(false);

                data.isConfirmed = JSON.parse(data.isConfirmed);
                if (data.userName && data.access_token) {
                    app.navigateToLoggedIn(data, data.access_token, false /* persistent */);
                } else {
                    self.errors.push("An unknown error occurred.");
                }
            }).failJSON(function (data) {
                self.registering(false);

                if (data && data.error_description) {
                    self.errors.push(data.error_description);
                } else {
                    self.errors.push("An unknown error occurred.");
                }
            });
        }).failJSON(function (data) {
            var errors;

            self.registering(false);
            errors = dataModel.toErrorsArray(data);

            if (errors) {
                self.errors(errors);
            } else {
                self.errors.push("An unknown error occurred.");
            }
        });
    };

    self.login = function () {
        app.navigateToLogin();
    };
}

app.addViewModel({
    name: "Register",
    bindingMemberName: "register",
    factory: RegisterViewModel
});
