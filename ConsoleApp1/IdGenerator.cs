namespace ConsoleApp1
{
    static class IdGenerator
    {
        private static int globalId = 0;
        private static int orderLineItemId = 0;
        public static int Get()
        {
            return ++globalId;
        }

        public static int GlobalId { get { return Get(); } }
        public static int OrderLineItemId { get { return ++orderLineItemId; } }
    }
}
