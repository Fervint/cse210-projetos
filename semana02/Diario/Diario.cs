using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Diario
{
    public class Diario
    {
        public List<Registro> _registros { get; private set; } = new List<Registro>();

        public void AdicionarRegistro(Registro novoRegistro)
        {
            if (novoRegistro == null)
                throw new ArgumentNullException(nameof(novoRegistro));

            _registros.Add(novoRegistro);
        }

        public void ExibirTodos()
        {
            if (_registros.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
                return;
            }

            foreach (Registro registro in _registros)
            {
                registro.Exibir(); // ✅ Chama o método da classe Registro
                Console.WriteLine(); // Linha em branco para separar
            }
        }

        public void SalvarNoArquivo(string arquivo)
        {
            string conteudo = JsonSerializer.Serialize(_registros, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(arquivo, conteudo);
            Console.WriteLine($"Diário salvo em: {Path.GetFullPath(arquivo)}");
        }

        public void CarregarDoArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }

            string conteudo = File.ReadAllText(arquivo);
            _registros = JsonSerializer.Deserialize<List<Registro>>(conteudo) ?? new List<Registro>();
            Console.WriteLine("Diário carregado com sucesso!");
        }
    }
}
