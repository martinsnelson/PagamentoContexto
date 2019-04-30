using System;
using Flunt.Notifications;
using PagamentoContexto.Domain.Commands;
using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.Repositories;
using PagamentoContexto.Domain.Services;
using PagamentoContexto.Domain.ValueObjects;
using PagamentoContexto.Shared.Commands;
using PagamentoContexto.Shared.Handlers;

namespace PagamentoContexto.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable, IHandler<CriarBoletoAssinaturaCommand>, 
    IHandler<CriarPayPalAssinaturaCommand>, IHandler<CriarCartaoCreditoAssinaturaCommand>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IAlunoRepository alunoRepository, IEmailService emailService)
        {
            _alunoRepository = alunoRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CriarBoletoAssinaturaCommand command)
        {
            //  Se usar Fail Fast Validations usar o código abaixo
            command.Validar();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //  Verifica se o Documento já está cadastrado
            if(_alunoRepository.DocumentoExiste(command.Documento))
                AddNotification("Documento", "Este CPF já está em uso");

            //  Verifica se o E-mail já está cadastrado
            if(_alunoRepository.EmailExiste(command.Email))
                AddNotification("Email", "Este CPF já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.SegundoNome);
            var documento = new Documento(command.Documento, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.Cep);

            //  Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new BoletoPagamento(
                command.CodigoBarra, 
                command.BoletoNumero, 
                command.DataPagamento,
                command.DataExpiracao, 
                command.Total, 
                command.TotalPago,
                command.Proprietario, 
                new Documento(command.DocumentoDonoCartao, command.TipoDocumentoCartao), 
                endereco, 
                email
                );

            //  Realacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            //  Agrupar as Validações
            AddNotifications(nome, documento, email, endereco, aluno, assinatura, pagamento);

            // Checar as notificações
            if(Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as Informações
            _alunoRepository.CriarAssinatura(aluno);

            //  Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.EmailEnd,
            "Bem vindo ao martinsnelson.io", 
            "Assinatura Criada");
            
            //  Retornar Informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CriarPayPalAssinaturaCommand command)
        {
            //  se usar Fail Fast Validations usar o código abaixo
            // command.Validar();
            // if(command.Invalid)
            // {
            //     AddNotifications(command);
            //     return new CommandResult(false, "Não foi possível realizar sua assinatura");
            // }

            //  Verifica se o Documento já está cadastrado
            if(_alunoRepository.DocumentoExiste(command.Documento))
                AddNotification("Documento", "Este CPF já está em uso");

            //  Verifica se o E-mail já está cadastrado
            if(_alunoRepository.EmailExiste(command.Email))
                AddNotification("Email", "Este CPF já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.SegundoNome);
            var documento = new Documento(command.Documento, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.Cep);

            //  Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            //  Tipos de Pagamento só muda a implementação do pagamento
            var pagamento = new PayPalPagamento( 
                command.CodigoTransacao, 
                command.DataPagamento,
                command.DataExpiracao, 
                command.Total, 
                command.TotalPago,
                command.Proprietario, 
                new Documento(command.DocumentoDonoCartao, command.TipoDocumentoCartao), 
                endereco, 
                email
                );

            //  Realacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            //  Agrupar as Validações
            AddNotifications(nome, documento, email, endereco, aluno, assinatura, pagamento);

            // Checar as notificações
            if(Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as Informações
            _alunoRepository.CriarAssinatura(aluno);

            //  Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.EmailEnd,
            "Bem vindo ao martinsnelson.io", 
            "Assinatura Criada");
            
            //  Retornar Informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CriarCartaoCreditoAssinaturaCommand command)
        {
            // //  Se usar Fail Fast Validations usar o código abaixo
            // command.Validar();
            // if(command.Invalid)
            // {
            //     AddNotifications(command);
            //     return new CommandResult(false, "Não foi possível realizar sua assinatura");
            // }

            //  Verifica se o Documento já está cadastrado
            if(_alunoRepository.DocumentoExiste(command.Documento))
                AddNotification("Documento", "Este CPF já está em uso");

            //  Verifica se o E-mail já está cadastrado
            if(_alunoRepository.EmailExiste(command.Email))
                AddNotification("Email", "Este CPF já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.SegundoNome);
            var documento = new Documento(command.Documento, EDocumentoTipo.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Pais, command.Cep);

            //  Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new CartaoCreditoPagamento(
                command.NomeTitular,
                command.NumeroCartao,
                command.UltimoNumeroTransacao,
                command.DataPagamento,
                command.DataExpiracao, 
                command.Total, 
                command.TotalPago,
                command.Proprietario, 
                new Documento(command.DocumentoDonoCartao, command.TipoDocumentoCartao), 
                endereco, 
                email
                );

            //  Realacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            //  Agrupar as Validações
            AddNotifications(nome, documento, email, endereco, aluno, assinatura, pagamento);

            // Checar as notificações
            if(Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as Informações
            _alunoRepository.CriarAssinatura(aluno);

            //  Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.EmailEnd,
            "Bem vindo ao martinsnelson.io", 
            "Assinatura Criada");
            
            //  Retornar Informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}