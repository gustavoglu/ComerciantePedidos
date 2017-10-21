var modelJS = ko.toJS(modelSer);
var ViewModel = new viewModel();
ko.applyBindings(ViewModel);

$(document).ready(function () {

    for (var i = 0; i < modelJS.length; i++) {
        var model = modelJS[i];
        ViewModel.pedidoReferencias.push(model);
    }
});

function viewModel() {

    var self = this;
    self.pedidoReferencias = ko.observableArray();
    self.selectedRow = ko.observable();

    self.excluir = function (row) {

        var id = ko.toJSON(row.id);

        self.selectedRow(row);

        $.ajax({
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            url: '/Pedido_Referencia/Deletar/',
            data: id
        }).done(function (data) {
            if (data) {

                self.pedidoReferencias.remove(row);
            }
        });

    }
}

