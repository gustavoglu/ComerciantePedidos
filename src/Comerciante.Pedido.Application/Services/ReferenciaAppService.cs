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
        private readonly IReferencia_CorAppService _referencia_CorAppService;
        private readonly IReferencia_TamanhoAppService _referencia_TamanhoAppService;

        public ReferenciaAppService(IReferenciaRepository referenciaRepository, IMapper mapper, IReferencia_CorAppService referencia_CorAppService, IReferencia_TamanhoAppService referencia_TamanhoAppService)
        {
            _referenciaRepository = referenciaRepository;
            _referencia_TamanhoAppService = referencia_TamanhoAppService;
            _referencia_CorAppService = referencia_CorAppService;
            _mapper = mapper;
        }

        public ReferenciaViewModel Atualizar(ReferenciaViewModel ReferenciaViewModel)
        {
            var viewModel = AtualizaCoresTamanhos(ReferenciaViewModel);

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
            var parseTipo = Enum.Parse(typeof(TipoReferenciaViewModel), tipo.ToString());
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerAtivoPorTipo((TipoReferencia)parseTipo).ToList());
        }

        public IEnumerable<ReferenciaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ReferenciaViewModel>>(_referenciaRepository.TrazerTodos().ToList());
        }

        private IEnumerable<Referencia_CorViewModel> GetCoresAtualizadas(IEnumerable<Referencia_CorViewModel> coresSelecionadas, Guid id_referencia)
        {
            var referencia_cores = _referencia_CorAppService.TrazerPorReferencia(id_referencia);

            var coresParaExcluir = from corSelecionada in coresSelecionadas
                                   from referencia_cor in referencia_cores
                                   where corSelecionada.Id_cor != referencia_cor.Id_cor
                                   select referencia_cor;

            var coresJaExistentes = from corSelecionada in coresSelecionadas
                                    from referencia_cor in referencia_cores
                                    where corSelecionada.Id_cor == referencia_cor.Id_cor
                                    select referencia_cor;

            if (coresParaExcluir.Any())
                _referencia_CorAppService.Deletar(coresParaExcluir.Distinct());


            if (coresJaExistentes.Any())
            {
                var coresAtualizadas = from corSelecionada in coresSelecionadas
                                       from corJaExistente in coresJaExistentes
                                       where corSelecionada.Id_cor != corJaExistente.Id_cor
                                       select corSelecionada;

                if (coresAtualizadas.Any())
                    _referencia_CorAppService.Criar(coresAtualizadas.ToList());

                return coresAtualizadas;
            }

            return _referencia_CorAppService.Criar(coresSelecionadas.ToList());
        }

        private IEnumerable<Referencia_TamanhoViewModel> GetTamanhosAtualizados(IEnumerable<Referencia_TamanhoViewModel> tamanhosSelecionados, Guid id_referencia)
        {
            var referencia_tamanhos = _referencia_TamanhoAppService.TrazerPorReferencia(id_referencia);

            var tamanhosParaExcluir = from tamanhoSelecionado in tamanhosSelecionados
                                      from referencia_tamanho in referencia_tamanhos
                                      where tamanhoSelecionado.Id_tamanho != referencia_tamanho.Id_tamanho
                                      select referencia_tamanho;

            var tamanhosJaExistentes = from tamanhoSelecionado in tamanhosSelecionados
                                       from referencia_tamanho in referencia_tamanhos
                                       where tamanhoSelecionado.Id_tamanho == referencia_tamanho.Id_tamanho
                                       select referencia_tamanho;

            if (tamanhosParaExcluir.Any())
                _referencia_TamanhoAppService.Deletar(tamanhosParaExcluir.Distinct());

            if (tamanhosJaExistentes.Any())
            {
                var tamanhosAtualizados = from tamanhoSelecionado in tamanhosSelecionados
                                          from tamanhoJaExistente in tamanhosJaExistentes
                                          where tamanhoSelecionado.Id_tamanho != tamanhoJaExistente.Id_tamanho
                                          select tamanhoSelecionado;

                if (tamanhosAtualizados.Any())
                    _referencia_TamanhoAppService.Criar(tamanhosAtualizados.ToList());

                return tamanhosAtualizados;
            }

            return _referencia_TamanhoAppService.Criar(tamanhosSelecionados.ToList());

        }

        private Referencia AtualizaCoresTamanhos(ReferenciaViewModel referenciaViewModel)
        {
            var coresParaAdicionar = GetCoresAtualizadas(referenciaViewModel.Referencia_Cores, referenciaViewModel.Id.Value).ToList();
            var tamanhosParaAdicionar = GetTamanhosAtualizados(referenciaViewModel.Referencia_Tamanhos, referenciaViewModel.Id.Value).ToList();

            var model = _referenciaRepository.TrazerPorId(referenciaViewModel.Id.Value);

            return _mapper.Map(referenciaViewModel, model);
        }
    }
}
