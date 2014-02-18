function VerifyEmailViewModel(app, dataModel) {
    var self = this;

    // HomeViewModel currently does not require data binding, so there are no visible members.
}

app.addViewModel({
    name: "VerifyEmail",
    bindingMemberName: "verifyEmail",
    factory: VerifyEmailViewModel
});
