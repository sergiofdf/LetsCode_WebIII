namespace LetsCode_WebIII.Repository
{
    public static class ListaClientes
    {
        public static List<Cliente> clienteList = new()
        {
           new Cliente("12345678912", "Joao Silva", new DateTime(1989, 10, 31)),
           new Cliente("12345678934", "Jose Amato", new DateTime(1988, 10, 31)),
           new Cliente("12345678956", "Marta Antunes", new DateTime(1987, 10, 31)),
        };
    }
}
