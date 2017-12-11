var model = ko.toJS(viewModelJs);
var referencia = model.referencia;
var viewModel = new ViewModel(referencia.id, referencia.codigo, referencia.descricao, referencia.preco,
                                referencia.grade, referencia.tipo, referencia.referencia_Tamanhos, referencia.referencia_Cores);
ko.applyBindings(viewModel);

$(document).ready(function () {

    criaCoresETamanhos(model.cores, model.tamanhos,
                        referencia.referencia_Cores, referencia.referencia_Tamanhos);

});

function ViewModel(id,descricao,codigo,preco,grade,tipo,tamanhos,cores) {

    var self = this;
    self.id = ko.observable(id);
    self.descricao = ko.observable(descricao);
    self.codigo = ko.observable(codigo);
    self.preco = ko.observable(preco);
    self.grade = ko.observable(grade);
    self.tipos = ko.observableArray(model.tipos);
    self.cores = ko.observableArray();
    self.tamanhos = ko.observableArray();
    self.tipo = ko.observableArray([tipo ? referenciaTipoConvert(tipo) : 'RovitexTeen']);

    self.salvarImagem = function () {

        var input = document.getElementById('inputFile');
        var file = input.files[0];

        $.ajax({
            type: 'POST',
        });
        //alert(input.files[0]);
    }

    self.cor = function(id, descricao, selecionado) {
        var self = this;
        self.id = ko.observable(id);
        self.descricao = ko.observable(descricao);
        self.selecionado = ko.observable(selecionado);
    }

    self.tamanho = function(id, descricao, selecionado) {
        var self = this;
        self.id = ko.observable(id);
        self.descricao = ko.observable(descricao);
        self.selecionado = ko.observable(selecionado);
    }

    self.salvar = function () {

        var coresEscolhidas = [];
        var tamanhosEscolhidos = [];

        ko.utils.arrayForEach(ko.toJS(viewModel.cores), function (data) {
            if (data.selecionado) 
                coresEscolhidas.push(data);
        });
        ko.utils.arrayForEach(ko.toJS(viewModel.tamanhos), function (data) {
            if (data.selecionado)
                tamanhosEscolhidos.push(data);
        });

        var referencia = criaReferencia(viewModel.descricao(), viewModel.codigo(), viewModel.preco(),
                        viewModel.grade(), viewModel.tipo()[0], coresEscolhidas, tamanhosEscolhidos);

       
        enviaRequest(referencia);

    }

}

function enviaRequest(referencia) {

    if (referencia.Id) {
        $.ajax({
            type: 'PUT',
            contentType: 'application/json',
            data: ko.toJSON(referencia),
            url: '/Referencias/Atualizar'

        }).done(function (data) {

        });

        return;
    }

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: ko.toJSON(referencia),
        url: '/Referencias/Criar'

    }).done(function (data) {

    });
}

function criaReferencia(descricao,codigo,preco,grade,tipo,cores,tamanhos) {

    var coresViewModel = [];
    var tamanhosViewModel = [];

    ko.utils.arrayForEach(cores, function (cor) {
   
        var corViewModel = criaCorViewModel(cor.id, this.referencia.id);
        coresViewModel.push(corViewModel)
    });

    ko.utils.arrayForEach(tamanhos, function (tamanho) {

        var tamanhoViewModel = criaTamanhoViewModel(tamanho.id, this.referencia.id);
        tamanhosViewModel.push(tamanhoViewModel)
    });

    var referencia = {
        Id : this.referencia.id,
        Codigo: codigo,
        Descricao: descricao,
        Preco: preco,
        Grade: grade,
        Tipo: tipo,
        Referencia_Tamanhos: tamanhosViewModel,
        Referencia_Cores: coresViewModel
    }

    return referencia;
}

function criaCorViewModel(id_cor, id_referencia) {

    return {

        Id_referencia: id_referencia,
        Id_cor: id_cor,
        Preco : null
    }
}

function criaTamanhoViewModel(id_tamanho, id_referencia) {
    
    return {

        Id_referencia: id_referencia,
        Id_tamanho: id_tamanho,
        Preco: null
    }
}

function criaCoresETamanhos(cores,tamanhos,coresJaExistentes,tamanhosJaExistentes) {

    ko.utils.arrayForEach(cores, function (data) {

        var exist = corExist(data.id, coresJaExistentes);
        var cor = new viewModel.cor(data.id, data.descricao, exist);
        viewModel.cores.push(cor);
    });

    ko.utils.arrayForEach(tamanhos, function (data) {

        var exist = tamanhoExist(data.id, tamanhosJaExistentes);
        var tamanho = new viewModel.tamanho(data.id, data.descricao, exist);
        viewModel.tamanhos.push(tamanho);
    });
}

function corExist(id_cor, coresJaExistentes) {

    var corExist = false;

    ko.utils.arrayForEach(coresJaExistentes, function (corExistente) {

        if (corExistente.id_cor == id_cor) corExist = true;
    });

    return corExist;
}

function tamanhoExist(id_tamanho, tamanhosJaExistentes) {

    var tamanhoExist = false;

    ko.utils.arrayForEach(tamanhosJaExistentes, function (tamanhoExistente) {
        if (tamanhoExistente.id_tamanho == id_tamanho) tamanhoExist = true;
    });

    return tamanhoExist;
}


function atualizaCoresETamanhos(cores, tamanhos) {

    if (cores.length == 0 && tamanhos.length == 0) return;

    if (cores.length > 0) {

        ko.utils.arrayForEach(cores, function (corExistente) {

            ko.tils.arrayForEach(ko.toJS(viewModel.cores), function (cor) {



            });

        });

    }

}