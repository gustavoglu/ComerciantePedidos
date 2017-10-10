using Comerciante.Pedido.Application.Interfaces;
using System;
using System.Collections.Generic;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using AutoMapper;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class Referencia_ImagemAppService : IReferencia_ImagemAppService
    {
        private readonly IReferencia_ImagemRepository _referencia_ImagemRepository;
        private readonly IMapper _mapper;

        public Referencia_ImagemAppService(IReferencia_ImagemRepository referencia_ImagemrRepository, IMapper mapper)
        {
            _referencia_ImagemRepository = referencia_ImagemrRepository;
            _mapper = mapper;
        }

        public void Atualizar(Referencia_ImagemViewModel Referencia_ImagemViewModel)
        {
            var model = _referencia_ImagemRepository.TrazerPorId(Referencia_ImagemViewModel.Id);
            var viewModel = _mapper.Map(Referencia_ImagemViewModel, model);
            _referencia_ImagemRepository.Atualizar(viewModel);
        }

        public void Criar(Referencia_ImagemViewModel Referencia_ImagemViewModel)
        {
            var model = _mapper.Map<Referencia_Imagem>(Referencia_ImagemViewModel);
            _referencia_ImagemRepository.Atualizar(model);
        }

        public void Criar(ICollection<Referencia_ImagemViewModel> Referencia_ImagemViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Imagem>>(Referencia_ImagemViewModels);
            _referencia_ImagemRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _referencia_ImagemRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._referencia_ImagemRepository.Dispose();
        }

        public IEnumerable<Referencia_ImagemViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Referencia_ImagemViewModel>>(_referencia_ImagemRepository.TrazerAtivos());
        }

        public IEnumerable<Referencia_ImagemViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Referencia_ImagemViewModel>>(_referencia_ImagemRepository.TrazerDeletados());
        }

        public Referencia_ImagemViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Referencia_ImagemViewModel>(_referencia_ImagemRepository.TrazerPorId(id));
        }

        public IEnumerable<Referencia_ImagemViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Referencia_ImagemViewModel>>(_referencia_ImagemRepository.TrazerTodos());
        }
    }
}
