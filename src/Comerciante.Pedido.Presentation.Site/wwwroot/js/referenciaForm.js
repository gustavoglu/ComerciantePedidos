var model = ko.toJS(viewModelJs);
var viewModel = new ViewModel();
ko.applyBindings(viewModel);

$(document).ready(function () {

    criaCoresETamanhos(model.cores, model.tamanhos);


});

function ViewModel() {

    var self = this;
    self.descricao = ko.observable();
    self.codigo = ko.observable();
    self.preco = ko.observable();
    self.grade = ko.observable();
    self.tipos = ko.observableArray();
    self.cores = ko.observableArray();
    self.tamanhos = ko.observableArray();
    self.tipo = ko.observable();

}

function cor(id,descricao,selecionado) {
    var self = this;
    self.Id = ko.observable(id);
    self.Descricao = ko.observable(descricao);
    self.Selecionado = ko.observable(selecionado);
}

function tamanho(id, descricao, selecionado) {
    var self = this;
    self.id = ko.observable(id);
    self.descricao = ko.observable(descricao);
    self.selecionado = ko.observable(selecionado);
}


function criaCoresETamanhos(cores,tamanhos) {

    ko.utils.arrayForEach(cores, function (data) {
        alert(ko.toJSON(data));
        var cor = new cor(data.id, data.descricao, false);
        viewModel.cores.push(cor);
    });

    ko.utils.arrayForEach(tamanhos, function (data) {
        var tamanho = new tamanho(data.id, data.descricao, false);
        viewModel.tamanhos.push(tamanho);
    });
}