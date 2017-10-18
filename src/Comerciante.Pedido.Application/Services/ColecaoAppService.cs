﻿using Comerciante.Pedido.Application.Interfaces;
using System;
using System.Collections.Generic;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using AutoMapper;
using Comerciante.Pedido.Domain.Models;
using System.Linq;

namespace Comerciante.Pedido.Application.Services
{
    public class ColecaoAppService : IColecaoAppService
    {
        private readonly IColecaoRepository _colecaoRepository;
        private readonly IMapper _mapper;

        public ColecaoAppService(IColecaoRepository colecaoRepository, IMapper mapper)
        {
            _colecaoRepository = colecaoRepository;
            _mapper = mapper;
        }

        public void Atualizar(ColecaoViewModel ColecaoViewModel)
        {
            var model = _colecaoRepository.TrazerPorId(ColecaoViewModel.Id.Value);
            var viewModel = _mapper.Map(ColecaoViewModel, model);
            _colecaoRepository.Atualizar(viewModel);
        }

        public void Criar(ColecaoViewModel ColecaoViewModel)
        {
            var model = _mapper.Map<Colecao>(ColecaoViewModel);
            _colecaoRepository.Criar(model);
        }

        public void Criar(ICollection<ColecaoViewModel> ColecaoViewModels)
        {
            var models = _mapper.Map<IEnumerable<Colecao>>(ColecaoViewModels);
            _colecaoRepository.Criar(models.ToList());
        }

        public int Deletar(Guid id)
        {
            return _colecaoRepository.Deletar(id);
        }

        public void Dispose()
        {
            _colecaoRepository.Dispose();
        }

        public IEnumerable<ColecaoViewModel> TrazerAtivos()
        {
            return _mapper.Map<IEnumerable<ColecaoViewModel>>(_colecaoRepository.TrazerAtivos());
        }

        public IEnumerable<ColecaoViewModel> TrazerDeletados()
        {
            return _mapper.Map<IEnumerable<ColecaoViewModel>>(_colecaoRepository.TrazerDeletados());
        }

        public ColecaoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ColecaoViewModel>(_colecaoRepository.TrazerPorId(id));
        }

        public IEnumerable<ColecaoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ColecaoViewModel>>(_colecaoRepository.TrazerTodos());
        }
    }
}
