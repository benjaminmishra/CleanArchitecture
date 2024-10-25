﻿using NimblePros.SampleToDo.Core.ProjectAggregate;

namespace NimblePros.SampleToDo.UseCases.Projects.Create;

public class CreateProjectHandler : ICommandHandler<CreateProjectCommand, Result<ProjectId>>
{
  private readonly IRepository<Project> _repository;

  public CreateProjectHandler(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task<Result<ProjectId>> Handle(CreateProjectCommand request,
    CancellationToken cancellationToken)
  {
    var newProject = new Project(ProjectName.From(request.Name));
    var createdItem = await _repository.AddAsync(newProject, cancellationToken);

    return createdItem.Id;
  }
}
