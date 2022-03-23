using Microsoft.EntityFrameworkCore;

namespace SPOAPAKmmReceiver.Data
{
    internal class SPOAPAKmmReceiverDBInitializer
    {
        private readonly SPOAPAKmmReceiverDB _db;

        public SPOAPAKmmReceiverDBInitializer(SPOAPAKmmReceiverDB db)
        {
            _db = db;
        }

        public void Initialize()
        {
            _db.Database.Migrate();
        }
    }
}
