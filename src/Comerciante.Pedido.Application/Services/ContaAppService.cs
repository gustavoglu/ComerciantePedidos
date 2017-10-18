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
    public class ContaAppService : IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaAppService(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public ContaViewModel Atualizar(ContaViewModel ContaViewModel)
        {
            var model = _contaRepository.TrazerPorId(ContaViewModel.Id.Value);
            var viewModel = _mapper.Map(ContaViewModel, model);
            return _mapper.Map<ContaViewModel>(_contaRepository.Atualizar(viewModel));
        }

        public ContaViewModel Criar(ContaViewModel ContaViewModel)
        {
            var model = _mapper.Map<Conta>(ContaViewModel);
            return _mapper.Map<ContaViewModel>(_contaRepository.Criar(model));
        }

        public IEnumerable<ContaViewModel> Criar(ICollection<ContaViewModel> ContaViewModels)
        {
            var models = _mapper.Map<IEnumerable<Conta>>(ContaViewModels);
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            return _contaRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._contaRepository.Dispose();
        }

        public IEnumerable<ContaViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerAtivos());
        }

        public IEnumerable<ContaViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerDeletados());
        }

        public ContaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.TrazerPorId(id));
        }

        public IEnumerable<ContaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerTodos());
        }
    }
}
