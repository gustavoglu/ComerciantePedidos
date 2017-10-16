
var ViewModel = new viewModel();

$(document).ready(function () {

    var modelJS = ko.toJS(modelSer);

    for (var i = 0; i < modelJS.length; i++) {

        var model = modelJS[i];
        var imagemA = model.referencia.referencia_Imagens[0].Uri;
        var imagemB = model.referencia.referencia_Imagens[1].Uri;
        var Referencia = new referencia(model.referencia.Codigo, model.referencia.Descricao, model.referencia.Preco, imagemA, imagemB);
        ViewModel.listReferencias.push(model);
    }

    ko.applyBindings(ViewModel);

});


function viewModel() {

    var self = this;
    self.listReferencias = ko.observableArray();
}

function referencia(codigo,descricao,preco,imagemA,imagemB) {

    var self = this;
    self.Codigo = ko.observable(codigo);
    self.Descricao = ko.observable(descricao);
    self.Preco = ko.observable(preco);
    self.ImagemA = ko.observable(imagemA);
    self.ImagemB = ko.observable(imagemB);
}


$('.btAdd').click(btAdd);


function btAdd() {

    var modelSer = 

    $('#modalAddEditRef').modal("show");

}