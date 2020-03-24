angular.module("app").factory("msgAlert",function ($mdDialog) {
    return {
        added: function () {
            $mdDialog.show(
                $mdDialog.alert({
                    title: 'Response',
                    textContent: 'Successfully added',
                    ok: 'Got it!',
                })
            );
        }
    }
});