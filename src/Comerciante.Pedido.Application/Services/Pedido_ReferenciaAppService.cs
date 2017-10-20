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
    public class Pedido_ReferenciaAppService : IPedido_ReferenciaAppService
    {
        private readonly IPedido_ReferenciaRepository _pedido_ReferenciaRepository;
        private readonly IMapper _mapper;

        public Pedido_ReferenciaAppService(IPedido_ReferenciaRepository pedido_ReferenciaRepository, IMapper mapper)
        {
            _pedido_ReferenciaRepository = pedido_ReferenciaRepository;
            _mapper = mapper;
        }

        public Pedido_ReferenciaViewModel Atualizar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {
            var pedido_Referencia = _pedido_ReferenciaRepository.Pesquisar(pr => pr.Id_pedido == Pedido_ReferenciaViewModel.Id_pedido && pr.Id_referencia == Pedido_ReferenciaViewModel.Id_referencia).FirstOrDefault();

            if (pedido_Referencia != null)
                _pedido_ReferenciaRepository.Deletar(pedido_Referencia.Id.Value);

            var model = _pedido_ReferenciaRepository.TrazerPorId(Pedido_ReferenciaViewModel.Id.Value);
            var viewModel = _mapper.Map(Pedido_ReferenciaViewModel, model);
            return _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.Atualizar(viewModel));
        }

        public Pedido_ReferenciaViewModel Criar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel)
        {
            var model = _mapper.Map<Pedido_Referencia>(Pedido_ReferenciaViewModel);
            return _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.Criar(model));
        }

        public IEnumerable<Pedido_ReferenciaViewModel> Criar(ICollection<Pedido_ReferenciaViewModel> Pedido_ReferenciaViewModels)
        {
            var models = _mapper.Map<IEnumerable<Pedido_Referencia>>(Pedido_ReferenciaViewModels);
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.Criar(models.ToList()).ToList());
        }

        public int Deletar(Guid id)
        {
            return _pedido_ReferenciaRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedido_ReferenciaRepository.Dispose();
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivos()
        {
            var list = _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerAtivos().ToList());
            return list;
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivosInclude_Pedido_Referencia_TamanhosPorPedido(Guid id_pedido)
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(id_pedido).ToList());
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivosPorPedido(Guid id_pedido)
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.Pesquisar(pr => pr.Id_pedido == id_pedido).ToList());
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerDeletados());
        }

        public Pedido_ReferenciaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Pedido_ReferenciaViewModel>(_pedido_ReferenciaRepository.TrazerPorId(id));
        }

        public IEnumerable<Pedido_ReferenciaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Pedido_ReferenciaViewModel>>(_pedido_ReferenciaRepository.TrazerTodos());
        }
    }
}
