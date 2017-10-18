﻿using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public PedidoAppService(IPedidoRepository pedidoRepository, IMapper mapper, IUser user)
        {
            _user = user;
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public void Atualizar(PedidoViewModel PedidoViewModel)
        {
            var model = _pedidoRepository.TrazerPorId(PedidoViewModel.Id.Value);
            var viewModel = _mapper.Map(PedidoViewModel, model);
            _pedidoRepository.Atualizar(viewModel);
        }

        public PedidoViewModel Criar(PedidoViewModel PedidoViewModel)
        {
            if (_user.IsAuthenticated()) { PedidoViewModel.Id_cliente = Guid.Parse(_user.UserId); PedidoViewModel.Numero = NovoNumero(); }
            var model = _mapper.Map<Domain.Models.Pedido>(PedidoViewModel);
            _pedidoRepository.Criar(model);
            return PedidoViewModel;
        }

        public IEnumerable<PedidoViewModel> Criar(ICollection<PedidoViewModel> PedidoViewModels)
        {
            Guid id_user = _user.IsAuthenticated() ? Guid.Parse(_user.UserId) : Guid.Empty;
            int count = NovoNumero();

            if (id_user != Guid.Empty)
            {
                foreach (var pedido in PedidoViewModels)
                {
                    pedido.Id_cliente = id_user;
                    pedido.Numero = count;
                    count++;
                }
            }

            var models = _mapper.Map<IEnumerable<Domain.Models.Pedido>>(PedidoViewModels);

            _pedidoRepository.Criar(models.ToList());

            return PedidoViewModels;
        }

        public int Deletar(Guid id)
        {
            return _pedidoRepository.Deletar(id);
        }

        public void Dispose()
        {
            this._pedidoRepository.Dispose();
        }

        public int NovoNumero()
        {
            int count = this.TrazerTodos().ToList().Count;
            return count == 0 ? 1 : count++;
        }

        public IEnumerable<PedidoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerAtivos());
        }

        public IEnumerable<PedidoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerDeletados());
        }

        public PedidoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(_pedidoRepository.TrazerPorId(id));
        }

        public IEnumerable<PedidoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(_pedidoRepository.TrazerTodos());
        }
    }
}
