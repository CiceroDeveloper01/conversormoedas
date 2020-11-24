using System.Collections.Generic;

namespace Conversor.Dominio.Interface
{
    public interface IRepositorio<Entidade, EntidadeRetorno>
    {
        void Salvar(List<Entidade> entidades);
        List<EntidadeRetorno> RetornaMoedas();
        void AtualizarMoedas();
    }
}