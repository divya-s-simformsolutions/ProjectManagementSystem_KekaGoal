using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace projectManagementSystem.Data
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _appDBContext;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(ApplicationDbContext appDBContext, ILogger<ProjectService> logger)
        {
            _appDBContext = appDBContext;
            _logger = logger;
        }

        public async Task<List<Project>> GetAllprojectAsync()
        {
            try
            {
                return await _appDBContext.Item.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all project items.");
                throw;
            }
        }

        public async Task<bool> InsertItemAsync(Project item)
        {
            try
            {
                await _appDBContext.Item.AddAsync(item);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting an project item.");
                throw;
            }
        }

        public async Task<Project> GetItemAsync(int Id)
        {
            try
            {
                Project item = await _appDBContext.Item.FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting an project item by Id.");
                throw;
            }
        }

        public async Task<bool> UpdateItemAsync(Project item)
        {
            try
            {
                _appDBContext.Item.Update(item);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating an project item.");
                throw;
            }
        }

        public async Task<bool> DeleteItemAsync(Project item)
        {
            try
            {
                _appDBContext.Remove(item);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting an project item.");
                throw;
            }
        }
    }
}
