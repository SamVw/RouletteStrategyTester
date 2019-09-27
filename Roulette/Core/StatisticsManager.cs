using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Roulette.Core.Game.Bets;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;

namespace Roulette.Core
{
    public class StatisticsManager : IStatisticsManager
    {
        private readonly Dictionary<string, StrategyStatistics> _strategyResults;
        private IMapper _mapper;

        public StatisticsManager()
        {
            _strategyResults = new Dictionary<string, StrategyStatistics>();

            var config = MapperConfiguration();
            _mapper = new Mapper(config);
        }

        public void Process(StrategyResult result)
        {
            var statistic = _mapper.Map<StrategyStatistics>(result);

            if (!_strategyResults.ContainsKey(result.Strategy))
            {
                _strategyResults.Add(result.Strategy, statistic);
            }
            else
            {
                _strategyResults[result.Strategy] = statistic;
            }
        }

        public List<StrategyStatistics> GetStatistics()
        {
            return _strategyResults.Values.ToList();
        }

        public void Clear()
        {
            _strategyResults.Clear();
        }

        private MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<StrategyResult, StrategyStatistics>()
                    .ForMember(d => d.Cycles, opt => opt.MapFrom(s => s.CyclesRan))
                    .ForMember(d => d.Average, opt => opt.MapFrom(s => s.AllBets.Average()))
                    .ForMember(d => d.Median, opt => opt.MapFrom(s => GetMedian(s.AllBets)))
                    .ForMember(d => d.EndBalance, opt => opt.MapFrom(s => s.EndBudget - s.StartBudget)));
            return config;
        }

        private double GetMedian(List<double> bets)
        {
            var orderedBets = bets.OrderBy(b => b).ToList();
            return orderedBets[(int)(orderedBets.Count / 2)];
        }
    }
}
