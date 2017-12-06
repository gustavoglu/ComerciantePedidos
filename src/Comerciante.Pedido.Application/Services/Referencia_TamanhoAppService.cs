using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comerciante.Pedido.Application.Services
{
    public class Referencia_TamanhoAppService : IReferencia_TamanhoAppService
    {
        private readonly IReferencia_TamanhoRepository _referencia_TamanhoRepository;
        private readonly IMapper _mapper;

        public Referencia_TamanhoAppService(IReferencia_TamanhoRepository referencia_TamanhoRepository, IMapper mapper)
        {
            _referencia_TamanhoRepository = referencia_TamanhoRepository;
            _mapper = mapper;
        }

        public Referencia_TamanhoViewModel Atualizar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel)
        {
            var model = _referencia_TamanhoRepository.TrazerPorId(Referencia_TamanhoViewModel.Id.Value);
            var viewModel = _mapper.Map(Referencia_TamanhoViewModel, model);
            return _mapper.Map<Referencia_TamanhoViewModel>( _referencia_TamanhoRepository.Atualizar(viewModel));
        }

        public Referencia_TamanhoViewModel Criar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel)
        {
            var model = _mapper.Map<Referencia_Tamanho>(Referencia_TamanhoViewModel);
            return _mapper.Map< Referencia_TamanhoViewModel>(_referencia_TamanhoRepository.Criar(model));
        }

        public IEnumerable<Referencia_TamanhoViewModel> Criar(ICollection<Referencia_TamanhoViewModel> Referencia_TamanhoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Tamanho>>(Referencia_TamanhoViewModels);
           return _mapper.Map<IEnumerable< Referencia_TamanhoViewModel>>( _referencia_TamanhoRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            return _referencia_TamanhoRepository.Deletar(id);
        }

        public int Deletar(IEnumerable<Referencia_TamanhoViewModel> referencia_tamanhos)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Tamanho>>(referencia_tamanhos);
            return _referencia_TamanhoRepository.Deletar(models);
        }

        public void Dispose()
        {
            this._referencia_TamanhoRepository.Dispose();
        }

        public IEnumerable<Referencia_TamanhoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Referencia_TamanhoViewModel>>(_referencia_TamanhoRepository.TrazerAtivos());
        }

        public IEnumerable<Referencia_TamanhoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Referencia_TamanhoViewModel>>(_referencia_TamanhoRepository.TrazerDeletados());
        }

        public Referencia_TamanhoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Referencia_TamanhoViewModel>(_referencia_TamanhoRepository.TrazerPorId(id));
        }

        public IEnumerable<Referencia_TamanhoViewModel> TrazerPorReferencia(Guid id_referencia)
        {
            return _mapper.Map<IEnumerable<Referencia_TamanhoViewModel>>(_referencia_TamanhoRepository.PesquisarAtivos(rt => rt.Id_referencia == id_referencia).ToList());
        }

        public IEnumerable<Referencia_TamanhoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Referencia_TamanhoViewModel>>(_referencia_TamanhoRepository.TrazerTodos());
        }
    }
}
