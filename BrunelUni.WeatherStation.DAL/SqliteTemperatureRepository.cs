﻿using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using BrunelUni.WeatherStation.Core.Interfaces.Contract;
using BrunelUni.WeatherStation.Core.Models;

namespace BrunelUni.WeatherStation.DAL
{
    public class SqliteTemperatureRepository : ITemperatureRepository
    {
        private readonly WeatherContext _weatherContext;

        public SqliteTemperatureRepository( WeatherContext weatherContext ) { _weatherContext = weatherContext; }

        public ObjectResult<IEnumerable<Temperature>> GetAll( ) => new( )
        {
            Status = OperationResultEnum.Success,
            Value = _weatherContext.TemperatureReadings
        };

        public Result Create( Temperature temperature )
        {
            _weatherContext.TemperatureReadings.Add( temperature );
            _weatherContext.SaveChanges( );
            return Result.Success( );
        }
    }
}