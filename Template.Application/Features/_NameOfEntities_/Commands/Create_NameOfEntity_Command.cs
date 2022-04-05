﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Application.Interfaces;
using Template.Domain;

namespace Template.Application.Features._NameOfEntity_.Commands
{
    public class Create_NameOfEntity_Command : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    public class Create_NameOfEntity_CommandHandler:IRequestHandler<Create_NameOfEntity_Command,Guid>
    {
        private readonly IAppDbContext _notes;
        public Create_NameOfEntity_CommandHandler(IAppDbContext notes)
        {
            _notes = notes;
        }


        public async Task<Guid> Handle(Create_NameOfEntity_Command request, CancellationToken cancellationToken)
        {
            var note = new _EntityName_
            {
                Name = request.Name,
            };
            await _notes.Names.AddAsync(note, cancellationToken);
            await _notes.SaveChangesAsync(cancellationToken);

            return note.PrimaryId;


        }
    }
}
