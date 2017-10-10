using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoAppService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public void Atualizar(PedidoViewModel PedidoViewModel)
        {
            var model = _pedidoRepository.TrazerPorId(PedidoViewModel.Id);
            var viewModel = _mapper.Map(PedidoViewModel, model);
            _pedidoRepository.Atualizar(viewModel);
        }

        public void Criar(PedidoViewModel PedidoViewModel)
        {
            var model = _mapper.Map<Domain.Models.Pedido>(PedidoViewModel);
            _pedidoRepository.Atualizar(model);
        }

        public void Criar(ICollection<PedidoViewModel> PedidoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Domain.Models.Pedido>>(PedidoViewModels);
            _pedidoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _pedidoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedidoRepository.Dispose();
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
    }
}
