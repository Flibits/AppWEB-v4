using AppWEB.Models;
using System.Collections.Generic;

namespace AppWEB.Data.Repositório.Interface
{
    public interface IAlunoRepositorio
    {
        void InserirAluno(AlunoModel alunos);

        List<AlunoModel> BuscarAlunos();
    }
}
