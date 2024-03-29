﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPOAPAKmmReceiver.Data
{
    internal class DbInitializer
    {
        private readonly SPOAPAKmmDB _db;

        public DbInitializer(SPOAPAKmmDB db)
        {
            _db = db;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);
#if DEBUG
            if (!await _db.Organizations.AnyAsync())
            {
                await _db.Organizations.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Rooms.AnyAsync())
            {
                await _db.Rooms.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Devices.AnyAsync())
            {
                await _db.Devices.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Elements.AnyAsync())
            {
                await _db.Elements.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.MeasPoints.AnyAsync())
            {
                await _db.MeasPoints.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Measurings.AnyAsync())
            {
                await _db.Measurings.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Levels.AnyAsync())
            {
                await _db.Levels.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.DeviceTypes.AnyAsync())
            {
                await _db.DeviceTypes.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.MeasSettings.AnyAsync())
            {
                await _db.MeasSettings.AddRangeAsync();
                await _db.SaveChangesAsync();
            }

            if (!await _db.Frequencies.AnyAsync())
            {
                await _db.Frequencies.AddRangeAsync();
                await _db.SaveChangesAsync();
            }
#endif
        }
    }
}