var model = ko.toJS(modelSer);

var ViewModel = new viewModel(model);
ko.applyBindings(ViewModel);



function viewModel(model) {

    var self = this;
    self.selectedRow = ko.observable();

    self.pedidos = ko.observableArray(model);

    self.editarPedido = function (row) {

        alert('editar');
    }

    self.excluirPedido = function (row) {

        alert('excluir');
    }

    self.novoPedido = function () {

        location.href = "/Criar";

    }

}

$(document).ready(function () {

    //for (var i = 0; i < model.length; i++) {
    //    ViewModel.pedidos.push(model[i]);
    //}

});
