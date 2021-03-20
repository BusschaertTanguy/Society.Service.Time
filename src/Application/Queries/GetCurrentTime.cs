using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Connections;
using Dapper;
using MediatR;

namespace Application.Queries
{
    public static class GetCurrentTime
    {
        public class Query : IRequest<Result>
        {
        }

        public class Result
        {
            public Result(DateTime currentTime)
            {
                CurrentTime = currentTime;
            }

            public DateTime CurrentTime { get; }
        }

        internal class Handler : IRequestHandler<Query, Result>
        {
            private readonly IDbConnectionProvider _connectionProvider;

            public Handler(IDbConnectionProvider connectionProvider)
            {
                _connectionProvider = connectionProvider;
            }
            
            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                using var connection = _connectionProvider.GetDbConnection();
                
                const string dbQuery = "SELECT [CurrentTime] FROM [Universe];";
                
                return await connection.QueryFirstOrDefaultAsync<Result>(dbQuery);
            }
        }
    }
}