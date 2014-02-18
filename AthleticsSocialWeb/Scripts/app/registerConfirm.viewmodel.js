function RegisterConfirmViewModel(app, dataModel) {
    var self = this;
    
    // Other UI state
    self.sending = ko.observable(false);
    

    // Operations
    self.send = function () {
        self.sending(true);

        dataModel.resendEmail()
            .done(function (data) {
                if (data)
                    BootstrapDialog.show({
                        title: 'Email Confirmation',
                        message: 'Email was successfully sent.',
                        buttons: [{
                            id: 'btn-ok',
                            icon: 'glyphicon glyphicon-check',
                            label: 'OK',
                            cssClass: 'btn-primary',
                            autospin: false,
                            action: function (dialogRef) {
                                dialogRef.close();
                            }
                        }]


                    });
                else
                    BootstrapDialog.show({
                        title: 'Email Confirmation',
                        message: 'Email failed to send.',
                        buttons: [{
                            id: 'btn-ok',
                            icon: 'glyphicon glyphicon-check',
                            label: 'OK',
                            cssClass: 'btn-primary',
                            autospin: false,
                            action: function (dialogRef) {
                                dialogRef.close();
                            }
                        }]
                    });

                self.sending(false);
            });
    };    
}

app.addViewModel({
    name: "RegisterConfirm",
    bindingMemberName: "registerConfirm",
    factory: RegisterConfirmViewModel
});
