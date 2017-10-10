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
    public class TamanhoAppService : ITamanhoAppService
    {
        private readonly ITamanhoRepository _tamanhoRepository;
        private readonly IMapper _mapper;

        public TamanhoAppService(ITamanhoRepository tamanhoRepository, IMapper mapper)
        {
            _tamanhoRepository = tamanhoRepository;
            _mapper = mapper;
        }

        public void Atualizar(TamanhoViewModel TamanhoViewModel)
        {
            var model = _tamanhoRepository.TrazerPorId(TamanhoViewModel.Id);
            var viewModel = _mapper.Map(TamanhoViewModel, model);
            _tamanhoRepository.Atualizar(viewModel);
        }

        public void Criar(TamanhoViewModel TamanhoViewModel)
        {
            var model = _mapper.Map<Tamanho>(TamanhoViewModel);
            _tamanhoRepository.Atualizar(model);
        }

        public void Criar(ICollection<TamanhoViewModel> TamanhoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Tamanho>>(TamanhoViewModels);
            _tamanhoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _tamanhoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._tamanhoRepository.Dispose();
        }

        public IEnumerable<TamanhoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<TamanhoViewModel>>(_tamanhoRepository.TrazerAtivos());
        }

        public IEnumerable<TamanhoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<TamanhoViewModel>>(_tamanhoRepository.TrazerDeletados());
        }

        public TamanhoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<TamanhoViewModel>(_tamanhoRepository.TrazerPorId(id));
        }

        public IEnumerable<TamanhoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<TamanhoViewModel>>(_tamanhoRepository.TrazerTodos());
        }
    }
}
