using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedido_ReferenciaAppService _pedido_referenciaAppService;
        private readonly IPedido_ReferenciaRepository _pedido_referenciaRepository;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public PedidoAppService(IPedidoRepository pedidoRepository, IPedido_ReferenciaAppService pedido_referenciaAppService, IPedido_ReferenciaRepository pedido_referenciaRepository, IMapper mapper, IUser user)
        {
            _user = user;
            _pedido_referenciaRepository = pedido_referenciaRepository;
            _pedidoRepository = pedidoRepository;
            _pedido_referenciaAppService = pedido_referenciaAppService;
            _mapper = mapper;
        }

        public PedidoViewModel Atualizar(PedidoViewModel PedidoViewModel)
        {
            var model = _pedidoRepository.TrazerPorId(PedidoViewModel.Id.Value);
            var viewModel = _mapper.Map(PedidoViewModel, model);
            return _mapper.Map<PedidoViewModel>(_pedidoRepository.Atualizar(viewModel));
        }

        public PedidoViewModel Criar(PedidoViewModel PedidoViewModel)
        {
            if (_user.IsAuthenticated()) { PedidoViewModel.Id_cliente = Guid.Parse(_user.UserId); PedidoViewModel.Numero = NovoNumero(); }
            var model = _mapper.Map<Domain.Models.Pedido>(PedidoViewModel);
            return _mapper.Map<PedidoViewModel>(_pedidoRepository.Criar(model));
        }

        public IEnumerable<PedidoViewModel> Criar(ICollection<PedidoViewModel> PedidoViewModels)
        {
            Guid id_user = _user.IsAuthenticated() ? Guid.Parse(_user.UserId) : Guid.Empty;
            int count = NovoNumero();

            if (id_user != Guid.Empty)
            {
                foreach (var pedido in PedidoViewModels)
                {
                    pedido.Id_cliente = id_user;
                    pedido.Numero = count;
                    count++;
                }
            }

            var models = _mapper.Map<IEnumerable<Domain.Models.Pedido>>(PedidoViewModels);

            _pedidoRepository.Criar(models.ToList());

            return PedidoViewModels;
        }

        public int Deletar(Guid id)
        {
            return _pedidoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedidoRepository.Dispose();
        }

        public int NovoNumero()
        {
            return this.TrazerTodos().ToList().Count + 1;
        }

        public IEnumerable<PedidoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerAtivos());
        }

        public IEnumerable<PedidoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerDeletados());
        }

        public PedidoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(_pedidoRepository.TrazerPorId(id));
        }

        public IEnumerable<PedidoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerTodos());
        }

        public TotalPedidoViewModel TrazerTotais(Guid id)
        {
            var pedidoReferencias = _pedido_referenciaRepository.TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(id).ToList();

            double totalPedido = _pedidoRepository.TrazerPorId(id).Total;
            int totalReferencias = pedidoReferencias.Count;
            int totalPecas = pedidoReferencias.Sum(prf => prf.Quantidade);

            return new TotalPedidoViewModel { TotalPecas = totalPecas, TotalPedido = totalPedido, TotalReferencias = totalReferencias };

        }
    }
}
