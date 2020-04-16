angular.module("app").factory("dialog",function ($mdDialog) {
    return {
        added: function () {
            $mdDialog.show(
                $mdDialog.alert({
                    title: 'Response',
                    textContent: 'Successfully added',
                    ok: 'Got it!',
                })
            );
        },
        confirm: function (txt) {
            $mdDialog.show(
                $mdDialog.confirm({
                    title: 'Deletion',
                    textContent: txt,
                    ok: 'Yes',
                    cancel:'No'
                })
            );
        }
    }
});