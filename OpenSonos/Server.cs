namespace OpenSonos
{
    public static class Server
    {
        public static ServerBuilder ImplementedBy<TServerType>()
        {
            return new ServerBuilder(typeof(TServerType));
        }
    }
}
