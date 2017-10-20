
ko.virtualElements.allowedBindings.foreachprop = true;
var ViewModel = new viewModel();
ko.applyBindings(ViewModel);

$(document).ready(function () {

    var modelJS = ko.toJS(modelSer);

    for (var i = 0; i < modelJS.length; i++) {

        var model = modelJS[i];

        var cores = model.cores;
        var tamanhos = ViewModel.criaTamanhos(model.tamanhos);
        var imagemA = model.referencia.referencia_Imagens[0].uri;
        var imagemB = model.referencia.referencia_Imagens[1].uri;
        var campos = ViewModel.criaCampos(cores, tamanhos);
        var Referencia = new ViewModel.referencia(model.referencia.id, model.referencia.codigo, model.referencia.descricao, model.referencia.preco, imagemA, imagemB, tamanhos, cores, campos);

        ViewModel.listReferencias.push(Referencia);
    }

    ViewModel.getTotais();

});


function viewModel() {

    var self = this;
    self.selectedRow = ko.observable();
    self.listReferencias = ko.observableArray();
    self.totais = {
        totalPedido: ko.observable('0'),
        totalPecas: ko.observable('0'),
        totalReferencias: ko.observable('0')
    }


    self.getTotais = function () {

        var idpedido = {};
        idpedido.id = pedidoSer.id;

        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            url: '/Pedidos/TotalPedido/' + idpedido.id,
        }).done(function (data) {

            if (data) {
                self.totais.totalPedido(data.totalPedido);
                self.totais.totalPecas(data.totalPecas);
                self.totais.totalReferencias(data.totalReferencias);
            }
        });
    }

    self.AddAoPedido = function (row) {

        ViewModel.selectedRow(row);
        var model = ko.toJS(row);

        self.atualizarAddEditRef(model.Id, model.Codigo, model.Descricao, model.Preco, model.ImagemA, model.ImagemB, model.Tamanhos, model.Cores, model.Campos);

        var pedidoReferencia = self.criaPedidoReferencia(self.addEditRef.Id(), self.addEditRef.Campos());

        alert(ko.toJSON(pedidoReferencia));

        $('#modalAddEditRef').modal('show');

    }

    self.salvarRef = function () {

        alert(ko.toJSON(ViewModel.addEditRef))
    }

    self.atualizarAddEditRef = function (id_referencia, codigo, descricao, preco, imagemA, imagemB, tamanhos, cores, campos) {

        self.addEditRef.Id(id_referencia);
        self.addEditRef.Codigo(codigo);
        self.addEditRef.Descricao(descricao);
        self.addEditRef.Preco(preco);
        self.addEditRef.ImagemA(imagemA);
        self.addEditRef.ImagemB(imagemB);
        self.addEditRef.Tamanhos(tamanhos);
        self.addEditRef.Cores(cores);
        self.addEditRef.Campos(campos);
    }

    self.addEditRef = {
        Id: ko.observable(),
        Id_referencia: ko.observable(),
        Codigo: ko.observable(),
        Descricao: ko.observable(),
        Preco: ko.observable(),
        ImagemA: ko.observable(),
        ImagemB: ko.observable(),
        Tamanhos: ko.observable(),
        Cores: ko.observable(),
        Campos: ko.observable()
    }


    self.campo = function (cor, tamanho, quantidade) {

        var self = this;
        self.Cor = ko.observable(cor);
        self.Tamanho = ko.observable(tamanho);
        self.Quantidade = ko.observable(quantidade);

        self.addUm = function () {

            self.Quantidade(1);
        }

    }


    self.refQtd = function (cor, tamanhos, campos) {

        var self = this;
        self.Cor = ko.observable(cor);
        self.Tamanho = ko.observableArray(tamanhos);
        self.Campos = ko.observableArray(campos);

        self.umDeCada = function () {

            for (var i = 0; i < self.Campos.length; i++) {

                self.Campos[i].AddUm();
            }
            alert(ko.toJSON(ViewModel.addEditRef.Campos));
        }

    }

    self.referencia = function (id, codigo, descricao, preco, imagemA, imagemB, tamanhos, cores, campos) {

        var self = this;
        self.Id = ko.observable(id);
        self.Codigo = ko.observable(codigo);
        self.Descricao = ko.observable(descricao);
        self.Preco = ko.observable(preco);
        self.ImagemA = ko.observable(imagemA);
        self.ImagemB = ko.observable(imagemB);
        self.Tamanhos = tamanhos;
        self.Cores = cores;
        self.Campos = ko.observableArray(campos);
    }

    self.criaCampos = function (cores, tamanhos) {

        var refQtds = [];
        var campos = [];

        for (var i = 0; i < cores.length; i++) {

            var cor = cores[i];

            var campo;

            for (var j = 0; j < tamanhos.length; j++) {

                var tamanho = tamanhos[j];

                if (tamanho.descricao) {

                    campo = new self.campo(cor, tamanho, 0);
                    campos.push(campo);
                }
            }

            var RefQtd = new self.refQtd(cor, tamanhos, campos);
            refQtds.push(RefQtd);

            campos = [];

        }

        return refQtds;
    }

    self.criaTamanhos = function (tamanhos) {

        var tamanhoNull = { id: null, descricao: null };
        var tamanhosCriados = [tamanhoNull];

        for (var h = 0; h < tamanhos.length; h++) {
            var tamanho = tamanhos[h];
            tamanhosCriados.push(tamanho);
        }

        return tamanhosCriados;
    }


    self.umDeCada = function (row) {

        var cor = row.Cor.descricao;

        ko.utils.arrayForEach(ViewModel.addEditRef.Campos(), function (campo) {

            if (campo.Cor.descricao == cor) {

                ko.utils.arrayForEach(campo.Campos, function (campoQtd) {
                    campoQtd.quantidade = 1;

                });
            }
        });
    }

    self.criaPedidoReferencia = function (id_referencia, campos) {

        var referenciaPedido = {
            Id_referencia: id_referencia,
            Id_pedido: pedidoSer.id
        }
        var pedido_Referencia_Tamanhos = [];
        for (var i = 0; i < campos.length; i++) {

            var campoTamanhos = campos[i].Campos;

            for (var j = 0; j < campoTamanhos.length; j++) {

                var tamanho = campoTamanhos[i];

                var pedido_Referencia_Tamanho = {
                    Id_referencia_tamanho: tamanho.Tamanho.id,
                    Id_referencia_cor: tamanho.Cor.id,
                    Quantidade: tamanho.Quantidade
                }

                pedido_Referencia_Tamanhos.push(pedido_Referencia_Tamanho);
            }
        }

        referenciaPedido.Pedido_Referencia_Tamanhos = pedido_Referencia_Tamanhos;

        alert(ko.toJSON(referenciaPedido));

        return { pedidoReferencia: referenciaPedido };

    }

}
