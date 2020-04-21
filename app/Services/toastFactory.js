angular.module("app").factory("toast", function ($mdToast) {
    return {
        added: function () {
            $mdToast.show(
                $mdToast.simple()
                .textContent("Successfully added")
                .position("bottom left")
                .hideDelay(6000)
                .action("Dismiss")
                .highlightClass('md-accent')
            );
        },
        updated: function() {
            $mdToast.show(
                $mdToast.simple()
                    .textContent("Successfully updated")
                    .position("bottom right")
                    .hideDelay(6000)
                    .action("Dismiss")
                    .highlightClass('md-accent')
            );
        },
        deleted: function () {
            $mdToast.show(
                $mdToast.simple()
                    .textContent("Successfully deleted")
                    .position("bottom right")
                    .hideDelay(6000)
                    .action("Dismiss")
                    .highlightClass('md-accent')
            );
        }
    }
});

//$mdToast.show({
//    template: "<md-toast class='md-toast  md-toast-success md-center'>Succesfully added</md-toast>",
//    position: "bottom",
//    hideDelay: 44000,
//    action: "Dismiss"
//});