var viewModel = new ViewModel();
ko.applyBindings(viewModel);

$(document).ready(function () {

    criaCoresETamanhos(viewModelJs.cores, viewModelJs.tamanhos);


});

function ViewModel() {

    var self = this;
    self.descricao = ko.observable();
    self.codigo = ko.observable();
    self.preco = ko.observable();
    self.grade = ko.observable();
    self.tipos = ko.arrayObservable();
    self.cores = ko.arrayObservable();
    self.tamanhos = ko.arrayObservable();
    self.tipo = ko.observable();

}

function cor(id,descricao,selecionado) {
    var self = this;
    self.id = ko.observable(id);
    self.descricao = ko.observable(descricao);
    self.selecionado = ko.observable(selecionado);
}

function tamanho(id, descricao, selecionado) {
    var self = this;
    self.id = ko.observable(id);
    self.descricao = ko.observable(descricao);
    self.selecionado = ko.observable(selecionado);
}


function criaCoresETamanhos(cores,tamanhos) {

    ko.arrayForEach(cores, data){
        var cor = new cor(data.id, data.descricao, false);
        viewModel.cores.push(cor);
    }

    ko.arrayForEach(tamanhos, data){
        var tamanho = new tamanho(data.id, data.descricao, false);
        viewModel.cores.push(cor);
    }
}