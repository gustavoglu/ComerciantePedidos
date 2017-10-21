using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class Pedido_ReferenciaAppService : IPedido_ReferenciaAppService
    {
        private readonly IPedido_ReferenciaRepository _pedido_ReferenciaRepository;
        private readonly IPedido_Referencia_TamanhoRepository _pedido_Referencia_TamanhoRepository;
        private readonly IReferenciaRepository _referenciaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public Pedido_ReferenciaAppService(IPedido_ReferenciaRepository pedido_ReferenciaRepository, IPedido_Referencia_TamanhoRepository pedido_Referencia_TamanhoRepository, IReferenciaRepository referenciaRepository, IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedido_Referencia_TamanhoRepository = pedido_Referencia_TamanhoRepository;
            _pedidoRepository = pedidoRepository;
            _referenciaRepository = referenciaRepository;
            _pedido_ReferenciaRepository = pedido_ReferenciaRepository;
            _mapper = mapper;
        }

        public Pedido_ReferenciaViewModel Atualizar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {
            var model = _pedido_ReferenciaRepository.TrazerPorId(Pedido_ReferenciaViewModel.Id.Value);
            var viewModel = _mapper.Map(Pedido_ReferenciaViewModel, model);
            return _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.Atualizar(viewModel));
        }

        private double SomaTotalPedido_Referencia_Tamanhos(IEnumerable<Pedido_Referencia_TamanhoViewModel> pedido_referencia_tamanhosVM, Referencia referencia)
        {
            double somaTotal = 0;

            foreach (var pedido_Referencia_Tamanho in pedido_referencia_tamanhosVM)
            {
                var referenciaTamanho = referencia.Referencia_Tamanhos.FirstOrDefault(rt => rt.Id == pedido_Referencia_Tamanho.Id_referencia_tamanho);
                double valor = referenciaTamanho.Preco.HasValue && referenciaTamanho.Preco.Value > 0 ? referenciaTamanho.Preco.Value : referencia.Preco;
                double total = pedido_Referencia_Tamanho.Quantidade * valor;
                somaTotal = somaTotal + total;
            }

            return somaTotal;
        }

        public Pedido_ReferenciaViewModel Criar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {

            var pedido = _pedidoRepository.TrazerPorId(Pedido_ReferenciaViewModel.Id_pedido.Value);

            var referencia = _referenciaRepository.TrazerPorId(Pedido_ReferenciaViewModel.Id_referencia.Value);

            var pedido_Referencia = _pedido_ReferenciaRepository.PesquisarAtivos(pr => pr.Id_pedido == Pedido_ReferenciaViewModel.Id_pedido && pr.Id_referencia == Pedido_ReferenciaViewModel.Id_referencia).FirstOrDefault();

            if (pedido_Referencia != null)
            {
                this.Deletar(pedido_Referencia.Id.Value);
            }

            var pedido_Referencia_TamanhosMaiorZero = Pedido_ReferenciaViewModel.Pedido_Referencia_Tamanhos.Where(prt => prt.Quantidade > 0);

            Pedido_ReferenciaViewModel.Quantidade = pedido_Referencia_TamanhosMaiorZero.Sum(prt => prt.Quantidade);

            double somaTotal = SomaTotalPedido_Referencia_Tamanhos(pedido_Referencia_TamanhosMaiorZero, referencia);

            Pedido_ReferenciaViewModel.Total = somaTotal;

            var model = _mapper.Map<Pedido_Referencia>(Pedido_ReferenciaViewModel);
            var pedidoReferenciaCriado = _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.Criar(model));

            pedido.Total = pedido.Total + somaTotal;

            _pedidoRepository.Atualizar(pedido);

            return pedidoReferenciaCriado;
        }

        public IEnumerable<Pedido_ReferenciaViewModel> Criar(ICollection<Pedido_ReferenciaViewModel> Pedido_ReferenciaViewModels)
        {
            var models = _mapper.Map<IEnumerable<Pedido_Referencia>>(Pedido_ReferenciaViewModels);
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            var pedido_referencia = this.TrazerPorId(id);
            var pedido = _pedidoRepository.TrazerPorId(pedido_referencia.Id_pedido.Value);

            var pedido_referencia_tamanhos = _pedido_Referencia_TamanhoRepository.PesquisarAtivos(prt => prt.Id_pedido_referencia == id);

            if (pedido_referencia_tamanhos.Any())
                _pedido_Referencia_TamanhoRepository.Deletar(pedido_referencia_tamanhos);


            var linhas = _pedido_ReferenciaRepository.Deletar(id);

            pedido.Total = pedido.Total - pedido_referencia.Total;
            _pedidoRepository.Atualizar(pedido);

            return linhas;
        }

        public void Dispose()
        {
            this._pedido_ReferenciaRepository.Dispose();
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivos()
        {
            var list = _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerAtivos().ToList());
            return list;
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivosInclude_Pedido_Referencia_TamanhosPorPedido(Guid id_pedido)
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(id_pedido).ToList());
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivosPorPedido(Guid id_pedido)
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.Pesquisar(pr => pr.Id_pedido == id_pedido).ToList());
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerDeletados());
        }

        public Pedido_ReferenciaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.TrazerPorId(id));
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerTodos());
        }
    }
}
