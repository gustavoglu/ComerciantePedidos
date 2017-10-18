using Comerciante.Pedido.Application.Interfaces;
using System;
using System.Collections.Generic;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using AutoMapper;
using Comerciante.Pedido.Domain.Models;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class CorAppService : ICorAppService
    {
        private readonly ICorRepository _corRepository;
        private readonly IMapper _mapper;

        public CorAppService(ICorRepository corRepository, IMapper mapper)
        {
            _corRepository = corRepository;
            _mapper = mapper;
        }

        public void Atualizar(CorViewModel CorViewModel)
        {
            var model = _corRepository.TrazerPorId(CorViewModel.Id.Value);
            var viewModel = _mapper.Map(CorViewModel, model);
            _corRepository.Atualizar(viewModel);
        }

        public void Criar(CorViewModel CorViewModel)
        {
            var model = _mapper.Map<Cor>(CorViewModel);
            _corRepository.Criar(model);
        }

        public void Criar(ICollection<CorViewModel> CorViewModels)
        {
            var models = _mapper.Map<IEnumerable<Cor>>(CorViewModels);
            _corRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _corRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._corRepository.Dispose();
        }

        public IEnumerable<CorViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_corRepository.TrazerAtivos());
        }

        public IEnumerable<CorViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_corRepository.TrazerDeletados());
        }

        public CorViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<CorViewModel>(_corRepository.TrazerPorId(id));
        }

        public IEnumerable<CorViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_corRepository.TrazerTodos());
        }
    }
}
