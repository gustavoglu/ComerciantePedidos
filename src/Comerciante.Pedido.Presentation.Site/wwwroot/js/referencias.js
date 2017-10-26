
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
        var Referencia = new ViewModel.referencia(model.referencia.id, model.referencia.codigo, model.referencia.descricao, model.referencia.preco, imagemA, imagemB, tamanhos, cores, campos, model.referencia.grade);

        ViewModel.listReferencias.push(Referencia);
    }

    ViewModel.getTotais();

    ViewModel.getReferenciasJaAdd();

});

function viewModel() {

    var self = this;
    self.selectedRow = ko.observable();
    self.listReferencias = ko.observableArray();
    self.listReferenciasJaAdd = ko.observableArray();


    self.teste = function (row) {
        //alert(ko.toJSON(row));
    }

    self.totais = {
        totalPedido: ko.observable('0'),
        totalPecas: ko.observable('0'),
        totalReferencias: ko.observable('0')
    }

    self.notificarRefAdd = function () {
        $.notify({ title: 'Sucesso!', message: 'Referência Adicionada' }, { type: 'success' });
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

    self.getReferenciasJaAdd = function () {


        $.ajax({
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            url: '/Pedidos/ReferenciasJaAdicionadas/',
            data: ko.toJSON(pedidoSer.id)
        }).done(function (data) {

            if (data) {
                self.atualizaRefJaAdd(data);
            } else {
                if (self.listReferenciasJaAdd().length > 0) {
                    self.listReferenciasJaAdd.removeAll();
                }
            }
        });

    }

    self.atualizaRefJaAdd = function (referencias) {

        self.listReferenciasJaAdd.removeAll();
        for (var i = 0; i < referencias.length; i++) {
            var referencia = referencias[i];
            self.listReferenciasJaAdd.push(referencia);
        }
    }

    self.notificarRefExcluida = function () {
        $.notify({ title: 'Sucesso!', message: 'Referência Excluida do Pedido' }, { type: 'warning' });
    }

    self.excluirReferencia = function (row) {

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

                self.listReferenciasJaAdd.remove(row);
                self.notificarRefExcluida();
                self.getTotais();
            }
        });

    }

    self.AddAoPedido = function (row) {

        ViewModel.selectedRow(row);
        var model = ko.toJS(row);

        self.atualizarAddEditRef(model.Id, model.Codigo, model.Descricao, model.Preco, model.ImagemA, model.ImagemB, model.Tamanhos, model.Cores, model.Campos, model.Grade, model.Grade ? 6 : 0);

        $('#modalAddEditRef').modal('show');
    }

    self.salvarRef = function () {

        // alert(ko.toJSON(ViewModel.addEditRef))
    }

    self.atualizarAddEditRef = function (id_referencia, codigo, descricao, preco, imagemA, imagemB, tamanhos, cores, campos, grade, qtdGrade) {

        self.addEditRef.Id(id_referencia);
        self.addEditRef.Codigo(codigo);
        self.addEditRef.Descricao(descricao);
        self.addEditRef.Preco(preco);
        self.addEditRef.ImagemA(imagemA);
        self.addEditRef.ImagemB(imagemB);
        self.addEditRef.Tamanhos(tamanhos);
        self.addEditRef.Cores(cores);
        self.addEditRef.Campos(campos);
        self.addEditRef.QtdGrade(qtdGrade);
        self.addEditRef.Grade(grade);
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
        Grade: ko.observable(),
        QtdGrade: ko.observable(),
        Campos: ko.observableArray(),

    }

    self.addGrade = function () {
        var qtdGrade = self.addEditRef.QtdGrade();
        ViewModel.addEditRef.QtdGrade(qtdGrade + 6);
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

        self.umDeCada = function (row) {

            for (var i = 0; i < self.Campos().length; i++) {

                var campo = self.Campos()[i];

                var obj = ko.utils.arrayFirst(ViewModel.addEditRef.Campos()[i], function (item) {

                    return item.Cor.descricao == campo.Cor.descricao &&
                        item.Tamanho.descricao == campo.Tamanho.descricao;

                });

                alert(ko.toJSON(obj));

                obj.Quantidade(1);

                alert(ko.toJSON(obj));
            }
        }

    }

    self.referencia = function (id, codigo, descricao, preco, imagemA, imagemB, tamanhos, cores, campos, grade) {

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
        self.Grade = ko.observable(grade);
    }

    self.criaCampos = function (cores, tamanhos) {

        var refQtds = [];
        var campos = [];

        for (var i = 0; i < cores.length; i++) {

            var cor = cores[i];

            var campo;

            for (var j = 0; j < tamanhos.length; j++) {

                var tamanho = tamanhos[j];

                if (tamanho.descricao != null) {

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

    self.criaPedidoReferencia = function (id_referencia, campos, qtdGrade) {

        var referenciaPedido = {
            Id: null,
            Id_referencia: id_referencia,
            Id_pedido: pedidoSer.id,
            Quantidade: qtdGrade,
            Total: 0,
            Pedido_Referencia_Tamanhos: []
        }
        var pedido_Referencia_Tamanhos = [];

        if (qtdGrade == 0 || qtdGrade == null) {

            for (var i = 0; i < campos.length; i++) {

                var campoTamanhos = campos[i].Campos;

                for (var j = 0; j < campoTamanhos.length; j++) {

                    var tamanho = campoTamanhos[j];

                    var pedido_Referencia_Tamanho = {
                        Id_referencia_tamanho: tamanho.Tamanho.id_referencia_tamanho,
                        Id_referencia_cor: tamanho.Cor.id_referencia_cor,
                        Quantidade: tamanho.Quantidade != null ? tamanho.Quantidade : 0
                    }

                    pedido_Referencia_Tamanhos.push(pedido_Referencia_Tamanho);
                }
            }

            referenciaPedido.Pedido_Referencia_Tamanhos = pedido_Referencia_Tamanhos;
        }
        return referenciaPedido;
    }

    self.enviaPedidoReferencia = function () {

        var pedido_referencia = self.criaPedidoReferencia(self.addEditRef.Id(), self.addEditRef.Campos(), self.addEditRef.QtdGrade());

        var existQtds = self.existQuantidades(pedido_referencia.Pedido_Referencia_Tamanhos);

        var pedidoReferencia = ko.toJSON(pedido_referencia);

        if (!self.addEditRef.QtdGrade() && !existQtds) {
            $('#modalAddEditRef').modal('toggle');
            return;
        }

        $.ajax({
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            url: '/Pedido_Referencia/CriarReferenciaPedido',
            data: pedidoReferencia
        }).done(function (data) {

            $('#modalAddEditRef').modal('toggle');

            if (data) {
                self.getTotais();
                self.notificarRefAdd();
            }

            self.getReferenciasJaAdd();

        });
    }

    self.existQuantidades = function (pedido_referencia_tamanhos) {


        for (var i = 0; i < pedido_referencia_tamanhos.length; i++) {

            var pedido_referencia_tamanho = pedido_referencia_tamanhos[i];

            if (pedido_referencia_tamanho.Quantidade > 0) {
                return true;
                break;
            }
        }

        return false;
    }

    self.refJaAdicionadas = function () {
        window.location.href = '/Pedidos/ReferenciasAdicionadas/' + pedidoSer.id;
    }

}
