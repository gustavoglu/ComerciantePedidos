var model = ko.toJS(modelSer);

var ViewModel = new viewModel(model);
ko.applyBindings(ViewModel);

function viewModel(model) {

    var self = this;
    self.selectedRow = ko.observable();

    self.pedidos = ko.observableArray(model);

    self.editarPedido = function (row) {

        var id = row.id;

        window.location.href = '/Pedidos/Editar/' + id;
    }

    self.excluirPedido = function (row) {

        var id = row.id;

        $.ajax({

            type: 'DELETE',
            contentType: 'application/json',
            url: '/Pedidos/Deletar/' + id,
        }).done(function (data) {
            if (data)
                self.pedidos.remove(row);
        });
    }

    self.novoPedido = function () {

        window.location.href = '/Pedidos/Criar';
    }

}

$(document).ready(function () {

    //for (var i = 0; i < model.length; i++) {
    //    ViewModel.pedidos.push(model[i]);
    //}

});
