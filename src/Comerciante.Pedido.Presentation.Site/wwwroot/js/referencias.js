
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
        var Referencia = new ViewModel.referencia(model.referencia.codigo, model.referencia.descricao, model.referencia.preco, imagemA, imagemB, tamanhos, cores, campos);

        ViewModel.listReferencias.push(Referencia);
    }
});


function viewModel() {

    var self = this;
    self.selectedRow = ko.observable();
    self.listReferencias = ko.observableArray();

    self.AddAoPedido = function (row) {

        ViewModel.selectedRow(row);
        var model = ko.toJS(row);

        self.addEditRef.Codigo(model.Codigo);
        self.addEditRef.Descricao(model.Descricao);
        self.addEditRef.Preco(model.Preco);
        self.addEditRef.ImagemA(model.ImagemA);
        self.addEditRef.ImagemB(model.ImagemB);
        self.addEditRef.Tamanhos(model.Tamanhos);
        self.addEditRef.Cores(model.Cores);
        self.addEditRef.Campos(model.Campos);

        $('#modalAddEditRef').modal('show');

    }

    self.addEditRef = {

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
    }

    self.referencia = function (codigo, descricao, preco, imagemA, imagemB, tamanhos, cores, campos) {

        var self = this;
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

        var campos = [];

        for (var i = 0; i < cores.length; i++) {
            var cor = cores[i];

            for (var j = 0; j < tamanhos.length; j++) {

                var tamanho = tamanhos[j];
                var campo = new self.campo(cor, tamanho, 0);
                campos.push(campo);
            }
        }

        return campos;
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
}