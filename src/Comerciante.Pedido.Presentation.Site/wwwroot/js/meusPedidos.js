var model = ko.toJS(modelSer);

var ViewModel = new viewModel(model);
ko.applyBindings(ViewModel);


$(document).ready(function () {

    ko.utils.arrayForEach(model, function (item) {

        ViewModel.pedidos.push(new ViewModel.pedido(item.pedido.id,item.pedido.numero, item.pedido.total, item.totalPedido.totalPecas, item.totalPedido.totalReferencias, item.pedido.finalizado));

    });

})

function viewModel(model) {

    var self = this;
    self.selectedRow = ko.observable();

    self.pedidos = ko.observableArray();

    self.notificarPedidoExcluido = function () {
        $.notify({ title: 'Sucesso!', message: 'Pedido Excludo com sucesso' }, { type: 'warning' });
    }

    self.editarPedido = function (row) {

        var id = row.Id();

        window.location.href = '/Pedidos/Editar/' + id;
    }

    self.excluirPedido = function (row) {

        var id = row.Id();

        $.ajax({

            type: 'DELETE',
            contentType: 'application/json',
            url: '/Pedidos/Deletar/' + id,
        }).done(function (data) {
            if (data) {
                self.pedidos.remove(row);
                self.notificarPedidoExcluido();
            }
        });
    }

    self.finalizarPedido = function (row) {

        $.ajax({
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: ko.toJSON(row.Id),
            url: '/Pedidos/FinalizarPedido'
        }).done(function (data) {

            if (data)
                row.Finalizado('Sim');
            });
    }

    self.novoPedido = function () {

        window.location.href = '/Pedidos/Criar';
    }

    self.pedido = function(id,numero, totalPedido, totalPecas, totalReferencias, finalizado) {
        var self = this;
        self.Id = ko.observable(id);
        self.Numero = ko.observable(numero);
        self.TotalPedido = ko.observable(totalPedido);
        self.TotalPecas = ko.observable(totalPecas);
        self.TotalReferencias = ko.observable(totalReferencias);
        self.Finalizado = ko.observable(finalizado ? 'Sim' : 'Não');
    }

}

