namespace LowBank_Windows.Data
{
    public abstract class BaseDataSource
    {
        public abstract void SalvarCliente(Cliente cliente);

        public abstract Cliente GetClienteByCpf(string cpfDaTela);
    }
}
