using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Servers
    {
        private readonly ServerContext _context;

        public Servers(ServerContext context)
        {
            _context = context;
        }

        public async Task ModifyGuildPrefix(ulong id, string prefix)
        {
            var server = await _context.Servers
                .FindAsync(id);

            if (server == null)
                _context.Add(new Server { Id = id, Prefix = prefix });
            else
                server.Prefix = prefix;

            await _context.SaveChangesAsync();

        }

        public async Task<string> GetGuildPrefix(ulong id)
        {
            var prefix = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Prefix)
                .FirstOrDefaultAsync();

            return await Task.FromResult(prefix);
        }
        //Setting Max xp----------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task ModifyMaxXp(ulong id, int goalmax, int discoverymax, int bondmax, int setbackmax)
        {
            var server = await _context.Servers
                .FindAsync(id);
            if (server == null)
                _context.Add(new Server { Id = id, GoalMax = goalmax, DiscoveryMax = discoverymax, BondMax = bondmax, SetbackMax = setbackmax });
            else
            {
                server.GoalMax = goalmax;
                server.DiscoveryMax = discoverymax;
                server.BondMax = bondmax;
                server.SetbackMax = setbackmax;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> SetGoalXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var goalmax = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.GoalMax)
                .FirstOrDefaultAsync();

            return await Task.FromResult(goalmax);

        }

        public async Task<int> SetDiscoveryXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var discoverymax = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.DiscoveryMax)
                .FirstOrDefaultAsync();

            return await Task.FromResult(discoverymax);

        }

        public async Task<int> SetBondXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var bondmax = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.BondMax)
                .FirstOrDefaultAsync();

            return await Task.FromResult(bondmax);

        }

        public async Task<int> SetSetbackXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var setbackmax = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.SetbackMax)
                .FirstOrDefaultAsync();

            return await Task.FromResult(setbackmax);

        }
        //Adding xp to party pool----------------------------------------------------------------------------------------------------------------------------------------------------
       //Goal xp
        public async Task AddGoalPoolXp(ulong id, int goalxp)
        {
            var server = await _context.Servers
                .FindAsync(id);
            if (server == null)
                _context.Add(new Server { Id = id, Goalxp = goalxp});
            else
            {
                server.Goalxp = goalxp;
            }

            await _context.SaveChangesAsync();
        }
        public async Task<int> AddGoalXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var goalxp = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Goalxp)
                .FirstOrDefaultAsync();

            return await Task.FromResult(goalxp);

        }
        //Discovery xp
        public async Task AddDiscoveryPoolXp(ulong id, int discoveryxp, int discoverymax)
        {
            var server = await _context.Servers
                .FindAsync(id);
            if (server == null)
                _context.Add(new Server { Id = id, Discoveryxp = discoveryxp, DiscoveryMax = discoverymax});
            else
            {
                server.Discoveryxp = discoveryxp;
                server.DiscoveryMax = discoverymax;
            }

            await _context.SaveChangesAsync();
        }
        public async Task<int> AddDiscoveryXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var discoveryxp = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Discoveryxp)
                .FirstOrDefaultAsync();

            return await Task.FromResult(discoveryxp);

        }
        //Bond xp
        public async Task AddBondPoolXp(ulong id, int bondxp, int bondmax)
        {
            var server = await _context.Servers
                .FindAsync(id);
            if (server == null)
                _context.Add(new Server { Id = id, Bondxp = bondxp, BondMax = bondmax});
            else
            {
                server.Bondxp = bondxp;
                server.BondMax = bondmax;
            }

            await _context.SaveChangesAsync();
        }
        public async Task<int> AddBondXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var bondxp = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Bondxp)
                .FirstOrDefaultAsync();

            return await Task.FromResult(bondxp);

        }
        //Setback xp
        public async Task AddSetbackPoolXp(ulong id, int setbackxp, int setbackmax)
        {
            var server = await _context.Servers
                .FindAsync(id);
            if (server == null)
                _context.Add(new Server { Id = id, Setbackxp = setbackxp, SetbackMax = setbackmax});
            else
            {
                server.Setbackxp = setbackxp;
                server.SetbackMax = setbackmax;
            }

            await _context.SaveChangesAsync();
        }
        public async Task<int> AddSetbackXp(ulong id)
        {
            if (id == 0)
            {
                return 0;
            }

            var setbackxp = await _context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Setbackxp)
                .FirstOrDefaultAsync();

            return await Task.FromResult(setbackxp);

        }
    }
}
