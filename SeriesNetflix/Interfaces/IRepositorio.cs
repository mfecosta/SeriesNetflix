using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SeriesNetflix.Interfaces
{
    public interface IRepositorio<T>
    {

        List<T> Lista();
        T RetornoPorId(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void Atualiza(int id ,T entidade);
        int ProximoId();
    }
}
