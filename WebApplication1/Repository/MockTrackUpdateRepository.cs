using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockTrackUpdateRepository : ITrackUpdateRepository
    {
        private readonly AppDbContext _context;

        public MockTrackUpdateRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        
        public async Task<List<TrackUpdateInformations>> All()
        {
            try
            {
                var trackUpdates = await _context.TrackUpdateInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return trackUpdates;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TrackUpdateInformations> Delete(int Id)
        {
            try
            {
                var trackUpdate = await _context.TrackUpdateInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(trackUpdate);
                await _context.SaveChangesAsync();

                return trackUpdate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TrackUpdateInformations> GetById(int Id)
        {
            try
            {
                var trackUpdate = await _context.TrackUpdateInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return trackUpdate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TrackUpdateInformations> Insert(TrackUpdateInformations trackUpdateInformations)
        {
            try
            {
                await _context.AddAsync(trackUpdateInformations);
                await _context.SaveChangesAsync();

                TrackUpdateInformations trackUpdateInfo = new TrackUpdateInformations();

                if (trackUpdateInformations.Id > 0)
                {
                    trackUpdateInfo = await _context.TrackUpdateInformations.FirstOrDefaultAsync(x => x.Id == trackUpdateInformations.Id);
                    return trackUpdateInfo;
                }
                else
                {
                    return trackUpdateInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TrackUpdateInformations> Update(TrackUpdateInformations trackUpdateInformations)
        {
            try
            {
                var trackUpdate = _context.TrackUpdateInformations.Attach(trackUpdateInformations);
                trackUpdate.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return trackUpdateInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
