using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Template.WebApi.DataAccess.Context;
using Template.WebApi.DataAccess.Repositories;
using Template.WebApi.Models;
using Xunit;

namespace Template.WebApi.Tests.DataAccess.Repositories
{
    public class ExampleRepositoryTests
    {
        public ExampleRepositoryTests()
        {
            var contextOptions = new DbContextOptionsBuilder<TemplateContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new TemplateContext(contextOptions);
            _exampleRepository = new ExampleRepository(_context);
        }

        private readonly TemplateContext _context;
        private readonly IExampleRepository _exampleRepository;

        [Fact]
        public async Task AddAsync_Should_AddData_And_MakeItAvailable_When_ManualSaveWasRun()
        {
            var newExample = new Example {Id = Guid.NewGuid(), Name = "test1"};

            await _exampleRepository.AddAsync(newExample);
            await _context.SaveChangesAsync();

            _context.Examples.Count().Should().Be(1);
            _context.Examples.Should().Contain(newExample);
        }

        [Fact]
        public async Task AddAsync_Should_NotSaveDataInDb()
        {
            var newExample = new Example {Id = Guid.NewGuid(), Name = "test1"};

            await _exampleRepository.AddAsync(newExample);

            _context.Examples.Should().BeEmpty();
            _context.Examples.Should().NotContain(newExample);
        }

        [Fact]
        public async Task GetAll_Should_ReturnAllExamples()
        {
            var examples = new List<Example>
            {
                new Example {Id = Guid.NewGuid(), Name = "test1"},
                new Example {Id = Guid.NewGuid(), Name = "test2"}
            };
            await _context.Examples.AddRangeAsync(examples);
            await _context.SaveChangesAsync();

            var result = await _exampleRepository.GetAll();

            result.Count.Should().Be(examples.Count);
            result.Should().Contain(examples[0]);
            result.Should().Contain(examples[1]);
        }
    }
}