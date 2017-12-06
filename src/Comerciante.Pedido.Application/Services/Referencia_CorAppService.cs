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
    public class Referencia_CorAppService : IReferencia_CorAppService
    {
        private readonly IReferencia_CorRepository _referencia_CorRepository;
        private readonly IMapper _mapper;

        public Referencia_CorAppService(IReferencia_CorRepository referencia_CorRepository, IMapper mapper)
        {
            _referencia_CorRepository = referencia_CorRepository;
            _mapper = mapper;
        }

        public Referencia_CorViewModel Atualizar(Referencia_CorViewModel Referencia_CorViewModel)
        {
            var model = _referencia_CorRepository.TrazerPorId(Referencia_CorViewModel.Id.Value);
            var viewModel = _mapper.Map(Referencia_CorViewModel, model);
            return _mapper.Map<Referencia_CorViewModel>(_referencia_CorRepository.Atualizar(viewModel));
        }

        public Referencia_CorViewModel Criar(Referencia_CorViewModel Referencia_CorViewModel)
        {
            var model = _mapper.Map<Referencia_Cor>(Referencia_CorViewModel);
            return _mapper.Map<Referencia_CorViewModel>(_referencia_CorRepository.Criar(model));
        }

        public IEnumerable<Referencia_CorViewModel> Criar(ICollection<Referencia_CorViewModel> Referencia_CorViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Cor>>(Referencia_CorViewModels);
            return _mapper.Map<IEnumerable<Referencia_CorViewModel>>(_referencia_CorRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            return _referencia_CorRepository.Deletar(id);
        }

        public int Deletar(IEnumerable<Referencia_CorViewModel> referencia_cores)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Cor>>(referencia_cores);
            return _referencia_CorRepository.Deletar(models);
        }

        public void Dispose()
        {
            this._referencia_CorRepository.Dispose();
        }

        public IEnumerable<Referencia_CorViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<Referencia_CorViewModel>>(_referencia_CorRepository.TrazerAtivos());
        }

        public IEnumerable<Referencia_CorViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Referencia_CorViewModel>>(_referencia_CorRepository.TrazerDeletados());
        }

        public Referencia_CorViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Referencia_CorViewModel>(_referencia_CorRepository.TrazerPorId(id));
        }

        public IEnumerable<Referencia_CorViewModel> TrazerPorReferencia(Guid id_referencia)
        {
            return _mapper.Map<IEnumerable<Referencia_CorViewModel>>(_referencia_CorRepository.PesquisarAtivos(rc => rc.Id_referencia == id_referencia).ToList());
        }

        public IEnumerable<Referencia_CorViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Referencia_CorViewModel>>(_referencia_CorRepository.TrazerTodos());
        }
    }
}
