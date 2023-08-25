namespace LowBank_Windows.Data
{
    public abstract class BaseDataSource
    {
        public abstract bool SalvarCliente(Cliente cliente);

        public abstract Cliente GetClienteByCpf(string cpfDaTela);
    }
}
