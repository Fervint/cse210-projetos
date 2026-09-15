using System;
using System.Collections.Generic;
using System.IO;

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
                registro.Exibir();
                Console.WriteLine();
            }
        }

        // 🔹 Salvar em formato CSV
        public void SalvarNoArquivo(string arquivo)
        {
            using (StreamWriter escritor = new StreamWriter(arquivo))
            {
                escritor.WriteLine("Data,Pergunta,Resposta");
                foreach (Registro registro in _registros)
                {
                    string linha = $"\"{registro._data}\",\"{registro._textoPergunta}\",\"{registro._textoResposta}\"";
                    escritor.WriteLine(linha);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ Diário salvo com sucesso em: {Path.GetFullPath(arquivo)}");
            Console.ResetColor();
        }

        // 🔹 Carregar do formato CSV
        public void CarregarDoArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }

            string[] linhas = File.ReadAllLines(arquivo);
            _registros.Clear();

            for (int i = 1; i < linhas.Length; i++) // Ignora o cabeçalho
            {
                string[] partes = linhas[i].Split("\",\"");
                if (partes.Length == 3)
                {
                    Registro registro = new Registro
                    {
                        _data = partes[0].Trim('"'),
                        _textoPergunta = partes[1].Trim('"'),
                        _textoResposta = partes[2].Trim('"')
                    };
                    _registros.Add(registro);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📂 Diário carregado com sucesso!");
            Console.ResetColor();
        }
    }
}
