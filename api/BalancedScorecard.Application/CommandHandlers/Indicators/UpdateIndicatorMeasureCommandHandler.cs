﻿using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class UpdateIndicatorMeasureCommandHandler : ICommandHandler<UpdateIndicatorMeasureCommand>
    {
        private readonly IRepository<Indicator> _repository;

        public UpdateIndicatorMeasureCommandHandler(
            IRepository<Indicator> repository)
        {
            _repository = repository;
        }

        public async Task Execute(UpdateIndicatorMeasureCommand command)
        {
            if (command == null) throw new ArgumentNullException("Command is null");

            var indicator = await _repository.GetById(command.IndicatorId);
            if (indicator == null)
            {
                throw new ItemNotFoundException("Indicator not found");
            }

            indicator.UpdateMeasure(command.IndicatorMeasureId, command.Date.Value, command.RealValue, command.ObjectiveValue, command.Notes);
            await _repository.SaveAsync(indicator);
        }
    }
}
