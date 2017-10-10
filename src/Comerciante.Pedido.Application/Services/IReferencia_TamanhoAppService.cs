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

        public void Atualizar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel)
        {
            var model = _referencia_TamanhoRepository.TrazerPorId(Referencia_TamanhoViewModel.Id);
            var viewModel = _mapper.Map(Referencia_TamanhoViewModel, model);
            _referencia_TamanhoRepository.Atualizar(viewModel);
        }

        public void Criar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel)
        {
            var model = _mapper.Map<Referencia_Tamanho>(Referencia_TamanhoViewModel);
            _referencia_TamanhoRepository.Atualizar(model);
        }

        public void Criar(ICollection<Referencia_TamanhoViewModel> Referencia_TamanhoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Referencia_Tamanho>>(Referencia_TamanhoViewModels);
            _referencia_TamanhoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _referencia_TamanhoRepository.Deletar(id);
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

        public IEnumerable<Referencia_TamanhoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Referencia_TamanhoViewModel>>(_referencia_TamanhoRepository.TrazerTodos());
        }
    }
}
