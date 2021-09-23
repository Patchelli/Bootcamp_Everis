using Dio.Bank.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Bank
{
    public class ContaRepositorio : IRepositorio<Conta>
    {
        private List<Conta> listaConta = new List<Conta>();
        public void Atualiza(int id, Conta entidade)
        {
            listaConta[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaConta[id].Excluir();
        }

        public void Insere(Conta entidade)
        {
            listaConta.Add(entidade);
        }

        public List<Conta> Lista()
        {
            return listaConta;
        }

        public int ProximoId()
        {
            return listaConta.Count;
        }

        public Conta RetornaPorId(int id)
        {
            return listaConta[id];
        }
    }
}
