namespace TNE.Data.Implementations
{
    public class DbUtilsImpl : IDbUtils
    {
        private readonly DatabaseContext _context;

        public DbUtilsImpl(DatabaseContext context) => _context = context;

        public void DropDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}