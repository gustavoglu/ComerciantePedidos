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
    public class Pedido_Referencia_TamanhoAppService : IPedido_Referencia_TamanhoAppService
    {
        private readonly IPedido_Referencia_TamanhoRepository _pedido_Referencia_TamanhoRepository;
        private readonly IMapper _mapper;

        public Pedido_Referencia_TamanhoAppService(IPedido_Referencia_TamanhoRepository pedido_Referencia_TamanhoRepository, IMapper mapper)
        {
            _pedido_Referencia_TamanhoRepository = pedido_Referencia_TamanhoRepository;
            _mapper = mapper;
        }

        public void Atualizar(Pedido_Referencia_TamanhoViewModel Pedido_Referencia_TamanhoViewModel)
        {
            var model = _pedido_Referencia_TamanhoRepository.TrazerPorId(Pedido_Referencia_TamanhoViewModel.Id);
            var viewModel = _mapper.Map(Pedido_Referencia_TamanhoViewModel, model);
            _pedido_Referencia_TamanhoRepository.Atualizar(viewModel);
        }

        public void Criar(Pedido_Referencia_TamanhoViewModel Pedido_Referencia_TamanhoViewModel)
        {
            var model = _mapper.Map<Pedido_Referencia_Tamanho>(Pedido_Referencia_TamanhoViewModel);
            _pedido_Referencia_TamanhoRepository.Atualizar(model);
        }

        public void Criar(ICollection<Pedido_Referencia_TamanhoViewModel> Pedido_Referencia_TamanhoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Pedido_Referencia_Tamanho>>(Pedido_Referencia_TamanhoViewModels);
            _pedido_Referencia_TamanhoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _pedido_Referencia_TamanhoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedido_Referencia_TamanhoRepository.Dispose();
        }

        public IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Pedido_Referencia_TamanhoViewModel>>(_pedido_Referencia_TamanhoRepository.TrazerAtivos());
        }

        public IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Pedido_Referencia_TamanhoViewModel>>(_pedido_Referencia_TamanhoRepository.TrazerDeletados());
        }

        public Pedido_Referencia_TamanhoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Pedido_Referencia_TamanhoViewModel>(_pedido_Referencia_TamanhoRepository.TrazerPorId(id));
        }

        public IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Pedido_Referencia_TamanhoViewModel>>(_pedido_Referencia_TamanhoRepository.TrazerTodos());
        }
    }
}
