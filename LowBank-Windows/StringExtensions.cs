using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LowBank_Windows
{
    public static class StringExtensions
    {
        public static string Criptografa(this string texto)
        {
            // Cria algoritmo de criptografia
            SHA256 algoritmo = SHA256.Create();

            //Pega a representação da string da senha, em bytes
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(texto);

            // Criptografa calculando o hash da senha
            byte[] senhaCriptografadaEmBytes = algoritmo.ComputeHash(senhaEmBytes);

            // Transforma cada byte em string (caracter)
            var listaDecaracteres = senhaCriptografadaEmBytes
                .Select(b => b.ToString("X2"));

            // Concatena todos os caracteres em uma string
            return string.Concat(listaDecaracteres);
        }
    }
}
