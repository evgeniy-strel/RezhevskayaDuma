﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RezhDumaASPCore_Backend.Model;
using RezhDumaASPCore_Backend.Repositories;
using RezhDumaASPCore_Backend.Services;

namespace RezhDumaASPCore_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : AbstractController<Application, ApplicationRepository>
    {
        private readonly IMessageService messageService;

        public ApplicationController(ApplicationRepository repository, IMessageService messageService) : base(repository)
        {
            this.messageService = messageService;
        }

        [HttpGet("deputy/{id}")]
        public async Task<ActionResult<IEnumerable<Application>>> Get(string id)
        {
            return await repository.GetByDeputy(id);
        }

        [HttpGet("status={status}")]
        public async Task<ActionResult<IEnumerable<Application>>> Get(Status status)
        {
            return await repository.GetByStatus(status);
        }

        [HttpGet("deputy/{id}/{status}")]
        public async Task<ActionResult<IEnumerable<Application>>> Get(string id, Status status)
        {
            return await repository.GetByDeputyStatus(id, status);
        }

        public async override Task<ActionResult<Application>> Post(Application entity)
        {
            await repository.Add(entity);
            messageService.Send(entity.Deputy, entity.Applicant, entity);
            return Ok(entity);
        }
    }
}
