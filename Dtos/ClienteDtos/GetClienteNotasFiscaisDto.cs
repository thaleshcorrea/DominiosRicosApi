using System;
using System.Collections.Generic;
using Teste.Dtos.NotaFiscalDtos;

namespace Teste.Dtos.ClienteDtos
{
    public class GetClienteNotasFiscaisDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public List<GetNotaFiscalDto> NotasFiscais { get; set; }
    }
}