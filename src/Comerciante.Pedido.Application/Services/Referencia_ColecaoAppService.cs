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
    public class Referencia_ColecaoAppService : IReferencia_ColecaoAppService
    {
        private readonly IReferencia_ColecaoRepository _referencia_ColecaoRepository;
        private readonly IMapper _mapper;

        public Referencia_ColecaoAppService(IReferencia_ColecaoRepository referencia_ColecaoRepository, IMapper mapper)
        {
            _referencia_ColecaoRepository = referencia_ColecaoRepository;
            _mapper = mapper;
        }

        public void Atualizar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel)
        {
            var model = _referencia_ColecaoRepository.TrazerPorId(Referencia_ColecaoViewModel.Id);
            var viewModel = _mapper.Map(Referencia_ColecaoViewModel, model);
            _referencia_ColecaoRepository.Atualizar(viewModel);
        }

        public void Criar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel)
        {
            var model = _mapper.Map<Referencia_Colecao>(Referencia_ColecaoViewModel);
            _referencia_ColecaoRepository.Atualizar(model);
        }

        public void Criar(ICollection<Referencia_ColecaoViewModel> Referencia_ColecaoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Colecao>>(Referencia_ColecaoViewModels);
            _referencia_ColecaoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _referencia_ColecaoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._referencia_ColecaoRepository.Dispose();
        }

        public IEnumerable<Referencia_ColecaoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Referencia_ColecaoViewModel>>(_referencia_ColecaoRepository.TrazerAtivos());
        }

        public IEnumerable<Referencia_ColecaoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Referencia_ColecaoViewModel>>(_referencia_ColecaoRepository.TrazerDeletados());
        }

        public Referencia_ColecaoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Referencia_ColecaoViewModel>(_referencia_ColecaoRepository.TrazerPorId(id));
        }

        public IEnumerable<Referencia_ColecaoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Referencia_ColecaoViewModel>>(_referencia_ColecaoRepository.TrazerTodos());
        }
    }
}
