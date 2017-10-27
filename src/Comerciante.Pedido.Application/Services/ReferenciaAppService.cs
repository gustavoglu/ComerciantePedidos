using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Comerciante.Pedido.Application.ViewModels.Enums;
using Comerciante.Pedido.Domain.Models.Enums;

namespace Comerciante.Pedido.Application.Services
{
    public class ReferenciaAppService : IReferenciaAppService
    {
        private readonly IReferenciaRepository _referenciaRepository;
        private readonly IMapper _mapper;

        public ReferenciaAppService(IReferenciaRepository referenciaRepository, IMapper mapper)
        {
            _referenciaRepository = referenciaRepository;
            _mapper = mapper;
        }

        public ReferenciaViewModel Atualizar(ReferenciaViewModel ReferenciaViewModel)
        {
            var model = _referenciaRepository.TrazerPorId(ReferenciaViewModel.Id.Value);
            var viewModel = _mapper.Map(ReferenciaViewModel, model);
            return _mapper.Map<ReferenciaViewModel>(_referenciaRepository.Atualizar(viewModel));
        }

        public ReferenciaViewModel Criar(ReferenciaViewModel ReferenciaViewModel)
        {
            var model = _mapper.Map<Referencia>(ReferenciaViewModel);
            return _mapper.Map<ReferenciaViewModel>(_referenciaRepository.Criar(model));
        }

        public IEnumerable<ReferenciaViewModel> Criar(ICollection<ReferenciaViewModel> ReferenciaViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia>>(ReferenciaViewModels);
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            return _referenciaRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._referenciaRepository.Dispose();
        }

        public IEnumerable<ReferenciaViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerAtivos().ToList());
        }

        public IEnumerable<ReferenciaViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerDeletados().ToList());
        }

        public ReferenciaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ReferenciaViewModel>(_referenciaRepository.TrazerPorId(id));
        }

        public IEnumerable<ReferenciaViewModel> TrazerAtivoPorTipo(TipoReferenciaViewModel? tipo)
        {
            var parseTipo = Enum.Parse(typeof(TipoReferenciaViewModel),tipo.ToString());
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerAtivoPorTipo((TipoReferencia)parseTipo).ToList());
        }

        public IEnumerable<ReferenciaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerTodos().ToList());
        }
    }
}
