using System;
using System.Collections.Generic;
using Bogus;
using Template.WebApi.Models;

namespace Template.WebApi.DataAccess
{
    public static class ExampleDataFiller
    {
        public static IEnumerable<Example> CreateExamplesTestData()
        {
            var client = new Faker<Example>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .Generate(10);
            return client;
        }
    }
}