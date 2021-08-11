using Teste.Dtos.NotaFiscalDtos;
using Teste.Models;

namespace Teste.Mappers
{
    public static class NotaFiscalMapper
    {
        public static GetNotaFiscalDto NotaFiscalToGetNotaFiscalDto(NotaFiscal notaFiscal)
        {
            return new GetNotaFiscalDto
            {
                Id = notaFiscal.Id,
                Modelo = notaFiscal.Modelo,
                Serie = notaFiscal.Serie,
                Numero = notaFiscal.Numero,
                DataEmissao = notaFiscal.DataEmissao,
                Status = notaFiscal.Status,
                Motivo = notaFiscal.Motivo,
                ClienteId = notaFiscal.ClienteId,
                ClienteNome = notaFiscal.Cliente.Nome,
            };
        }
    }
}