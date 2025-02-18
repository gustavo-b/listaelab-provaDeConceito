﻿using listelab_dominio.Conceitos;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace listelab_servico.Validacoes
{
    public class ValidacoesQuestaoDiscursiva : ValidadorPadrao<QuestaoDiscursiva>
    {
        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraCodigoValido()
        {
            RuleFor(questao => questao.Codigo)
                .Must(codigo => codigo > 0 && codigo < 9999)
                .WithMessage("O código da questão deve ser superior à 0 e menor ou igual à 9999");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraDeveTerEnunciado()
        {
            RuleFor(questao => questao.Enunciado)
                .Must(enunciado => !string.IsNullOrEmpty(enunciado))
                .WithMessage("O enunciado da questão deve ser informado");
        }

        /// <summary>
        /// Número do requisito.
        /// </summary>
        public void AssineRegraPalavraChaveInformado()
        {
            RuleFor(questao => questao.PalavrasChaves)
                .Must(ValidePalavrasChaves)
                .WithMessage("Pelo menos uma palavra chave deve ser informada");
        }

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraCodigoValido();
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraCodigoValido();
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de exclusão.
        /// </summary>
        protected override void AssineRegrasDeExclusao()
        {
        }

        private bool ValidePalavrasChaves(IList<string> palavras)
        {
            if (palavras == null)
            {
                return false;
            }

            var listaValidada = palavras.ToList();

            return listaValidada.Any(x => !string.IsNullOrWhiteSpace(x));
        }
    }
}
