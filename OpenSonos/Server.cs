namespace OpenSonos
{
    public static class Server
    {
        public static ServerCreationStateWrapper ImplementedBy<TServerType>()
        {
            return new ServerCreationStateWrapper(typeof(TServerType));
        }
    }
}
