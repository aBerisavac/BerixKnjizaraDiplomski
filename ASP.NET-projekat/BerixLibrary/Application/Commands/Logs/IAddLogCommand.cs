﻿using Application.DTOs.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Logs
{
    public interface IAddLogCommand: ICommand<LogDTO>
    {
    }
}
