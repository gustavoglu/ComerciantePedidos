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
        private readonly IMapper _mapper;

        public Pedido_ReferenciaAppService(IPedido_ReferenciaRepository pedido_ReferenciaRepository, IMapper mapper)
        {
            _pedido_ReferenciaRepository = pedido_ReferenciaRepository;
            _mapper = mapper;
        }

        public void Atualizar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {
            var model = _pedido_ReferenciaRepository.TrazerPorId(Pedido_ReferenciaViewModel.Id.Value);
            var viewModel = _mapper.Map(Pedido_ReferenciaViewModel, model);
            _pedido_ReferenciaRepository.Atualizar(viewModel);
        }

        public void Criar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {
            var model = _mapper.Map<Pedido_Referencia>(Pedido_ReferenciaViewModel);
            _pedido_ReferenciaRepository.Criar(model);
        }

        public void Criar(ICollection<Pedido_ReferenciaViewModel> Pedido_ReferenciaViewModels)
        {
            var models = _mapper.Map<IEnumerable<Pedido_Referencia>>(Pedido_ReferenciaViewModels);
            _pedido_ReferenciaRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _pedido_ReferenciaRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedido_ReferenciaRepository.Dispose();
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerAtivos());
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
