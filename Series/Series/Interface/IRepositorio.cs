using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Interface
{
    public interface IRepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int proximoId();



    }
}
